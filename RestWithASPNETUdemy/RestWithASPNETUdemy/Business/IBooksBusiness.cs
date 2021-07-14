using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Business
{
    public interface IBooksBusiness
    {
        Books Create(Books person);
        Books FindByID(long id);
        List<Books> FindAll();
        Books Update(Books person);
        void Delete(long id);
    }
}
