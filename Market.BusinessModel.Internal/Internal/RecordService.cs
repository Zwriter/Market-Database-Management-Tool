using Market.BusinessModel.Enums;
using Market.BusinessModel.Interfaces;
using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Interfaces;

namespace Market.BusinessLogic.Services
{
    public class RecordService : BaseService<RecordModel, RecordQuery, RecordSortBy>, IRecordService
    {
        public RecordService(IRepository<RecordModel> repo) : base(repo) { }

        public List<RecordModel> GetRecords(RecordQuery query) => Get(query);
        public RecordModel GetRecordsById(string id) => GetById(id);
        public void CreateRecord(RecordModel record) => Create(record);
        public void UpdateRecord(RecordModel record) => Update(record);
        public void DeleteRecord(RecordModel record) => Delete(record);
        public bool Exists(string id) => base.Exists(id);
        public void Save(RecordModel record) => Save(record);
    }
}