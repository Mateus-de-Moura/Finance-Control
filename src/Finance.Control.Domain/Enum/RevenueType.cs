using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Domain.Enum
{
    public enum RevenueType
    {
        [Description("A vencer")]
        AVencer = 1,

        [Description("Vencida")]
        Vencida = 2,

        [Description("Paga")]
        Paga = 3
    }

}
