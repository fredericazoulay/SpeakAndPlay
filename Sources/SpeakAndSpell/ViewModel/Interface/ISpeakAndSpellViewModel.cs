using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeakAndSpell.ViewModel.Interface
{
    public interface ISpeakAndSpellViewModel
    {
        int? ID { get; set; }
        string Word_Fr { get; set; }
        string Word_En { get; set; }
        string Word_Response { get; set; }
        string Word_Picture { get; set; }
    }
}
