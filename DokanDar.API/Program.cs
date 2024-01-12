using DokanDar.API.Configurations;
using DokanDar.Application.AutoMapper;
using DokanDar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionstring = builder.Configuration.GetConnectionString("dokandar");
builder.Services.AddDbContext<DokanDbContext>(options => options.UseSqlServer(connectionstring));

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.RegisterRepositories();
builder.RegisterServices();
builder.RegisterStartupService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
