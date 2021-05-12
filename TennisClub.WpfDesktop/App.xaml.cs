using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.Data.Context;
using TennisClub.Data.Repository;
using TennisClub.Data.Repository.interfaces;
using TennisClub.Infrastructure.Interfaces;
using TennisClub.Infrastructure.Pipelines;
using TennisClub.Infrastructure.Services;
using TennisClub.WpfDesktop.ViewModel;

namespace TennisClub.WpfDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        private void OnStartup(object sender, StartupEventArgs startupEventArgs)
        {
            var connectionString = "Host=localhost;Port=5432;Database=tennis-club;Username=postgres;Password=123";
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, connectionString);
            ServiceProvider = serviceCollection.BuildServiceProvider();

            ViewLocator viewLocator = new ViewLocator(ServiceProvider);
            
            Application.Current.Resources["ViewLocator"] = viewLocator;
            
            MainWindow window = new MainWindow(viewLocator.MainViewModel);
            window.Show();
            
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            ServiceProvider.GetRequiredService<IUnitOfWork>().Dispose();
        }
        
        private void ConfigureServices(IServiceCollection services, string connectionString)
        {
            var options = new DbContextOptionsBuilder<PostgresDbContext>().UseNpgsql().Options;
            var dbContext = new PostgresDbContext(connectionString, options);
            
            services.AddSingleton<IUnitOfWork>(s => new UnitOfWork(
                dbContext,
                new ChildRepository(dbContext),
                new GroupRepository(dbContext),
                new ChildChosenDaysRepository(dbContext))
            );

            services.AddScoped<IChildFacade, ChildFacade>(s => new ChildFacade(s));
            
            services.AddScoped<IGroupFacade, GroupFacade>(s => new GroupFacade(
                s.GetRequiredService<IUnitOfWork>()));
            
            services.AddTransient<IChildService, ChildService>(s => new ChildService(
                s.GetRequiredService<IUnitOfWork>()));
            
            services.AddTransient<IGroupService, GroupService>(s => new GroupService(s));
        }
    }
}