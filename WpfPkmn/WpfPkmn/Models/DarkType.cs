using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class DarkType : PkmnType
    {
        public DarkType() : base("Ténèbre") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is PsychicType || target is GhostType) return 2.0;
            if (target is FightingType || target is DarkType || target is FairyType) return 0.5;
            return 1.0;
        }
    }
}
