using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using WCPAL.Model;

namespace WCPAL
{
    public class WoWPlatform : BasePlatform
    {
        private string wowApiUrl = "wow/";

        public WoWPlatform()
        {
            base.InitializeConnection(wowApiUrl);
        }

        /// <summary>
        /// Gets the current status of a specific realm
        /// </summary>
        /// <param name="realm">The realm name to lookup</param>
        /// <returns>A <see cref="WCPAL.Model.Realm"/> which contains the current status of the realm.</returns>
        public Realm GetRealmStatus(string realm)
        {
            if (String.IsNullOrEmpty(realm))
                throw new ArgumentNullException("realm");

            Realm r;

            XmlDictionaryReader xdr = ProcessRequest("realm/status?realm=" + realm);

            XElement el = XElement.Load(xdr);
            XElement rlm = el.Element("realms").Element("item");

            r = Realm.ReadRealm(rlm);

            if (r.Name.ToLower() != realm.ToLower())
                throw new InvalidRealmException(realm);

            return r;
        }
        
        public IEnumerable<Realm> GetRealmStatus(List<String> realms)
        {
            if (realms == null || realms.Count == 0)
                throw new ArgumentNullException("realms");

            List<Realm> rlms = new List<Realm>();

            StringBuilder sb = new StringBuilder("realm/status?");
            foreach (string r in realms)
            {
                sb.Append("realm=" + r + "&");
            }

            sb.Remove(sb.Length - 1, 1); // remove last &

            XmlDictionaryReader xdr = ProcessRequest(sb.ToString());

            XElement el = XElement.Load(xdr);
            XElement rlm = el.Element("realms");

            foreach (XElement e in rlm.Elements())
            {
                rlms.Add(Realm.ReadRealm(e));
            }

            return rlms;
        }

        public IEnumerable<Realm> GetRealmStatus()
        {
            List<Realm> rlms = new List<Realm>();

            XmlDictionaryReader xdr = ProcessRequest("realm/status");

            XElement el = XElement.Load(xdr);
            XElement rlm = el.Element("realms");

            foreach (XElement e in rlm.Elements())
            {
                rlms.Add(Realm.ReadRealm(e));
            }

            return rlms;
        }

        
    }
}
