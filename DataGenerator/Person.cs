using Bogus;
using System;

namespace DataGenerator
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }

        private static int nextId = 1;

        public Person(int id)
        {
            Id = id;
        }

        internal static Person CreateRandom()
        {
            return new Faker<Person>()
                .CustomInstantiator(x => new Person(nextId++))
                .RuleFor(x => x.FullName, x => x.Person.FullName)
                .RuleFor(x => x.Email, x => x.Person.Email)
                .RuleFor(x => x.BirthDate, x => x.Person.DateOfBirth)
                .RuleFor(x => x.Phone, x => x.Person.Phone)
                .RuleFor(x => x.Gender, x => x.Person.Gender.ToString())
                .Generate();
        }
    }
}
