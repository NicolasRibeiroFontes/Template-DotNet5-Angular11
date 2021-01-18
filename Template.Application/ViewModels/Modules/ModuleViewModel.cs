namespace Template.Application.ViewModels.Modules
{
    public class ModuleViewModel: EntityViewModel
	{
		public string Name { get; set; }
		public string URL { get; set; }
		public string Icon { get; set; }
		public int Sequence { get; set; }
	}
}
