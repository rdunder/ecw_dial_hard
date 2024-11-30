

namespace Lib.Main.Core.Interfaces;

internal interface IRepository<TEntity, TModel>
{
    public void Add(TEntity entity);
    public IEnumerable<TModel> Get();
    public TModel Get(Guid id);
    public void Delete(TModel model);
    public void Update(TModel model);
    
}
