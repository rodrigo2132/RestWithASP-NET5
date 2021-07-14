using RestWithASPNETUdemy.Model;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Repository
{
    public interface IBooksRepository
    {
        Books Create(Books person);
        Books FindByID(long id);
        List<Books> FindAll();
        Books Update(Books person);
        void Delete(long id);

        bool Exists(long id);
    }
}
