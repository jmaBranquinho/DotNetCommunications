using DataGenerator;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            return Task.FromResult(GetFakePerson(request.UserId));
        }

        public override async Task GetCrowdInfo(CrowdLookupModel request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
                foreach (var user in request.UserIds)
                {
                    await responseStream.WriteAsync(GetFakePerson(user.UserId));
                }
        }

        public override async Task GetCrowdInfoFromId(CustomerLookupModel request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            foreach (var id in new int[] { 1, 2, 3, 4 })
            {
                await responseStream.WriteAsync(GetFakePerson(id));
            }
        }

        private CustomerModel GetFakePerson(int userId)
        {
            var fakePerson = new PersonGenerator().GetNewPerson();
            return new CustomerModel
            {
                Fullname = fakePerson.FullName,
                EmailAddress = fakePerson.Email,
                Gender = fakePerson.Gender,
                Phone = fakePerson.Phone,
                UserId = userId
            };
        }
    }
}
