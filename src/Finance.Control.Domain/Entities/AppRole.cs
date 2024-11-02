using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Domain.Entities
{
    public sealed class AppRole
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<AppUser> appUsers { get; set; }
    }
}
