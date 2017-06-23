using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace SpeakAndSpell.View
{
	public partial class AboutScreen : Window //UserControl
    {
		public AboutScreen()
		{
			// Required to initialize variables
			InitializeComponent();
            this.PreviewKeyDown += new KeyEventHandler(CloseOnEscape);
        }

        private void CloseOnEscape(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Escape)
                || (e.Key == Key.Space)
                || (e.Key == Key.Enter)
                )
            { 
                Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}