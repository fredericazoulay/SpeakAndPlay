using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using SpeakAndSpell.Helpers;
using System.Threading;
using System.Windows.Threading;

namespace SpeakAndSpell.ViewModel
{
    public class AboutScreenViewModel : BindableObject, IViewInfo
    {
        public AboutScreenViewModel()
        {
            //CloseAboutCommand = new RelayCommand(CloseWindowAbout);

//            clockTimer.Tick += clockTimer_Tick;
//            clockTimer.Start();
        }

        void clockTimer_Tick(object sender, EventArgs e)
        {
            RaisePropertyChanged("CurrentTime");
        }

        public string Copyrights
        {
            get
            {
                return "© " +
                    DateTime.Now.ToString("MMM") + " " +
                    DateTime.Now.Year + " Frederic AZOULAY";
            }
        }

        public string CurrentTime
        {
            get { return DateTime.Now.ToString("HH:mm:ss"); }
        }

        private DispatcherTimer clockTimer = new DispatcherTimer() { Interval = new TimeSpan(0, 0, 1) };


        public string Name
        {
            get
            {
                return "About box";
            }
        }



        //public ICommand CloseAboutCommand { get; private set; }
        //private void CloseWindowAbout(object parameter)
        //{
        //    //AboutScreen aboutDlg = new AboutScreen();
        //    //aboutDlg.ShowDialog();
        //    //this.Close;
        //}

    }
}
