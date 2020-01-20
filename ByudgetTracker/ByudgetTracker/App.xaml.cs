using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ByudgetTracker.Services;
using ByudgetTracker.Views;
using Autofac;
using Autofac.Builder;
using ByudgetTracker.Data;
using Xamarin.Forms.Internals;

namespace ByudgetTracker
{
    public partial class App : Application
    {
        //TODO: Replace with *.azurewebsites.net url after deploying backend to Azure
        //To debug on Android emulators run the web backend against .NET Core not IIS
        //If using other emulators besides stock Google images you may need to adjust the IP address
        public static bool UseMockDataStore = true;
        private Autofac.IContainer _container;
        private AutoMapper.MapperConfiguration _automapperCfg;

        public App()
        {
            InitializeComponent();
            RegisterAutoMapperMappings();
            RegisterServices();
            MainPage = new MainPage();
        }

        private void RegisterAutoMapperMappings()
        {
            _automapperCfg = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.AddProfile<EntityMappingProfile>();
            });
        }

        private void RegisterServices()
        {
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterType<SqliteDataStore<Entities.Transaction>>().As<IDataStore<Entities.Transaction>>();
            containerBuilder.Register<AutoMapper.IMapper>(cc => _automapperCfg.CreateMapper());
            _container = containerBuilder.Build();
            DependencyResolver.ResolveUsing((t, ro) => _container.IsRegistered(t) ? _container.Resolve(t) : null);
            System.Threading.Tasks.Task.Run(() => DependencyService.Resolve<IDataStore<Entities.Transaction>>().CreateTablesAsync());
        }
        protected override void OnStart()
        {
            // Handle when your app starts
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
