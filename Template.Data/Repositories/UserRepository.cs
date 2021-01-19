using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Template.Data.Context;
using Template.Domain.Entities;
using Template.Domain.Interfaces;

namespace Template.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
	{
		public UserRepository(MySQLContext context)
			: base(context) { }

		public User GetByEmailAndPassword(string email, string password)
		{
			return Find(x => x.Email.ToLower() == email.ToLower() && x.Password == password && x.IsActive, i => i.Include(x => x.Profile));
		}

		public User GetByEmail(string email)
		{
			return Find(x => x.Email.ToLower() == email.ToLower() && x.IsActive, i => i.Include(x => x.Profile).ThenInclude(then => then.Modules));
		}

		public User GetByEmailAndCode(string email, string code)
		{
			return Find(x => x.Email.ToLower() == email.ToLower() && x.Code.ToUpper() == code.ToUpper() && x.IsActive);
		}

		public IQueryable<User> GetByProfileId(int profileId)
		{
			return Query(x => x.IsActive && x.ProfileId == profileId);
		}

		public User GetById(int userId)
		{
			return Find(x => x.Id == userId, i => i.Include(x => x.Profile).ThenInclude(x => x.Modules));
		}

		public IQueryable<User> Get()
		{
			return Query(x => x.IsActive, i => i.Include(x => x.Profile).ThenInclude(x => x.Modules));
		}
	}
}
