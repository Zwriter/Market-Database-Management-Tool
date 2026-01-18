using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface IFactoryService
    {
        List<FactoryModel> GetFactories(FactoryQuery query);
        void CreateFactory(FactoryModel factory);
        void UpdateFactory(FactoryModel factory);
        void DeleteFactory(FactoryModel factory);
        bool Exists(string id);
        void Save(FactoryModel factory);
    }
}
