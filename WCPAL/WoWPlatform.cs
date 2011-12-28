using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace WCPAL
{
    public class WoWPlatform : BasePlatform
    {
        /// <summary>
        /// Creates a new WoWPlatform Object with the default connection options. See <see cref="BattlenetConnectionOptions"/>.
        /// </summary>
        public WoWPlatform() :
            base("wow", new BattlenetConnectionOptions())
        {
        }

        /// <summary>
        /// Creates a new WoWPlatform object with a specified set of connection options.
        /// </summary>
        /// <param name="connectionOptions">The connection options to use when accessing the community API.</param>
        public WoWPlatform(BattlenetConnectionOptions connectionOptions) :
            base("wow", connectionOptions)
        {
        }

        #region Realm Methods
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
        
        /// <summary>
        /// Get the current status of a set of realms
        /// </summary>
        /// <param name="realms">The list of realms to lookup.</param>
        /// <returns>An <see cref="IEnumerable"/> containing the <see cref="Realm"/> objects retrieved.</returns>
        public IEnumerable<Realm> GetRealmStatus(List<String> realms)
        {
            if (realms == null || realms.Count == 0)
                throw new ArgumentNullException("realms");

            List<Realm> rlms = new List<Realm>();

            StringBuilder sb = new StringBuilder("realm/status?");
            bool f = true;
            foreach (string r in realms)
            {
                string n = r.Replace(' ', '-'); // replace ' ' with - for slug versions
                if (f)
                {
                    sb.Append("realms=" + n);
                    f = false;
                }
                else
                {
                    sb.Append("," + n);
                }
            }

            XmlDictionaryReader xdr = ProcessRequest(sb.ToString());

            XElement el = XElement.Load(xdr);
            XElement rlm = el.Element("realms");

            foreach (XElement e in rlm.Elements())
            {
                rlms.Add(Realm.ReadRealm(e));
            }

            return rlms;
        }

        /// <summary>
        /// Gets the status of all the realms in the current locale
        /// </summary>
        /// <returns>An <see cref="IEnumerable"/> containing all the <see cref="Realm"/> objects returned.</returns>
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
        #endregion

        #region Character Methods

        public Character GetCharacter(string name, string realm)
        {
            if (String.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");

            Character c;

            String req = String.Format("character/{0}/{1}", realm, name);
            XmlDictionaryReader xdr = ProcessRequest(req);

            XElement el = XElement.Load(xdr);
            XElement cha = el.Element("item");

            c = Character.ReadCharacter(cha);

            if (c.Name.ToLower() != name.ToLower())
                throw new InvalidRealmException(name);

            return c;
        }

        public Character GetCharacter(string name, string realm, params string[] args)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
