using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface IReceiptService
    {
        List<ReceiptModel> GetReceipts(ReceiptQuery query);
        void CreateReceipt(ReceiptModel receipt);
        void UpdateReceipt(ReceiptModel receipt);
        void DeleteReceipt(ReceiptModel receipt);
        bool Exists(string id);
        void Save(ReceiptModel receipt);
    }
}
