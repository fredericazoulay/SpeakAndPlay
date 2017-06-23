using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeakAndSpell.Helpers;
using SpeakAndSpell.Helpers.Enums;
using SpeakAndSpell.Helpers.Settings;
using System.CodeDom;
using System.Reflection;
using System.CodeDom.Compiler;
using System.Threading;

namespace SpeakAndSpell.Model.Services
{
    public static class ServiceNumber
    {

        //public static string ComputeNumberStumper(double tryNumber, double secretNumber)
        public static string ComputeNumberStumper(string tryNumber, string secretNumber)
        {
            //Settings.Answer = "1 bull(s) and 2 cow(s)";
            string result = "";
            int counterBulls = 0;
            int counterCows = 0;

            //for (int i = 0; i < 4; i++)
            //{
            //    if (secretNumber[i] == tryNumber[i])
            //    {
            //        counterBulls++;
            //    }
            //}
            for (int i = 0; i < 4; i++)
            {
                if (secretNumber.ToString().Contains(tryNumber[i]))
                {
                    if (secretNumber[i] == tryNumber[i])
                        counterBulls++;
                    else
                        counterCows++;
                }
            }

            result = string.Format("{0} bull{1} and {2} cow{3}", counterBulls, (counterBulls>1?"s":""), counterCows, (counterCows > 1 ? "s" : ""));
            return result;
        }


        /// <summary>
        /// GenerateNumber
        /// </summary>
        /// <param name="level"></param>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static Number Generate_2NumbersOperationResult(Enums.Level level, Enums.MathOperation operation)
        {
            int randomNumber1 = 0;
            int randomNumber2 = 0;
            string strRandomNumber1 = "";
            string strRandomNumber2 = "";

            // + - * /
            Enums.MathOperation randomOperation = GetRandomOperation(1, 4);
            operation = Settings.paramMathOperation;
            if (operation == Enums.MathOperation.Random)
                operation = randomOperation;

            if (level == Enums.Level.Level1)
            {
                //int randomNumber1 = GetRandomValueLength(level);
                //int randomNumber2 = GetRandomValueLength(level);
                randomNumber1 = GetRandomValue(0, 10);
                Thread.Sleep(10);
                randomNumber2 = GetRandomValue(0, 10);
            }
            else if (level == Enums.Level.Level2)
            {
                randomNumber1 = GetRandomValue(0, 100);
                Thread.Sleep(10);
                randomNumber2 = GetRandomValue(0, 100);
            }
            else if (level == Enums.Level.Level3)
            {
                randomNumber1 = GetRandomValue(0, 1000);
                Thread.Sleep(10);
                randomNumber2 = GetRandomValue(0, 1000);
            }
            else if (level == Enums.Level.Level4)
            {
                randomNumber1 = GetRandomValue(0, 10000);
                Thread.Sleep(10);
                randomNumber2 = GetRandomValue(0, 100);
            }
            else if (level == Enums.Level.Level5)
            {
                randomNumber1 = GetRandomValue(0, 1000000);
                Thread.Sleep(10);
                randomNumber2 = GetRandomValue(0, 1000000);
            }
            else if (level == Enums.Level.Level6)
            {
                randomNumber1 = GetRandomValue(0, 10000);
                Thread.Sleep(10);
                randomNumber2 = GetRandomValue(0, 100);
                strRandomNumber2 = string.Format("Math.{0}({1})", GetRandomMathFunctionWith1Parameter().ToString(), randomNumber2);
            }
            else if (level == Enums.Level.Level7)
            {
                randomNumber1 = GetRandomValue(0, 10000);
                Thread.Sleep(10);
                randomNumber2 = GetRandomValue(0, 100);
                int randomNumber3 = GetRandomValueLength(3);
                strRandomNumber2 = string.Format("Math.{0}({1} , {2})", GetRandomMathFunctionWith1Parameter().ToString(), randomNumber2, randomNumber3);
            }

            if (strRandomNumber1 == "")
                strRandomNumber1 = randomNumber1.ToString();
            if (strRandomNumber2 == "")
                strRandomNumber2 = randomNumber2.ToString();

            // Never DIVIDE BY 0
            if ((randomNumber2 == 0) && (operation == Enums.MathOperation.Division))
                randomNumber2 = 1;

            Number number = new Number();
            number = FillNumber(level, randomNumber1, operation, randomNumber2, strRandomNumber1, strRandomNumber2);
            return number;
        }

