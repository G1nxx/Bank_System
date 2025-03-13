using Microsoft.Extensions.Logging;
using Infrastructure.Models.Mapping;
using Application.Interfaces;
using Domain.Entities.Users;
using Infrastructure.Presistence.Context;
using Infrastructure.Presistence.UnitOfWork;
using Domain.Enums;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BankSystem
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            builder.Services.AddSingleton(provider =>
            {
                string dbPath = Path.Combine(@"G:\Projects\OOP\Bank_System\db", "main.db");
                var context = new AppDbContext(dbPath);
                context.CreateTablesAsync().Wait();
                return context;
            });

            builder.Services.AddAutoMapper(typeof(BankMappingProfile).Assembly);

            builder.Services.AddTransient<IUnitOfWork, SQLiteUnitOfWork>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
