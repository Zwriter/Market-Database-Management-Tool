using Market.BusinessModel.Enums;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Interfaces;

namespace Market.BusinessLogic.Services
{
    public class ReceiptService : BaseService<ReceiptModel, ReceiptQuery, ReceiptSortBy>, IReceiptService
    {
        public ReceiptService(IRepository<ReceiptModel> repo) : base(repo) { }

        public List<ReceiptModel> GetReceipts(ReceiptQuery query) => Get(query);
        public ReceiptModel GetReceiptsById(string id) => GetById(id);
        public void CreateReceipt(ReceiptModel receipt) => Create(receipt);
        public void UpdateReceipt(ReceiptModel receipt) => Update(receipt);
        public void DeleteReceipt(ReceiptModel receipt) => Delete(receipt);
        public bool Exists(string id) => base.Exists(id);
        public void Save(ReceiptModel receipt) => Save(receipt);
    }
}
