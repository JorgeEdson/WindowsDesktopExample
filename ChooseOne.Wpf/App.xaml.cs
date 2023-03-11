using ChooseOne.Database;
using ChooseOne.Database.Repositories;
using ChooseOne.Database.Repositories.Interfaces;
using ChooseOne.Database.Services;
using ChooseOne.Database.Services.Interfaces;
using ChooseOne.Wpf.ViewModels;
using ChooseOne.Wpf.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ChooseOne.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<ICustomizationRepository>().To<CustomizationRepository>();
            kernel.Bind<ICustomizationService>().To<CustomizationService>();            

            var InitialWindowViewModel = kernel.Get<InitialWindowViewModel>();

            MainWindow = new InitialWindow();
            MainWindow.DataContext = InitialWindowViewModel;
            MainWindow.Show();
        }
    }
}
