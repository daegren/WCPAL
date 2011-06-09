using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    public class InvalidRealmException : Exception
    {
        public InvalidRealmException(string realmName)
            : base(String.Format("The realm {0} is not a valid realm", realmName))
        {
        }

        public InvalidRealmException()
            : base()
        {
        }
    }
}
