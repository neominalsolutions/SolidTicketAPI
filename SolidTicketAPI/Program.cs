using SolidTicketAPI.Entities;
using SolidTicketAPI.Repo;
using SolidTicketAPI.Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// IOC ile uygulamada IRepo gördüðüm her yeri  EFEmployeeRepository olarak oluþtur. 

builder.Services.AddScoped<IRepo<Employee>, DapperEmployeeRepository>();
builder.Services.AddScoped<EmployeeAssignTicketService>();

// Mediator Paketi ile çalýþýrken bunu servis olarak NET CORE IOC tanýmamýz register etmemiz lazým
// Mediator ile tanýmlanmýþ tüm bileþenleri Reflection ile Load et.
// Uygulama Meditor ile ilgili ne kadar nesne varsa baðýmlýk olarak ekle.
builder.Services.AddMediatR(config =>
{
  config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
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
