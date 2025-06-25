using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    class DragonType : PkmnType
    {
        public DragonType() : base("Dragon") { }
        public override double GetEffectivenessAgainst(IPkmnType target)
        {
            if (target is DragonType) return 2.0;
            if (target is SteelType) return 0.5;
            if (target is FairyType) return 0.0;
            return 1.0;
        }
    }
}
