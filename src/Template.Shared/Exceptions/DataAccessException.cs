using System;

namespace Template.Shared.Exceptions
{
    public class DataAccessException : BaseException
    {
        public DataAccessException(Exception ex) : base("", ex)
        {

        }
        public DataAccessException(string customMessage) : base(customMessage)
        {

        }
        public DataAccessException(string customMessage, Exception ex) : base(customMessage, ex)
        {

        }
    }
}