using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {
        

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
         
        }

        public List<Person> FindAll()
        {
            List<Person> persons = new List<Person>();

            for (int i = 0; i < 8; i++)
            {
                Person p = MockePerson(i);
                persons.Add(p);
            }      

            return persons;
        }

        private Person MockePerson(int i)
        {
            return new Person
            {
                Id = i,
                FirstName = "Person Name" + i,
                LastName = "Lima" + i,
                Address = "Brasília - DF" + i,
                Gender = "Male" + i
            };
        }

        public Person FindByID(long id)
        {
            return new Person 
            {
                Id = 1,
                FirstName = "Rodrigo",
                LastName = "Lima",
                Address = "Brasília - DF",
                Gender = "Male"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
