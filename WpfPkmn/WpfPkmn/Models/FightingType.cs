using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class FightingType : PkmnType
    {
        public FightingType() : base("Combat") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is NormalType || target is IceType || target is RockType || target is DarkType || target is SteelType) return 2.0;
            if (target is PoisonType || target is FlyingType || target is PsychicType || target is BugType || target is FairyType) return 0.5;
            if (target is GhostType) return 0.0;
            return 1.0;
        }
    }
}
