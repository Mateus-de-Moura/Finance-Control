using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Application.Common.Models
{
    public sealed record GetPagedRequest(int PageNumber = 1, int PageSize = 10, string Name = null);

}
