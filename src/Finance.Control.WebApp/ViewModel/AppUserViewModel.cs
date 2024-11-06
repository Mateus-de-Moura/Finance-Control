using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Finance.Control.webApp.ViewModel
{
    public class AppUserViewModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string PassWord { get; set; }

        [Required]
        [Compare("PassWord", ErrorMessage = "A senha e a confirmação da senha não coincidem.")]
        public string ConfirmPassWord { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid AppRoleId { get; set; }

        public List<SelectListItem> AppRoleSelectListItems { get; set; } = new List<SelectListItem>();
    }
}
