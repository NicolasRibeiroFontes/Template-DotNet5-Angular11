using System.Collections.Generic;
using Template.Application.ViewModels.Modules;

namespace Template.Application.Interfaces
{
	public interface IModuleService
	{
		List<ModuleViewModel> GetByProfile(int profileId);
	}
}
