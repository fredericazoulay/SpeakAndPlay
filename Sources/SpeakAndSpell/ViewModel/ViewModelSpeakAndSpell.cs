using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SpeakAndSpell.Helpers;
using System.Windows;
using SpeakAndSpell.Model;
using SpeakAndSpell.ViewModel.Interface;
using SpeakAndSpell.Model.Services;
using SpeakAndSpell.View;
using System.Threading;

namespace SpeakAndSpell.ViewModel
{
    class ViewModelSpeakAndSpell : ObservableObject, ISpeakAndSpellViewModel //BindableObject
    {

        /// <summary>
        /// ID unique du contact
        /// </summary>
        private int? _ID = null;
        public int? ID
        {
            get { return _ID; }
            set
            {
                _ID = value;
                OnPropertyChanged("ID");
            }
        }

        /// <summary>
        /// Mot en Français
        /// </summary>
        private string _word_Fr = null;
        public string Word_Fr
        {
            get { return _word_Fr; }
            set
            {
                _word_Fr = value;
                OnPropertyChanged("Word_Fr");
            }
        }

        /// <summary>
        /// Mot en Anglais
        /// </summary>
        private string _word_En = null;
        public string Word_En
        {
            get { return _word_En; }
            set
            {
                _word_En = value;
                OnPropertyChanged("Word_En");
            }
        }

        /// <summary>
        /// Reponse
        /// </summary>
        private string _word_Response = null;
        public string Word_Response
        {
            get { return _word_Response; }
            set
            {
                _word_Response = value;
                OnPropertyChanged("Word_Response");
            }
        }

        /// <summary>
        /// Reponse
        /// </summary>
        private string _word_Picture = null;
        public string Word_Picture
        {
            get { return _word_Picture; }
            set
            {
                _word_Picture = value;
                OnPropertyChanged("Word_Picture");
            }
        }

        // ******************************************************************************************************************

        /// <summary>
        /// Définition de la commande permettant de charger le contact
        /// </summary>
        public ICommand PressClickCommand { get; private set; }

        public ICommand AboutCommand { get; private set; }



        /// <summary>
        /// Constructeur
        /// </summary>
        public ViewModelSpeakAndSpell()
        {
            // on associe la commande ChargerContactCommand à la méthode ChargeContact
            PressClickCommand = new RelayCommand(ChargeWord);

            AboutCommand = new RelayCommand(DialogWindows);
        }

        private void DialogWindows(object parameter)
        {
            AboutScreen aboutDlg = new AboutScreen();
            aboutDlg.ShowDialog();
        }

        private void ChargeWord(object parameter)
        {
            //MessageBox.Show("Hello");
            //if (parameter == null) return;

            ServiceWord service = new ServiceWord();
            //Word word = service.Charger();
            Word word = service.ChargerOK();
            //
            if (word != null)
            {
                this.ID = word.ID;
                this.Word_Fr = word.Word_French;
                this.Word_En = word.Word_English;
                this.Word_Response = word.Word_Response;
                this.Word_Picture = word.Word_Picture;
            }

            Thread thread = new Thread(Speak);
            thread.Start();
        }

        private void Speak(object parameter)
        {
            Helpers.Speaker speaker = new Helpers.Speaker();
            speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, Word_En);
            speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, Word_Fr);
        }

    }
}
