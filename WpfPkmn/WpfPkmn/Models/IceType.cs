using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class IceType : PkmnType
    {
        public IceType() : base("Glace") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is GrassType || target is GroundType || target is FlyingType || target is DragonType) return 2.0;
            if (target is FireType || target is WaterType || target is IceType || target is SteelType) return 0.5;
            return 1.0;
        }
    }
}
