namespace Lands8.Helpers
{
    using Plugin.Settings;
    using Plugin.Settings.Abstractions;

    public static class Settings
    {
        static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        const string token = "Token";
        const string tokentype = "TokenType";
        static readonly string stringDefault = string.Empty;

        public static string Token
        {
            get
            {
                return AppSettings.GetValueOrDefault(token, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(token, value);
            }
        }


        public static string TokenType
        {
            get
            {
                return AppSettings.GetValueOrDefault(TokenType, stringDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue(TokenType, value);
            }
        }
    }

}
