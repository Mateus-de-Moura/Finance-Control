using Finance.Control.Application.Dtos;
using Finance.Control.webApp.ViewModel;

namespace Finance.Control.webApp.Mappers
{
    public static class AppUserViewModelMapper
    {
        //public static AppUserViewModel MapDToToViewModel(this AppUserDto model)
        //{


        //}

        public static AppUserDto MapViewModelToDto(this AppUserViewModel model)
        {
            return new AppUserDto
            {
                IsActive = model.IsActive,
                Name = model.Name,
                Email = model.Email,
                PassWord = model.PassWord,
                ConfirmPassWord = model.ConfirmPassWord,
                AppRoleId = model.AppRoleId,
            };

        }
    }
}
