using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class PoisonType : PkmnType
    {
        public PoisonType() : base("Poison") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is GrassType || target is FairyType) return 2.0;
            if (target is PoisonType || target is GroundType || target is RockType || target is GhostType) return 0.5;
            if (target is SteelType) return 0.0;
            return 1.0;
        }
    }
}
