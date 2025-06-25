using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class GrassType : PkmnType
    {
        public GrassType() : base("Plante") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is WaterType || target is GroundType || target is RockType) return 2.0;
            if (target is GrassType || target is FireType || target is PoisonType || target is FlyingType || target is BugType || target is DragonType || target is SteelType) return 0.5;
            return 1.0;
        }
    }
}
