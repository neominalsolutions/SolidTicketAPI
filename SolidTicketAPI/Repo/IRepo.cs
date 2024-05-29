using SolidTicketAPI.Entities;

namespace SolidTicketAPI.Repo
{
  public interface IRepo<TEntity>
  {
    public TEntity GetById(Guid Id);


    public void Insert(TEntity employee);


    public void Update(TEntity employee);


    public void Delete(TEntity Id);
   
  }
}
