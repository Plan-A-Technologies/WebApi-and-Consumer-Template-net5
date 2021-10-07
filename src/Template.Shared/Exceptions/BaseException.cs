using System;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Base exception.
    /// </summary>
    /// <seealso cref="Exception" />
    public class BaseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public BaseException(Exception ex) : base("", ex)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        public BaseException(string customMessage) : base(customMessage)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The ex.</param>
        public BaseException(string customMessage, Exception ex) : base(customMessage, ex)
        {
        }
    }
}