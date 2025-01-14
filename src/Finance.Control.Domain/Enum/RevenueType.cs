using System.ComponentModel;

namespace Finance.Control.Domain.Enum
{
    public enum AccountStatus
    {
        [Description("Pendente")]
        Pendente,

        [Description("Pago")]
        Pago,

        [Description("Vencido")]
        Vencido
    }

}
