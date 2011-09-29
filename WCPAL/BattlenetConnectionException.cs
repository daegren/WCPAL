using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    [Serializable]
    public class BattlenetConnectionException : Exception
    {
        public BattlenetConnectionException() { }
        public BattlenetConnectionException(string message) : base(message) { }
        public BattlenetConnectionException(string message, Exception inner) : base(message, inner) { }
        public BattlenetConnectionException(string message, System.Net.HttpStatusCode code) : base(message) { ResponseStatusCode = code; }
        protected BattlenetConnectionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context)
            : base(info, context) { }

        public System.Net.HttpStatusCode ResponseStatusCode { get; set; }
    }
}
