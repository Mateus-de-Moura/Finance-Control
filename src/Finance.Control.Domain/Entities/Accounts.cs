using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Control.Domain.Enum;

namespace Finance.Control.Domain.Entities
{
    public class Accounts
    {
        public Guid Id { get; set; }
        public bool Active { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public Guid CategoryId { get; set; }
        public AccountStatus Status { get; set; }
        public byte[] ProofOfPaymenyt { get; set; }
        public DateTime MaturityDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Category Category { get; set; }
    }
}
