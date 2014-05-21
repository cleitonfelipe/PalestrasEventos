using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ReconhecimentoVoz.Resources;
using Windows.Phone.Speech.Recognition;
using Windows.Phone.Speech.VoiceCommands;

namespace ReconhecimentoVoz
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            InicializaVCD();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private async System.Threading.Tasks.Task InicializaVCD()
        {
            await VoiceCommandService.InstallCommandSetsFromFileAsync(new Uri("ms-appx:///VoiceCommandDefinition1.xml"));
        }

        private async void btnRecVoz_Click(object sender, RoutedEventArgs e)
        {
            SpeechRecognizerUI sr = new SpeechRecognizerUI();
            sr.Settings.ListenText = "Hello Windows Phone 8";
            sr.Settings.ExampleText = "Diga o texto por favor";
            sr.Settings.ReadoutEnabled = true;
            sr.Settings.ShowConfirmation = true;
            SpeechRecognitionUIResult result = await sr.RecognizeWithUIAsync();
            if (result.ResultStatus == SpeechRecognitionUIStatus.Succeeded)
            {
                txtStatus.Text = result.RecognitionResult.Text;
                txtResultado.Text = result.RecognitionResult.TextConfidence.ToString();
            }
        }

        private async void btnDia_Click(object sender, RoutedEventArgs e)
        {
            SpeechRecognizerUI sr = new SpeechRecognizerUI();
            sr.Settings.ListenText = "Que dia é hoje?";
            sr.Settings.ExampleText = "Sunday";
            sr.Settings.ReadoutEnabled = true;
            sr.Settings.ShowConfirmation = true;
            //sr.Recognizer.Grammars.AddGrammarFromList("answer", new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" });
            // veja um exemplo com textos em portugues
            sr.Recognizer.Grammars.AddGrammarFromList("answer", new string[] { "Domingo", "Segunda", "Sabado" });
            SpeechRecognitionUIResult result = await sr.RecognizeWithUIAsync();
            if (result.ResultStatus == SpeechRecognitionUIStatus.Succeeded)
            {
                txtDia.Text = result.RecognitionResult.Text;
                txtResultadoDia.Text = result.RecognitionResult.TextConfidence.ToString();
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}