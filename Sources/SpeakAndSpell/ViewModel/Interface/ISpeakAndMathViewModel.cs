using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakAndSpell.ViewModel.Interface
{
    public interface ISpeakAndMathViewModel
    {
        int? ID { get; set; }
        string Line1 { get; set; }
        string Line2 { get; set; }
        string Line3 { get; set; }
        string Line4 { get; set; }
        string Line5 { get; set; }
        string Line6 { get; set; }
        string Line7 { get; set; }
        string Line8 { get; set; }
        string Line9 { get; set; }

        //string Word_Fr { get; set; }
        //string Word_En { get; set; }
        //string Word_Response { get; set; }
        //string Word_Picture { get; set; }
    }
}
