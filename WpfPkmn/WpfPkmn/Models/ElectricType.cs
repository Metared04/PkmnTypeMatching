using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class ElectricType : PkmnType
    {
        public ElectricType() : base("Electrik") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is WaterType || target is FlyingType) return 2.0;
            if (target is GrassType || target is ElectricType || target is DragonType) return 0.5;
            if (target is GroundType) return 0.0;
            return 1.0;
        }
    }
}
