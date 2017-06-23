using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeakAndSpell.ViewModel.Interface;
using SpeakAndSpell.Model;

namespace SpeakAndSpell.ViewModel.Design
{
    public class DesignSpeakAndMathViewModel : ISpeakAndMathViewModel
    {
        public int? ID
        {
            get { return 1; }
            set { }
        }

        //public Number DisplayNumber
        //{
        //    get { return "BONJOUR"; }
        //    set { }
        //}

        public string Line1
        {
            get
            { return "HELLO : 2 + 1 = ?";
            }
            set { }
        }

        public string Line2
        {
            get
            { return "Deux + Un = ? | Two + One = ?";
            }
            set { }
        }

        public string Line3
        {
            get
            { return "------------------------------------------------------------";
            }
            set { }
        }

        public string Line4
        {
            get
            { return "3";
            }
            set { }
        }

        public string Line5
        {
            get
            { return "Trois | Three";
            }
            set { }
        }

        public string Line6
        {
            get
            { return "------------------------------------------------------------";
            }
            set { }
        }

        public string Line7
        {
            get
            { return "Incorrect. Essaie encore. | Wrong answer. Try again.";
            }
            set { }
        }

        public string Line8
        {
            get
            { return "------------------------------------------------------------";
            }
            set { }
        }

        public string Line9
        {
            get
            {
                return "REPONSE";
            }
            set { }
        }


        //public string Word_En
        //{
        //    get { return "HELLO"; }
        //    set { }
        //}
        //
        //public string Word_Picture
        //{
        //    get { return @"..\Resources\SpeakAndSpellSpeaker.jpg"; }
        //    set { }
        //}
        //
        //public string Word_Response
        //{
        //    get { return "B"; }
        //    set { }
        //}
    }
}
