namespace Template.Bll.Dto
{
    /// <summary>
    /// Ping Dto
    /// </summary>
    public class PingDbDto
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