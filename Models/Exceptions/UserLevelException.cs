using System;

namespace Models.Exceptions
{
    public class UserLevelException : BaseAmadeusException
    {
        public UserLevelException(string message) : base(message)
        {
        }

        public UserLevelException(string message, Exception exception)
            : base(message, exception)
        {
        }
    }
}