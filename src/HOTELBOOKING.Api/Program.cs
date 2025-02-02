using HOTELBOOKING.Api.Authentication;
using HOTELBOOKING.Api.Extensions.Middleware;
using HOTELBOOKING.Application.UseCase.Extensions;
using HOTELBOOKING.Infrastructure.Extensions;
using HOTELBOOKING.Persistence.Extension;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registrar servicios personalizados antes de Build()
builder.Services
    .AddInjectionPersistence()  
    .AddInjectionApplication() 
    .AddInjectionInfrastructure(builder.Configuration)
    .AddAuthentication(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
// Agregar cualquier middleware personalizado
app.AddMiddleware();

app.MapControllers();

app.Run();
