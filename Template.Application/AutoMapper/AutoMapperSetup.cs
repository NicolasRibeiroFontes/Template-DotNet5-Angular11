using Template.Application.Services;
using Template.Application.ViewModels.Modules;
using Template.Application.ViewModels.Profiles;
using Template.Application.ViewModels.Users;
using Template.Domain.Entities;
using Profile = AutoMapper.Profile;
using ProfileUser = Template.Domain.Entities.Profile;

namespace Template.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {

            #region "ViewModel To Domain"

            CreateMap<UserRequestCreateAccountViewModel, User>()
                .ForMember(x => x.Password, y => y.MapFrom(m => UtilsService.EncryptPassword(m.Password)));

            #endregion

            #region "Domain to ViewModel"

            CreateMap<User, UserViewModel>();
            CreateMap<User, UserResponseListViewModel>();
            CreateMap<User, UserResponseAuthenticateViewModel>();
            CreateMap<ProfileUser, ProfileViewModel>();
            CreateMap<Module, ModuleViewModel>();

            #endregion
        }
    }
}
