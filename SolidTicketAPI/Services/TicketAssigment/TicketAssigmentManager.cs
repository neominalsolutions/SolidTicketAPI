﻿using SolidTicketAPI.Dtos;
using SolidTicketAPI.Entities;
using SolidTicketAPI.Repos;
using System.Text.Json;

namespace SolidTicketAPI.Services.TicketAssigment
{

  // Not: Net Core ile 2 farklı şekilde zayıf bağlılığı bozmayacak şekilde bir service instance erişim işlemi mevcut bunlardan 1. Dependecy Injection, 2. Service Locator (Service Provider)

  /// <summary>
  /// Hangi isteğe göre hangi servis işlem yapacak bunu yöneten ara service.
  /// </summary>
  public class TicketAssigmentManager
  {
    // private IRepo<AssignedTicket> _repo;
    private IServiceProvider _serviceProvider; // service locator ile IoC üzerinden nesnenin instance okuma işlemi

    /*
    public TicketAssigmentManager(IRepo<AssignedTicket> repo, )
    {
      _repo = repo;
      
    }

    */

    public TicketAssigmentManager(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;

    }

    public void OnProcess(AssigmentPropertiesDto props, Ticket ticket, Employee employee)
    {
      ITicketAssigment? assigment = null;

      // service locator ile nesne instance erişim 
      

      using (var scope = _serviceProvider.CreateScope())
      {

        

        IRepo<AssignedTicket> _repo = _serviceProvider.GetRequiredService<IRepo<AssignedTicket>>();

        switch (props.AssignmentType)
        {
          case int type when type == 100 && props.PlanningHour <= 6:
            assigment = new DailyTicketAssigment(_repo);
            break;
          case int type when type == 200 && props.PlanningHour <= 30:
            assigment = new WeeklyTicketAssigment(_repo);
            break;
          case int type when type == 300 && props.PlanningHour <= 150:
            assigment = new MonthlyTicketAssigment(_repo);
            break;
          default:
            break;
        }

        if (assigment is not null)
        {
          assigment.Assign(employee, ticket, props.PlanningHour);
        }
        else
        {
          throw new Exception("Görev atama tipi uygun değil. Saatleri ve Plan tipini doğru seçmelisiniz. ");
        }
      }

      //  switch (props.AssignmentType)
      //  {
      //    case int type when type == 100 && props.PlanningHour <= 6:
      //      assigment = new DailyTicketAssigment(_repo);
      //      break;
      //    case int type when type == 200 && props.PlanningHour <= 30:
      //      assigment = new WeeklyTicketAssigment(_repo);
      //      break;
      //    case int type when type == 300 && props.PlanningHour <= 150:
      //      assigment = new MonthlyTicketAssigment(_repo);
      //      break;
      //    default:
      //      break;
      //  }

      //  if(assigment is not null)
      //  {
      //    assigment.Assign(employee, ticket, props.PlanningHour);
      //  }
      //  else
      //  {
      //    throw new Exception("Görev atama tipi uygun değil. Saatleri ve Plan tipini doğru seçmelisiniz. ");
      //  }

      //}
    }
  }
}
