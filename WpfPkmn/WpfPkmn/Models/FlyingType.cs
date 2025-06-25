using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class FlyingType : PkmnType
    {
        public FlyingType() : base("Vol") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is GrassType || target is FightingType || target is BugType) return 2.0;
            if (target is ElectricType || target is RockType || target is SteelType) return 0.5;
            return 1.0;
        }
    }
}
