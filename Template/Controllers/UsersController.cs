using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using Template.Application.Interfaces;
using Template.Application.Services;
using Template.Application.ViewModels.Users;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.ViewModels;

namespace Template.Controllers
{
    [Route("api/[controller]"), ApiController]
	public class UsersController : ControllerBase
	{
        private readonly IUserService service;
        private readonly IAuthService authService;

        public UsersController(IUserService service, IAuthService authService)
        {
            this.service = service;
            this.authService = authService;
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Post(UserRequestCreateAccountViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(service.Post(user, Request.Host.Value));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("authenticate"), AllowAnonymous]
        public IActionResult Authenticate(UserRequestAuthenticateViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(service.Authenticate(user));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("forgot-password/{email}"), AllowAnonymous]
        public IActionResult ForgotPassword(string email)
        {
            try
            {
                return Ok(service.ForgotPassword(email));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("change-password"), AllowAnonymous]
        public IActionResult ChangePassword(UserRequestChangePasswordViewModel user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(service.ChangePassword(user));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("activate/{userId}")]
        public IActionResult ActivateUser(int userId)
        {
            try
            {
                ContextUserViewModel _user = authService.GetLoggedUser();
                if (_user == null || !UtilsService.IsAdmin(_user.Profile))
                    return Unauthorized();

                return Ok(service.ActivateUser(userId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("deactivate/{userId}")]
        public IActionResult DeactivateUser(int userId)
        {
            try
            {
                ContextUserViewModel _user = authService.GetLoggedUser();
                if (_user == null || !UtilsService.IsAdmin(_user.Profile))
                    return Unauthorized();

                return Ok(service.DeactivateUser(userId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{userId}")]
        public IActionResult GetById(int userId)
        {
            try
            {
                ContextUserViewModel _user = authService.GetLoggedUser();
                if (_user == null || !UtilsService.IsAdmin(_user.Profile))
                    return Unauthorized();

                return Ok(service.GetById(userId));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("activate/{email}/{code}"), AllowAnonymous]
        public IActionResult ActivateByEmail(string email, string code)
        {
            try
            {
                service.ActivateByEmail(email, code);
                return Redirect("https://" + Request.Host.Value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                ContextUserViewModel _user = authService.GetLoggedUser();
                if (_user == null || !UtilsService.IsAdmin(_user.Profile))
                    return Unauthorized();

                return Ok(service.Get());
            }
            catch (Exception)
            {
                throw;
            }
        }



        [HttpPut]
        public IActionResult Put(UserUpdateAccount user)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                return Ok(service.Put(user));
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
