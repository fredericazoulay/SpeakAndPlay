using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Data;

//namespace SpeakAndSpell.Helpers
//{
//    class Calculator
//    {
//    }
//}


//namespace Calculatrice.Tools.Converter
namespace SpeakAndSpell.Helpers
{
    // IValueConverter
    // Does a math equation on the bound value.
    // Use @VALUE in your mathEquation as a substitute for bound value

    // IMultiValueConverter
    // Does a math equation on a series of bound values. 
    // Use @VALUEN in your mathEquation as a substitute for bound values, where N is the 0-based index of the bound value

    // both can use most functions from System.Math, named as in the class (Abs(x), Cos(x), Pow(x,y), etc.)
    // spaces are optional
    // a cache store all results, but if count > 100 results, keep results for 30s since last use

    public class MathConverter : IValueConverter, IMultiValueConverter
    {
        private static Dictionary<String, KeyValuePair<Double, DateTime>> _cache = new Dictionary<String, KeyValuePair<Double, DateTime>>();

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Convert(new object[] { value }, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IMultiValueConverter Members

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            // Remove spaces
            var mathEquation = parameter as string;
            mathEquation = mathEquation.Replace(" ", "");

            // Loop through values to substitute placeholders for values
            // Using a backwards loop to avoid replacing something like @VALUE10 with @VALUE1
            for (var i = (values.Length - 1); i >= 0; i--)
                mathEquation = mathEquation.Replace(string.Format("@VALUE{0}", i), values[i].ToString());
            //case from IValueConverter.Convert(...) @VALUE == @VALUE0
            mathEquation = mathEquation.Replace("@VALUE", "(" + values[0].ToString() + ")");

            KeyValuePair<Double, DateTime> found;
            if (_cache.TryGetValue(mathEquation, out found))
            {
                _cache[mathEquation] = new KeyValuePair<Double, DateTime>(found.Key, DateTime.Now);
                return found.Key;
            }
            if (_cache.Count > 100)
                _cache.Where(e => (DateTime.Now - e.Value.Value).TotalSeconds > 30.0).ToList().ForEach(e => _cache.Remove(e.Key));

            var result = MathConverterHelpers.EvalExpression(mathEquation);
            _cache.Add(mathEquation, new KeyValuePair<double, DateTime>(result, DateTime.Now));
            // Return result of equation
            return result;
            //return MathConverterHelpers.RunEquation(ref mathEquation);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

    public static class MathConverterHelpers
    {
        private static readonly char[] _allOperators = new[] { '+', '-', '*', '/', '%', '(', ')', ',' };
        private static Dictionary<String, Func<Double, Double>> _unaryFunctions = new Dictionary<String, Func<Double, Double>>()
        {
            { "Abs", new Func<Double, Double>((x) => Math.Abs(x)) },
            { "Cos", new Func<Double, Double>((x) => Math.Cos(x)) },
            { "Cosh", new Func<Double, Double>((x) => Math.Cosh(x)) },
            { "Sin", new Func<Double, Double>((x) => Math.Sin(x)) },
            { "Sinh", new Func<Double, Double>((x) => Math.Sinh(x)) },
            { "Tan", new Func<Double, Double>((x) => Math.Tan(x)) },
            { "Acos", new Func<Double, Double>((x) => Math.Acos(x)) },
            { "Asin", new Func<Double, Double>((x) => Math.Asin(x)) },
            { "Atan", new Func<Double, Double>((x) => Math.Atan(x)) },
            { "Ceil", new Func<Double, Double>((x) => Math.Ceiling(x)) },
            { "Floor", new Func<Double, Double>((x) => Math.Floor(x)) },
            { "Round", new Func<Double, Double>((x) => Math.Round(x)) },
            { "Exp", new Func<Double, Double>((x) => Math.Exp(x)) },
            { "Log", new Func<Double, Double>((x) => Math.Log(x)) },
            { "Log10", new Func<Double, Double>((x) => Math.Log10(x)) },
            { "Sign", new Func<Double, Double>((x) => Math.Sign(x)) },
            { "Truncate", new Func<Double, Double>((x) => Math.Truncate(x)) },
        };
        private static Dictionary<String, Func<Double, Double, Double>> _binaryFunctions = new Dictionary<String, Func<Double, Double, Double>>()
        {
            { "Log", new Func<Double, Double, Double>((x,y) => Math.Log(x,y)) },
            { "Atan2", new Func<Double, Double, Double>((x,y) => Math.Atan2(x,y)) },
            { "Max", new Func<Double, Double, Double>((x,y) => Math.Max(x,y)) },
            { "Min", new Func<Double, Double, Double>((x,y) => Math.Min(x,y)) },
            { "Pow", new Func<Double, Double, Double>((x,y) => Math.Pow(x,y)) },
        };

        public static string ConvertMathEquation(string parameter)
        {
            // Remove spaces
            var mathEquation = parameter as string;
            mathEquation = mathEquation.Replace(" ", "");

            // Loop through values to substitute placeholders for values
            // Using a backwards loop to avoid replacing something like @VALUE10 with @VALUE1
//            for (var i = (values.Length - 1); i >= 0; i--)
//                mathEquation = mathEquation.Replace(string.Format("@VALUE{0}", i), values[i].ToString());
//            //case from IValueConverter.Convert(...) @VALUE == @VALUE0
//            mathEquation = mathEquation.Replace("@VALUE", "(" + values[0].ToString() + ")");

            //KeyValuePair<Double, DateTime> found;
            //if (_cache.TryGetValue(mathEquation, out found))
            //{
            //    _cache[mathEquation] = new KeyValuePair<Double, DateTime>(found.Key, DateTime.Now);
            //    return found.Key;
            //}
            //if (_cache.Count > 100)
            //    _cache.Where(e => (DateTime.Now - e.Value.Value).TotalSeconds > 30.0).ToList().ForEach(e => _cache.Remove(e.Key));

            var result = MathConverterHelpers.EvalExpression(mathEquation);
            //_cache.Add(mathEquation, new KeyValuePair<double, DateTime>(result, DateTime.Now));
            // Return result of equation
            return mathEquation; // result;
            //return MathConverterHelpers.RunEquation(ref mathEquation);
        }

        public static double EvalExpression(string expression)
        {
            double result = SumExpression(ref expression);
            if (expression.Length > 0)
                throw new Exception("unexpected token");
            return result;
        }

        private static double SumExpression(ref string expression)
        {
            // (['-'])? FactorExpr ((['+']|['-']) FactorExpr)*
            double operand;
            if (expression.First() == '-')
            {
                // unary minus
                expression = expression.Remove(0, 1);
                operand = -FactorExpression(ref expression);
            }
            else
                operand = FactorExpression(ref expression);

            while (expression.Length > 0)
            {
                var op = expression.First();
                if (op == '-' || op == '+')
                {
                    switch (op)
                    {
                        case '+':
                            expression = expression.Remove(0, 1);
                            operand += FactorExpression(ref expression);
                            break;
                        case '-':
                            expression = expression.Remove(0, 1);
                            operand -= FactorExpression(ref expression);
                            break;
                    }
                }
                else
                    break;
            }
            return operand;
        }

        private static double FactorExpression(ref string expression)
        {
            // ParenthesisExpr ((['*']|['/']|['%']) ParenthesisExpr)*
            var operand = ParenthesisExpression(ref expression);
            while (expression.Length > 0)
            {
                var op = expression.First();
                if (op == '*' || op == '/' || op == '%')
                {
                    switch (op)
                    {
                        case '*':
                            expression = expression.Remove(0, 1);
                            operand *= ParenthesisExpression(ref expression);
                            break;
                        case '/':
                            expression = expression.Remove(0, 1);
                            operand /= ParenthesisExpression(ref expression);
                            break;
                        case '%':
                            expression = expression.Remove(0, 1);
                            operand %= ParenthesisExpression(ref expression);
                            break;
                    }
                }
                else
                    break;
            }
            return operand;
        }

        private static double ParenthesisExpression(ref string expression)
        {
            // unaryFunc | binaryFunc | (['('] SumExpr [')']) | double

            foreach (var func in _unaryFunctions)
            {
                if (expression.StartsWith(func.Key + "("))
                {
                    expression = expression.Remove(0, func.Key.Length);
                    return func.Value.Invoke(ParenthesisExpression(ref expression));
                }
            }
            foreach (var func in _binaryFunctions)
            {
                if (expression.StartsWith(func.Key + "("))
                {
                    expression = expression.Remove(0, func.Key.Length + 1 /*func(*/);
                    var op1 = SumExpression(ref expression);
                    if (expression.First() != ',')
                        throw new Exception("Expecting token ','");
                    expression = expression.Remove(0, 1);
                    var op2 = SumExpression(ref expression);
                    if (expression.First() != ')')
                        throw new Exception("Expecting token ')'");
                    expression = expression.Remove(0, 1);
                    return func.Value.Invoke(op1, op2);
                }
            }

            if (expression.First() == '(')
            {
                expression = expression.Remove(0, 1);
                double result = SumExpression(ref expression);
                if (expression.First() == ')')
                {
                    expression = expression.Remove(0, 1);
                    return result;
                }
                else
                    throw new Exception("Expected token ')'");
            }
            else // Double
            {
                string tmp = "";
                foreach (char c in expression)
                {
                    if (c != '-' && _allOperators.Contains(c))
                        break;
                    else
                        tmp += c;
                }
                if (tmp.Length == 0)
                    throw new Exception("Expecting double");
                expression = expression.Remove(0, tmp.Length);
                return double.Parse(tmp);
            }
        }
    }
}