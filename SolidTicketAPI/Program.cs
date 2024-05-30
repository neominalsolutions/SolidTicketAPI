using ApplicationLayer;
using ApplicationLayer.Features.Employees;
using DomainLayer;
using DomainLayer.Repositories;
using InfrastrastureLayer;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IOC ile uygulamada IRepo g�rd���m her yeri  EFEmployeeRepository olarak olu�tur. 

builder.Services.AddScoped<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddScoped<IAssignedTicketRepository, EFAssignedTicketRepository>();
builder.Services.AddScoped<ITicketRepository, TicketRepo>();
builder.Services.AddScoped<EmployeeAssignTicketService>();
builder.Services.AddScoped<TicketAssigmentManager>();

// Mediator Paketi ile �al���rken bunu servis olarak NET CORE IOC tan�mam�z register etmemiz laz�m
// Mediator ile tan�mlanm�� t�m bile�enleri Reflection ile Load et.
// Uygulama Meditor ile ilgili ne kadar nesne varsa ba��ml�k olarak ekle.
builder.Services.AddMediatR(config =>
{
  //config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
  // Katmanlara ay�rd���m�zdan Hangi katmana ait kodu �al��t�raca��m�z Katman i�indeki bir tip �zerinden belirledik.
  config.RegisterServicesFromAssemblyContaining<TicketAssignedEvent>();
  config.RegisterServicesFromAssemblyContaining<EmployeeAssignTicketCommandHandler>();
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
