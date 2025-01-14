using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Finance.Control.webApp.ViewModel
{
    public class AccountsPayableViewModel
    {
        public bool Active { get; set; }

        [Required(ErrorMessage = "Descrição Obrigatória.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Valor Obrigatório.")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "Vencimento Obrigatório.")]
        public DateTime MaturityDate { get; set; }

        public Guid CategoryId { get; set; }

        [Required(ErrorMessage = "Status Obrigatório.")]
        public string status { get; set; }

        [ValidateNever]
        public SelectList SelectListStatus { get; set; }

        [ValidateNever]
        public SelectList SelectListCategory { get; set; }
    }
}
