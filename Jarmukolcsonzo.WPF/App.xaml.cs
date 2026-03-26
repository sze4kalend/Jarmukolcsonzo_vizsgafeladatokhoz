using ApiClient.Repositories;
using CommunityToolkit.Mvvm.DependencyInjection;
using Jarmukolcsonzo.Shared.Models;
using Jarmukolcsonzo.Shared.Repositories;
using Jarmukolcsonzo.WPF.Repositories;
using Jarmukolcsonzo.WPF.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Jarmukolcsonzo.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Ioc.Default.ConfigureServices(new ServiceCollection()
                // 3 életciklusa van a szolgáltatásoknak
                // Scoped = amint hivatkozás történik rá, új példányt készít
                // Transient = Hagyományos úton, konstruktor alapján készít példányt
                // Singleton = 1en példány készül az alkalmazás élete során
                .AddTransient<JarmuvekViewModel>()
                .AddTransient<LoginViewModel>()
                .AddTransient<MainViewModel>()
                // .AddTransient<IGenericRepository<Jarmu>, JarmuLocalRepository>()
                // .AddTransient<IGenericRepository<JarmuTipus>, JarmuTipusLocalRepository>()
                .AddTransient<ILoginRepository, LoginLocalRepository>()
                .AddTransient<IDataTableRepository<Jarmu>, DataTableApiRepository<Jarmu>>(x =>
                {
                    return new("http://localhost:5182", "api/Jarmuvek");
                })
                .AddTransient<IGenericRepository<JarmuTipus>, GenericApiRepository<JarmuTipus>>(x =>
                {
                    return new("http://localhost:5182", "api/JarmuTipusok");
                })
                .BuildServiceProvider());
        }
    }
}
