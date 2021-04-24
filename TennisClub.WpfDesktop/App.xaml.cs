using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.pipelines;
using Microsoft.Extensions.DependencyInjection;
using TennisClub.Data.context;
using TennisClub.Data.dao.interfaces;
using TennisClub.Infrastructure.services;

namespace TennisClub.WpfDesktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }
        // private UnitOfWork _unitOfWork;
        
        private void OnStartup(object sender, StartupEventArgs startupEventArgs)
        {
            var connectionString = "Host=localhost;Port=5432;Database=tennis-club;Username=postgres;Password=123";
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, connectionString);
            ServiceProvider = serviceCollection.BuildServiceProvider();
            
            MainWindowViewModel viewModel = new MainWindowViewModel(this.ServiceProvider);
            MainWindow window = new MainWindow(viewModel);
            window.Show();
            
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            ServiceProvider.GetRequiredService<IUnitOfWork>().Dispose();
        }
        
        private void ConfigureServices(IServiceCollection services, string connectionString)
        {
            
            
            services.AddDbContext<PostgresDbContext>(options =>
                options.UseNpgsql(connectionString));
            services.AddSingleton<IChildRepository>(s => new ChildRepository(
                s.GetRequiredService<PostgresDbContext>()));
            services.AddSingleton<IGroupRepository>(s => new GroupRepository(
                s.GetRequiredService<PostgresDbContext>()));
            services.AddSingleton<IChildChosenDaysRepository>(s => new ChildChosenDaysRepository(
                s.GetRequiredService<PostgresDbContext>()));
            
            services.AddSingleton<IUnitOfWork>(s => new UnitOfWork(
                s.GetRequiredService<PostgresDbContext>())
            {
                ChildRepository = s.GetRequiredService<IChildRepository>(),
                GroupRepository = s.GetRequiredService<IGroupRepository>(),
                ChildChosenDaysRepository = s.GetRequiredService<IChildChosenDaysRepository>()
            });
            
            
            services.AddScoped<IChildFacade, ChildFacade>(s => new ChildFacade(s));
            
            services.AddScoped<IGroupFacade, GroupFacade>(s => new GroupFacade(
                s.GetRequiredService<IUnitOfWork>()));
            
            services.AddTransient<IChildService, ChildService>(s => new ChildService(
                s.GetRequiredService<IUnitOfWork>()));
            
            services.AddTransient<IGroupService, GroupService>(s => new GroupService(s));
        }
    }
}