        private static Number FillNumber(Enums.Level level, int randomNumber1, Enums.MathOperation operation, int randomNumber2, string strRandomNumber1, string strRandomNumber2)//, double result)
        {
            //double result = Calculate(randomNumber1, operation, randomNumber2);
            // CALCULATE
            string formula = string.Format("{0} {1} {2}", strRandomNumber1, ConvertEnums.ConvertMathOperation(operation), strRandomNumber2);
            double result = CalculateMathFormula(formula); //.Replace(" ",""));
            //if (result.Equals(double.NaN))
            //    result = 0.00;

            Number number = new Number();
            if (result.Equals(double.NaN))
            {
                string strError = "ERROR";
                number.ID = 0;
                number.Number_1 = randomNumber1;
                number.Number_1_French      = strError;
                number.Number_1_English     = strError;
                number.Number_1_Italian     = strError;
                number.Number_1_Spanish     = strError;
                number.Number_1_Portuguese  = strError;
                number.Number_1_German      = strError;
                number.Number_operation = operation;
                number.Number_2 = randomNumber2;
                number.Number_2_French = strError;
                number.Number_2_English = strError;
                number.Number_2_Italian = strError;
                number.Number_2_Spanish = strError;
                number.Number_2_Portuguese = strError;
                number.Number_2_German = strError;
                number.Number_result = result;
                number.Number_result_French = strError;
                number.Number_result_English = strError;
                number.Number_result_Italian = strError;
                number.Number_result_Spanish = strError;
                number.Number_result_Portuguese = strError;
                number.Number_result_German = strError;
                number.Number_equation_LessOrGreaterOrEqual = (strRandomNumber1 + " ? " + strRandomNumber2);

                number.Number_result_LessOrGreaterOrEqual = strError;
                
                number.Number_equation = string.Format("{0} {1} {2} = ?", strRandomNumber1, ConvertEnums.ConvertMathOperation(operation), strRandomNumber2);
                number.Number_equation_French = string.Format("{0} {1} {2} = ?", number.Number_1_French, ConvertEnums.ConvertMathOperation_French(operation), number.Number_2_French);
                number.Number_equation_English = string.Format("{0} {1} {2} = ?", number.Number_1_English, ConvertEnums.ConvertMathOperation_English(operation), number.Number_2_English);
                number.Number_equation_Italian = string.Format("{0} {1} {2} = ?", number.Number_1_Italian, ConvertEnums.ConvertMathOperation_Italian(operation), number.Number_2_Italian);
                number.Number_equation_Spanish = string.Format("{0} {1} {2} = ?", number.Number_1_Spanish, ConvertEnums.ConvertMathOperation_Spanish(operation), number.Number_2_Spanish);
                number.Number_equation_Portuguese = string.Format("{0} {1} {2} = ?", number.Number_1_Portuguese, ConvertEnums.ConvertMathOperation_Portuguese(operation), number.Number_2_Portuguese);
                number.Number_equation_German = string.Format("{0} {1} {2} = ?", number.Number_1_German, ConvertEnums.ConvertMathOperation_German(operation), number.Number_2_German);
            }
            else
            {
                number.ID = 0;
                number.Number_1 = randomNumber1;
                number.Number_1_French = NumberToWord.NumberToWords_French(randomNumber1);
                number.Number_1_English = NumberToWord.NumberToWords_English(randomNumber1);
                number.Number_1_Italian = NumberToWord.NumberToWords_Italian(randomNumber1);
                number.Number_1_Spanish = NumberToWord.NumberToWords_Spanish(randomNumber1);
                number.Number_1_Portuguese = NumberToWord.NumberToWords_Portuguese(randomNumber1);
                number.Number_1_German = NumberToWord.NumberToWords_German(randomNumber1);
                number.Number_operation = operation;
                number.Number_2 = randomNumber2;
                number.Number_2_French = NumberToWord.NumberToWords_French(randomNumber2);
                number.Number_2_English = NumberToWord.NumberToWords_English(randomNumber2);
                number.Number_2_Italian = NumberToWord.NumberToWords_Italian(randomNumber2);
                number.Number_2_Spanish = NumberToWord.NumberToWords_Spanish(randomNumber2);
                number.Number_2_Portuguese = NumberToWord.NumberToWords_Portuguese(randomNumber2);
                number.Number_2_German = NumberToWord.NumberToWords_German(randomNumber2);
                number.Number_result = result;
                number.Number_result_French = NumberToWord.NumberToWords_French(result);
                number.Number_result_English = NumberToWord.NumberToWords_English((int)result);
                number.Number_result_Italian = NumberToWord.NumberToWords_Italian(result);
                number.Number_result_Spanish = NumberToWord.NumberToWords_Spanish(result);
                number.Number_result_Portuguese = NumberToWord.NumberToWords_Portuguese(result);
                number.Number_result_German = NumberToWord.NumberToWords_German(result);
                number.Number_equation_LessOrGreaterOrEqual = (strRandomNumber1 + " ? " + strRandomNumber2);

                string strResultGreaterOrLessThan = "";
                if (number.Number_1 > number.Number_2)
                    strResultGreaterOrLessThan = ">";
                else if (number.Number_1 < number.Number_2)
                    strResultGreaterOrLessThan = "<";
                else if (number.Number_1 == number.Number_2)
                    strResultGreaterOrLessThan = "=";
                number.Number_result_LessOrGreaterOrEqual = strResultGreaterOrLessThan;

                number.Number_equation = string.Format("{0} {1} {2} = ?", strRandomNumber1, ConvertEnums.ConvertMathOperation(operation), strRandomNumber2);
                number.Number_equation_French = string.Format("{0} {1} {2} = ?", number.Number_1_French, ConvertEnums.ConvertMathOperation_French(operation), number.Number_2_French);
                number.Number_equation_English = string.Format("{0} {1} {2} = ?", number.Number_1_English, ConvertEnums.ConvertMathOperation_English(operation), number.Number_2_English);
                number.Number_equation_Italian = string.Format("{0} {1} {2} = ?", number.Number_1_Italian, ConvertEnums.ConvertMathOperation_Italian(operation), number.Number_2_Italian);
                number.Number_equation_Spanish = string.Format("{0} {1} {2} = ?", number.Number_1_Spanish, ConvertEnums.ConvertMathOperation_Spanish(operation), number.Number_2_Spanish);
                number.Number_equation_Portuguese = string.Format("{0} {1} {2} = ?", number.Number_1_Portuguese, ConvertEnums.ConvertMathOperation_Portuguese(operation), number.Number_2_Portuguese);
                number.Number_equation_German = string.Format("{0} {1} {2} = ?", number.Number_1_German, ConvertEnums.ConvertMathOperation_German(operation), number.Number_2_German);
            }
            return number;
        }

