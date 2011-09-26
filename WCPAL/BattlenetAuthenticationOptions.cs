using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    public class BattlenetAuthenticationOptions
    {
        private String _privateKey;
        private String _publicKey;
        private bool _isAthenticated;

        public String PrivateKey { get { return _privateKey; } set { _privateKey = value; } }
        public String PublicKey { get { return _publicKey; } set { _publicKey = value; } }
        public bool IsAuthenticated { get { return _isAthenticated; } set { _isAthenticated = value; } }
    }
}
