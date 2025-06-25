using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class GroundType : PkmnType
    {
        public GroundType() : base("Sol") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is FireType || target is ElectricType || target is PoisonType || target is RockType || target is SteelType) return 2.0;
            if (target is GrassType || target is BugType) return 0.5;
            if (target is FlyingType) return 0.0;
            return 1.0;
        }
    }
}
