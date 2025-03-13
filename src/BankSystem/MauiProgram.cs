using Microsoft.Extensions.Logging;
using Infrastructure.Models.Mapping;
using Application.Interfaces;
using Application.Interfaces.Handlers;
using Domain.Entities.Users;
using Infrastructure.Persistence.Context;
using Infrastructure.Persistence.UnitOfWork;
using Domain.Enums;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Application.Handlers;
using Application.Dtos;
using Infrastructure.Persistence.Repositories;
using BankSystem.Pages.BankPages;
using Application.Interfaces.Repositories;
using Domain.Entities;
using BankSystem.Pages;

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
            //builder.Services.AddSingleton<RegistrationPage>();
            builder.Services.AddSingleton<SQLiteUnitOfWork>();

            string dbPath = Path.Combine(@"G:\Projects\OOP\Bank_System\db", "main.db");
            var context = new AppDbContext(dbPath);
            builder.Services.AddSingleton(context);

            builder.Services.AddAutoMapper(typeof(BankMappingProfile).Assembly, 
                                           typeof(UserMappingProfile).Assembly);

            builder.Services.AddSingleton<BankHandler>();
            builder.Services.AddSingleton<UserHandler>();

            builder.Services.AddSingleton<IBankHandler, BankHandler>();
            builder.Services.AddSingleton<IUserHandler, UserHandler>();

            builder.Services.AddSingleton<IRepository<BankDto>, BankRepository>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();

            builder.Services.AddTransient<IUnitOfWork, SQLiteUnitOfWork>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
