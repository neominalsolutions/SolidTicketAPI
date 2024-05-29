using SolidTicketAPI.Entities;

namespace SolidTicketAPI.Repo
{
  public class EmployeeRepo
  {
    public Employee GetEmployeeById(Guid Id)
    {
      return Employee.Create("Ali", "Can");
    }

    public void Insert(Employee employee)
    {
      Console.WriteLine("Kayıt girildi");
    }

    public void Update(Employee employee)
    {
      Console.WriteLine("Kayıt Güncellendi");
    }

    public void Delete(Guid Id)
    {
      Console.WriteLine("Kayıt Silindi");
    }
  }
}
