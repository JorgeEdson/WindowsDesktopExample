using ChooseOne.Core.Domain.Entities;
using ChooseOne.Core.Domain.Entities.Enuns;
using ChooseOne.Database.Services.Interfaces;
using ChooseOne.UWP.Common;
using ChooseOne.UWP.Models;
using Prism.Commands;
using Prism.Windows.Mvvm;
using Prism.Windows.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

namespace ChooseOne.UWP.ViewModels
{
    public class CustomizationPageViewModel : ViewModelBase
    {
        private readonly ICustomizationService _customizationService;
        DataPackage dataPackage;

        #region Propertys
        private Customization customizationObj;
        public Customization CustomizationObj
        {
            get { return customizationObj; }
            set { SetProperty(ref customizationObj, value); }
        }        

        private List<ChooseComponent> chooseComponentList;
        public List<ChooseComponent> ChooseComponentList
        {
            get { return chooseComponentList; }
            set { SetProperty(ref chooseComponentList, value); }
        }

        private ChooseComponent chooseComponentSelectedItem;
        public ChooseComponent ChooseComponentSelectedItem
        {
            get { return chooseComponentSelectedItem; }
            set { SetProperty(ref chooseComponentSelectedItem, value); }
        }

        private string codeXaml;
        public string CodeXaml
        {
            get { return codeXaml; }
            set { SetProperty(ref codeXaml, value); }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private string content;
        public string Content
        {
            get { return content; }
            set { SetProperty(ref content, value); }
        }

        private string backgroundColor;
        public string BackgroundColor
        {
            get { return backgroundColor; }
            set { SetProperty(ref backgroundColor, value); }
        }

        private string foregroundColor;
        public string ForegroundColor
        {
            get { return foregroundColor; }
            set { SetProperty(ref foregroundColor, value); }
        }

        private string cornerRadius;
        public string CornerRadius
        {
            get { return cornerRadius; }
            set { SetProperty(ref cornerRadius, value); }
        }

        private string minValue;
        public string MinValue
        {
            get { return minValue; }
            set { SetProperty(ref minValue, value); }
        }

        private string maxValue;
        public string MaxValue
        {
            get { return maxValue; }
            set { SetProperty(ref maxValue, value); }
        }

        private string fontSize;
        public string FontSize
        {
            get { return fontSize; }
            set { SetProperty(ref fontSize, value); }
        }

        private string height;
        public string Height
        {
            get { return height; }
            set { SetProperty(ref height, value); }
        }

        private string width;
        public string Width
        {
            get { return width; }
            set { SetProperty(ref width, value); }
        }

        private string dialogButton1;
        public string DialogButton1
        {
            get { return dialogButton1; }
            set { SetProperty(ref dialogButton1, value); }
        }

        private string dialogButton2;
        public string DialogButton2
        {
            get { return dialogButton2; }
            set { SetProperty(ref dialogButton2, value); }
        }

        private string dialogButton3;
        public string DialogButton3
        {
            get { return dialogButton3; }
            set { SetProperty(ref dialogButton3, value); }
        }

        private MyColor backgroundColorSelectedItem;
        public MyColor BackgroundColorSelectedItem
        {
            get { return backgroundColorSelectedItem; }
            set { SetProperty(ref backgroundColorSelectedItem, value); }
        }

        private MyColor foregroundColorSelectedItem;
        public MyColor ForegroundColorSelectedItem
        {
            get { return foregroundColorSelectedItem; }
            set { SetProperty(ref foregroundColorSelectedItem, value); }
        }

        private List<MyColor> listColors;
        public List<MyColor> ListColors
        {
            get { return listColors; }
            set { SetProperty(ref listColors, value); }
        }

        private ObservableCollection<FrameworkElement> listToRender;
        public ObservableCollection<FrameworkElement> ListToRender
        {
            get { return listToRender; }
            set { SetProperty(ref listToRender, value); }
        }

        #endregion

        #region Commands  
        public DelegateCommand AddCustomizationCommand { get; set; }
        async Task AddCustomizationAsync()
        {
            try 
            {
                if (CustomizationObj == null)
                {
                    var customization = new Customization();
                    customization.ChooseComponent = ChooseComponentSelectedItem;
                    customization.Name = Name;
                    customization.Content = Content;
                    customization.BackGroundColor = BackgroundColorSelectedItem.Hexa;
                    customization.ForeGroundColor = ForegroundColorSelectedItem.Hexa;
                    customization.FontSize = FontSize;
                    customization.Height = Height;
                    customization.Width = Width;                    
                    customization.CornerRadius = CornerRadius;
                    customization.MinValue = MinValue;
                    customization.MaxValue = MaxValue;
                    customization.DialogButton1 = DialogButton1;
                    customization.DialogButton2= DialogButton2;
                    customization.DialogButton3 = DialogButton3;

                    CustomizationObj = customization;

                    await _customizationService.AddAsync(customization);

                    RenderComponentInView();
                    
                }
                else 
                {
                    CustomizationObj.ChooseComponent = ChooseComponentSelectedItem;
                    CustomizationObj.Name = Name;
                    CustomizationObj.Content = Content;
                    CustomizationObj.BackGroundColor = BackgroundColorSelectedItem.Hexa;
                    CustomizationObj.ForeGroundColor = ForegroundColorSelectedItem.Hexa;
                    CustomizationObj.FontSize = FontSize;
                    CustomizationObj.Height = Height;
                    CustomizationObj.Width = Width;
                    CustomizationObj.CornerRadius = CornerRadius;
                    CustomizationObj.MinValue = MinValue;
                    CustomizationObj.MaxValue = MaxValue;
                    CustomizationObj.DialogButton1 = DialogButton1;
                    CustomizationObj.DialogButton2 = DialogButton2;
                    CustomizationObj.DialogButton3 = DialogButton3;

                    await _customizationService.UpdateAsync(CustomizationObj);

                    RenderComponentInView();

                }               
            }
            catch(Exception ex) 
            {                
                CustomizationObj = null;
            }
        }

        public DelegateCommand DeleteCustomizationCommand { get; set; }
        async Task DeleteCustomizationAsync()
        {
            if (CustomizationObj != null) 
            {
                await _customizationService.RemoveAsync(CustomizationObj);
                Clear();
            }            
        }

        public DelegateCommand ClearCommand { get; set; }
        void Clear()
        {
            CustomizationObj = null;
            Name = string.Empty;
            Content = string.Empty;
            ForegroundColorSelectedItem = null;
            BackgroundColorSelectedItem = null;
            FontSize = string.Empty;
            Height = string.Empty;
            Width = string.Empty;
            CornerRadius = string.Empty;
            MinValue = string.Empty;
            MaxValue = string.Empty;
            DialogButton1 = string.Empty;
            DialogButton3 = string.Empty;
            DialogButton3 = string.Empty;
            CodeXaml = string.Empty;
            ListToRender.Clear();
        }

        public DelegateCommand GetCustomizationByIdCommand { get; set; }
        async Task GetCustomizationByIdAsync() 
        {
            if (GlobalParameters.CustomizationId != null) 
            {
                CustomizationObj = await _customizationService.GetByIdAsync(Convert.ToInt32(GlobalParameters.CustomizationId));
                FillFields();
                RenderComponentInView();
            }
        }

        public DelegateCommand CloseCommand { get; set; }
        void Close()
        {
            CoreApplication.Exit();
        }

        public DelegateCommand ViewCodeCommand { get; set; }
        void ViewCode()
        {
            if (customizationObj != null) 
            {
                switch (CustomizationObj.ChooseComponent)
                {
                    case ChooseComponent.Button:
                        string buttonXaml = $"<Button Name=\"{CustomizationObj.Name}\">\n" +
                                                                $"  Content=\"{CustomizationObj.Content}\"\n";
                        buttonXaml += CustomizationObj.BackGroundColor == null ? "" : $"  Background=\"{GetNameColorByHex(CustomizationObj.BackGroundColor)}\"\n";
                        buttonXaml += CustomizationObj.ForeGroundColor == null ? "" : $"  Foreground=\"{GetNameColorByHex(CustomizationObj.ForeGroundColor)}\"\n";
                        buttonXaml += CustomizationObj.CornerRadius == null ? "" : $"  CornerRadius=\"{CustomizationObj.CornerRadius}\"\n";
                        buttonXaml += CustomizationObj.FontSize == null ? "" : $"  FontSize=\"{CustomizationObj.FontSize}\"\n";
                        buttonXaml += CustomizationObj.Height == null ? "" : $"  Height=\"{CustomizationObj.Height}\"\n";
                        buttonXaml += CustomizationObj.Width == null ? "" : $"  Width=\"{CustomizationObj.Width}\"\n";
                        buttonXaml += "</Button>";
                        CodeXaml = buttonXaml;
                        CopyToClipboard(buttonXaml);
                        break;
                    case ChooseComponent.RadioButton:
                        string RadioButtonXaml = $"<RadioButton Name=\"{CustomizationObj.Name}\">\n" +
                                                                $"  Content=\"{CustomizationObj.Content}\"\n";
                        RadioButtonXaml += CustomizationObj.BackGroundColor == null ? "" : $"  Background=\"{GetNameColorByHex(CustomizationObj.BackGroundColor)}\"\n";
                        RadioButtonXaml += CustomizationObj.ForeGroundColor == null ? "" : $"  Foreground=\"{GetNameColorByHex(CustomizationObj.ForeGroundColor)}\"\n";
                        RadioButtonXaml += CustomizationObj.CornerRadius == null ? "" : $"  CornerRadius=\"{CustomizationObj.CornerRadius}\"\n";
                        RadioButtonXaml += CustomizationObj.FontSize == null ? "" : $"  FontSize=\"{CustomizationObj.FontSize}\"\n";
                        RadioButtonXaml += CustomizationObj.Height == null ? "" : $"  Height=\"{CustomizationObj.Height}\"\n";
                        RadioButtonXaml += CustomizationObj.Width == null ? "" : $"  Width=\"{CustomizationObj.Width}\"\n";
                        RadioButtonXaml += "</Button>";
                        CodeXaml = RadioButtonXaml;
                        CopyToClipboard(RadioButtonXaml);
                        break;
                    case ChooseComponent.CheckButton:
                        string CheckButtonXaml = $"<CheckBox Name=\"{CustomizationObj.Name}\">\n" +
                                                            $"  Content=\"{CustomizationObj.Content}\"\n";
                        CheckButtonXaml += CustomizationObj.BackGroundColor == null ? "" : $"  Background=\"{GetNameColorByHex(CustomizationObj.BackGroundColor)}\"\n";
                        CheckButtonXaml += CustomizationObj.ForeGroundColor == null ? "" : $"  Foreground=\"{GetNameColorByHex(CustomizationObj.ForeGroundColor)}\"\n";
                        CheckButtonXaml += CustomizationObj.CornerRadius == null ? "" : $"  CornerRadius=\"{CustomizationObj.CornerRadius}\"\n";
                        CheckButtonXaml += CustomizationObj.FontSize == null ? "" : $"  FontSize=\"{CustomizationObj.FontSize}\"\n";
                        CheckButtonXaml += CustomizationObj.Height == null ? "" : $"  Height=\"{CustomizationObj.Height}\"\n";
                        CheckButtonXaml += CustomizationObj.Width == null ? "" : $"  Width=\"{CustomizationObj.Width}\"\n";
                        CheckButtonXaml += "</CheckBox>";
                        CodeXaml = CheckButtonXaml;
                        CopyToClipboard(CheckButtonXaml);
                        break;
                    case ChooseComponent.ToogleButton:
                        string ToggleButtonXaml = $"<ToggleSwitch Name=\"{CustomizationObj.Name}\">\n" +
                                                            $"  Content=\"{CustomizationObj.Content}\"\n";
                        ToggleButtonXaml += CustomizationObj.BackGroundColor == null ? "" : $"  Background=\"{GetNameColorByHex(CustomizationObj.BackGroundColor)}\"\n";
                        ToggleButtonXaml += CustomizationObj.ForeGroundColor == null ? "" : $"  Foreground=\"{GetNameColorByHex(CustomizationObj.ForeGroundColor)}\"\n";
                        ToggleButtonXaml += CustomizationObj.CornerRadius == null ? "" : $"  CornerRadius=\"{CustomizationObj.CornerRadius}\"\n";
                        ToggleButtonXaml += CustomizationObj.FontSize == null ? "" : $"  FontSize=\"{CustomizationObj.FontSize}\"\n";
                        ToggleButtonXaml += CustomizationObj.Height == null ? "" : $"  Height=\"{CustomizationObj.Height}\"\n";
                        ToggleButtonXaml += CustomizationObj.Width == null ? "" : $"  Width=\"{CustomizationObj.Width}\"\n";
                        ToggleButtonXaml += "</ToggleSwitch>";
                        CodeXaml = ToggleButtonXaml;
                        CopyToClipboard(ToggleButtonXaml);
                        break;
                    case ChooseComponent.Slider:
                        string SliderXaml = $"<Slider Name=\"{CustomizationObj.Name}\">\n" +
                                                            $"  Content=\"{CustomizationObj.Content}\"\n";
                        SliderXaml += CustomizationObj.BackGroundColor == null ? "" : $"  Background=\"{GetNameColorByHex(CustomizationObj.BackGroundColor)}\"\n";
                        SliderXaml += CustomizationObj.ForeGroundColor == null ? "" : $"  Foreground=\"{GetNameColorByHex(CustomizationObj.ForeGroundColor)}\"\n";
                        SliderXaml += CustomizationObj.CornerRadius == null ? "" : $"  CornerRadius=\"{CustomizationObj.CornerRadius}\"\n";
                        SliderXaml += CustomizationObj.FontSize == null ? "" : $"  FontSize=\"{CustomizationObj.FontSize}\"\n";
                        SliderXaml += CustomizationObj.Height == null ? "" : $"  Height=\"{CustomizationObj.Height}\"\n";
                        SliderXaml += CustomizationObj.Width == null ? "" : $"  Width=\"{CustomizationObj.Width}\"\n";
                        SliderXaml += "</Slider>";
                        CodeXaml = SliderXaml;
                        CopyToClipboard(SliderXaml);
                        break;
                    case ChooseComponent.Dialog:
                        string DialogCode = $"ContentDialog contentDialog = new ContentDialog()\n";
                        DialogCode += "{\n";
                        DialogCode += $"    Title = \"{CustomizationObj.Name}\",\n";
                        DialogCode += $"    Content = \"{CustomizationObj.Content}\",\n";
                        DialogCode += $"    PrimaryButtonText = \"{CustomizationObj.DialogButton1}\"";
                        DialogCode += CustomizationObj.DialogButton2 == null ? "" : $",\n    SecondaryButtonText = \"{CustomizationObj.DialogButton2}\"";
                        DialogCode += CustomizationObj.DialogButton3 == null ? "" : $",\n    CloseButtonText = \"{CustomizationObj.DialogButton3}\"";
                        DialogCode += "\n}";
                        CodeXaml = DialogCode;
                        CopyToClipboard(DialogCode);
                        break;
                }
            }
            
        }
        #endregion

        public CustomizationPageViewModel(ICustomizationService customizationService)
        {
            _customizationService = customizationService;
            dataPackage = new DataPackage();

            AddCustomizationCommand = new DelegateCommand(async () => await AddCustomizationAsync());
            GetCustomizationByIdCommand = new DelegateCommand(async () => await GetCustomizationByIdAsync());
            DeleteCustomizationCommand = new DelegateCommand(async () => await DeleteCustomizationAsync());
            ClearCommand = new DelegateCommand(Clear);
            CloseCommand = new DelegateCommand(Close);
            ViewCodeCommand = new DelegateCommand(ViewCode);

            chooseComponentList = Enum.GetValues(typeof(ChooseComponent)).Cast<ChooseComponent>().ToList();
            ListToRender = new ObservableCollection<FrameworkElement>();

            listColors = new List<MyColor>();
            listColors.Add(new MyColor("None", null));
            listColors.Add(new MyColor("Black", "#000000"));
            listColors.Add(new MyColor("Rose", "#ff007f"));
            listColors.Add(new MyColor("Orange", "#ffa500"));
            listColors.Add(new MyColor("LightYellow", "#ffffe0"));
            listColors.Add(new MyColor("Green", "#00ff00"));
            listColors.Add(new MyColor("Lime", "#32cd32"));
            listColors.Add(new MyColor("Teal", "#008080"));
            listColors.Add(new MyColor("Aqua", "#00ffff"));
            listColors.Add(new MyColor("SkyBlue", "#87ceeb"));
            listColors.Add(new MyColor("Blue", "#0000ff"));
            listColors.Add(new MyColor("LightBlue", "#add8e6"));
            listColors.Add(new MyColor("DarkPurple", "#551a8b"));
            listColors.Add(new MyColor("Purple", "#a020f0"));
            listColors.Add(new MyColor("Lavender", "#e6e6fa"));
            listColors.Add(new MyColor("Pink", "#ffc0cb"));
        }

        public override void OnNavigatedTo(NavigatedToEventArgs e, Dictionary<string, object> viewModelState)
        {
            base.OnNavigatedTo(e, viewModelState);
        }

        void FillFields()
        {
            ChooseComponentSelectedItem = customizationObj.ChooseComponent;
            Name = customizationObj.Name;
            Content = customizationObj.Content;
            BackgroundColor = customizationObj.BackGroundColor;
            ForegroundColor = customizationObj.ForeGroundColor;
            FontSize = customizationObj.FontSize;
            Width = customizationObj.Width;
            Height = customizationObj.Height;
            CornerRadius = customizationObj.CornerRadius;
            MinValue = customizationObj.MinValue;
            MaxValue = customizationObj.MaxValue;
            DialogButton1 = customizationObj.DialogButton1;
            DialogButton2 = customizationObj.DialogButton2;
            DialogButton3= customizationObj.DialogButton3;
        }
        void RenderComponentInView() 
        {
            ListToRender.Clear();
            switch (CustomizationObj.ChooseComponent)
            {
                case ChooseComponent.Button:
                    var renderButton = new Button();
                    renderButton.Name = CustomizationObj.Name;
                    renderButton.Content = CustomizationObj.Content;
                    if (CustomizationObj.BackGroundColor != null)
                        renderButton.Background = GetSolidColorBrushByHex(CustomizationObj.BackGroundColor);

                    if (CustomizationObj.ForeGroundColor != null)
                        renderButton.Foreground = GetSolidColorBrushByHex(CustomizationObj.ForeGroundColor);

                    if (CustomizationObj.FontSize != null)
                        renderButton.FontSize = Convert.ToDouble(CustomizationObj.FontSize);

                    if (CustomizationObj.Width != null)
                        renderButton.Width = Convert.ToDouble(CustomizationObj.Width);

                    if (CustomizationObj.Height != null)
                        renderButton.Height = Convert.ToDouble(CustomizationObj.Height);

                    if (CustomizationObj.CornerRadius != null)
                        renderButton.CornerRadius = new CornerRadius(Convert.ToDouble(CustomizationObj.CornerRadius));
                    
                    renderButton.Margin = new Thickness(100);
                    ListToRender.Add(renderButton);
                    break;
                case ChooseComponent.RadioButton:
                    var renderButtonRadioButton = new RadioButton();
                    renderButtonRadioButton.Name = CustomizationObj.Name;
                    renderButtonRadioButton.Content = CustomizationObj.Content;

                    if (CustomizationObj.BackGroundColor != null)
                        renderButtonRadioButton.Background = GetSolidColorBrushByHex(CustomizationObj.BackGroundColor);

                    if (CustomizationObj.ForeGroundColor != null)
                        renderButtonRadioButton.Foreground = GetSolidColorBrushByHex(CustomizationObj.ForeGroundColor);

                    if (CustomizationObj.FontSize != null)
                        renderButtonRadioButton.FontSize = Convert.ToDouble(CustomizationObj.FontSize);

                    if (CustomizationObj.Width != null)
                        renderButtonRadioButton.Width = Convert.ToDouble(CustomizationObj.Width);

                    if (CustomizationObj.Height != null)
                        renderButtonRadioButton.Height = Convert.ToDouble(CustomizationObj.Height);

                    if (CustomizationObj.CornerRadius != null)
                        renderButtonRadioButton.CornerRadius = new CornerRadius(Convert.ToDouble(CustomizationObj.CornerRadius));
                    
                    renderButtonRadioButton.Margin = new Thickness(100);
                    ListToRender.Add(renderButtonRadioButton);
                    break;
                case ChooseComponent.CheckButton:
                    var renderButtonCheckButton = new RadioButton();
                    renderButtonCheckButton.Name = CustomizationObj.Name;
                    renderButtonCheckButton.Content = CustomizationObj.Content;

                    if (CustomizationObj.BackGroundColor != null)
                        renderButtonCheckButton.Background = GetSolidColorBrushByHex(CustomizationObj.BackGroundColor);

                    if (CustomizationObj.ForeGroundColor != null)
                        renderButtonCheckButton.Foreground = GetSolidColorBrushByHex(CustomizationObj.ForeGroundColor);

                    if (CustomizationObj.FontSize != null)
                        renderButtonCheckButton.FontSize = Convert.ToDouble(CustomizationObj.FontSize);

                    if (CustomizationObj.Width != null)
                        renderButtonCheckButton.Width = Convert.ToDouble(CustomizationObj.Width);

                    if (CustomizationObj.Height != null)
                        renderButtonCheckButton.Height = Convert.ToDouble(CustomizationObj.Height);

                    if (CustomizationObj.CornerRadius != null)
                        renderButtonCheckButton.CornerRadius = new CornerRadius(Convert.ToDouble(CustomizationObj.CornerRadius));
                    
                    renderButtonCheckButton.Margin = new Thickness(100);
                    ListToRender.Add(renderButtonCheckButton);
                    break;
                case ChooseComponent.Slider:
                    var renderSlider = new Slider();
                    renderSlider.Name = CustomizationObj.Name;
                    renderSlider.Header = CustomizationObj.Content;

                    if (CustomizationObj.BackGroundColor != null)
                        renderSlider.Background = GetSolidColorBrushByHex(CustomizationObj.BackGroundColor);

                    if (CustomizationObj.ForeGroundColor != null)
                        renderSlider.Foreground = GetSolidColorBrushByHex(CustomizationObj.ForeGroundColor);

                    if (CustomizationObj.FontSize != null)
                        renderSlider.FontSize = Convert.ToDouble(CustomizationObj.FontSize);

                    if (CustomizationObj.Width != null)
                        renderSlider.Width = Convert.ToDouble(CustomizationObj.Width);

                    if (CustomizationObj.Height != null)
                        renderSlider.Height = Convert.ToDouble(CustomizationObj.Height);

                    if (CustomizationObj.CornerRadius != null)
                        renderSlider.CornerRadius = new CornerRadius(Convert.ToDouble(CustomizationObj.CornerRadius));

                    renderSlider.Minimum = Convert.ToInt32(CustomizationObj.MinValue);
                    renderSlider.Maximum = Convert.ToInt32(CustomizationObj.MaxValue);                    
                    renderSlider.Margin = new Thickness(100);
                    
                    ListToRender.Add(renderSlider);
                    break;
                case ChooseComponent.ToogleButton:
                    var renderToggleButton = new ToggleSwitch();
                    renderToggleButton.Name = CustomizationObj.Name;
                    renderToggleButton.Header = CustomizationObj.Content;

                    if (CustomizationObj.BackGroundColor != null)
                        renderToggleButton.Background = GetSolidColorBrushByHex(CustomizationObj.BackGroundColor);

                    if (CustomizationObj.ForeGroundColor != null)
                        renderToggleButton.Foreground = GetSolidColorBrushByHex(CustomizationObj.ForeGroundColor);

                    if (CustomizationObj.CornerRadius != null)
                        renderToggleButton.CornerRadius = new CornerRadius(Convert.ToDouble(CustomizationObj.CornerRadius));

                    
                    renderToggleButton.Margin = new Thickness(100);
                    ListToRender.Add(renderToggleButton);
                    break;
                case ChooseComponent.Dialog:
                    var showDialogButton = new Button();
                    showDialogButton.Content = CustomizationObj.Name;
                    showDialogButton.Click += new RoutedEventHandler(showDialog);
                    
                    showDialogButton.Margin = new Thickness(100);
                    ListToRender.Add(showDialogButton);
                    break;
            }
        }

        private async void showDialog(object sender, RoutedEventArgs e)
        {
            ContentDialog contentDialog = new ContentDialog()
            {
                Title = Name,
                Content = Content,
                PrimaryButtonText = "Teste",
                SecondaryButtonText = "Teste",
                CloseButtonText = "Teste"
            };
            await contentDialog.ShowAsync();
        }

        private SolidColorBrush GetSolidColorBrushByHex(string hex)
        {
            hex = hex.Replace("#", string.Empty);

            var r = (byte)System.Convert.ToUInt32(hex.Substring(0, 2), 16);
            var g = (byte)System.Convert.ToUInt32(hex.Substring(2, 2), 16);
            var b = (byte)System.Convert.ToUInt32(hex.Substring(4, 2), 16);
            SolidColorBrush renderBrush = new SolidColorBrush(Color.FromArgb(255, r, g, b));
            return renderBrush;
        }

        private string GetNameColorByHex(string hex)
        {
            switch (hex)
            {
                case "#000000":
                    return "Black";
                    break;
                case "#ff007f":
                    return "Rose";
                    break;
                case "#ffa500":
                    return "Orange";
                    break;
                case "#ffffe0":
                    return "LightYellow";
                    break;
                case "#00ff00":
                    return "Green";
                    break;
                case "#32cd32":
                    return "Lime";
                    break;
                case "#008080":
                    return "Teal";
                    break;
                case "#00ffff":
                    return "Aqua";
                    break;
                case "#87ceeb":
                    return "SkyBlue";
                    break;
                case "#0000ff":
                    return "Blue";
                    break;
                case "#add8e6":
                    return "LightBlue";
                    break;
                case "#551a8b":
                    return "DarkPurple";
                    break;
                case "#a020f0":
                    return "Purple";
                    break;
                case "#e6e6fa":
                    return "Lavender";
                    break;
                case "#ffc0cb":
                    return "Pink";
                    break;
                default:
                    return null;
                    break;
            }
        }

        private void CopyToClipboard(string content)
        {
            dataPackage.SetText(content);
            Clipboard.SetContent(dataPackage);
        }
    }
}