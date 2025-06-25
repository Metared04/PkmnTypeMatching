using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class GhostType : PkmnType
    {
        public GhostType() : base("Spectre") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is PsychicType || target is GhostType) return 2.0;
            if (target is DarkType) return 0.5;
            if (target is NormalType) return 0.0;
            return 1.0;
        }
    }
}
