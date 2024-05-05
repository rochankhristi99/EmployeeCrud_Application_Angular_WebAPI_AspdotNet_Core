using EmployeeAPI.DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
using TableReservation.api.DataAccess;
using TableReservation.api.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Configure CORS 
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularFrontend", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add services to the container.
var services = builder.Services;

// Add DbContext using SQL Server provider
services.AddDbContext<EmployeeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("con")));

// Add scoped services
services.AddScoped<IEmployee, EmployeeRepository>();



var app = builder.Build();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Enable CORS
app.UseCors("AllowAngularFrontend");

app.UseAuthorization();

app.MapControllers();

app.Run();
