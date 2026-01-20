using Market.BusinessModel.Models;
using Market.BusinessModel.Requests;
using Market.DataAccess.Interfaces;

namespace Market.BusinessLogic.Services
{
    public abstract class BaseService<TModel, TQuery, TSort>
        where TModel : BaseModel
        where TQuery : QueryRequest<TSort>
        where TSort : struct, Enum
    {
        protected readonly IRepository<TModel> _repo;

        protected BaseService(IRepository<TModel> repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public virtual List<TModel> Get(TQuery query)
        {
            if (query == null) throw new ArgumentNullException(nameof(query));
            return _repo.Query(query).ToList();
        }

        public virtual void Create(TModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            _repo.Add(entity);
        }

        public virtual void Update(TModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(entity.Id) || !_repo.Exists(entity.Id))
                throw new InvalidOperationException("Entity does not exist.");
            _repo.Update(entity);
        }

        public virtual void Delete(TModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(entity.Id) || !_repo.Exists(entity.Id))
                throw new InvalidOperationException("Entity does not exist.");
            _repo.Delete(entity);
        }

        public virtual bool Exists(string id)
        {
            if (string.IsNullOrEmpty(id)) return false;
            return _repo.Exists(id);
        }

        public virtual void Save(TModel entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            if (string.IsNullOrEmpty(entity.Id) || !_repo.Exists(entity.Id))
                _repo.Add(entity);
            else
                _repo.Update(entity);
        }
    }
}