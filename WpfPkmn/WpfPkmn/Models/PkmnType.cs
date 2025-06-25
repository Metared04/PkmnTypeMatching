using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    public abstract class PkmnType : IPkmnType
    {
        public string PkmnTypeName { get; }
        protected PkmnType(string name) { PkmnTypeName = name; }
        public abstract double GetEffectivenessAgainst(IPkmnType target);
    }
}
