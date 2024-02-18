using Microsoft.EntityFrameworkCore;
using RestWithASPNETDarlan.Model.Context;
using RestWithASPNETDarlan.Business;
using RestWithASPNETDarlan.Business.Implementation;
using RestWithASPNETDarlan.Repository;
using RestWithASPNETDarlan.Repository.Implementation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31))));

// Versioning API
builder.Services.AddApiVersioning();

// Injecao de dependencia
builder.Services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
builder.Services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
