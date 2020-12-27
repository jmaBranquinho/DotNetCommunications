using DataGenerator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLServer
{
    public class MovieActorsData
    {
        private readonly List<Person> _people = new List<Person>();

        public MovieActorsData()
        {
            var generator = new PersonGenerator();
            _people.AddRange(generator.GetNewCrowd(new Random().Next(20, 100)));
        }

        public Task<Person> GetPersonByIdAsync(int id)
        {
            return Task.FromResult(_people.FirstOrDefault(x => x.Id == id));
        }

        public Task<Person> GetPersonByNameAsync(string partialName)
        {
            return Task.FromResult(_people.FirstOrDefault(x => x.FullName.Contains(partialName)));
        }
    }
}
