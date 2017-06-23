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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SpeakAndSpell.View
{
    /// <summary>
    /// Logique d'interaction pour UserKeyBoardSpeakAndMath_Fr.xaml
    /// </summary>
    public partial class UserKeyBoardSpeakAndMath_Fr : UserControl
    {
        public UserKeyBoardSpeakAndMath_Fr()
        {
            InitializeComponent();
        }

        //private void buttonEnter_Click(object sender, RoutedEventArgs e)
        //{
        //    Helpers.Speaker speaker = new Helpers.Speaker();
        //    speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, "Hello Kyle and Jayce. How are you ? I'm fine. E.T. telephone maison.");
        //    speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, "Je vais bien. Merci.");
        //}

        public void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hello");
        }

        public void button_Display()
        {
            MessageBox.Show("Hello");
        }
    }
}
