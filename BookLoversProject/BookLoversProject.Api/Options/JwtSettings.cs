namespace BookLoversProject.Presentation.Options
{
    public class JwtSettings
    {
        public string Issuer { get; set; }

        public string[] Audiences { get; set; }

        public string Key { get; set; }
    }
}