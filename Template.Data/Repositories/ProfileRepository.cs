using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class ProfileRepository: Repository<Profile>, IProfileRepository
	{
		public ProfileRepository(MySQLContext context)
			: base(context) { }

		public Profile GetDefault()
		{
			return Find(x => x.IsDefault);
		}
	}
}
