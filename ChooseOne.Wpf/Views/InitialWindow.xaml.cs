using ChooseOne.Core.Domain.Entities;
using ChooseOne.Wpf.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ChooseOne.Wpf.Views
{
    public partial class InitialWindow : Window
    {
        public InitialWindowViewModel ViewModel => (InitialWindowViewModel)DataContext;
        public InitialWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.LoadLastCustomizationsCommand.Execute(ViewModel);
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Customization customization = button.CommandParameter as Customization;

            Process.Start(new ProcessStartInfo { FileName = $"com.chooseone.uwp://?CustomizationId={customization.Id}", UseShellExecute = true });
        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Customization customization = button.CommandParameter as Customization;
            ViewModel.CustomizationObj = customization;
            ViewModel.RemoveCustomizationCommand.Execute(ViewModel);                        
        }
    }
}
