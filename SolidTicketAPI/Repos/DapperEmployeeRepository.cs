using SolidTicketAPI.Entities;
using System.Linq.Expressions;

namespace SolidTicketAPI.Repos
{
  public class DapperEmployeeRepository : IRepo<Employee>
  {
    public void Delete(Employee Id)
    {
      throw new NotImplementedException();
    }

    public Employee GetById(Guid Id)
    {
      Console.WriteLine("Dapper Repo");
      return Employee.Create("Ali", "Can");
    }

    public void Insert(Employee employee)
    {
      throw new NotImplementedException();
    }

    public void Update(Employee employee)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Employee> Where(Expression<Func<Employee, bool>> predicate)
    {
      throw new NotImplementedException();
    }
  }
}
