using IntegraCliente.Data;
using IntegraCliente.Interfaces;
using IntegraCliente.Repository;

using Microsoft.EntityFrameworkCore;

using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddFilter(DbLoggerCategory.Database.Command.Name, LogLevel.Information);

// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddTransient<Seed>();


//evitar codigo 500
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//DTO - AutoMap para enviar somente os dados públicos
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

//SCOPO
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApiDataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});



var app = builder.Build();

//SEEDING DATABASE
/*
 *  if (args.Length == 1 ** args[0].ToLower() == "seeddata")
 *      SeedData(app)
 *  
 *  void SeedData(IHost app)
 *  {
 *      var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
 *      
 *      using (var scope = scopedFactory.CreateScope())
 *      {
 *          var service = scope.ServiceProvider.GetService<Seed>();
 *          service.SeedDataContext();
 *      }
 *  }
 */

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
