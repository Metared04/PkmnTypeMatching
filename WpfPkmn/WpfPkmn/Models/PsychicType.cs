using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class PsychicType : PkmnType
    {
        public PsychicType() : base("Psy") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is FightingType || target is PoisonType) return 2.0;
            if (target is PsychicType || target is SteelType) return 0.5;
            if (target is DarkType) return 0.0;
            return 1.0;
        }
    }
}
