using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class FairyType : PkmnType
    {
        public FairyType() : base("Fée") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is FightingType || target is DragonType || target is DarkType) return 2.0;
            if (target is FireType || target is PoisonType || target is SteelType) return 0.5;
            return 1.0;
        }
    }
}
