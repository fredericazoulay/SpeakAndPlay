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
//using SpeakAndSpell.ViewModel;
//using SpeakAndSpell.ViewModel.Interface;
//using SpeakAndSpell.ViewModel.Design;

namespace SpeakAndSpell.View
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class SpeakAndSpell : Window
    {
        public SpeakAndSpell()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(CloseOnEscape);
        }

        private void CloseOnEscape(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                Close();
            if (e.Key == Key.F1)
            {
                AboutScreen aboutScreen = new AboutScreen();
                aboutScreen.Show();
            }
        }
    }
}
