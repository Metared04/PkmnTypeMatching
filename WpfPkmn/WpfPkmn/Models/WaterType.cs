using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class WaterType : PkmnType
    {
        public WaterType() : base("Eau") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is FireType || target is GroundType || target is RockType) return 2.0;
            if (target is GrassType || target is WaterType || target is DragonType) return 0.5;
            return 1.0;
        }
    }
}
