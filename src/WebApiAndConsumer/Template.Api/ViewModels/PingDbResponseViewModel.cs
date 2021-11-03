namespace Template.Api.ViewModels
{
    /// <summary>
    /// Ping Db response view model.
    /// </summary>
    public class PingDbResponseViewModel
    {
        /// <summary>
        /// Can Connect
        /// </summary>
        public bool CanConnect { get; set; }
        
        /// <summary>
        /// Connection Sting
        /// </summary>
        public string ConnectionSting { get; set; }
        
        /// <summary>
        /// Exception Message
        /// </summary>
        public string ExceptionMessage { get; set; }
    }
}