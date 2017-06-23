using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakAndSpell.Helpers.Enums
{
    public static class Enums
    {
        public enum MathSwitchOnOff
        {
            On = 0,              //
            Off = 1,             // 
            InProgress = 2,      //
        };

        public enum PlayOrCompute
        {
            Play = 0,              //
            Enter = 1,             // 
        };

        public enum MathGameMode
        {
            WriteIt = 0,           // Treize + Speaker : 13 + Enter         : generate number + NumberToWords + Speak + [Test Answer + Speak (OK or NOK)] 3 times
            SpellIt = 1,           // 13 + Enter : Treize                   : 1 -> Un 3 -> Trois
            WordProblems = 2,         // 13 + 50 = ? -> 63 Soixante Trois
            Equation =3,           // 3 * (2 + 3) -> 15 Quinze
            LessGreaterEqual = 4,  // 23 ? 21 -> > Greater than
            NumberStumper = 5,     // 1234 : if 4251 => 1 Bulls (2) and 2 cows (1+4)
        };

        public enum MathOperation
        {
            Random = 0,
            Addition = 1,          // 
            Substraction = 2,      //
            Multiplication = 3,    //
            Division = 4,          //
        };

        public enum MathFunctionWith1Parameter
        {
            //"Abs()","Cos()","Cosh()","Sin()","Sinh()","Tan()","Acos()","Asin()","Atan()","Ceil()","Floor()","Round()","Exp()","Log()","Log10()","Sign()","Truncate()",
            Abs,
            Cos,
            Cosh,
            Sin,
            Sinh,
            Tan,
            Acos,
            Asin,
            Atan,
            Ceil,
            Floor,
            Round,
            Exp,
            Log,
            Log10,
            Sign,
            Truncate,
        };

        public enum MathFunctionWith2Parameters
        {
            //"Log(,)","Atan2(,)","Max(,)","Min(,)","Pow(,)"
            Log,
            Atan2,
            Max,
            Min,
            Pow,
        }

        public enum Language
        {
            French      , //= 0,
            English     , //= 1,
            Spanish     , //= 2,
            Italian     , //= 3,
            Portuguese  , //= 4,
            German      , //= 5,
        };

        public enum Level
        {
            Level0 = 0, // RANDOM
            Level1 = 1, //VeryEasy, //= 0,
            Level2 = 2, //Easy, //= 1,
            Level3 = 3, //Middle, //= 2,
            Level4 = 4, //Difficult, //= 3,
            Level5 = 5, //VeryDifficult, //= 4,
            Level6 = 6, //VeryHard, //= 5,
            Level7 = 7, //VeryHard, //= 5,
        };

        #region Enums

        //Speak &amp; Spell / La dictée magique / Grillo
        //Speak &amp; Math
        //Speak &amp; Read
        //Speak &amp; Translate
        //Speak &amp; Music / La musique magique
        //Speak &amp; Song / Les paroles de chansons magiques
        //Speak &amp; Conjugate / La conjuguaison magique
        //The Little Professor
        //Simon
        //Les maths Magiques
        //Le Calcul Magique / Mathe-Fix
        //Le super livre Magique
        //DataMan
        //DataMath
        //Magic Wand Speak &amp; Learn
        //About

        /// <summary>
        /// Enum des ecrans
        /// </summary>
        public enum eWindows
        {
            Accueil,
            TTXLot1,
            TTXLot2,
            TTXLot3,
            DemandeActivite,
            CahierResultat,
            Incident,
            PlanningLot1,
            PlanningLot2,
        }

        #endregion

    }
}
