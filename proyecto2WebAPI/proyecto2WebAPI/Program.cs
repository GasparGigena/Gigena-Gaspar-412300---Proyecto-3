using BibliotecaBack.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using BibliotecaBack.Services;
using BibliotecaBack.Entities;
using BibliotecaBack.Repositories;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<FacturaDbContext>(options =>
options
.UseSqlServer(builder.Configuration
.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IFacturaRepository, FacturaRepository>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
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
