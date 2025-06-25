using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class BugType : PkmnType
    {
        public BugType() : base("Insecte") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is GrassType || target is PsychicType || target is DarkType) return 2.0;
            if (target is FireType || target is FightingType || target is PoisonType || target is FlyingType || target is GhostType || target is SteelType || target is FairyType) return 0.5;
            return 1.0;
        }
    }
}
