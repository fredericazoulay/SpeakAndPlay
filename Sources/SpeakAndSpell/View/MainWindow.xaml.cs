using SpeakAndSpell.Helpers.Enums;
using System;
using System.Collections.Generic;
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
using static SpeakAndSpell.Helpers.DesignPatterns.Singletons;

namespace SpeakAndSpell.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>_selectedRight</summary>
        //private IUserWindow _selectedWindow;

        SpeakAndMath speakAndMath = SingletonSpeakAndMath.Instance;
        SpeakAndMusic speakAndMusic = SingletonSpeakAndMusic.Instance;
        SpeakAndRead speakAndRead = SingletonSpeakAndRead.Instance;
        SpeakAndSpell speakAndSpell = SingletonSpeakAndSpell.Instance;
        SpeakAndTranslate speakAndTranslate = SingletonSpeakAndTranslate.Instance;
        //SpeakAndMath speakAndMath = null;
        AboutScreen aboutScreen = new AboutScreen();

        public MainWindow()
        {
            InitializeComponent();

            //Default Application
            //speakAndMath.Show();
            //speakAndMath.Activate();

            //speakAndMath = new SpeakAndMath();
            //speakAndMusic = new SpeakAndMusic();
            //speakAndRead = new SpeakAndRead();
            //speakAndSpell = new SpeakAndSpell();
            //speakAndTranslate = new SpeakAndTranslate();
        }

        //public Loa

        //public IUserWindow GetSelectedWindow(int WindowSelectedIndex = -1)
        //{
        //    int switchValue = WindowSelectedIndex;
        //
        //    switch (switchValue)
        //    {
        //        case (int)Enums.eWindows.Accueil:
        //            _selectedWindow = UserWindow.Instance.Accueil;
        //            break;
        //        case (int)Enums.eWindows.Rapport:
        //            _selectedWindow = UserWindow.Instance.Rapport;
        //            break;
        //        case (int)Enums.eWindows.Config:
        //            _selectedWindow = UserWindow.Instance.Config;
        //            break;
        //    default: 
        //            //UserMessage.Error(Properties.Resources.ErrorMsg);
        //            break;
        //}
        //
        //    return _selectedWindow;
        //}

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender.ToString().Contains("Spell"))
            {
                speakAndSpell.Show();
                speakAndSpell.Activate();
            }
            if (sender.ToString().Contains("Math"))
            { 
                speakAndMath.Show();
                speakAndMath.Activate();
            }
            if (sender.ToString().Contains("Music"))
            { 
                speakAndMusic.Show();
                speakAndMusic.Activate();
            }
            if (sender.ToString().Contains("Read"))
            {
                speakAndRead.Show();
                speakAndRead.Activate();
            }
            if (sender.ToString().Contains("Translate"))
            {
                speakAndTranslate.Show();
                speakAndTranslate.Activate();
            }
            if (sender.ToString().Contains("About"))
            {
                aboutScreen.Show();
                aboutScreen.Activate();
            }
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            //speakAndSpell.ShowActivated = false;
            if(speakAndSpell != null)
                speakAndSpell.Close();
            if (speakAndMath != null)
                speakAndMath.Close();
            if (speakAndMusic != null)
                speakAndMusic.Close();
            if (speakAndRead != null)
                speakAndRead.Close();
            if (speakAndTranslate != null)
                speakAndTranslate.Close();
            if (aboutScreen != null)
                aboutScreen.Close();

            this.Close();
        }

        private void OnLoad(object sender, RoutedEventArgs e)
        {
            //speakAndMath.Show();
            //speakAndMath.Activate();
        }
    }
}
