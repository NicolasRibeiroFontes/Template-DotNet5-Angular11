using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Template.Application.Interfaces;

namespace Template.UnitTests.Application.Services
{
    [TestClass]
    public class UserServiceTest
    {
        Mock<IUserService> userService = new Mock<IUserService>();

        public void Test()
		{
            //userService.Setup
		}
    }
}
