using System.Linq.Expressions;

namespace KT.Db.Repository;

public interface IBaseRepository
{
    public ILog Log { get; }

    public IMapper Mapper { get; }

    Task<bool> IsExistsAsync<TEntity>(ObjectId id) where TEntity : MongoEntity;

    Task<TDto> GetAsync<TEntity, TDto>(ObjectId id) where TEntity : MongoEntity;

    Task<List<TDto>> GetsAsync<TEntity, TDto>() where TEntity : MongoEntity;

    Task<CreateResponse> AddAsync<TEntity, TDto>(CreateRequest<TDto> request) where TEntity : MongoEntity where TDto : BaseDto;

    Task<CreateManyResponse> AddManyAsync<TEntity, TDto>(CreateManyRequest<TDto> request) where TEntity : MongoEntity where TDto : BaseDto;

    Task<SaveResponse> SaveAsync<TEntity, TDto>(SaveRequest<TDto> request) where TEntity : MongoEntity where TDto : BaseDto;

    Task<TEntity> DeleteAsync<TEntity>(ObjectId id, ObjectId? by = null, bool backup = true) where TEntity : MongoEntity;

    Task<bool> UpdateFieldAsync<TEntity, TField>(ObjectId id, Expression<Func<TEntity, TField>> field, TField value) where TEntity : MongoEntity;

    Task<bool> UpdateFieldsAsync<TEntity, TField>(ObjectId id, (Expression<Func<TEntity, TField>> Field, TField Value)[] fields) where TEntity : MongoEntity;
}
