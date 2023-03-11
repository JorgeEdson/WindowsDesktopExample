using ChooseOne.Core.Domain.Entities;
using ChooseOne.Database.Services.Interfaces;
using ChooseOne.Wpf.ViewModels.Commands;
using Microsoft.EntityFrameworkCore;
using Ninject;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ChooseOne.Wpf.ViewModels
{
    public class InitialWindowViewModel : INotifyPropertyChanged
    {
        public ICustomizationService _customizationService;

        #region Propertys
        private ObservableCollection<Customization> customizations;
        public ObservableCollection<Customization> Customizations
        {
            get { return customizations; }
            set
            {
                customizations = value;
                OnPropertyChanged("Customizations");
            }
        }

        private Customization customizationObj;
        public Customization CustomizationObj
        {
            get { return customizationObj; }
            set
            {
                customizationObj = value;
                OnPropertyChanged("CustomizationObj");
            }
        }
        #endregion

        #region Commands

        public ICommand LoadAllCustomizationsCommand { get; }
        public async void LoadAllCustomizations()
        {
            Customizations = await _customizationService.GetAllInObsCollectionAsync();
        }

        public ICommand LoadLastCustomizationsCommand { get; }
        public async void LoadLast3Customizations()
        {
            Customizations = await _customizationService.GetLast3Async();
        }

        public ICommand RemoveCustomizationCommand { get; }
        public async void RemoveCustomization()
        {
            await _customizationService.RemoveAsync(CustomizationObj);
            LoadLast3Customizations();
        }

        public ICommand CreateCommand { get; }
        public async void Create()
        {
            Process.Start(new ProcessStartInfo { FileName = $"com.chooseone.uwp://", UseShellExecute = true });
        }


        public ICommand CloseCommand { get; }
        public async void Close()
        {
            Application.Current.Shutdown();
        }
        #endregion





        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string propertyName) 
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null) 
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public InitialWindowViewModel(ICustomizationService customizationService)
        {
            _customizationService = customizationService;
            LoadLastCustomizationsCommand = new LoadLast3CustomizationsCommand(LoadLast3Customizations);
            LoadAllCustomizationsCommand = new LoadAllCustomizationsCommand(LoadAllCustomizations);            
            RemoveCustomizationCommand = new RemoveCustomizationCommand(RemoveCustomization);
            CloseCommand = new CloseCommand(Close);
            CreateCommand = new CreateCommand(Create);
        }
    }
}
