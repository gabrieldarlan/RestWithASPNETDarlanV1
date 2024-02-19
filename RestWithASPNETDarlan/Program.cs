using Microsoft.EntityFrameworkCore;
using RestWithASPNETDarlan.Model.Context;
using RestWithASPNETDarlan.Business;
using RestWithASPNETDarlan.Business.Implementation;
using RestWithASPNETDarlan.Repository;
using RestWithASPNETDarlan.Repository.Implementation;
using MySqlConnector;
using Serilog;
using EvolveDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

var connection = builder.Configuration["MySQLConnection:MySQLConnectionString"];
builder.Services.AddDbContext<MySQLContext>(options => options.UseMySql(connection, new MySqlServerVersion(new Version(8, 0, 31))));

if (builder.Environment.IsDevelopment())
{
    MigrateDatabase(connection);
}

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

void MigrateDatabase(string connection)
{
    try
    {
        var evolveConnection = new MySqlConnection(connection);
        var evolve = new Evolve(evolveConnection, Log.Information)
        {
            Locations = new List<string> { "db/migrations", "db/dataset" },
            IsEraseDisabled = true,
        };
        evolve.Migrate();
    }
    catch (Exception ex)
    {
        Log.Error("Database migration failed", ex);
        throw;
    }
}