
namespace carpark_info_assignment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           // builder.Services.AddSingleton<CarparkInfoDbContext,CarparkInfoDbContext>();
            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSingleton<CarparkInfoDbContext,CarparkInfoDbContext>();
            builder.Services.AddSingleton<IFileParser,CarparkInfoCsvParser>();
            builder.Services.AddSingleton<ICarparkInfoRepository,CarparkInfoRepository>();
            builder.Services.AddSingleton<CarparkInfoService,CarparkInfoService>();
            
            builder.Services.AddTransient<Startup,Startup>();
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

             Startup startup = app.Services.GetService<Startup>() ?? throw new ArgumentException();
             startup.DoStartupProcess();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}