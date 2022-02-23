namespace Template.Shared.IdentityServer.Settings
{
    /// <summary>
    ///     OAuth2 introspection settings
    /// </summary>
    public static class IntrospectionSettings
    {
        /// <summary>
        ///     OAuth2 Introspection section
        /// </summary>
        public const string IntrospectionSection = "IntrospectionSettings:Introspection";

        /// <summary>
        ///     OAuth2 Introspection scheme
        /// </summary>
        public const string Scheme = "IntrospectionSettings:Scheme";

        /// <summary>
        ///     Authentication section for OAuth2 Introspection
        /// </summary>
        public const string AuthenticationSection = "IntrospectionSettings:Authentication";
    }
}