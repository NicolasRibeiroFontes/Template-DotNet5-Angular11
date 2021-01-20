using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Template.Application.AutoMapper;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.ExceptionHandler.Extensions;
using Template.CrossCutting.Notification.Interfaces;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Test.Application.Services
{
	[TestClass]
	public class UserServiceTest
	{
		private readonly Mock<IUserRepository> userRepository = new Mock<IUserRepository>();
		private Mock<IMapper> mapper = new Mock<IMapper>();		
		private readonly Mock<ITokenService> tokenService = new Mock<ITokenService>();
		private readonly Mock<IEmailSender> emailSender = new Mock<IEmailSender>();
		private readonly Mock<IProfileRepository> profileRepository = new Mock<IProfileRepository>();
		private UserService userService;

		[TestInitialize()]
		public void MyTestInitialize()
		{
			userService = new UserService(mapper.Object, tokenService.Object, emailSender.Object, userRepository.Object, profileRepository.Object);
		}

		[TestMethod]
		public void SaveEmailInvalid()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel { Email = "test" };
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("The e-mail is invalid", exception.Message);
		}

		[TestMethod]
		public void SavePasswordEmpty()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel
			{
				Email = "test@test.com",
				Password = "",
				PasswordConfirm = ""
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Password and Confirm Password are required fields", exception.Message);
		}

		[TestMethod]
		public void SavePasswordDoesntMatch()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel
			{
				Email = "test@test.com",
				Password = "12345678",
				PasswordConfirm = "123456"
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Password doesn't match", exception.Message);
		}

		[TestMethod]
		public void SavePasswordLengthLowerThan8()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel
			{
				Email = "test@test.com",
				Password = "123456",
				PasswordConfirm = "123456"
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Password must contains more than 8 characters.", exception.Message);
		}

		[TestMethod]
		public void SavePasswordNoLetters()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel { 
				Email = "test@test.com", Password = "12345678", PasswordConfirm = "12345678"
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Password must contains 1 letter at least.", exception.Message);
		}

		[TestMethod]
		public void SavePasswordNoNumbers()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel
			{
				Email = "test@test.com",
				Password = "ABCDEFGH",
				PasswordConfirm = "ABCDEFGH"
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Password must contains 1 number at least.", exception.Message);
		}

		[TestMethod]
		public void SavePasswordNoSpecialCharacters()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel
			{
				Email = "test@test.com",
				Password = "ABCDEFGH123",
				PasswordConfirm = "ABCDEFGH123"
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Password must contains 1 special character at least.", exception.Message);
		}

		[TestMethod]
		public void SaveWithoutDefaultProfile()
		{
			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel
			{
				Email = "test@test.com",
				Password = "ABCDEFGH123!",
				PasswordConfirm = "ABCDEFGH123!"
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Your account can't be registered because there is no default profile.", exception.Message);
		}

		//[TestMethod] - Commented because Mock for AutoMapper is not working.
		public void SaveWithDefaultProfile()
		{
			profileRepository.Setup(x => x.GetDefault()).Returns(new Domain.Entities.Profile
			{
				Id = 1,
				Name = "Default"
			});

			mapper.Setup(m => m.Map<UserRequestCreateAccountViewModel, User>(It.IsAny<UserRequestCreateAccountViewModel>()))
					.Returns(new User());		

			UserRequestCreateAccountViewModel userRequest = new UserRequestCreateAccountViewModel
			{
				Email = "test@test.com",
				Password = "ABCDEFGH123!",
				PasswordConfirm = "ABCDEFGH123!"
			};
			ApiException exception = Assert.ThrowsException<ApiException>(() => userService.Post(userRequest, ""));

			Assert.AreEqual("Your account can't be registered because there is no default profile.", exception.Message);
		}
	}
}
