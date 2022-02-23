namespace Template.Shared.IdentityServer.Settings
{
    /// <summary>
    ///     OpenIdConnect settings
    /// </summary>
    public static class OpenIdConnectSettings
    {
        /// <summary>
        ///     OpenIdConnect section
        /// </summary>
        public const string OpenIdConnectSection = "OpenIdConnectSettings:OpenIdConnect";

        /// <summary>
        ///     OpenIdConnect scheme
        /// </summary>
        public const string Scheme = "OpenIdSettings:Scheme";

        /// <summary>
        ///     Authentication section for OpenIdConnect
        /// </summary>
        public const string AuthenticationSection = "OpenIdSettings:Authentication";

        /// <summary>
        ///     Cookie section for OpenIdConnect
        /// </summary>
        public const string CookieSection = "OpenIdSettings:CookieAuthentication";
    }
}