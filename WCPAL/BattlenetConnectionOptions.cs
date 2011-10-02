using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    public class BattlenetConnectionOptions
    {
        private Region _region;
        private bool _https;
        private BattlenetAuthenticationOptions _authOptions;
        private String _locale;

        public Region Region { get { return _region; } set { _region = value; } }
        public bool IsSecure { get { return _https; } set { _https = value; } }
        public BattlenetAuthenticationOptions AuthenticationOptions { get { return _authOptions; } set { _authOptions = value; } }
        public String Locale { get { return _locale; } set { _locale = value; } }

        public BattlenetConnectionOptions()
        {
            _region = Region.US;
            _https = false;
            _authOptions = new BattlenetAuthenticationOptions()
            {
                PrivateKey = "",
                PublicKey = "",
                IsAuthenticated = false
            };
            _locale = "en-US";
        }
    }
}
