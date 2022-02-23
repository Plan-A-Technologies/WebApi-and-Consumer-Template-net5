using System;

namespace Template.Shared.IdentityServer.Settings
{
    /// <summary>
    ///     Client settings
    /// </summary>
    public class ClientSettings
    {
        /// <summary>
        ///     The Client section
        /// </summary>
        public const string Section = "ClientSettings";

        /// <summary>
        ///     Gets or sets the base address
        /// </summary>
        /// <value>
        ///     The base address
        /// </value>
        public string BaseAddress { get; set; }

        /// <summary>
        ///     Gets or sets the access token address
        /// </summary>
        /// <value>
        ///     The access token address
        /// </value>
        public string AccessTokenAddress { get; set; }

        /// <summary>
        ///     Gets or sets the client
        /// </summary>
        /// <value>
        ///     The client
        /// </value>
        public ClientInfo Client { get; set; }

        /// <summary>
        ///     Client information
        /// </summary>
        public class ClientInfo
        {
            /// <summary>
            ///     Gets or sets the credentials
            /// </summary>
            /// <value>
            ///     The credentials
            /// </value>
            public CredentialsSettings Credentials { get; set; }

            /// <summary>
            ///     Gets or sets the retry policy
            /// </summary>
            /// <value>
            ///     The retry policy
            /// </value>
            public RetryPolicySettings RetryPolicy { get; set; }
        }

        /// <summary>
        ///     Credentials settings
        /// </summary>
        public class CredentialsSettings
        {
            /// <summary>
            ///     Gets or sets the client name
            /// </summary>
            /// <value>
            ///     The client name
            /// </value>
            public string ClientName { get; set; }

            /// <summary>
            ///     Gets or sets the client id
            /// </summary>
            /// <value>
            ///     The client id
            /// </value>
            public string ClientId { get; set; }

            /// <summary>
            ///     Gets or sets the client secret
            /// </summary>
            /// <value>
            ///     The client secret
            /// </value>
            public string ClientSecret { get; set; }

            /// <summary>
            ///     Gets or sets the scope
            /// </summary>
            /// <value>
            ///     The scope
            /// </value>
            public string Scope { get; set; }

            /// <summary>
            ///     Gets or sets the grant type
            /// </summary>
            /// <value>
            ///     The grant type
            /// </value>
            public string GrantType { get; set; }
        }

        /// <summary>
        ///     Retry policy settings
        /// </summary>
        public class RetryPolicySettings
        {
            /// <summary>
            ///     Gets or sets the wait and retry
            /// </summary>
            /// <value>
            ///     The wait and retry
            /// </value>
            public TimeSpan[] WaitAndRetry { get; set; }
        }
    }
}