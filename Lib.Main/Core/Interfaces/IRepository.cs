

namespace Lib.Main.Core.Interfaces;

public interface IRepository<TEntity, TModel>
{
    public void Add(TEntity entity);
    public IEnumerable<TModel> Get();
    public TModel Get(Guid id);
    public bool Delete(TModel model);
    public bool Update(TModel model);
    
}
