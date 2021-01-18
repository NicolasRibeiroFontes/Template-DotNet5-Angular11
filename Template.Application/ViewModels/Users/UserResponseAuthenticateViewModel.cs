namespace Template.Application.ViewModels.Users
{
    public class UserResponseAuthenticateViewModel : EntityViewModel
	{
		public string Name { get; set; }
		public string Email { get; set; }
		public string Profile { get; set; }
		public string Token { get; set; }
	}
}
