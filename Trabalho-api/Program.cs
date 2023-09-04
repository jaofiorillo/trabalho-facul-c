using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trabalho_api.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<Trabalho_apiContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("Trabalho_apiContext"),
        new MySqlServerVersion(new Version(8, 1, 00)))); 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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