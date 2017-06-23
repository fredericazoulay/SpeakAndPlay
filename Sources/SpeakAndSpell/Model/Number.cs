using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeakAndSpell.Helpers.Enums;

namespace SpeakAndSpell.Model
{
    public class Number
    {
        public int? ID { get; set; }

        // int
        public double Number_1 { get; set; }
        public Enums.MathOperation Number_operation { get; set; }
        public double Number_2 { get; set; }
        public double Number_result { get; set; }
        public string Number_equation { get; set; }
        public string Number_equation_LessOrGreaterOrEqual { get; set; }
        public string Number_result_LessOrGreaterOrEqual { get; set; }

        // French
        public string Number_1_French { get; set; }
        public string Number_operation_French { get; set; }
        public string Number_2_French { get; set; }
        public string Number_result_French { get; set; }
        public string Number_equation_French { get; set; }

        // English
        public string Number_1_English { get; set; }
        public string Number_operation_English { get; set; }
        public string Number_2_English { get; set; }
        public string Number_result_English { get; set; }
        public string Number_equation_English { get; set; }

        // Italian
        public string Number_1_Italian { get; set; }
        public string Number_operation_Italian { get; set; }
        public string Number_2_Italian { get; set; }
        public string Number_result_Italian { get; set; }
        public string Number_equation_Italian { get; set; }

        // Spanish
        public string Number_1_Spanish { get; set; }
        public string Number_operation_Spanish { get; set; }
        public string Number_2_Spanish { get; set; }
        public string Number_result_Spanish { get; set; }
        public string Number_equation_Spanish { get; set; }

        // Portuguese
        public string Number_1_Portuguese { get; set; }
        public string Number_operation_Portuguese { get; set; }
        public string Number_2_Portuguese { get; set; }
        public string Number_result_Portuguese { get; set; }
        public string Number_equation_Portuguese { get; set; }

        // German
        public string Number_1_German { get; set; }
        public string Number_operation_German { get; set; }
        public string Number_2_German { get; set; }
        public string Number_result_German { get; set; }
        public string Number_equation_German { get; set; }
    }
}
