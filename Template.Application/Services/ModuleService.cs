using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using Template.Application.Interfaces;
using Template.Application.ViewModels.Modules;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Application.Services
{
	public class ModuleService: IModuleService
	{
		private readonly IMapper mapper;
		private readonly IModuleRepository repository;

		public ModuleService(IModuleRepository repository, IMapper mapper)
		{
			this.repository = repository;
			this.mapper = mapper;
		}

		public List<ModuleViewModel> GetByProfile(int profileId)
		{
			IQueryable<Module> _modules = repository.GetByProfileId(profileId);

			return mapper.Map<List<ModuleViewModel>>(_modules);
		}
	}
}
