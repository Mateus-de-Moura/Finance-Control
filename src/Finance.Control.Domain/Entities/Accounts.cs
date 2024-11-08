using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Domain.Entities
{
    public class Accounts
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string CodePayment { get; set; }
        public DateTime Maturity { get; set; }
        public DateTime Emission { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public double Value { get; set; }
    }
}
