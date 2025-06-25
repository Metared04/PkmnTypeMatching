using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfPkmn.Interfaces;

namespace Pkmn.Models
{
    public class Pokemon
    {
        public IPkmnType Type1 { get; }
        public IPkmnType Type2 { get; }
        public Pokemon(IPkmnType type1, IPkmnType type2 = null)
        {
            Type1 = type1; Type2 = type2;
        }
        public double GetEffectiveness(IPkmnType attackerType)
        {
            double mult = attackerType.GetEffectivenessAgainst(Type1);
            if (Type2 != null)
            {
                mult *= attackerType.GetEffectivenessAgainst(Type2);
            }
            return mult;
        }
    }
}
