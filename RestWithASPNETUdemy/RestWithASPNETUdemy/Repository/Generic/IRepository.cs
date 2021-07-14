using RestWithASPNETUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Repository.Generic
{
    public interface IRepository<T> where T : BaseEntity
    {
        T Create(T person);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T person);
        void Delete(long id);
        bool Exists(long id);
    }
}
