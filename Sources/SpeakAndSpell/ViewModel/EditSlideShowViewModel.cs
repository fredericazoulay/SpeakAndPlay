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
    public class EditSlideShowViewModel : BindableObject, IViewInfo
    {
        #region IViewInfo
        public string Name
        {
            get { return "Edit Slide Show"; }
        }
        #endregion

        #region Ctor
        public EditSlideShowViewModel()
        {
            data = SlideData.Slide;
         }
        #endregion

        #region private fields
        // list of shots
        private ObservableCollection<Shot> data;

        #endregion

        #region public properties
		/// <summary>
		/// Returns the shot collection
		/// </summary>
		/// <returns></returns>
       public ObservableCollection<Shot> Data
		{ get { return data; } }

        /// <summary>
        /// Number of shots in the current slide show
        /// </summary>
        public int ShotCount
        { get { return data.Count; } }

        #endregion

    }
}
