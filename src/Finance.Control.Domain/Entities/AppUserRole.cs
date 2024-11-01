using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Domain.Entities
{
    public sealed class AppUserRole
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid AppUserId { get; set; }
        public AppUser User { get; set; }
        public string Role { get; set; }
    }
}
