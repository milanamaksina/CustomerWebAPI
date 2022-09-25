using AutoMapper;
using CustomerData.Contexts;
using CustomerWebAPI.Extensions;

using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRepositories();
builder.Services.AddAutoMapper(typeof(MapperConfiguration));

builder.Services.AddDbContext<CustomerProjectContext>(o =>
{
    
    o.UseSqlServer(@"Server=.;Database=Maksina_Customer.db;Trusted_Connection=True;");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
