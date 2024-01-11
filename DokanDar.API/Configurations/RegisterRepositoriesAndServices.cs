using DokanDar.Application.IServices.EntityServices;
using DokanDar.Application.IServices;
using DokanDar.Domain.IRepositories.EntityRepository;
using DokanDar.Domain.IRepositories;
using DokanDar.Infrastructure.Repositories.EntityRepository;
using DokanDar.Infrastructure.Repositories;
using DokanDar.Infrastructure.Services.EntityServices;
using DokanDar.Infrastructure.Services;

namespace DokanDar.API.Configurations
{
    public static class RegisterRepositoriesAndServices
    {
        public static WebApplicationBuilder RegisterUoW(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            return builder;
        }
        public static WebApplicationBuilder RegisterRepositories(this WebApplicationBuilder builder)
        {
            //----------- Add Repository -----------------//
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            return builder;
        }
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {
            //----------- Add Services -----------------//
            builder.Services.AddScoped(typeof(IGenericService<,>), typeof(GenericServices<,>));
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            return builder;
        }
    }
}
