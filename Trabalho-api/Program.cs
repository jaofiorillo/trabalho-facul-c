using Microsoft.EntityFrameworkCore;
using Trabalho_api.Data;
using Trabalho_api.Repository;
using Trabalho_api.Services;

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
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<DoacaoRepository>();
builder.Services.AddScoped<DoacaoService>();

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