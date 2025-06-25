using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace WpfPkmn.ViewModels
{
    public class OptionItem
    {
        public string Label { get; set; }
        public IPkmnType Value { get; set; }

        public OptionItem(string label, IPkmnType value)
        {
            Label = label;
            Value = value;
        }
    }
}
