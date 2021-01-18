using Template.Application.ViewModels.Profiles;

namespace Template.Application.ViewModels.Users
{
    public class UserResponseListViewModel : EntityViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public bool IsAuthorised { get; set; }
        public ProfileViewModel Profile { get; set; }
    }
}
