using Finance.Control.Application.Dtos;
using Finance.Control.webApp.ViewModel;

namespace Finance.Control.webApp.Mappers
{
    public static class AppUserViewModelMapper
    {
        public static AppUserViewModel MapDToToViewModel(this AppUserDto model)
        {
            return new AppUserViewModel
            {
                IsActive = model.IsActive,
                Name = model.Name,
                Email = model.Email,
                PassWord = model.PassWord,
                ConfirmPassWord = model.ConfirmPassWord,
                AppRoleId = model.AppRoleId,
            };

        }

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


        public static AppUserViewModel MapAppUserResponseToViewModel(this AppUserResponseDto model)
        {
            return new AppUserViewModel
            {
                IsActive = model.IsActive,
                Name = model.Name,
                Email = model.Email,              
                AppRoleId = model.AppRoleId,
            };

        }
    }
}
