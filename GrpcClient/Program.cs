using DataGenerator;
using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var personGenerator = new PersonGenerator();
            var person = personGenerator.GetNewPerson();

            var channel = GrpcChannel.ForAddress("https://localhost:5001");

            var client = new Greeter.GreeterClient(channel);

            Console.WriteLine("Hello from client");
            var input = new HelloRequest { Name = person.FullName };
            var reply = await client.SayHelloAsync(input);
            Console.WriteLine(reply.Message);

            var customerService = new Customer.CustomerClient(channel);
            var customerId = new CustomerLookupModel { UserId = new Random().Next(1, 100) };
            var userFound = customerService.GetCustomerInfo(customerId);
            Console.WriteLine($"Name: {userFound.Fullname}\nEmailAddress:{userFound.EmailAddress}\nGender:{userFound.Gender}\nId:{userFound.UserId}");

            //var input2 = new CrowdLookupModel { UserIds = new Google.Protobuf.Collections.RepeatedField<CustomerLookupModel> { customerId, customerId } };
            var cancel = new CancellationToken();
            using (var call = customerService.GetCrowdInfoFromId(customerId))
            {
                while (await call.ResponseStream.MoveNext(cancel))
                {
                    var current = call.ResponseStream.Current;
                    Console.WriteLine($"Name: {current.Fullname}");
                }
            }



            Console.ReadLine();
        }
    }
}
