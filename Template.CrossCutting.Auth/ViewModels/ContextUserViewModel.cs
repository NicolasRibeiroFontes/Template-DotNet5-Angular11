namespace Template.CrossCutting.Auth.ViewModels
{
    public class ContextUserViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public bool IsAuthenticated { get; set; }

        public string Name { get; set; }

        public string Profile { get; set; }
    }
}
