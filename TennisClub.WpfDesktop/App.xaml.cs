using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TennisClub.Data.dao;
using TennisClub.Infrastructure.interfaces;
using TennisClub.Infrastructure.pipelines;
using Microsoft.Extensions.DependencyInjection;

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
            UnitOfWork unitOfWork = new UnitOfWork(connectionString);
            IChildFacade childLine = new ChildFacade(unitOfWork);

            // _unitOfWork = new UnitOfWork(connectionString);
            // MainWindowViewModel viewModel = new MainWindowViewModel(_unitOfWork);
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection, connectionString);
            
            ServiceProvider = serviceCollection.BuildServiceProvider();
            
            MainWindowViewModel viewModel = new MainWindowViewModel(this.ServiceProvider);
            MainWindow window = new MainWindow(viewModel);
            window.Show();
            
        }
        
        protected override void OnExit(ExitEventArgs e)
        {
            // _unitOfWork.Dispose();
           ServiceProvider.GetRequiredService<UnitOfWork>().Dispose();
        }
        
        private void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddSingleton<UnitOfWork>(s => new UnitOfWork(connectionString));
            services.AddScoped<ChildFacade>(s => new ChildFacade(
                s.GetRequiredService<UnitOfWork>()));
            services.AddScoped<GroupFacade>(s => new GroupFacade(
                s.GetRequiredService<UnitOfWork>()));
        }
    }
}