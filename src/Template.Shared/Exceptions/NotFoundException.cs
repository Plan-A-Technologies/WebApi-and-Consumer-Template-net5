using System;

namespace Template.Shared.Exceptions
{
    /// <summary>
    /// Not Found Exception.
    /// </summary>
    /// <seealso cref="BaseException" />
    public class NotFoundException : BaseException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public NotFoundException(Exception ex) : base("", ex)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        public NotFoundException(string customMessage) : base(customMessage)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NotFoundException"/> class.
        /// </summary>
        /// <param name="customMessage">The custom message.</param>
        /// <param name="ex">The ex.</param>
        public NotFoundException(string customMessage, Exception ex) : base(customMessage, ex)
        {

        }
    }
}