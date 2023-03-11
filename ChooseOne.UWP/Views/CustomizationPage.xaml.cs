using ChooseOne.Core.Domain.Entities;
using ChooseOne.Core.Domain.Entities.Enuns;
using ChooseOne.UWP.Common;
using ChooseOne.UWP.Models;
using ChooseOne.UWP.ViewModels;
using System;
using System.Linq;
using System.Reflection;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ChooseOne.UWP.Views
{
    public sealed partial class CustomizationPage : Page
    {
        public CustomizationPageViewModel ViewModel => (CustomizationPageViewModel)DataContext;        
        public CustomizationPage()
        {
            this.InitializeComponent();            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (GlobalParameters.CustomizationId != null)
            {
                ViewModel.GetCustomizationByIdCommand.Execute();
                AlterVisibilityDialogButtons();
            }
        }

        private void ComponentCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AlterVisibilityDialogButtons();
        }

        private void OnlyNumbers(TextBox sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }      

        private void AlterVisibilityDialogButtons()
        {
            if (ViewModel.ChooseComponentSelectedItem == ChooseComponent.Dialog)
                DialogButtons.Visibility = Visibility.Visible;
            else
                DialogButtons.Visibility = Visibility.Collapsed;
        }
    }
}
