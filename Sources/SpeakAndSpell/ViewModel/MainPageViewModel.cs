/* 
 * Application de démonstration Silverlight 4
 * Model-View-ViewModel par la pratique
 * © Janvier 2010 Olivier Dahan, MVP C# 2009, MVP Client App Dev 2010
 * Contact : odahan@e-naxos.com
 * Blog : www.e-naxos.com/blog
 * 
 * Le code qui suit est fourni à titre d'exemple pour accompagner l'article
 * "M-V-VM avec Silverlight en pratique"
 * 
 * Reproduction, diffusion ou exploittion interdites sans l'autorisation
 * de l'auteur.
 */
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
using System.Windows.Browser;
using Utils;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;

namespace mvvm_2.ViewModels
{
    public class MainPageViewModel : BindableObject
    {
        #region private fields
        private UIElement currentPage;

        // commanding
        private RelayCommand showAboutBoxImpl;
        private RelayCommand linkToODWebImpl;
        private RelayCommand showSlideShowImpl;
		private RelayCommand editSlideShowImpl;

        private List<RelayCommand> commands = new List<RelayCommand>();
        #endregion

        #region Ctor
        public MainPageViewModel()
        {
            // init commands
            showAboutBoxImpl = new RelayCommand(() =>
                { CurrentPage = new Views.AboutScreen(); CheckCommandState(); },
                () => !(this.CurrentPage is Views.AboutScreen));
            commands.Add(showAboutBoxImpl);
            linkToODWebImpl = new RelayCommand(() => HtmlPage.Window.Navigate(new Uri("http://www.e-naxos.com/blog"), "_blank"));
            commands.Add(linkToODWebImpl);
            showSlideShowImpl = new RelayCommand(() =>
                { CurrentPage = new Views.SlideShow(); CheckCommandState(); },
                () => !(this.CurrentPage is Views.SlideShow));
            commands.Add(showSlideShowImpl);
			editSlideShowImpl = new RelayCommand(()=>
			  { CurrentPage = new Views.EditSlideShow(); CheckCommandState(); },
			 ()=>!(this.CurrentPage is Views.EditSlideShow));
			commands.Add(editSlideShowImpl);
            // init first displayed view (about box)
            if (showAboutBoxImpl.CanExecute(null)) showAboutBoxImpl.Execute(null);
        }
        #endregion

        #region public properties

        /// <summary>
        /// Current page (view) displayed in the central frame
        /// </summary>
        public UIElement CurrentPage
        {
            get { return currentPage; }
            private set
            {
                currentPage = value;
                RaisePropertyChanged("CurrentPage");
                RaisePropertyChanged("CurrentPageName");
            }
        }

        /// <summary>
        /// Current page name
        /// </summary>
        public string CurrentPageName
        {
            get
            {
                if (currentPage == null) return "(no page loaded)";
                var vi = (IViewInfo)((UserControl)(currentPage)).DataContext;
                if (vi == null) return "(no name!)";
                return vi.Name;
            }
        }
        #endregion

        #region Commanding

        /// <summary>
        /// Show about box
        /// </summary>
        public ICommand ShowAboutBox
        {
            get { return showAboutBoxImpl; }
        }

        /// <summary>
        /// Link to Olivier's blog
        /// </summary>
        public ICommand LinkToODWeb
        {
            get { return linkToODWebImpl; }
        }

        /// <summary>
        /// Display slide show view
        /// </summary>
        public ICommand ShowSlideShow
        {
            get { return showSlideShowImpl; }
        }
		
		/// <summary>
        /// Display edit slide show view
        /// </summary>
        public ICommand EditSlideShow
        {
            get { return editSlideShowImpl; }
        }

        // About box command display name
        public string ShowAboutBoxCommandName
        { get { return "About..."; } }

        // Link to OD's web command display name
        public string LinkToODWebCommandName
        { get { return "Go to Dot.Blog !"; } }

        // Slide show command display name
        public string ShowSlideShowCommandName
        { get { return "Slide Show"; } }
		
		// Edit slide show command display name
        public string EditSlideShowCommandName
        { get { return "Edit Slide"; } }
        #endregion

        #region Commanding - "Enabled" state check
        private void CheckCommandState()
        {
            foreach (var rc in commands)
            {
               if (rc!=null) rc.RaiseCanExecuteChanged(true);
            }
        }
        #endregion

        #region Commanding - class sample

        /*
        /// <summary>
        /// Show About box command
        /// This is showing how to implement the command without the help of RelayCommand class
        /// </summary>
        public class ShowAboutBoxImpl : ICommand
        {
            private MainPageViewModel main;

            private ShowAboutBoxImpl() { }
            public ShowAboutBoxImpl(MainPageViewModel mainPage)
            { main = mainPage; }

            public bool CanExecute(object parameter)
            {
                return !(main.CurrentPage is Views.AboutScreen);
            }

            public event EventHandler CanExecuteChanged;

            public void Execute(object parameter)
            {
                main.CurrentPage = new Views.AboutScreen();
            }
        }

        */
        #endregion
    }
}