        public static Number GenerateNumberStumper()
        {
            // Random pour nombre à 4 chiffres
            int randomNumber = GetRandomValueLength(4);
            string englishNumber1 = NumberToWord.NumberToWords_English(randomNumber);
            string frenchNumber1 = NumberToWord.NumberToWords_French(randomNumber);
            Number number = new Number();
            //number = FillNumber((Enums.Level)Settings.counterLevel, randomNumber, Enums.MathOperation.Addition, 0, randomNumber.ToString(), "0");
            number = TransformMathNumberToLetter(randomNumber);
            return number;
        }

        public static Number GenerateMath(int level)
        {
            // Dictée de nombre
            int randomNumber = GetRandomValue(0, level * level * 99);
            string englishNumber1 = NumberToWord.NumberToWords_English(randomNumber);
            string frenchNumber1 = NumberToWord.NumberToWords_French(randomNumber);

            Number number = new Number();
            number = FillNumber((Enums.Level)Settings.counterLevel, randomNumber, Enums.MathOperation.Addition, 0, randomNumber.ToString(), "0");
            return number;

            //int randomNumber = 2593; //
            //int numberResponse = 2592;

            // Params init
            //Settings.counterGoodAnswers = 0;

            //for (int counterGame = 0; counterGame < SettingsApp.Default.paramMaxCounterGame; counterGame++)
            {
                //Mathmode = mode;
                //string englishNumber1 = NumberToWord.NumberToWords_English(randomNumber);
                //string frenchNumber1 = NumberToWord.NumberToWords_French(randomNumber);
                //
                //Helpers.Speaker speaker = new Helpers.Speaker();
                //speaker.SpeakText(SettingsApp.Default.paramVoiceEnglish, englishNumber1);
                //speaker.SpeakText(SettingsApp.Default.paramVoiceFrench, frenchNumber1);

                //bool resultOK = false;
                //Settings.counterWrongTry = 0;
                ////for (int counterTry = 0; counterTry < SettingsApp.Default.paramMaxWrongTry; counterTry++)
                //{
                //    if (randomNumber == numberResponse)
                //    {
                //        resultOK = true;
                //        break;
                //    }
                //    Settings.counterWrongTry++;
                //}

                // Counters
                //if (resultOK)
                //    Settings.counterGoodAnswers++;
                //else
                //    Settings.counterWrongAnswers++;

                //counterGame++;
                //if (counterGame >= SettingsApp.Default.paramMaxCounterGame)
                //    break;
            }

            //Set Display
            //Settings.displayResultGoodAnswers = Settings.counterGoodAnswers + "/" + SettingsApp.Default.paramMaxCounterGame;
            //
            //Number number = new Number();
            //return number;
        }

