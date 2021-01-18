namespace Template.CrossCutting.Auth.ViewModels
{
    public class TokenConfigurationsViewModel
    {
        public const string Key = "TokenConfigurations";
        public string Secret { get; set; }
        public double ExpiresIn { get; set; }
    }
}
