using System;

namespace WCPAL
{
    [Serializable]
    public class InvalidRealmException : Exception
    {
        public InvalidRealmException() { }
        public InvalidRealmException(string message) : base(message) { }
        public InvalidRealmException(string message, Exception inner) : base(message, inner) { }
        protected InvalidRealmException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }
    }
}
