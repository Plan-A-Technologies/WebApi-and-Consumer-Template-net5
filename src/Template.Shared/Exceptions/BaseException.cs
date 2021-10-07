using System;

namespace Template.Shared.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(Exception ex) : base("", ex)
        {
        }

        public BaseException(string customMessage) : base(customMessage)
        {
        }

        
        public BaseException(string customMessage, Exception ex) : base(customMessage, ex)
        {
        }
    }
}