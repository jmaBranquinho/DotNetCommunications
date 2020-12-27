using System.Collections.Generic;
using System.Linq;

namespace DataGenerator
{
    public class PersonGenerator
    {
        public Person GetNewPerson()
        {
            return Person.CreateRandom();
        }

        public IEnumerable<Person> GetNewCrowd(int numberOfPeople)
        {
            return numberOfPeople > 0 
                ? Enumerable.Repeat(GetNewPerson(), numberOfPeople).ToList()
                : Enumerable.Empty<Person>();
        }
    }
}