        private static double Calculate(int number1 = 0, Enums.MathOperation operation = Enums.MathOperation.Addition, int number2 = 0)
        {
            double result = 0;

            if (operation == Enums.MathOperation.Addition)
                result = number1 + number2;
            if (operation == Enums.MathOperation.Substraction)
                result = number1 - number2;
            if (operation == Enums.MathOperation.Multiplication)
                result = number1 * number2;
            if (operation == Enums.MathOperation.Division)
                result = number1 / number2;

            return result;
        }

        #region Calulatrice
        private static double ComputeMathEquation(string equation)
        {
            //Math.
            return 0;
        }

        public static Number TransformMathNumberToLetter(double numberToTransform)
        {
            Number number = new Number();

            if (numberToTransform.Equals(double.NaN))
            {
                string strError = "ERROR";
                number.ID = 0;
                number.Number_1 = numberToTransform;
                number.Number_1_French = strError;
                number.Number_1_English = strError;
                number.Number_1_Italian = strError;
                number.Number_1_Spanish = strError;
                number.Number_1_Portuguese = strError;
                number.Number_1_German = strError;

                number.Number_result = numberToTransform;
                number.Number_result_French = strError;
                number.Number_result_English = strError;
                number.Number_result_Italian = strError;
                number.Number_result_Spanish = strError;
                number.Number_result_Portuguese = strError;
                number.Number_result_German = strError;
            }
            else
            {
                number.ID = 0;
                number.Number_1 = numberToTransform;
                number.Number_1_French = NumberToWord.NumberToWords_French(numberToTransform);
                number.Number_1_English = NumberToWord.NumberToWords_English((int)numberToTransform);
                number.Number_1_Italian = NumberToWord.NumberToWords_Italian(numberToTransform);
                number.Number_1_Spanish = NumberToWord.NumberToWords_Spanish(numberToTransform);
                number.Number_1_Portuguese = NumberToWord.NumberToWords_Portuguese(numberToTransform);
                number.Number_1_German = NumberToWord.NumberToWords_German(numberToTransform); ;

                number.Number_result = numberToTransform;
                number.Number_result_French = NumberToWord.NumberToWords_French(numberToTransform);
                number.Number_result_English = NumberToWord.NumberToWords_English((int)numberToTransform);
                number.Number_result_Italian = NumberToWord.NumberToWords_Italian(numberToTransform);
                number.Number_result_Spanish = NumberToWord.NumberToWords_Spanish(numberToTransform);
                number.Number_result_Portuguese = NumberToWord.NumberToWords_Portuguese(numberToTransform);
                number.Number_result_German = NumberToWord.NumberToWords_German(numberToTransform);
            }

            return number;
        }

        public static Number ComputeMathFormula(string formula)
        {
            double result = CalculateMathFormula(formula);
            //if (result.Equals(double.NaN))
            //    result = 0.00;

            string equationLetter = TransformMathEquationToLetter(formula);

            return TransformMathNumberToLetter(result);
        }

        private static string TransformMathEquationToLetter(string formula)
        {
            return formula; // BAD
        }

        private static double CalculateMathFormula(string formula)
        {
            double result = double.NaN;
            //if (result.Equals(double.NaN))
            //    result = 0.00;
            CodeCompileUnit unit = prepareCompileUnit("(double)" + formula);
            Assembly dynamicAssembly = compileCode(unit, "CSharp");
            if (dynamicAssembly != null)
            {
                object formulaComputer = dynamicAssembly.CreateInstance("DynGen.Compute.formulaComputing", true);
                MethodInfo computeFormula = formulaComputer.GetType().GetMethod("computeFormula");
                result = (double)computeFormula.Invoke(formulaComputer, null);
            }
            return result;
        }

