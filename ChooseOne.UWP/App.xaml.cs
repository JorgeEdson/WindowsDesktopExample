using ChooseOne.Core.Domain.Entities;
using ChooseOne.Database.Repositories;
using ChooseOne.Database.Repositories.Interfaces;
using ChooseOne.Database.Services;
using ChooseOne.Database.Services.Interfaces;
using ChooseOne.UWP.Common;
using Prism.Unity.Windows;
using System.Threading.Tasks;
using Windows.ApplicationModel.Activation;


namespace ChooseOne.UWP
{    
    sealed partial class App : PrismUnityApplication
    {
        public App()
        {
            this.InitializeComponent();
        }
        
        protected override Task OnLaunchApplicationAsync(LaunchActivatedEventArgs args)
        {
            NavigationService.Navigate(PageTokens.CustomizationPage, null);

            return Task.CompletedTask;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            RegisterTypeIfMissing(typeof(ICustomizationService), typeof(CustomizationService), true);
            RegisterTypeIfMissing(typeof(ICustomizationRepository), typeof(CustomizationRepository), true);
        }

        protected override void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);
            NavigationService.Navigate(PageTokens.CustomizationPage, null);

            if (args.Kind == ActivationKind.Protocol) 
            {
                ProtocolActivatedEventArgs protocolActivatedEventArgs = (ProtocolActivatedEventArgs)args;
                GlobalParameters.CustomizationId = System.Web.HttpUtility.ParseQueryString(protocolActivatedEventArgs.Uri.Query).Get("CustomizationId");                 
            }
        }
    }
}
