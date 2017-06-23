using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SpeakAndSpell.Helpers.Enums.Enums;

namespace SpeakAndSpell.Helpers.Enums
{
    public static class ConvertEnums
    {
        /// <summary>
        /// ConvertMathOperation
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ConvertMathOperation(MathOperation operation)
        {
            string result = "+";

            if (operation == Enums.MathOperation.Addition)
                result = "+";
            else if (operation == Enums.MathOperation.Substraction)
                result = "-";
            else if (operation == Enums.MathOperation.Multiplication)
                result = "*";
            else if (operation == Enums.MathOperation.Division)
                result = "/";

            return result;
        }

        #region Language ConvertMathOperation_ 
        /// <summary>
        /// ConvertMathOperation_French
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ConvertMathOperation_French(MathOperation operation)
        {
            // French     : erreur + plus + moins + fois + divisé par
            // English    : error + plus + minus + times + divided by
            // Italian    : errore + Plus + meno + tempo + diviso per
            // Spanish    : error + más + menos + tiempo + dividido por
            // Portuguese : erro + mais + menos + tempo + dividido pelo 
            // German     : error + plus + weniger + Zeit + dividiert durch
            //string[] text_fr = new[] {"erreur", "plus", "moins", "fois", "divisé par"};

            string result = "erreur";

            if (operation == Enums.MathOperation.Addition)
                result = "plus";
            else if (operation == Enums.MathOperation.Substraction)
                result = "moins";
            else if (operation == Enums.MathOperation.Multiplication)
                result = "fois";
            else if (operation == Enums.MathOperation.Division)
                result = "divisé par";

            return result;
        }

        /// <summary>
        /// ConvertMathOperation_English
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ConvertMathOperation_English(MathOperation operation)
        {
            // English    : error + plus + minus + times + divided by
            string result = "error";

            if (operation == Enums.MathOperation.Addition)
                result = "plus";
            else if (operation == Enums.MathOperation.Substraction)
                result = "minus";
            else if (operation == Enums.MathOperation.Multiplication)
                result = "times";
            else if (operation == Enums.MathOperation.Division)
                result = "divided by";

            return result;
        }

        /// <summary>
        /// ConvertMathOperation_Italian
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ConvertMathOperation_Italian(MathOperation operation)
        {
            // Italian    : errore + plus + meno + tempo + diviso per
            string result = "errore";

            if (operation == Enums.MathOperation.Addition)
                result = "plus";
            else if (operation == Enums.MathOperation.Substraction)
                result = "meno";
            else if (operation == Enums.MathOperation.Multiplication)
                result = "tempo";
            else if (operation == Enums.MathOperation.Division)
                result = "diviso per";

            return result;
        }

        /// <summary>
        /// ConvertMathOperation_Spanish
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ConvertMathOperation_Spanish(MathOperation operation)
        {
            // Spanish    : error + más + menos + tiempo + dividido por
            string result = "error";

            if (operation == Enums.MathOperation.Addition)
                result = "más";
            else if (operation == Enums.MathOperation.Substraction)
                result = "menos";
            else if (operation == Enums.MathOperation.Multiplication)
                result = "tiempo";
            else if (operation == Enums.MathOperation.Division)
                result = "dividido por";

            return result;
        }

        /// <summary>
        /// ConvertMathOperation_Portuguese
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ConvertMathOperation_Portuguese(MathOperation operation)
        {
            // Portuguese : erro + mais + menos + tempo + dividido pelo 
            string result = "erro";

            if (operation == Enums.MathOperation.Addition)
                result = "mais";
            else if (operation == Enums.MathOperation.Substraction)
                result = "menos";
            else if (operation == Enums.MathOperation.Multiplication)
                result = "tempo";
            else if (operation == Enums.MathOperation.Division)
                result = "dividido pelo";

            return result;
        }

        /// <summary>
        /// ConvertMathOperation_German
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static string ConvertMathOperation_German(MathOperation operation)
        {
            // German     : error + plus + weniger + Zeit + dividiert durch
            string result = "error";

            if (operation == Enums.MathOperation.Addition)
                result = "plus";
            else if (operation == Enums.MathOperation.Substraction)
                result = "weniger";
            else if (operation == Enums.MathOperation.Multiplication)
                result = "Zeit";
            else if (operation == Enums.MathOperation.Division)
                result = "dividiert durch";

            return result;
        }
        #endregion

        #region Language TranslateCaracters_ 

        /// <summary>
        /// TranslateCaracters_French
        /// </summary>
        /// <param name="strToTranslate"></param>
        /// <returns></returns>
        public static string TranslateCaracters_French(string strToTranslate)
        {
            string result = "TranslateCaracters_French Erreur";

            if (strToTranslate == "=")
                result = " est égal à ";
            else if (strToTranslate == ">")
                result = " est supérieur à ";
            else if (strToTranslate == "<")
                result = " est inférieur à ";

            return result;
        }

        /// <summary>
        /// TranslateCaracters_English
        /// </summary>
        /// <param name="strToTranslate"></param>
        /// <returns></returns>
        public static string TranslateCaracters_English(string strToTranslate)
        {
            string result = "TranslateCaracters_English Error";

            if (strToTranslate == "=")
                result = " is equal to ";
            else if (strToTranslate == ">")
                result = " is greater than ";
            else if (strToTranslate == "<")
                result = " is less than ";

            return result;
        }

        /// <summary>
        /// TO DO
        /// </summary>
        /// <param name="strToTranslate"></param>
        /// <returns></returns>
        public static string TranslateCaracters_Spanish(string strToTranslate)
        {
            string result = "TranslateCaracters_Spanish Erreur";

            if (strToTranslate == "=")
                result = " est égal à ";
            else if (strToTranslate == ">")
                result = " est supérieur à ";
            else if (strToTranslate == "<")
                result = " est inférieur à ";

            return result;
        }

        /// <summary>
        /// TO DO
        /// </summary>
        /// <param name="strToTranslate"></param>
        /// <returns></returns>
        public static string TranslateCaracters_Italian(string strToTranslate)
        {
            string result = "TranslateCaracters_Italian Erreur";

            if (strToTranslate == "=")
                result = " est égal à ";
            else if (strToTranslate == ">")
                result = " est supérieur à ";
            else if (strToTranslate == "<")
                result = " est inférieur à ";

            return result;
        }

        /// <summary>
        /// TO DO
        /// </summary>
        /// <param name="strToTranslate"></param>
        /// <returns></returns>
        public static string TranslateCaracters_Portuguese(string strToTranslate)
        {
            string result = "TranslateCaracters_Portuguese Erreur";

            if (strToTranslate == "=")
                result = " est égal à ";
            else if (strToTranslate == ">")
                result = " est supérieur à ";
            else if (strToTranslate == "<")
                result = " est inférieur à ";

            return result;
        }

        /// <summary>
        /// TO DO
        /// </summary>
        /// <param name="strToTranslate"></param>
        /// <returns></returns>
        public static string TranslateCaracters_German(string strToTranslate)
        {
            string result = "TranslateCaracters_German Erreur";

            if (strToTranslate == "=")
                result = " est égal à ";
            else if (strToTranslate == ">")
                result = " est supérieur à ";
            else if (strToTranslate == "<")
                result = " est inférieur à ";

            return result;
        }

        #endregion
    }
}
