using System;
using System.Collections.Generic;

using Template.Shared.Errors;

namespace Template.Shared.Exceptions
{
    /// <summary>
    ///     Base exception.
    /// </summary>
    /// <seealso cref="Exception"/>
    public abstract class BaseException : Exception
    {
        /// <summary>
        ///     Gets the error code.
        /// </summary>
        /// <value>
        ///     The error code.
        /// </value>
        public IList<ErrorModel> Errors { get; internal set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        protected BaseException(string customMessage, string errorCode) : base(customMessage)
        {
            Errors = new[]
            {
                new ErrorModel(errorCode)
                {
                    Message = customMessage
                }
            };
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="errorCode">The error code.</param>
        /// <param name="data">The data.</param>
        protected BaseException(string customMessage, string errorCode, object data) : base(customMessage)
        {
            Errors = new[]
            {
                new ErrorModel(errorCode)
                {
                    Message = customMessage,
                    Data = data
                }
            };
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The exception.</param>
        /// <param name="errorCode">The error code.</param>
        protected BaseException(string customMessage, Exception ex, string errorCode) : base(customMessage, ex)
        {
            Errors = new[]
            {
                new ErrorModel(errorCode)
                {
                    Message = customMessage
                }
            };
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="errors"></param>
        protected BaseException(IList<ErrorModel> errors) : base("")
        {
            Errors = errors;
        }
    }
}