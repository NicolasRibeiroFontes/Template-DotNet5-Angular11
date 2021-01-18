using System.Collections.Generic;

namespace Template.Domain.Entities
{
	public class Profile : Entity
	{
		public string Name { get; set; }
		public bool IsDefault { get; set; }


		public ICollection<User> Users { get; set; }
		public ICollection<ModuleProfile> Modules { get; set; }
	}
}
