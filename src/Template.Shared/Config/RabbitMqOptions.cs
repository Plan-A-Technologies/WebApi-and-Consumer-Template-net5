namespace Template.Shared.Config
{
    /// <summary>
    /// The RabbitMQ configuration.
    /// </summary>
    public class RabbitMqOptions
    {
        /// <summary>
        /// Default timeout for request.
        /// </summary>
        public int DefaultTimeout { get; set; }

        /// <summary>
        /// The host name.
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// The virtual host name.
        /// </summary>
        public string VirtualHost { get; set; }

        /// <summary>
        /// The user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The password.
        /// </summary>
        public string Password { get; set; }
    }
}
