using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Control.Domain.Entities
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; }

        [BindProperty]
        public bool Active { get; set; }

        public string Name { get; set; }
        public string Type { get; set; }
    }
}
