using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeakAndSpell.Helpers.Enums;

namespace SpeakAndSpell.Helpers.Settings
{
    public class Settings
    {
        // SwitchOff
        public static bool isMathSwitchOff = true;
        public static bool isCorrectAnswer = true;
        public static bool isUseCounters = true;
        public static bool isNewGame = true;
        public static string Question = "";
        public static string Answer = "";

        //SettingsApp.Default.paramVoiceEnglish : Microsoft Zira Desktop
        //SettingsApp.Default.paramVoicFrench : Microsoft Hortense Desktop

        //public static int paramMaxWrongTry = 1; //3;
        //public static int paramMaxCounterGame = 1; //10;
        //public static int paramMinLevel = 1;
        //public static int paramMaxLevel = 4;
        public static Helpers.Enums.Enums.MathGameMode paramMathmode = Enums.Enums.MathGameMode.WordProblems;
        public static Helpers.Enums.Enums.Language paramLangage = Enums.Enums.Language.French;
        public static Helpers.Enums.Enums.MathOperation paramMathOperation = Enums.Enums.MathOperation.Random;

        public static int counterLevel = 1;
        public static int counterWrongTry = 0;
        public static int counterGoodAnswers = 0;
        public static int counterWrongAnswers = 0;
        //public static int counterGame = 0;
        
        //public static string numberWrongAnswers = counterWrongAnswers + "/" + paramMaxCounterGame;
        public static string displayResultGoodAnswers = counterGoodAnswers + " / " + SettingsApp.Default.paramMaxCounterGame;


    }
}
