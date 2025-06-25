using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class RockType : PkmnType
    {
        public RockType() : base("Roche") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is IceType || target is FlyingType || target is BugType || target is FireType) return 2.0;
            if (target is FightingType || target is GroundType || target is SteelType) return 0.5;
            return 1.0;
        }
    }
}
