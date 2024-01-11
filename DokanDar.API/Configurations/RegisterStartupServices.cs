namespace DokanDar.API.Configurations
{
    public static class RegisterStartupServices
    {
        public static WebApplicationBuilder RegisterStartupService(this WebApplicationBuilder startupservice)
        {
            startupservice.Services.AddControllers();
            startupservice.Services.AddEndpointsApiExplorer();
            startupservice.Services.AddSwaggerGen();
            return startupservice;
        }
    }
}
