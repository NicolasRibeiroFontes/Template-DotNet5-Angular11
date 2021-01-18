using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Application.Interfaces;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.ViewModels;

namespace Template.Controllers
{
	[Route("api/[controller]"), ApiController]
	public class ProfilesController : ControllerBase
	{
        private readonly IProfileService service;
        private readonly IAuthService authService;

        public ProfilesController(IProfileService service, IAuthService authService)
        {
            this.service = service;
            this.authService = authService;
        }

    }
}
