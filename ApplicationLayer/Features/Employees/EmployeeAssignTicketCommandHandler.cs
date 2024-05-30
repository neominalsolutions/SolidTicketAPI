using DomainLayer;
using DomainLayer.Repositories;
using InfrastrastureLayer;
using InfrastructureCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Features.Employees
{
  public class EmployeeAssignTicketCommandHandler : IRequestHandler<EmployeeAssignTicketCommand>
  {
    private TicketAssigmentManager _ticketAssigmentManager;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly ITicketRepository _ticketRepository;

    public EmployeeAssignTicketCommandHandler(TicketAssigmentManager ticketAssigmentManager, IEmployeeRepository employeeRepository, ITicketRepository ticketRepository)
    {
      _ticketAssigmentManager = ticketAssigmentManager;
      _employeeRepository = employeeRepository;
      _ticketRepository = ticketRepository;
    }

    public Task Handle(EmployeeAssignTicketCommand request, CancellationToken cancellationToken)
    {

      var employee = _employeeRepository.GetById(request.EmployeeId);
      var ticket = _ticketRepository.GetById(request.TicketId);

      var props = new AssigmentPropertiesDto { AssignmentType = request.AssigmentType, PlanningHour = request.PlanningHour };

      this._ticketAssigmentManager.OnProcess(props, ticket, employee);

      return Task.CompletedTask;

      // await Task.CompletedTask;


      // await kullanabilmek için async keyword ihtiyaç var
      // Task tek başına kullanılınca void method gibi değer döndürmeyen bir çalışma yapar.
      // Task<ResponseType> şeklinde tanımlanırsa bu durumda bir değer döndürebilir
      // Task kullanırken ilgili methodunun paralel çalışacağından dolayı CancellationToken eklemeyi unutmayalım. Yoksa developer isteği iptal edemez.
      // await Task.FromCanceled(cancellationToken); istek iptalinde yandaki gibi bir kod yazmamız lazım
      // Bazen asenkron bir çağırı exception ile sonlanabilir bu durumda 
      // Task.FromException(new Exception("Hata"));
      // Taskları execute etmek için Task.Run function kullanabiliriz
      // Paralelde birden fazla Task promise.all gibi çalıştırabilmek için Task.WhenAll kullanabiliriz       //await Task.WhenAll(t1, t2);
      // Birden fazla task ifadesinin bitişinden emin olmak için       //await Task.WaitAll(t1, t2); kullanırız
      // Task.Delay ile belirli bir süre taskın bekletimesini sağlaya biliri. thread sleep komutan benzer
      // Task.FromResult<int>(1); veya Task.Completed ile taskın sonucunu döndürebiliriz.
      // Task.CurrentId Task Thread pool üzerinde Thread Idsini buradan yakalarız.
      // Kullanım alanları API'den başka API call işlemleri, REDIS veri kaynağında veri çekme işlemleri, DAtabase çağrı işlemleri, Event Driven Development işlemleri, Message Queue gibi Asenkron Mesaj Kuyruk sistemleri çalışma durumları, Streaming gibi yoğun I/O işlemler, file upload, file download gibi işlemlerde sıklıkla Task TPL kütüphanesini tercih ederiz
      // await ile asenkron işlemleri sıralı bir şekilde cavplarını sanki senkron programlama yaparmış yakalamak istersek bu durumda kullanıyoruz.

      // async işlemi iptal et.
      //await Task.FromCanceled(cancellationToken);
      //var t1 = new Task(() => Console.WriteLine("1. iş"));
      //var t2 = new Task<int>(() => 1);

      //// TPL Task Paralel Library Thread Pool üzerinden yapılıyor.

      //Task.Run(() => t1);
      //Task.Delay(1000); // 1 ms bekleterek Tread bekleterek işlem
      //var result1 = await Task.Run(() => t2);

      //// bitişi bekleyecek isek await kullan
      //await Task.WhenAll(t1, t2);

      ////Task.FromResult<int>(1);
      ////Task.FromException<>


      //var t1 = new Thread();
      //t1.Start();
      // Thread.Sleep(1000);

    }
  }
}
