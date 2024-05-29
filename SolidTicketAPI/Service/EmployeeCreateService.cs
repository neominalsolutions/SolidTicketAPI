using SolidTicketAPI.Dtos;
using SolidTicketAPI.Dtos.Employee;
using SolidTicketAPI.Repo;

namespace SolidTicketAPI.Service
{
  // SRP ile her bir operasyon ve her bir request ,için bir sınıf açıyoruz
  // Employee Entity => CreateEmployeeDto, UpdateEmployeeDto, AssingTicketEmployeeDto
  // Employee Entity => EmployeeCreateService, EmployeeUpdateSewrv
  public class EmployeeCreateService
  {
    //2.ref
    private readonly EFEmployeeRepo eFEmployeeRepo = new EFEmployeeRepo();

    public void Create(CreateEmployeeDto request)
    {

    }
  }
}
