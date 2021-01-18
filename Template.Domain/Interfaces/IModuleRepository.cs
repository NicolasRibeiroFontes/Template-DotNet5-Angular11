using System.Collections.Generic;
using Template.Domain.Entities;

namespace Template.Domain.Interfaces
{
    public interface IModuleRepository
	{
		List<Module> GetByProfileId(int profileId);
	}
}
