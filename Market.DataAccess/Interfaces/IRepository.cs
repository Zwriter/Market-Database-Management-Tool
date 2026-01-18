using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T? GetById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Query<TSort>(QueryRequest<TSort> request) where TSort : struct, Enum;
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Exists(string id);
    }
}