        private static Assembly compileCode(CodeCompileUnit compileunit, string language)
        {
            CompilerParameters compilerParameters = new CompilerParameters();
            compilerParameters.ReferencedAssemblies.Add("System.dll");
            compilerParameters.GenerateExecutable = false;
            compilerParameters.GenerateInMemory = true;
            compilerParameters.IncludeDebugInformation = false;
            compilerParameters.WarningLevel = 1;
            // compile.
            CodeDomProvider provider = CodeDomProvider.CreateProvider(language);
            CompilerResults compilerResults = provider.CompileAssemblyFromDom(compilerParameters, compileunit);

            // Return assembly if compilation OK - otherwise return null
            return (compilerResults.Errors.Count == 0) ? compilerResults.CompiledAssembly : null;
        }


        private static CodeCompileUnit prepareCompileUnit(string formulaString)
        {
            CodeNamespace compute = new CodeNamespace("DynGen.Compute");
            compute.Imports.Add(new CodeNamespaceImport("System"));
            CodeCompileUnit compileUnit = new CodeCompileUnit();
            compileUnit.Namespaces.Add(compute);
            CodeTypeDeclaration formulaComputing = new CodeTypeDeclaration("formulaComputing");
            compute.Types.Add(formulaComputing);
            CodeMemberMethod computeFormulaCode = new CodeMemberMethod();
            computeFormulaCode.Attributes = MemberAttributes.Public;
            computeFormulaCode.Name = "computeFormula";
            computeFormulaCode.ReturnType = new CodeTypeReference(typeof(double));
            CodeSnippetExpression formula = new CodeSnippetExpression(formulaString);
            CodeMethodReturnStatement computeFormulaReturnStatement = new CodeMethodReturnStatement(formula);
            computeFormulaCode.Statements.Add(computeFormulaReturnStatement);

            formulaComputing.Members.Add(computeFormulaCode);
            return compileUnit;
        }
        #endregion

        public static int GetRandomValue(int min, int max) // = 0 = 1000)
        {
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomValue = rnd.Next(min, max);
            return randomValue;
        }

        public static int GetRandomValueLength(int length) // = 0 = 1000)
        {
            string randomValueText = "";
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomValue = 0;
            for (int cpt = 0; cpt < length; cpt++)
            {
                int temp = rnd.Next(0, 9);
                randomValueText += temp.ToString();
            }
            int.TryParse(randomValueText, out randomValue);
            return randomValue;
        }

        public static Enums.MathOperation GetRandomOperation(int min = 1, int max = 4)
        {
            Enums.MathOperation operation;
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomValue = rnd.Next(min, max);
            switch (randomValue)
            {
                case 1:
                    operation = Enums.MathOperation.Addition;
                    break;
                case 2:
                    operation = Enums.MathOperation.Substraction;
                    break;
                case 3:
                    operation = Enums.MathOperation.Multiplication;
                    break;
                case 4:
                    operation = Enums.MathOperation.Division;
                    break;
                default:
                    operation = Enums.MathOperation.Addition;
                    break;
            }

            return operation;
        }

        public static Enums.MathFunctionWith1Parameter GetRandomMathFunctionWith1Parameter(int min = (int)Enums.MathFunctionWith1Parameter.Abs, int max = (int)Enums.MathFunctionWith1Parameter.Truncate)
        {
            Enums.MathFunctionWith1Parameter operation;
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomValue = rnd.Next(min, max);
            operation = (Enums.MathFunctionWith1Parameter)randomValue;
            return operation;
        }

        public static Enums.MathFunctionWith2Parameters GetRandomMathFunctionWith2Parameters(int min = (int)Enums.MathFunctionWith2Parameters.Log, int max = (int)Enums.MathFunctionWith2Parameters.Pow)
        {
            Enums.MathFunctionWith2Parameters operation;
            Random rnd = new Random(DateTime.Now.Millisecond);
            int randomValue = rnd.Next(min, max);
            operation = (Enums.MathFunctionWith2Parameters)randomValue;
            return operation;
        }

    }
}
