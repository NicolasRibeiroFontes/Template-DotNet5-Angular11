namespace Template.Domain.Entities
{
	public class ModuleProfile
	{
		public int ModuleId { get; set; }
		public int ProfileId { get; set; }

		public virtual Module Module { get; set; }
		public virtual Profile Profile { get; set; }
	}
}
