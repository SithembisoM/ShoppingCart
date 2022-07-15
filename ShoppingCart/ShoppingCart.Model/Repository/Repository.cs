using ShoppingCart.Model.Repository.Interface;

namespace ShoppingCart.Model.Repository
{
  public class Repository : IRepository
  {
    public void Create<TEntity>(TEntity entity, string createdBy = null) where TEntity : class
    {
      throw new NotImplementedException();
    }

    public void Update<TEntity>(TEntity entity, string modifiedBy = null) where TEntity : class
    {
      throw new NotImplementedException();
    }

    public void Delete<TEntity>(object id) where TEntity : class
    {
      throw new NotImplementedException();
    }

    public void Delete<TEntity>(TEntity entity) where TEntity : class
    {
      throw new NotImplementedException();
    }

    public void Save()
    {
      throw new NotImplementedException();
    }

    public Task SaveAsync()
    {
      throw new NotImplementedException();
    }
  }
}
