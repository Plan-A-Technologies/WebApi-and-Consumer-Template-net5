namespace Template.Shared.Errors
{
    /// <summary>
    /// Error model
    /// </summary>
    public sealed class ErrorModel
    {
        /// <summary>
        /// General error code - default value if nothing is specified
        /// </summary>
        public const string ErrorCodeGeneral = @"10000";

        /// <summary>
        /// General error code for bad request - something wrong was passed from the client to the service.
        /// </summary>
        public const string ErrorCodeGeneralBadRequest = @"10001";

        /// <summary>
        /// Default error message
        /// </summary>
        public const string ErrorMessageDefault = @"An error occurred on the server preventing it to handle the request successfully.";

        /// <summary>
        /// Default error message
        /// </summary>
        public const string ErrorMessageDefaultBadRequest = @"Wrong or invalid data was sent to the service. Please, review it.";

        /// <summary>
        /// Default error detail message
        /// </summary>
        public const string ErrorDetailDefault = @"Check the logs for further detail.";

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="errorCode">The errorCode</param>
        public ErrorModel(string errorCode = ErrorCodeGeneral)
        {
            ErrorCode = errorCode;
        }

        /// <summary>
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// Title of the error - short message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Detail of the error.
        /// </summary>
        public string Detail { get; set; }
    }
}
