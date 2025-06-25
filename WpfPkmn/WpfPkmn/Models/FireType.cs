using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class FireType : PkmnType
    {
        public FireType() : base("Feu") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is GrassType || target is IceType || target is BugType || target is SteelType) return 2.0;
            if (target is FireType || target is RockType || target is WaterType || target is DragonType) return 0.5;
            return 1.0;
        }
    }
}
