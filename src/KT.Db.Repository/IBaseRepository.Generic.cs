using System.Linq.Expressions;

namespace KT.Db.Repository;

public interface IBaseRepository<TEntity, TDto> : IBaseRepository
      where TEntity : MongoEntity, new()
      where TDto : BaseDto, new()
{
    Task<bool> IsExistsAsync(ObjectId id);

    Task<TDto> GetAsync(ObjectId id);

    Task<List<TDto>> GetsAsync();

    Task<DeleteResponse<TDto>> DeleteAsync(DeleteRequest request, bool backup = true);

    Task<CreateResponse> AddAsync(CreateRequest<TDto> request);

    Task<CreateManyResponse> AddManyAsync(CreateManyRequest<TDto> request);

    Task<SaveResponse> SaveAsync(SaveRequest<TDto> request);

    Task<bool> UpdateFieldAsync<TField>(ObjectId id, Expression<Func<TEntity, TField>> field, TField value);

    Task<bool> UpdateFieldsAsync<TField>(ObjectId id, (Expression<Func<TEntity, TField>> Field, TField Value)[] fields);
}