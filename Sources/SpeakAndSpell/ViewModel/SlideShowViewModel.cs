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
using System.ComponentModel;
using Utils;
using System.Collections.ObjectModel;
using mvvm_2.Models;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;

namespace mvvm_2.ViewModels
{
    /// <summary>
    /// This class is the ViewModel for the SlideShow View
    /// </summary>
    public class SlideShowViewModel : BindableObject, IViewInfo
    {
        #region IViewInfo
        public string Name
        {
            get { return "Slide Show"; }
        }
        #endregion

        #region Ctor
        public SlideShowViewModel()
        {
            data = SlideData.Slide;
            gotoNextShotCommand = new RelayCommand(
                () => { gotoNextShot(); CheckCommandState(); }, () => CurrentPos < ShotCount - 1);
            gotoPrevShotCommand = new RelayCommand(
                () => { gotoPrevShot(); CheckCommandState(); }, () => CurrentPos > 0);
            resetRatingCommand = new RelayCommand(() => { resetRating(); CheckCommandState(); });
            commands.Add(gotoNextShotCommand);
            commands.Add(gotoPrevShotCommand);
            commands.Add(resetRatingCommand);
        }
        #endregion

        #region private fields
        // list of shots
        private ObservableCollection<Shot> data;

        // current position
        private int currentPos = 0;

        // instance of command objets
        private RelayCommand gotoNextShotCommand;
        private RelayCommand gotoPrevShotCommand;
        private RelayCommand resetRatingCommand;
        private List<RelayCommand> commands = new List<RelayCommand>();

        #endregion

        #region public properties
        /// <summary>
        /// Current position in the slide show
        /// </summary>
        public int CurrentPos
        {
            get { return currentPos; }
            private set
            {
                if (value == currentPos) return;
                currentPos = value;
                RaisePropertyChanged("CurrentPos");
                RaisePropertyChanged("CurrentShot");
				RaisePropertyChanged("CurrentPosForUser");
            }
        }
		
		public int CurrentPosForUser
		{ get { return CurrentPos+1; } }

        /// <summary>
        /// Current shot
        /// </summary>
        public Shot CurrentShot
        { get { return currentPos>=0 && currentPos<ShotCount ? data[currentPos] : null; } }


        /// <summary>
        /// Number of shots in the current slide show
        /// </summary>
        public int ShotCount
        { get { return data.Count; } }

        #endregion

        #region public commands

        public ICommand GotoNextShot
        { get { return gotoNextShotCommand; } }

		public string GotoNextShotCommandName
		{ get { return "4"; } } // right arrow webdings
		
        public ICommand GotoPrevShot
        { get { return gotoPrevShotCommand; } }
		
		public string GotoPrevShotCommandName
		{ get { return "3"; } } // left arrow webdings

        public ICommand ResetRating
        { get { return resetRatingCommand; } }

		public string ResetRatingCommandName
        { get { return "r"; } } // cross webdings
		
		
        #endregion

        #region private methods / commanding

        /// <summary>
        /// Goto next shot
        /// </summary>
        /// <returns>false if end is reached (return to position 0)</returns>
        private void gotoNextShot()
        {
            if (currentPos < data.Count - 1) CurrentPos++;
        }

        /// <summary>
        /// Goto prev shot
        /// </summary>
        /// <returns>false 1st shot is the current one (send to end of list)</returns>
        private void gotoPrevShot()
        {
            if (currentPos > 0) CurrentPos--;
        }

        /// <summary>
        /// Resets all shot ranks
        /// </summary>
        private void resetRating()
        {
            CurrentShot.Rating = -1;
        }

        #endregion

        #region Commanding - "Enabled" state check
        private void CheckCommandState()
        {
            foreach (var rc in commands)
            {
                if (rc != null) rc.RaiseCanExecuteChanged(true);
            }
        }
        #endregion

    }
}
