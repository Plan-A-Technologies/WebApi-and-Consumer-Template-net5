namespace Template.Shared.Errors
{
    /// <summary>
    ///     Error model
    /// </summary>
    public sealed class ErrorModel
    {
        /// <summary>
        ///     Default error message
        /// </summary>
        public const string ErrorMessageDefault = "An error occurred on the server preventing it to handle the request successfully.";

        /// <summary>
        ///     Default error detail message
        /// </summary>
        public const string ErrorDetailDefault = "Check the logs for further detail.";

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="errorCode">The errorCode</param>
        public ErrorModel(string errorCode)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        ///     Title of the error - short message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        ///     Detail of the error.
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        ///     Gets or sets the data.
        /// </summary>
        /// <value>
        ///     The data.
        /// </value>
        public object Data { get; set; }
    }
}
