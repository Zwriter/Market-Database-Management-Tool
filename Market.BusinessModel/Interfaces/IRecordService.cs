using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Market.BusinessModel.Interfaces
{
    public interface IRecordService
    {
        List<RecordModel> GetRecords(RecordQuery query);
        RecordModel GetRecordsById(string id);
        void CreateRecord(RecordModel record);
        void UpdateRecord(RecordModel record);
        void DeleteRecord(RecordModel record);
        bool Exists(string id);
        void Save(RecordModel record);
    }
}
