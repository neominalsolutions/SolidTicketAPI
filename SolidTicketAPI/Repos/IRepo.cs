using SolidTicketAPI.Entities;
using System.Linq.Expressions;

namespace SolidTicketAPI.Repos
{
  public interface IRepo<TEntity>
  {
    public TEntity GetById(Guid Id);


    public void Insert(TEntity employee);

    public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);


    public void Update(TEntity employee);


    public void Delete(TEntity Id);
   
  }
}
