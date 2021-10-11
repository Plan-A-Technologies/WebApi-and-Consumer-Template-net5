using System;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Forbidden Exception
    /// </summary>
    /// <seealso cref="Template.Shared.Exceptions.BaseException" />
    public class ForbiddenException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public ForbiddenException(Exception ex) : base("", ex)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        public ForbiddenException(string customMessage) : base(customMessage)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BadRequestException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The ex.</param>
        public ForbiddenException(string customMessage, Exception ex) : base(customMessage, ex)
        {

        }
    }
}