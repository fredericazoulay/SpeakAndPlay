using SpeakAndSpell.Helpers;
using SpeakAndSpell.View;
using SpeakAndSpell.ViewModel.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using SpeakAndSpell.Helpers.Enums;
using SpeakAndSpell.Helpers.Settings;
using SpeakAndSpell.Model.Services;
using SpeakAndSpell.Model;
using System.Threading;
using System.Globalization;
using System.Windows;
using System.Windows.Threading;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace SpeakAndSpell.ViewModel
{


    public class ViewModelSpeakAndMath : INotifyPropertyChanged //ObservableObject //, ISpeakAndSpellViewModel
    {

        #region Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public ViewModelSpeakAndMath()
        {
            // on associe la commande ChargerContactCommand à la méthode ChargeContact
            OnCommand = new RelayCommand(SwitchOn);
            OffCommand = new RelayCommand(SwitchOff);
            RepeatCommand = new RelayCommand(Repeat);
            IncreaseLevelCommand = new RelayCommand(IncreaseLevel);
            DecreaseLevelCommand = new RelayCommand(DecreaseLevel);
            ChangeGameModeCommand = new RelayCommand(ChangeGameMode);
            ChangeOperationModeCommand = new RelayCommand(ChangeOperationMode);
            ChangeLanguageCommand = new RelayCommand(ChangeLanguage);
            EnterCommand = new RelayCommand(Enter);
            AboutCommand = new RelayCommand(About);
            PlayCommand = new RelayCommand(PlaySpell);
            ClearCommand = new RelayCommand(ClearAnswer);
            LessThanCommand = new RelayCommand(AnswerLessThan);
            GreaterThanCommand = new RelayCommand(AnswerGreaterThan);
            EqualCommand = new RelayCommand(AnswerEqual);
            PlusOrMinusCommand = new RelayCommand(AnswerPlusOrMinus);
            OpenParenthesisCommand = new RelayCommand(AnswerOpenParenthesis);
            CloseParenthesisCommand = new RelayCommand(AnswerCloseParenthesis);

            //WriteCommand = new RelayCommand<string>(e => WriteKeyBoard(e));
            //WriteCommand = new RelayCommand(<Action> ((s) => WriteKeyBoard(s)));
            //WriteCommand = new RelayCommand(() => WriteKeyBoard("12"));

            // OK
            WriteCommand = new RelayCommand(param => this.WriteKeyBoard(param));
            WriteCommand_Greater = new RelayCommand(param => this.WriteKeyBoard(">"));
            WriteCommand_Less = new RelayCommand(param => this.WriteKeyBoard("<"));
            WriteCommand_Equal = new RelayCommand(param => this.WriteKeyBoard("="));

            //WriteCommand_Repeate = new RelayCommand(param => this.WriteKeyBoard("Repeate"));
            //WriteCommand_7 = new RelayCommand(param => this.WriteKeyBoard("7"));
            //WriteCommand_8 = new RelayCommand(param => this.WriteKeyBoard("8"));
            //WriteCommand_9 = new RelayCommand(param => this.WriteKeyBoard("9"));
            //WriteCommand_Divide = new RelayCommand(param => this.WriteKeyBoard("/"));
            //WriteCommand_WordProblems = new RelayCommand(param => this.WriteKeyBoard("WordProblems"));
            //WriteCommand_On = new RelayCommand(param => this.WriteKeyBoard("On"));
            //
            //WriteCommand_Greater = new RelayCommand(param => this.WriteKeyBoard(">"));
            //WriteCommand_4 = new RelayCommand(param => this.WriteKeyBoard("4"));
            //WriteCommand_5 = new RelayCommand(param => this.WriteKeyBoard("5"));
            //WriteCommand_6 = new RelayCommand(param => this.WriteKeyBoard("6"));
            //WriteCommand_Times = new RelayCommand(param => this.WriteKeyBoard("*"));
            //WriteCommand_LessGreater = new RelayCommand(param => this.WriteKeyBoard("LessGreater"));
            //WriteCommand_Off = new RelayCommand(param => this.WriteKeyBoard("Off"));
            //
            //WriteCommand_Less = new RelayCommand(param => this.WriteKeyBoard("<"));
            //WriteCommand_1 = new RelayCommand(param => this.WriteKeyBoard("1"));
            //WriteCommand_2 = new RelayCommand(param => this.WriteKeyBoard("2"));
            //WriteCommand_3 = new RelayCommand(param => this.WriteKeyBoard("3"));
            //WriteCommand_Minus = new RelayCommand(param => this.WriteKeyBoard("-"));
            //WriteCommand_WriteIt = new RelayCommand(param => this.WriteKeyBoard("WriteIt"));
            //WriteCommand_Go = new RelayCommand(param => this.WriteKeyBoard("Go"));
            //
            //WriteCommand_Clear = new RelayCommand(param => this.WriteKeyBoard("Clear"));
            //WriteCommand_0 = new RelayCommand(param => this.WriteKeyBoard("0"));
            //WriteCommand_Point = new RelayCommand(param => this.WriteKeyBoard("."));
            //WriteCommand_MixIt = new RelayCommand(param => this.WriteKeyBoard("MixIt"));
            //WriteCommand_Plus = new RelayCommand(param => this.WriteKeyBoard("+"));
            //WriteCommand_NumberStumper = new RelayCommand(param => this.WriteKeyBoard("NumberStumper"));
            //WriteCommand_Enter = new RelayCommand(param => this.WriteKeyBoard("Enter"));

            //ModeCommand_WordProblems = new RelayCommand(param => this.ChangeModeKeyBoard("WordProblems"));
            //ModeCommand_LessGreater = new RelayCommand(param => this.ChangeModeKeyBoard("LessGreater"));
            //ModeCommand_WriteIt = new RelayCommand(param => this.ChangeModeKeyBoard("WriteIt"));
            //ModeCommand_Go = new RelayCommand(param => this.ChangeModeKeyBoard("Go"));
            //ModeCommand_MixIt = new RelayCommand(param => this.ChangeModeKeyBoard("MixIt"));
            //ModeCommand_NumberStumper = new RelayCommand(param => this.ChangeModeKeyBoard("NumberStumper"));
        }

        #endregion


        #region Properties

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        /// <summary>
        /// Mot en Français
        /// </summary>
        private Number _displayNumber = null;
        public Number DisplayNumber
        {
            get { return _displayNumber; }
            set
            {
                _displayNumber = value;
                //OnPropertyChanged("DisplayNumber");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line1
        /// </summary>
        private string _line1 = null;
        public string Line1
        {
            get { return _line1; }
            set
            {
                _line1 = value;
                //OnPropertyChanged("Line1");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line2
        /// </summary>
        private string _line2 = null;
        public string Line2
        {
            get { return _line2; }
            set
            {
                _line2 = value;
                //OnPropertyChanged("Line2");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line3
        /// </summary>
        private string _line3 = null;
        public string Line3
        {
            get { return _line3; }
            set
            {
                _line3 = value;
                //OnPropertyChanged("Line3");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line4
        /// </summary>
        private string _line4 = null;
        public string Line4
        {
            get { return _line4; }
            set
            {
                _line4 = value;
                //OnPropertyChanged("Line4");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line5
        /// </summary>
        private string _line5 = null;
        public string Line5
        {
            get { return _line5; }
            set
            {
                _line5 = value;
                //OnPropertyChanged("Line5");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line6
        /// </summary>
        private string _line6 = null;
        public string Line6
        {
            get { return _line6; }
            set
            {
                _line6 = value;
               // OnPropertyChanged("Line6");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line7
        /// </summary>
        private string _line7 = null;
        public string Line7
        {
            get { return _line7; }
            set
            {
                _line7 = value;
                //OnPropertyChanged("Line7");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line8
        /// </summary>
        private string _line8 = null;
        public string Line8
        {
            get { return _line8; }
            set
            {
                _line8 = value;
                //OnPropertyChanged("Line8");
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Line9
        /// </summary>
        private string _line9 = null;
        public string Line9
        {
            get { return _line9; }
            set
            {
                _line9 = value;
                //OnPropertyChanged("Line9");
                NotifyPropertyChanged();
            }
        }
        #endregion

        #region Commands

        /// <summary>
        /// Définition de la commande permettant de charger le contact
        /// </summary>
        // public ICommand PressClickCommand { get; private set; }

        public ICommand AboutCommand { get; private set; }
        public ICommand IncreaseLevelCommand { get; private set; }
        public ICommand DecreaseLevelCommand { get; private set; }
        public ICommand OnCommand { get; private set; }
        public ICommand OffCommand { get; private set; }
        public ICommand RepeatCommand { get; private set; }
        public ICommand ChangeGameModeCommand { get; private set; }
        public ICommand ChangeOperationModeCommand { get; private set; }
        public ICommand ChangeLanguageCommand { get; private set; }
        public ICommand EnterCommand { get; private set; }
        public ICommand PlayCommand { get; private set; }
        public ICommand ClearCommand { get; private set; }

        public ICommand LessThanCommand { get; private set; }
        public ICommand GreaterThanCommand { get; private set; }
        public ICommand EqualCommand { get; private set; }
        public ICommand PlusOrMinusCommand { get; private set; }
        public ICommand OpenParenthesisCommand { get; private set; }
        public ICommand CloseParenthesisCommand { get; private set; }

        public ICommand WriteCommand { get; private set; }
        public ICommand WriteCommand_Greater { get; private set; }
        public ICommand WriteCommand_Less { get; private set; }
        public ICommand WriteCommand_Equal { get; private set; }

        //public ICommand WriteCommand_Repeate { get; private set; }
        //public ICommand WriteCommand_7 { get; private set; }
        //public ICommand WriteCommand_8 { get; private set; }
        //public ICommand WriteCommand_9 { get; private set; }
        //public ICommand WriteCommand_Divide { get; private set; }
        //public ICommand WriteCommand_WordProblems { get; private set; }
        //public ICommand WriteCommand_On { get; private set; }
        //
        //public ICommand WriteCommand_Greater { get; private set; }
        //public ICommand WriteCommand_4 { get; private set; }
        //public ICommand WriteCommand_5 { get; private set; }
        //public ICommand WriteCommand_6 { get; private set; }
        //public ICommand WriteCommand_Times { get; private set; }
        //public ICommand WriteCommand_LessGreater { get; private set; }
        //public ICommand WriteCommand_Off { get; private set; }
        //
        //public ICommand WriteCommand_Less { get; private set; }
        //public ICommand WriteCommand_1 { get; private set; }
        //public ICommand WriteCommand_2 { get; private set; }
        //public ICommand WriteCommand_3 { get; private set; }
        //public ICommand WriteCommand_Minus { get; private set; }
        //public ICommand WriteCommand_WriteIt { get; private set; }
        //public ICommand WriteCommand_Go { get; private set; }
        //
        //public ICommand WriteCommand_Clear { get; private set; }
        //public ICommand WriteCommand_0 { get; private set; }
        //public ICommand WriteCommand_Point { get; private set; }
        //public ICommand WriteCommand_MixIt { get; private set; }
        //public ICommand WriteCommand_Plus { get; private set; }
        //public ICommand WriteCommand_NumberStumper { get; private set; }
        //public ICommand WriteCommand_Enter { get; private set; }


        //public ICommand ModeCommand_WordProblems { get; private set; }
        //public ICommand ModeCommand_LessGreater { get; private set; }
        //public ICommand ModeCommand_WriteIt { get; private set; }
        //public ICommand ModeCommand_Go { get; private set; }
        //public ICommand ModeCommand_MixIt { get; private set; }
        //public ICommand ModeCommand_NumberStumper { get; private set; }
        #endregion

        #region Methods with parameter

        /// <summary>
        /// About
        /// </summary>
        /// <param name="parameter"></param>
        private void About(object parameter)
        {
            AboutScreen aboutDlg = new AboutScreen();
            aboutDlg.ShowDialog();
        }

        /// <summary>
        /// IncreaseLevel
        /// </summary>
        /// <param name="parameter"></param>
        private void IncreaseLevel(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            ClearScreen(true, true, true);
            ResetCounters();

            if (Settings.counterLevel < SettingsApp.Default.paramMaxLevel)
                Settings.counterLevel++;

            //Line1 = "Level : " + Settings.counterLevel.ToString();
            DisplayModeAndLevel();
        }

        /// <summary>
        /// DecreaseLevel
        /// </summary>
        /// <param name="parameter"></param>
        private void DecreaseLevel(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            ClearScreen(true, true, true);
            ResetCounters();

            if (Settings.counterLevel > SettingsApp.Default.paramMinLevel)
                Settings.counterLevel--;

            //Line1 = "Level : " + Settings.counterLevel.ToString();
            DisplayModeAndLevel();
        }

        /// <summary>
        /// ChangeOperationMode
        /// </summary>
        /// <param name="parameter"></param>
        private void ChangeOperationMode(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            ClearScreen();
            //ClearScreen(true, true, true);
            ResetCounters();

            if (Settings.paramMathOperation + 1 < Enums.MathOperation.Division)
                Settings.paramMathOperation++;
            else
                Settings.paramMathOperation = Enums.MathOperation.Random;

            //Line1 = "Operation : " + Settings.paramMathOperation.ToString();
            DisplayModeAndLevel();
        }

        /// <summary>
        /// ChangeGameMode
        /// </summary>
        /// <param name="parameter"></param>
        private void ChangeGameMode(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            ClearScreen(true, true, true);
            ResetCounters();

            if (Settings.paramMathmode < Enums.MathGameMode.NumberStumper)
                Settings.paramMathmode++;
            else
                Settings.paramMathmode = Enums.MathGameMode.WriteIt;

            //Line1 = "Mode : " + Settings.paramMathmode.ToString();
            DisplayModeAndLevel();

            SetChangeGameMode(Settings.paramMathmode);
        }

        /// <summary>
        /// SetChangeGameMode
        /// </summary>
        /// <param name="gameMode"></param>
        private void SetChangeGameMode(Enums.MathGameMode gameMode, bool startGame = true)
        {
            Settings.paramMathmode = Enums.MathGameMode.WordProblems;
            Settings.paramMathmode = gameMode;
            Settings.Question = "";
            Settings.Answer = "";
            ResetCounters();
            DisplayModeAndLevel();

            if(startGame)
            {
                PlayAndCompute(Enums.PlayOrCompute.Play);
            }
    }


    /// <summary>
    /// ChangeLanguage
    /// </summary>
    /// <param name="parameter"></param>
    private void ChangeLanguage(object parameter)
    {
        if (Settings.isMathSwitchOff == true)
            return;

        ClearScreen();

        if (Settings.paramLangage < Enums.Language.German)
            Settings.paramLangage++;
        else if (Settings.paramLangage == Enums.Language.German)    //Math.Max(Enums.Language)
            Settings.paramLangage = Enums.Language.French;          //Math.Min(Enums.Language)

        //Line1 = "Language : " + Settings.paramLangage.ToString();
        DisplayModeAndLevel();
    }


    /// <summary>
    /// SwitchOn
    /// </summary>
    /// <param name="parameter"></param>
    private void SwitchOn(object parameter)
        {
            // Math SwitchOn
            if (Settings.isMathSwitchOff == false)
                return;

            // INIT
            //Settings.isMathSwitchOff = false;
            Settings.isNewGame = true;
            Settings.isCorrectAnswer = true;
            Settings.counterLevel = 1;
            Settings.counterWrongTry = 0;
            Settings.counterGoodAnswers = 0;
            Settings.counterWrongAnswers = 0;
            //ResetCounter();

            Settings.paramMathmode = Enums.MathGameMode.WordProblems;
            Settings.paramLangage = Enums.Language.French;
            Settings.paramMathOperation = Enums.MathOperation.Random;

            Line1 = "";                                         // 
            Line2 = "Hello";                                    // Anglais
            Line3 = "Bonjour";                                  // Français
            Line4 = "Hola";                                     // Espagnol
            Line5 = "Buongiorno";                               // Italien
            Line6 = "Olá";                                      // Portugais
            Line7 = "Hallo";                                    // Allemand
            Line8 = "привет | صباح الخير | もしもし | 你好";    // Russe / Arabe / Japonais / Chinois
            Line9 = "";                                         // 

            Settings.Question = Line2;

            Thread thread = new Thread(WaitAndSpeakOn);
            thread.Start();
        }

        /// <summary>
        /// SwitchOff
        /// </summary>
        /// <param name="parameter"></param>
        private void SwitchOff(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            // Math MathSwitchOff
            //Settings.isMathSwitchOff = true;

            Line1 = "";
            Line2 = "Good bye";
            Line3 = "Au revoir";
            Line4 = "Adiós";
            Line5 = "Arriverdeci";
            Line6 = "Adeus";
            Line7 = "Auf Wiedersehen";
            Line8 = "до свидания | إلى اللقاء | さようなら | 再见";
            Line9 = "";

            Settings.Question = Line2;

            Thread thread = new Thread(WaitAndSpeakOff);
            thread.Start();
        }


        /// <summary>
        /// ClearAnswer
        /// </summary>
        /// <param name="parameter"></param>
        private void ClearAnswer(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            Line9 = "";
        }

        /// <summary>
        /// AnswerLessThan
        /// </summary>
        /// <param name="parameter"></param>
        private void AnswerLessThan(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            if (Settings.paramMathmode == Enums.MathGameMode.LessGreaterEqual)
                Line9 = "<";
            else
            {
                BeepError();
            }
        }

        /// <summary>
        /// AnswerGreaterThan
        /// </summary>
        /// <param name="parameter"></param>
        private void AnswerGreaterThan(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            if (Settings.paramMathmode == Enums.MathGameMode.LessGreaterEqual)
                Line9 = ">";
            else
            {
                BeepError();
            }
        }

        /// <summary>
        /// AnswerEqual
        /// </summary>
        /// <param name="parameter"></param>
        private void AnswerEqual(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            if (Settings.paramMathmode == Enums.MathGameMode.LessGreaterEqual)
                Line9 = "=";
            else
            {
                BeepError();
            }
        }

        /// <summary>
        /// AnswerPlusOrMinus
        /// </summary>
        /// <param name="parameter"></param>
        private void AnswerPlusOrMinus(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            switch (Settings.paramMathmode)
            {
                case Enums.MathGameMode.WriteIt:
                case Enums.MathGameMode.SpellIt:
                case Enums.MathGameMode.Equation:
                case Enums.MathGameMode.WordProblems:

                    if (!Line9.Contains("-"))
                        Line9 = "-" + Line9;
                    else
                        Line9 = Line9.Replace("-", "");

                    break;

                default:
                    BeepError();
                    break;
            }
        }

        /// <summary>
        /// AnswerOpenParenthesis
        /// </summary>
        /// <param name="parameter"></param>
        private void AnswerOpenParenthesis(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            switch (Settings.paramMathmode)
            {
                case Enums.MathGameMode.Equation:
                    Line9 += "(";
                    break;

                default:
                    BeepError();
                    break;
            }
        }

        /// <summary>
        /// AnswerCloseParenthesis
        /// </summary>
        /// <param name="parameter"></param>
        private void AnswerCloseParenthesis(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            switch (Settings.paramMathmode)
            {
                case Enums.MathGameMode.Equation:
                    Line9 += ")";
                    break;

                default:
                    BeepError();
                    break;
            }
        }

        /// <summary>
        /// WriteKeyBoard : VERY IMPORTANT : DISPATCH COMMANDS
        /// </summary>
        /// <param name="parameter"></param>
        private void WriteKeyBoard(object parameter)
        {
            string strParameter = parameter.ToString();

            // ON OFF
            if (strParameter == "On")
                SwitchOn("");
            else if (strParameter == "Off")
                SwitchOff("");

            if (Settings.isMathSwitchOff == true)
                    return;

            // LESS GREAT OR EQUAL
            if (strParameter == "Greater")
                strParameter = ">";
            else if (strParameter == "Less")
                strParameter = "<";
            else if (strParameter == "Equal")
                strParameter = "=";

            if ((strParameter.ToString() == "<")
                || (strParameter.ToString() == ">")
                || (strParameter.ToString() == "=")
                )
                {
                    if (Settings.paramMathmode == Enums.MathGameMode.LessGreaterEqual)
                        Line9 = parameter.ToString();
                    else
                        BeepError();

                    return;
                }

            // MODES
            if (strParameter == "Repeat")
            { 
                Repeat("");
                
            }
            else if (strParameter == "WordProblems")
            {
                SetChangeGameMode(Enums.MathGameMode.WordProblems);
                //Settings.paramMathmode = Enums.MathGameMode.WordProblems;
                //ResetCounters();
                //DisplayModeAndLevel();
            }
            else if (strParameter == "LessGreater")
            {
                SetChangeGameMode(Enums.MathGameMode.LessGreaterEqual);
                //Settings.paramMathmode = Enums.MathGameMode.LessGreaterEqual;
                //ResetCounters();
                //DisplayModeAndLevel();
            }
            else if (strParameter == "WriteIt")
            {
                SetChangeGameMode(Enums.MathGameMode.WriteIt);
                //Settings.paramMathmode = Enums.MathGameMode.WriteIt;
                //ResetCounters();
                //DisplayModeAndLevel();
            }
            else if (strParameter == "NumberStumper")
            {
                SetChangeGameMode(Enums.MathGameMode.NumberStumper);
                //Settings.paramMathmode = Enums.MathGameMode.NumberStumper;
                //ResetCounters();
                //DisplayModeAndLevel();
            }
            else if (strParameter == "MixIt")
            {
                ChangeOperationMode("");
                //ResetCounters();
            }
            else if (strParameter == "Go")
            { 
                PlayAndCompute(Enums.PlayOrCompute.Play);
            }
            else if (strParameter == "Enter")
            { 
                PlayAndCompute(Enums.PlayOrCompute.Enter);
            }
            else if (strParameter == "Clear")
            { 
                ClearScreen(false, false, true);
            }
            else if (strParameter == "IncreaseLevel")
            {
                IncreaseLevel("");
                //ResetCounters();
            }
            else if (strParameter == "DecreaseLevel")
            { 
                DecreaseLevel("");
                //ResetCounters();
            }
            else if (strParameter == "-+")
            { 
                AnswerPlusOrMinus("");
            }

            // WRITE ANSWER
            if ((strParameter.Equals("+"))
                || (strParameter.Equals("-"))
                || (strParameter.Equals("*"))
                || (strParameter.Equals("/"))
                || (strParameter.Equals("."))
                || (strParameter.Equals("0"))
                || (strParameter.Equals("1"))
                || (strParameter.Equals("2"))
                || (strParameter.Equals("3"))
                || (strParameter.Equals("4"))
                || (strParameter.Equals("5"))
                || (strParameter.Equals("6"))
                || (strParameter.Equals("7"))
                || (strParameter.Equals("8"))
                || (strParameter.Equals("9"))
                )
            {
                Line9 += strParameter;
            }
        }

        /*
        private void ChangeModeKeyBoard(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            string strParameter = parameter.ToString();
            if (strParameter.ToString() == "WordProblems")
                Settings.paramMathmode = Enums.MathMode.WordProblems;
            else if (strParameter == "LessGreater")
                Settings.paramMathmode = Enums.MathMode.LessGreaterEqual;
            else if (strParameter == "WriteIt")
                Settings.paramMathmode = Enums.MathMode.WriteIt;
            else if (strParameter == "Go")
            {
                PlayAndCompute(Enums.PlayOrCompute.Play);
                //ChangeOperationMode("");
                //Settings.paramMathmode = Enums.MathMode.Calculate;
            }
            else if (strParameter == "MixIt")
            {
                ChangeOperationMode("");
                //Settings.paramMathOperation = Enums.MathOperation.Random;
            }
            
            else if (strParameter == "NumberStumper")
                Settings.paramMathmode = Enums.MathMode.NumberStumper;

            //Update
            DisplayModeAndLevel();
        }
        */

        /// <summary>
        /// Repeat
        /// </summary>
        /// <param name="parameter"></param>
        private void Repeat(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            //WaitAndSpeak(Line3);
            WaitAndSpeak(Settings.Question);

            //Helpers.Speaker speaker = new Helpers.Speaker();
            //speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, Line2);    //English
            //speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, Line3); //frenchNumber1);
        }

        /// <summary>
        /// PlaySpell
        /// </summary>
        /// <param name="parameter"></param>
        private void PlaySpell(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            ClearScreen(true, false, false);
            PlayAndCompute(Enums.PlayOrCompute.Play);
            //DisplayCongratulation();
        }

        /// <summary>
        /// Enter
        /// </summary>
        /// <param name="parameter"></param>
        private void Enter(object parameter)
        {
            if (Settings.isMathSwitchOff == true)
                return;

            PlayAndCompute(Enums.PlayOrCompute.Enter);
            //DisplayCongratulation();
        }

        #endregion

        #region Method without parameter

        /// <summary>
        /// ResetCounters
        /// </summary>
        private void ResetCounters()
        {
            if (Settings.isMathSwitchOff == true)
                return;

            Settings.counterWrongTry = 0;
            Settings.counterGoodAnswers = 0;
            Settings.counterWrongAnswers = 0;
        }

        /// <summary>
        /// ClearScreen
        /// </summary>
        /// <param name="cleanFirstLine"></param>
        /// <param name="cleanScore"></param>
        /// <param name="cleanAnswer"></param>
        private void ClearScreen(bool cleanFirstLine = true, bool cleanScore = false, bool cleanAnswer = true)
        {
            if (cleanFirstLine)
            { 
                Line1 = "";
            }

            Line2 = "";
            Line3 = "";
            Line4 = "";
            Line5 = "";
            Line6 = "";
            Line7 = "";

            if(cleanScore)
            { 
                Line8 = "";
            }

            if (cleanAnswer)
            { 
                Line9 = "";
            }
        }



        //private void DisplayCongratulation()
        //{
        //    if (DisplayNumber != null)
        //    {
        //        if ((Settings.counterWrongTry % 3) == 0)
        //        { 
        //            Line4 = (Line9 == DisplayNumber.Number_result.ToString()) ? "Correct" : "Incorrect";
        //            Line5 = (Line9 == DisplayNumber.Number_result.ToString()) ? "Good answer" : "Wrong answer";
        //        }
        //        else
        //        { 
        //            Line6 = (Line9 == DisplayNumber.Number_result.ToString()) ? "Bravo, continue" : "Essaie encore une fois";
        //            Line7 = (Line9 == DisplayNumber.Number_result.ToString()) ? "Congratulation, continue" : "Try again";
        //        }
        //    }
        //
        //    Thread thread = new Thread(WaitAndSpeak);
        //    thread.Start();
        //}

        /// <summary>
        /// PlayAndCompute : VERY IMPORTANT : PLAY AND ENTER
        /// </summary>
        /// <param name="playOrCompute"></param>
        private void PlayAndCompute(Enums.PlayOrCompute playOrCompute)
        {
            DisplayModeAndLevel();

            //SetMode(Enums.MathMode.Dictee);
            //Helpers.Speaker speaker = new Helpers.Speaker();
            double numberWritten = 0;
            bool isNumberParsed = Double.TryParse(Line9, out numberWritten);
            string textWritten = "";
            textWritten = Line9;
            bool isTextParsed = false;

            // Caractères authorisés :
            //'+', '-', '*', '/', '%', '(', ')', ','
            //"Abs()","Cos()","Cosh()","Sin()","Sinh()","Tan()","Acos()","Asin()","Atan()","Ceil()","Floor()","Round()","Exp()","Log()","Log10()","Sign()","Truncate()",
            //"Log(,)","Atan2(,)","Max(,)","Min(,)","Pow(,)",

            //if (Settings.isNewGame == true)
            //    return;
            //Settings.isCorrectAnswer = true;
            //if (isPlay == true)
            //    return;
            //if (isCompute == true)
            //    return;

            if ((playOrCompute == Enums.PlayOrCompute.Enter)
             && (isNumberParsed == false) 
             && ((Settings.paramMathmode == Enums.MathGameMode.SpellIt)  
                || (Settings.paramMathmode == Enums.MathGameMode.WriteIt) 
                || (Settings.paramMathmode == Enums.MathGameMode.WordProblems) 
                || (Settings.paramMathmode == Enums.MathGameMode.NumberStumper))
             )
            {
                BeepError();
                return;
            }

            isTextParsed = !string.IsNullOrEmpty(textWritten);
            if ((playOrCompute == Enums.PlayOrCompute.Enter)
             && (isTextParsed == false)
            && ((Settings.paramMathmode == Enums.MathGameMode.Equation)
                || (Settings.paramMathmode == Enums.MathGameMode.LessGreaterEqual))
            )
            {
                BeepError();
                return;
            }

            if (playOrCompute == Enums.PlayOrCompute.Play)
            { 
                //ClearAnswer("");
                DisplayClearAnswer();
            }

            switch (Settings.paramMathmode)
            {
                case Enums.MathGameMode.SpellIt:
                    if (playOrCompute == Enums.PlayOrCompute.Play)
                    {
                        Settings.Question = "écrivez un nombre";
                        Line2 = Settings.Question;
                    }
                    //Line1 = "SpellIt mode";// : Write a number + Enter";
                    if (playOrCompute == Enums.PlayOrCompute.Enter)
                    { 
                        Double.TryParse(Line9, out numberWritten);
                        DisplayNumber = ServiceNumber.TransformMathNumberToLetter(numberWritten);
                        Settings.Answer = DisplayNumber.Number_1.ToString();
                        Settings.isUseCounters = false;
                    }
                    break;

                case Enums.MathGameMode.WriteIt:
                    //Line1 = "WriteIt mode : Write the correct answer + Enter";
                    //DisplayModeAndLevel();
                    Double.TryParse(Line9, out numberWritten);
                    if(playOrCompute == Enums.PlayOrCompute.Play)
                    {
                        DisplayNumber = ServiceNumber.GenerateMath(Settings.counterLevel);
                        Settings.Question = "écrivez le nombre " + DisplayNumber.Number_1_French;
                        Line2 = Settings.Question;
                        //Line3 = DisplayNumber.Number_1_French;
                    }
                    if ((playOrCompute == Enums.PlayOrCompute.Enter) 
                    //    && (Settings.counterWrongTry % SettingsApp.Default.paramMaxWrongTry == 0)
                      )
                    {
                        if (DisplayNumber == null)
                        {
                            //WaitContinuePlayAndCompute();
                            BeepError();
                            return;
                        }

                        Settings.isUseCounters = true;
                        Settings.isCorrectAnswer = (numberWritten == DisplayNumber.Number_result);
                        Settings.Answer = DisplayNumber.Number_1.ToString();
                        //Line4 = (Settings.isCorrectAnswer ? "Correct" : "Incorrect");
                    }

                    //Line3 = DisplayNumber.Number_1_French;

                    //DisplayNumber = number3;
                    //Helpers.Speaker speaker = new Helpers.Speaker();
                    //speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, number3.Number_1_English);
                    //speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, DisplayNumber.Number_1_French);
                    break;

                case Enums.MathGameMode.WordProblems:
                    if (playOrCompute == Enums.PlayOrCompute.Play)
                    {
                        DisplayNumber = ServiceNumber.Generate_2NumbersOperationResult((Enums.Level)Settings.counterLevel, Enums.MathOperation.Random);
                        //Settings.Question = DisplayNumber.Number_equation;
                        Settings.Question = DisplayNumber.Number_equation_French;

                        //Thread threadWaitSpeak = new Thread(() => WaitAndSpeak(DisplayNumber.Number_equation_French));
                        //threadWaitSpeak.Start();
                    }
                    if (playOrCompute == Enums.PlayOrCompute.Enter)
                    {
                        if (DisplayNumber == null)
                        {
                            BeepError();
                            return;
                        }

                        Settings.isUseCounters = true;
                        Settings.isCorrectAnswer = (numberWritten == DisplayNumber.Number_result);
                        Settings.Answer = DisplayNumber.Number_1.ToString();
                        //Line4 = (Settings.isCorrectAnswer ? "Correct" : "Incorrect");
                    }
                    Line2 = DisplayNumber.Number_equation;

                    //Thread threadDisplayAnswer = new Thread((WaitSpeak( DisplayNumber.Number_equation_French));
//                    Thread threadWaitSpeak = new Thread(() => WaitAndSpeak(DisplayNumber.Number_equation_French));
//                    threadWaitSpeak.Start();
                    //WaitSpeak(DisplayNumber.Number_equation_French);
                    //speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, DisplayNumber.Number_equation_French);
                    break;

                case Enums.MathGameMode.Equation:
                    if (playOrCompute == Enums.PlayOrCompute.Play)
                    {
                        Settings.Question = "écrivez une équation";
                        Line2 = Settings.Question;
                    }
                    if (playOrCompute == Enums.PlayOrCompute.Enter)
                    {
                        Settings.isUseCounters = false;

                        //Number number5 = new Number();
                        //Line9 = "(2+1)*4";
                        DisplayNumber = ServiceNumber.ComputeMathFormula(textWritten);
                        //Line2 = number5.Number_result.ToString();
                        //Line8 = textWritten;
                        //DisplayNumber = number5;
                        DisplayNumber.Number_equation = textWritten;
                        //speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, number5.Number_1_French);
                        //WaitAndSpeak(number5.Number_1_French);
                        //MathConverter mathConverter = new MathConverter();
                        //mathConverter.Convert("2", Type.DefaultBinder.ToString(), "(2+3)*2", CultureInfo.CurrentCulture);
                    }
                    break;

                case Enums.MathGameMode.LessGreaterEqual:
                    //Number number6 = new Number();
                    if (playOrCompute == Enums.PlayOrCompute.Play)
                    {
                        //Number number7 = new Number();
                        DisplayNumber = ServiceNumber.Generate_2NumbersOperationResult((Enums.Level)Settings.counterLevel, Enums.MathOperation.Random);
                        //DisplayNumber = ServiceNumber.GenerateMath(Settings.counterLevel);
                        //Settings.Question = DisplayNumber.Number_equation_LessOrGreaterOrEqual;
                        //Line2 = (number6.Number_result + " ? " + number7.Number_result);
                        Settings.Question = DisplayNumber.Number_1_French + "est plus grand, plus petit ou égal à " + DisplayNumber.Number_2_French + "?";
                    }
                    //number7 = ServiceNumber.GenerateNumber((Enums.Level)Settings.counterLevel, Enums.MathOperation.Random);
                    //Display(number1);
                    //Line2 = string.Format("{0} ? { 1}", number6.Number_result, number7.Number_result);
                    
                    if (playOrCompute == Enums.PlayOrCompute.Enter)
                    {
                        if (DisplayNumber == null)
                        {
                            BeepError();
                            return;
                        }

                        Settings.isUseCounters = true;
                        Settings.isCorrectAnswer = (textWritten.ToString() == DisplayNumber.Number_result_LessOrGreaterOrEqual);// strResultGreaterOrLessThan.ToString());
                        Settings.Answer = DisplayNumber.Number_result_LessOrGreaterOrEqual;
                        Line4 = (Settings.isCorrectAnswer ? "Correct" : "Incorrect");
                    }
                    Line2 = DisplayNumber.Number_equation_LessOrGreaterOrEqual;
                    break;

                case Enums.MathGameMode.NumberStumper:
                    if (playOrCompute == Enums.PlayOrCompute.Play)
                    {
                        DisplayNumber = ServiceNumber.GenerateNumberStumper(); // Settings.counterLevel);
                        Settings.Question = "Trouvez le nombre secret";
                        Line2 = "---- ?";
                        ResetCounters();
                    }
                    if (playOrCompute == Enums.PlayOrCompute.Enter)
                    {
                        if ((textWritten.Length != 4) || (isNumberParsed == false))
                        {
                            BeepError();
                            return;
                        }

                        ClearScreen(true, false, false);
                        //number2 = ServiceNumber.GenerateMath();
                        // 1234 : if 4251 => 1 Bulls (2) and 2 cows (1+4)
                        //Line2 = "1234";
                        //Line2 = "1234";

                        //Settings.isCorrectAnswer = (numberWritten == DisplayNumber.Number_1);
                        Settings.isCorrectAnswer = (textWritten.ToString() == DisplayNumber.Number_1.ToString());
                        Line4 = (Settings.isCorrectAnswer ? "Correct" : "Incorrect");

                        // TO DO : algo to determine bulls and cows
                        //string strResultNumberStumper = ServiceNumber.ComputeNumberStumper(numberWritten, DisplayNumber.Number_1);
                        string strResultNumberStumper = ServiceNumber.ComputeNumberStumper(textWritten, DisplayNumber.Number_1.ToString());
                        //Line3 = "1 bull(s) and 2 cow(s)";
                        Line3 = strResultNumberStumper;
                        Settings.isUseCounters = true;
                        Settings.Answer = strResultNumberStumper;
                    }
                    break;

                default:
                    BeepError();
                    break;
            }

            // QUESTION
            if (playOrCompute == Enums.PlayOrCompute.Play)
            {
                Thread threadDisplayAnswer = new Thread(() => WaitAndSpeak(Settings.Question));
                threadDisplayAnswer.Start();
            }

            // COUNTER ONLY ON ENTER
            if (playOrCompute == Enums.PlayOrCompute.Enter)
            {
                if (Settings.isCorrectAnswer)
                {
                    Settings.counterGoodAnswers++;
                    //Line5 = "CORRECT";
                    //speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, "Well done. Continue.");
                }
                else
                {
                    Settings.counterWrongAnswers++;
                    //Line5 = "INCORRECT";
                    //speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, "Try again.");
                }
                DisplayIsCorrectStatistiques();
                // Display ANSWER
                Thread threadDisplayAnswer = new Thread(WaitDisplayAnswer);
                threadDisplayAnswer.Start();

                // if (Settings.isCorrectAnswer)
                //     Settings.counterWrongTry = 0;
                // else
                //     Settings.counterWrongTry++;
                //
                // // DISPLAY CORRECT
                // DisplayIsCorrectStatistiques();
                // DisplayClearAnswer();
                //
                // //if ( (Settings.counterWrongTry % SettingsApp.Default.paramMaxWrongTry) == 0)
                // {
                //     if (Settings.isCorrectAnswer)
                //     { 
                //         Settings.counterGoodAnswers++;
                //         //Line5 = "CORRECT";
                //         speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, "Well done. Continue.");
                //     }
                //     else
                //     { 
                //         Settings.counterWrongAnswers++;
                //         //Line5 = "INCORRECT";
                //         speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, "Try again.");
                //     }
                // }
                //
                // bool isContinueGame = false;
                // if ((Settings.counterWrongTry % SettingsApp.Default.paramMaxWrongTry) == 0)
                // {
                //     isContinueGame = true;
                // }
                //
                // // ANSWER + CONTINUE
                // if (isContinueGame || Settings.isCorrectAnswer)
                // {
                //     // Display ANSWER
                //     Thread threadDisplayAnswer = new Thread(WaitDisplayAnswer);
                //     threadDisplayAnswer.Start();
                //
                //     Settings.counterWrongTry = 0;
                // }
            }

        }

        /// <summary>
        /// DisplayIsCorrectStatistiques
        /// </summary>
        private void DisplayIsCorrectStatistiques()
        {
            //Line6 = "Wrong try : " + Settings.counterWrongTry;
            if(Settings.isUseCounters)
            { 
                int totalAnswers = Settings.counterWrongAnswers + Settings.counterGoodAnswers;
                Line8 = "Good answers : " + Settings.counterGoodAnswers + " / " + totalAnswers;

                if(Settings.isCorrectAnswer == true)
                {
                    WaitAndSpeak("Correct");
                    //Thread thread = new Thread(() => WaitAndSpeak("Correct"));
                    //thread.Start();
                }
                else
                {
                    WaitAndSpeak("Incorrect");
                    //Thread thread = new Thread(() => WaitAndSpeak("Incorrect"));
                    //thread.Start();
                }
            }
        }

        /// <summary>
        /// DisplayClearAnswer
        /// </summary>
        private void DisplayClearAnswer()
        {
            Line9 = "";
        }

        /// <summary>
        /// BeepError
        /// </summary>
        private void BeepError()
        {
            Helpers.Speaker speaker = new Helpers.Speaker();
            speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, "BEEP");
        }

        /// <summary>
        /// WaitDisplayAnswer
        /// </summary>
        private void WaitDisplayAnswer()
        {
            DisplayAnswer(DisplayNumber);

            Thread thread = new Thread(() => SpeakAnswer(DisplayNumber));
            thread.Start();

            Thread.Sleep(5000);

            // CONTINUE
            ClearScreen(false, false, true);
            //speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, Line8);
            Thread threadContinue = new Thread(WaitContinuePlayAndCompute);
            threadContinue.Start();
        }

        /// <summary>
        /// WaitContinuePlayAndCompute
        /// </summary>
        private void WaitContinuePlayAndCompute()
        {
            //Thread.Sleep(1000);
            PlayAndCompute(Enums.PlayOrCompute.Play);
        }

        /// <summary>
        /// DisplayModeAndLevel
        /// </summary>
        private void DisplayModeAndLevel()
        {
            //Line1 = String.Format("Language : {0} - Mode : {1} - Level : {2} - Operation {3}",
            Line1 = String.Format("{0} - Mode: {1} - Level: {2} - Operation: {3}",
                Settings.paramLangage,
                Settings.paramMathmode,
                Settings.counterLevel.ToString(),
                Settings.paramMathOperation
                );
        }

        /// <summary>
        /// DisplayEquation
        /// </summary>
        /// <param name="number"></param>
        //private void DisplayEquation(Number number)
        //{
        //    Line2 = number.Number_equation;
        //    Line3 = number.Number_result.ToString();
        //    Line4 = number.Number_result_French;
        //    Line5 = number.Number_result_English;
        //    //Line6 = number.Number_result_Spanish;
        //}

        /// <summary>
        /// DisplayAnswer
        /// </summary>
        /// <param name="number"></param>
        private void DisplayAnswer(Number number)
        {
            switch (Settings.paramMathmode)
            {
                case Enums.MathGameMode.SpellIt:
                    Line2 = number.Number_1.ToString();
                    Line3 = number.Number_1_French;
                    Line4 = number.Number_1_English;
                    //Line5 = number.Number_1_Spanish;
                    //Line6 = number.Number_1_Italian;
                    //Line7 = number.Number_1_Portuguese;
                    //Line8 = number.Number_1_German;
                    break;

                case Enums.MathGameMode.WriteIt:
                    Line2 = number.Number_1.ToString();
                    Line3 = number.Number_1_French;
                    Line4 = number.Number_1_English;
                    //Line5 = number.Number_1_Spanish;
                    //Line6 = number.Number_1_Italian;
                    //Line7 = number.Number_1_Portuguese;
                    //Line8 = number.Number_1_German;
                    break;

                case Enums.MathGameMode.Equation:
                    Line2 = number.Number_equation + " = " + number.Number_result;
                    Line3 = number.Number_result.ToString();
                    Line4 = number.Number_result_French;
                    Line5 = number.Number_result_English;
                    break;

                case Enums.MathGameMode.WordProblems:
                    Line2 = number.Number_equation;
                    Line3 = number.Number_result.ToString();
                    Line4 = number.Number_result_French;
                    Line5 = number.Number_result_English;
                    break;

                case Enums.MathGameMode.LessGreaterEqual:
                    Line2 = number.Number_equation_LessOrGreaterOrEqual;
                    Line3 = number.Number_result_LessOrGreaterOrEqual;
                    break;

                case Enums.MathGameMode.NumberStumper:
                    //Line2 = number.Number_equation_LessOrGreaterOrEqual;
                    //Line3 = number.Number_result_LessOrGreaterOrEqual;
                    //Line2 = "1234";
                    //Line3 = "1 bull(s) and 2 cow(s)";
                    Line2 = number.Number_1.ToString();
                    Line3 = Settings.Answer; //number.Number_1.ToString();
                    break;

                default:
                    BeepError();
                    break;
            }
        }

        private void SpeakAnswer(Number number)
        {
            string strAnswerToSpeak = "";
            switch (Settings.paramMathmode)
            {
                case Enums.MathGameMode.SpellIt:
                    strAnswerToSpeak = number.Number_1_French;
                    break;

                case Enums.MathGameMode.WriteIt:
                    strAnswerToSpeak = number.Number_1_French;
                    break;

                case Enums.MathGameMode.Equation:
                    strAnswerToSpeak = "Le résultat de l'équation égale à " + number.Number_result_French;
                    break;

                case Enums.MathGameMode.WordProblems:
                    strAnswerToSpeak = number.Number_equation_French + number.Number_result_French;
                                      //ConvertEnums.TranslateCaracters_French("=") + 
                    break;

                case Enums.MathGameMode.LessGreaterEqual:
                    strAnswerToSpeak = number.Number_1_French + ConvertEnums.TranslateCaracters_French(number.Number_result_LessOrGreaterOrEqual) + number.Number_2_French;
                    break;

                case Enums.MathGameMode.NumberStumper:
                    //Line2 = number.Number_equation_LessOrGreaterOrEqual;
                    //Line3 = number.Number_result_LessOrGreaterOrEqual;
                    //Line2 = "1234";
                    //Line3 = "1 bull(s) and 2 cow(s)";
                    // PAS BON : TO DO
                    //strAnswerToSpeak = string.Format("{0} bull(s) and {1} cow(s)", number.Number_1_French, number.Number_1_French);
                    strAnswerToSpeak = Settings.Answer;
                    break;

                default:
                    //BeepError();
                    strAnswerToSpeak = "Beep";
                    break;
            }

            Thread thread = new Thread(() => WaitAndSpeak(strAnswerToSpeak));
            thread.Start();
        }


        /// <summary>
        /// WaitAndSpeak
        /// </summary>
        /// <param name="parameter"></param>
        ///private void WaitAndSpeak(object parameter)
        ///{
        ///    Helpers.Speaker speaker = new Helpers.Speaker();
        ///    speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, Line4);
        ///    speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, Line5);
        ///    speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, Line6);
        ///    speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, Line7);
        ///
        ///    Thread.Sleep(5000);
        ///    //Clear(parameter);
        ///    Line7 = "";
        ///}

        /// <summary>
        /// WaitAndSpeakOn
        /// </summary>
        private void WaitAndSpeakOn()
        {
            Helpers.Speaker speaker = new Helpers.Speaker();
            speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, Line2);
            //speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, Line3);
            //speaker.SpeakText(SettingsApp.Default.paramVoiceSpanish, Line3);
            //speaker.SpeakText(SettingsApp.Default.paramVoiceItalian, Line4);

            Thread.Sleep(1000);
            ClearScreen(true,  true, true);
            DisplayModeAndLevel();
            //Settings.isMathSwitchOff
            Settings.isMathSwitchOff = false;
        }

        /// <summary>
        /// WaitAndSpeakOff
        /// </summary>
        private void WaitAndSpeakOff()
        {
            Helpers.Speaker speaker = new Helpers.Speaker();
            speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, Line2);
            //speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, Line3);
            //speaker.SpeakText(SettingsApp.Default.paramVoiceSpanish, Line3);
            //speaker.SpeakText(SettingsApp.Default.paramVoiceItalian, Line4);

            Thread.Sleep(1000);
            ClearScreen(true, true, true);
            Settings.isMathSwitchOff = true;
        }

        /// <summary>
        /// WaitSpeak
        /// </summary>
        /// <param name="strToSpeak"></param>
        private void WaitAndSpeak(string strToSpeak)
        {
            Helpers.Speaker speaker = new Helpers.Speaker();
            speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, strToSpeak);
        }

        #endregion
    }

}
