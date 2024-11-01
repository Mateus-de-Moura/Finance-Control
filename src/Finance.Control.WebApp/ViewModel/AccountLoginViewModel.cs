using System.ComponentModel.DataAnnotations;

namespace Finance.Control.webApp.ViewModel
{
    public class AccountLoginViewModel
    {
        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Mantenha-me conectado")]
        public bool RememberMe { get; set; }
    }
}
