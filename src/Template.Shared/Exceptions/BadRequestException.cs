using System;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Bad Request Exception.
    /// </summary>
    /// <seealso cref="BaseException" />
    public class BadRequestException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public BadRequestException(Exception ex) : base("", ex)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        public BadRequestException(string customMessage) : base(customMessage)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The ex.</param>
        public BadRequestException(string customMessage, Exception ex) : base(customMessage, ex)
        {

        }
    }
}