using System;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Data access exception.
    /// </summary>
    /// <seealso cref="BaseException" />
    public class DataAccessException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public DataAccessException(Exception ex) : base("", ex)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        public DataAccessException(string customMessage) : base(customMessage)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The ex.</param>
        public DataAccessException(string customMessage, Exception ex) : base(customMessage, ex)
        {

        }
    }
}