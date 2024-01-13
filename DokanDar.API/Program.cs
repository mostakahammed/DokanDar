using DokanDar.API.Configurations;
using DokanDar.Application.AutoMapper;


var builder = WebApplication.CreateBuilder(args);


builder.RegisterDbContext();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.RegisterRepositories();
builder.RegisterServices();
builder.RegisterStartupService();
builder.RegisterAuthenticationService();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
