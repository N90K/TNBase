using System;

namespace TNBase.Objects
{
    public class ListenerStateChangeException : Exception
    {
        public ListenerStateChangeException()
        { }

        public ListenerStateChangeException(string message) : base(message)
        { }
    }
}
