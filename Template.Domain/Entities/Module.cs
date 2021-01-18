using System.Collections.Generic;

namespace Template.Domain.Entities
{
	public class Module: Entity
	{
		public string Name { get; set; }
		public string URL { get; set; }
		public string Icon { get; set; }
        public int Sequence { get; set; }

		public ICollection<ModuleProfile> Profiles { get; set; }
	}
}
