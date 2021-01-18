﻿using System.ComponentModel.DataAnnotations;

namespace Template.Application.ViewModels.Users
{
    public class UserRequestChangePasswordViewModel
	{
		[Required]
		public string Email { get; set; }
		[Required]
		public string Code { get; set; }
		[Required]
		public string Password { get; set; }
		[Required]
		public string PasswordConfirm { get; set; }
	}
}
