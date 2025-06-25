using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class SteelType : PkmnType
    {
        public SteelType() : base("Acier") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is IceType || target is RockType || target is FairyType) return 2.0;
            if (target is FireType || target is ElectricType || target is SteelType || target is WaterType) return 0.5;
            return 1.0;
        }
    }
}
