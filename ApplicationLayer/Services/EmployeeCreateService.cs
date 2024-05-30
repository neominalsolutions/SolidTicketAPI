using ApplicationLayer;
using InfrastrastureLayer;


namespace ApplicationLayer
{
    // SRP ile her bir operasyon ve her bir request ,için bir sınıf açıyoruz
    // Employee Entity => CreateEmployeeDto, UpdateEmployeeDto, AssingTicketEmployeeDto
    // Employee Entity => EmployeeCreateService, EmployeeUpdateSewrv
    public class EmployeeCreateService
  {
    //2.ref
    // DIP yok tight coupled sıkı sıkıya bağlılık var. yanlış kullanım
    private readonly EFEmployeeRepository eFEmployeeRepo = new EFEmployeeRepository();

    public void Create(CreateEmployeeDto request)
    {

    }
  }
}
