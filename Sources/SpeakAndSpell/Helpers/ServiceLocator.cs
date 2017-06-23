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
using SpeakAndSpell.ViewModel; // ViewModel access

namespace SpeakAndSpell.Helpers
{
    /// <summary>
    /// Service Locator is a minimal implementation of the design pattern of same name.
    /// It is one way to solve the Inversion Of Control pattern. The other used way is
    /// to implement the Dependencies Injection pattern.
    /// The Service locator is used here to get access to ViewModels. The pattern can also
    /// be used to give access to all kind of services needed by the application. Implementation
    /// can be extended to manage a cache, to dynamicaly load assemblies, etc.
    /// 
    /// ServiceLocator class must be instancianted in App.xaml file see "How-to" comment below for
    /// more information.
    /// </summary>
    public class ServiceLocator
    {
        #region How-to
        /*
         * In App.xaml:
         * <Application.Resources>
         *     <vm:ServiceLocator xmlns:vm="clr-namespace:YOURAPPNAMESPACE.Utils"
         *                                  x:Key="ServiceLocator" />
         * </Application.Resources>
         * 
         * In the View:
         * DataContext="{Binding Source={StaticResource ServiceLocator}, Path=VIEWMODELNAME}"
         * 
         */
        #endregion

        #region private field (ViewModel instances)

        // Slide Show View Model
//        private SlideShowViewModel slideShowVM;
        private AboutScreenViewModel aboutScreenVM;
//        private MainPageViewModel mainPageVM;
//		private EditSlideShowViewModel editSlideShowVM;

        #endregion

        #region public access point to viewmodels

        /// <summary>
        /// Gets the SlideShow ViewModel property.
        /// </summary>
//        public SlideShowViewModel SlideShowViewModel
//        {
//            get
//            {
//                if (slideShowVM == null) slideShowVM = new SlideShowViewModel();
//                return slideShowVM;
//            }
//        }

        /// <summary>
        /// Gets the AboutScreen ViewModel property.
        /// </summary>
        public AboutScreenViewModel AboutScreenViewModel
        {
            get
            {
                if (aboutScreenVM == null) aboutScreenVM = new AboutScreenViewModel();
                return aboutScreenVM;
            }
        }

        /// <summary>
        /// Gets the MainPage ViewModel property.
        /// </summary>
//        public MainPageViewModel MainPageViewModel
//        {
//            get
//            {
//                if (mainPageVM == null) mainPageVM = new MainPageViewModel();
//                return mainPageVM;
//            }
//        }

		/// <summary>
        /// Gets the EditSlideShow  ViewModel property.
        /// </summary>
//        public EditSlideShowViewModel EditSlideShowViewModel
//        {
//            get
//            {
//                if (editSlideShowVM == null) editSlideShowVM = new EditSlideShowViewModel();
//                return editSlideShowVM;
//            }
//        }

        #endregion

    }
}
