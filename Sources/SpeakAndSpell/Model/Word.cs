using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakAndSpell.Model
{
    public class Word
    {
        public int? ID { get; set; }

        // Word
        public string Word_French { get; set; }
        public string Word_English { get; set; }
        public string Word_Italian { get; set; }
        public string Word_Spanish { get; set; }
        public string Word_Portuguese { get; set; }

        // Pronoun
        public string Pronoun_French { get; set; }
        public string Pronoun_English { get; set; }
        public string Pronoun_Italian { get; set; }
        public string Pronoun_Spanish { get; set; }
        public string Pronoun_Portuguese { get; set; }

        // Sentence
        public string Sentence_French { get; set; }
        public string Sentence_English { get; set; }
        public string Sentence_Italian { get; set; }
        public string Sentence_Spanish { get; set; }
        public string Sentence_Portuguese { get; set; }

        // ToDisplay
        public string Word_ToDisplay_French { get; set; }
        public string Word_ToDisplay_English { get; set; }
        public string Word_ToDisplay_Italiah { get; set; }
        public string Word_ToDisplaySpanish { get; set; }
        public string Word_ToDisplay_Portuguese { get; set; }

        // Others
        public string Word_Response { get; set; }
        public string Word_Answer { get; set; }
        
        public string Word_Picture { get; set; }
        public string Word_IsVerb { get; set; }
        public string Word_IsNoun { get; set; }
        public string Word_IsPronoun { get; set; }
    }
}
