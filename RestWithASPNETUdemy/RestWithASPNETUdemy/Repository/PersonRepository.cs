using RestWithASPNETUdemy.Model;
using RestWithASPNETUdemy.Model.Context;
using RestWithASPNETUdemy.Repository.Generic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASPNETUdemy.Repository
{
    public class PersonRepository : GenericRepository<Person>, IPersonRepository
    {
        
        public PersonRepository(MySQLContext context) : base(context) { }

        public Person Disabled(long id)
        {
            if (!_context.Persons.Any(x => x.Id.Equals(id))) return null;

            var user = _context.Persons.SingleOrDefault(x => x.Id.Equals(id));

            if (user != null)
            {
                user.Enabled = false;
                try
                {
                    _context.Entry(user).CurrentValues.SetValues(user);
                    _context.SaveChanges();
                }
                catch (Exception)
                {
                    throw;
                }
            }

            return user;                
        }

        public List<Person> FindByName(string firstName, string lastName)
        {
            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(x => x.FirstName.ToUpper().Contains(firstName.ToUpper()) &&
                                                   x.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
            }
            else if (string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(x => x.LastName.ToUpper().Contains(lastName.ToUpper())).ToList();
            }
            else if (!string.IsNullOrWhiteSpace(firstName) && string.IsNullOrWhiteSpace(lastName))
            {
                return _context.Persons.Where(x => x.FirstName.ToUpper().Contains(firstName.ToUpper())).ToList();
            }

            return new List<Person>();
        }
    }
}
