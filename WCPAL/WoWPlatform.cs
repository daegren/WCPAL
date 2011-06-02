using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WCPAL.Model;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Linq;

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

            r = ReadRealm(rlm);

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
                rlms.Add(ReadRealm(e));
            }

            return rlms;
        }

        public IEnumerable<Realm> GetRealmStatus()
        {
            throw new NotImplementedException();
        }

        private static Realm ReadRealm(XElement rlm)
        {
            Realm r;

            r = new Realm(
                rlm.Element("name").Value,
                rlm.Element("slug").Value,
                (RealmType)Enum.Parse(typeof(RealmType), rlm.Element("type").Value.ToUpper()),
                bool.Parse(rlm.Element("status").Value),
                bool.Parse(rlm.Element("queue").Value),
                rlm.Element("population").Value
            );

            return r;
        }
    }
}
