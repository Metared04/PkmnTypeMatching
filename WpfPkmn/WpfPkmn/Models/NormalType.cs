using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class NormalType : PkmnType
    {
        public NormalType() : base("Normal") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is SteelType || target is RockType) return 0.5;
            if (target is GhostType) return 0.0;
            return 1.0;
        }
    }
}
