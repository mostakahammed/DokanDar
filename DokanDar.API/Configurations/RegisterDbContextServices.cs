using DokanDar.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace DokanDar.API.Configurations
{
    public static class RegisterDbContextServices
    {
        public static WebApplicationBuilder RegisterDbContext(this WebApplicationBuilder builder)
        {
            var connectionstring = builder.Configuration.GetConnectionString("dokandar");
            builder.Services.AddDbContext<DokanDbContext>(options => options.UseSqlServer(connectionstring));
            builder.Services.AddDbContext<AuthDbContext>(options => options.UseSqlServer(connectionstring));
            return builder;
        }
    }
}
