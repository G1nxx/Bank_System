using Microsoft.Extensions.Logging;
using Application.Interfaces;
using Application.Interfaces.Handlers;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Infrastructure.Persistence.Repositories;
using Application.Interfaces.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Handlers;
using Application.Mapping;
using Application.Mappings;

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

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<SQLiteUnitOfWork>();

            string dbPath = Path.Combine(@"G:\Projects\OOP\Bank_System\db", "main.db");
            var context = new AppDbContext(dbPath);
            builder.Services.AddSingleton(context);

            builder.Services.AddAutoMapper(typeof(BankMappingProfile).Assembly,
                                           typeof(UserMappingProfile).Assembly,
                                           typeof(RCBAMappingProfile).Assembly,
                                           typeof(BAMappingProfile).Assembly,
                                           typeof(TransactionMappingProfile).Assembly);

            builder.Services.AddSingleton<TransactionHandler>();
            builder.Services.AddSingleton<BankHandler>();
            builder.Services.AddSingleton<UserHandler>();
            builder.Services.AddSingleton<BankAccount>();
            builder.Services.AddSingleton<RCBA>();

            builder.Services.AddSingleton<ITransactionHandler, TransactionHandler>();
            builder.Services.AddSingleton<IBankHandler, BankHandler>();
            builder.Services.AddSingleton<IUserHandler, UserHandler>();
            builder.Services.AddSingleton<IRCBAHandler, RCBAHandler>();
            builder.Services.AddSingleton<IBAHandler, BAHandler>();

            builder.Services.AddSingleton<IBankRepository, BankRepository>();
            builder.Services.AddSingleton<ITransactionRepository, TransactionRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IRCBARepository, RCBARepository>();
            builder.Services.AddSingleton<IBARepository, BARepository>();

            builder.Services.AddTransient<IUnitOfWork, SQLiteUnitOfWork>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
