using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpeakAndSpell.ViewModel.Interface;

namespace SpeakAndSpell.ViewModel.Design
{
    public class DesignSpeakAndSpellViewModel : ISpeakAndSpellViewModel
    {
        public int? ID
        {
            get { return 1; }
            set { }
        }

        public string Word_Fr
        {
            get { return "BONJOUR"; }
            set { }
        }

        public string Word_En
        {
            get { return "HELLO"; }
            set { }
        }

        public string Word_Picture
        {
            get { return @"..\Resources\SpeakAndSpellSpeaker.jpg"; }
            set { }
        }

        public string Word_Response
        {
            get { return "B"; }
            set { }
        }
    }
}
