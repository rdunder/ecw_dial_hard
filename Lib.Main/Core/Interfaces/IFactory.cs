

namespace Lib.Main.Core.Interfaces;

internal interface IFactory<TFormModel, TEntity, TModel>
{
    public TFormModel Create();
    public TEntity Create(TFormModel formModel);
    public TModel Create(TEntity entity);
}
