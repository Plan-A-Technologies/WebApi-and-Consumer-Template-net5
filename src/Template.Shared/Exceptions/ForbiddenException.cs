using System;
using System.Collections.Generic;

using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    ///     Forbidden Exception
    /// </summary>
    /// <seealso cref="BaseException"/>
    public class ForbiddenException : BaseException
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        public ForbiddenException(string customMessage, string errorCode) : base(customMessage, errorCode)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        public ForbiddenException(string customMessage, Exception ex, string errorCode) : base(customMessage, ex, errorCode)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ForbiddenException"/> class.
        /// </summary>
        /// <param name="errors"></param>
        public ForbiddenException(IList<ErrorModel> errors) : base(errors)
        {
        }
    }
}