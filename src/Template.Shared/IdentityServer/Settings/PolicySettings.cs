namespace Template.Shared.IdentityServer.Settings
{
    /// <summary>
    ///     Policy settings
    /// </summary>
    public class PolicySettings
    {
        /// <summary>
        ///     The Policy section
        /// </summary>
        public const string Section = "PolicySettings";

        /// <summary>
        ///     Gets or sets the policies.
        /// </summary>
        /// <value>
        ///     The policies.
        /// </value>
        public PolicyItem[] Policies { get; set; }

        /// <summary>
        ///     Policy settings
        /// </summary>
        public class PolicyItem
        {
            /// <summary>
            ///     Gets or sets the policy name.
            /// </summary>
            /// <value>
            ///     The policy name.
            /// </value>
            public string PolicyName { get; set; }

            /// <summary>
            ///     Gets or sets the collection
            /// </summary>
            /// <value>
            ///     The collection.
            /// </value>
            public KeyValues[] Collection { get; set; }

            /// <summary>
            ///     Key values
            /// </summary>
            public class KeyValues
            {
                /// <summary>
                ///     Gets or sets the name
                /// </summary>
                /// <value>
                ///     The name
                /// </value>
                public string Name { get; set; }

                /// <summary>
                ///     Gets or sets the values
                /// </summary>
                /// <value>
                ///     The values
                /// </value>
                public string[] Values { get; set; }
            }
        }
    }
}