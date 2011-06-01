using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCPAL.Model;

namespace WCPAL
{
    public class WoWPlatform : BasePlatform
    {
        private string wowApiUrl = "wow/";

        public Realm GetRealmStatus(string realm)
        {
            
        }
        public IEnumerable<Realm> GetRealmStatus(string[] realms)
        {
            return new List<Realm>();
        }

        public IEnumerable<Realm> GetRealmStatus()
        {
        }
    }
}
