using Library.Abstractions.Analytics;
using Library.Abstractions.Factories;
using Library.Abstractions.Models;
using Library.Abstractions;
using Library.Realisation.Analytics;
using Library.Realisation.Factories;
using Library.Realisation.Models;
using Library.Realisation.Storages;
using Microsoft.Extensions.DependencyInjection;
using System.Xml;
using Library.Realisation.MenuFacade;
using Library.Realisation.FileHandlers;
using System.Text.Json;
using System.Diagnostics;
using Library.Realisation;

public class Settings
{
    public static IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddSingleton<IBankAccount, BankAccount>();
        services.AddSingleton<ICategory, Category>();
        services.AddSingleton<IOperation, Operation>();
        // services.AddSingleton<IGrouperBy, GrouperBy>();

        // Регистрация сервисов для Factories
        services.AddSingleton<IFactory, AccountFactory>();
        services.AddSingleton<IFactory, OperationFactory>();
        services.AddSingleton<IFactory, CategoryFactory>();

        // Регистрация сервисов для Models
        services.AddTransient<IBankAccount, BankAccount>();
        services.AddTransient<ICategory, Category>();
        services.AddTransient<IOperation, Operation>();

        // Регистрация для Storage
        services.AddSingleton<AccountStorage<BankAccount>>();
        services.AddSingleton<OperationStorage<Operation>>();
        services.AddSingleton<CategoryStorage<Category>>();

        // Регистрация сервисов для Realisation
        services.AddSingleton<IAnalyticsFacade, AnalyticsFacade>();
        // services.AddSingleton<GroupedBy>();

        // Menu
        services.AddSingleton<Menu>();
        services.AddSingleton<MenuProxi>();

        // FilesHandlers
        services.AddSingleton<JsonFileHandler>();
        services.AddSingleton<CsvFileHandler>();
        services.AddSingleton<YamlFileHandler>();

        //Process
        services.AddSingleton<Processor>();

        return services.BuildServiceProvider();
    }
}