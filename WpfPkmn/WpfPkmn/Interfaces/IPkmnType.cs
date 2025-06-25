using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfPkmn.Interfaces
{
    public interface IPkmnType
    {
        string PkmnTypeName { get; }
        double GetEffectivenessAgainst(IPkmnType target);
    }
}
