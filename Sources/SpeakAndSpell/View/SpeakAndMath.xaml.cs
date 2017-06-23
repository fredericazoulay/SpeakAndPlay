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

namespace SpeakAndSpell.View
{
    /// <summary>
    /// Logique d'interaction pour SpeakAndMath.xaml
    /// </summary>
    public partial class SpeakAndMath : Window
    {
        public SpeakAndMath()
        {
            InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(CloseOnEscape);
        }

        private void CloseOnEscape(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Close();
            }
            else if (e.Key == Key.F1)
            {
                AboutScreen aboutScreen = new AboutScreen();
                aboutScreen.Show();
            }
            //else if ((e.Key == Key.Delete) || (e.Key == Key.Back))
            //{
            //    txtLine9.Text = "";
            //}
            //else
            //{
            //    //txtLine9.Focus();
            //    button_Enter.Focus();
            //}
        }
    }
}
