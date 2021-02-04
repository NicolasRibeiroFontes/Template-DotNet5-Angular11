using System.Collections.Generic;
using System.Linq;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ModuleRepository: Repository<Module>, IModuleRepository
	{
        public ModuleRepository(MySQLContext context)
            : base(context) { }

        public IQueryable<Module> GetByProfileId(int profileId)
        {
            return (from m in context.Modules
                    join mp in context.ModuleProfiles on m.Id equals mp.ModuleId
                    where mp.ProfileId == profileId
                    select m);
        }
    }
}
