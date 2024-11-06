using System.ComponentModel.DataAnnotations;

namespace Finance.Control.Application.Dtos
{
    public class AppUserDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public bool IsActive { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string ConfirmPassWord { get; set; }
        public Guid AppRoleId { get; set; }          
    }
}
