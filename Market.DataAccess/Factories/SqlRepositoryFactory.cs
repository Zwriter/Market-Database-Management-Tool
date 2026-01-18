using Market.BusinessModel.Models;
using Market.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.DataAccess.Factories
{
    public class RepositoryFactory
    {
        public IRepository<T> Create<T>() where T : BaseModel
        {
            return new SQLRepository<T>();
        }
    }
}
