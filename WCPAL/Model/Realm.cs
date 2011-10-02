using System;
using System.Xml.Linq;

namespace WCPAL
{
    /// <summary>
    /// A World of Warcraft Realm
    /// </summary>
    public class Realm
    {
        private String _name;
        private String _slug;
        private RealmType _type;
        private bool _status;
        private bool _queue;
        private String _population;
        private DateTime _lastUpdated;

        public Realm() 
        {
            _lastUpdated = DateTime.Now;
        }


        /// <summary>
        /// The name of the realm
        /// </summary>
        public String Name
        {
            get { return _name; }
        }

        /// <summary>
        /// A web safe version of the realm name
        /// </summary>
        public String Slug
        {
            get { return _slug; }
        }

        /// <summary>
        /// The type of realm this is, whether PVE, PVP, RP or RPPVP. See <see cref="RealmType"/>.
        /// </summary>
        public RealmType Type
        {
            get { return _type; }
        }

        /// <summary>
        /// Current status of the realm. True if the realm is online, false if it is not.
        /// </summary>
        public bool Status
        {
            get { return _status; }
        }

        /// <summary>
        /// Current queue status. True if the realm has a queue, false if not.
        /// </summary>
        public bool Queue
        {
            get { return _queue; }
        }

        /// <summary>
        /// Current population on the realm. Can be, but not limited to, Low, Medium, High.
        /// </summary>
        public String Population
        {
            get { return _population; }
        }

        /// <summary>
        /// Time this object was last updated.
        /// </summary>
        public DateTime LastUpdated
        {
            get { return _lastUpdated; }
        }

        public override bool Equals(object obj)
        {
            // if parameter is null return false
            if (obj == null)
                return false;

            // if parameter cannot be cast into a Realm return false
            Realm r = obj as Realm;
            if ((System.Object)r == null)
                return false;

            return Equals(r);
        }

        public bool Equals(Realm realm)
        {
            // if paramter is null return false;
            if (realm == null)
            {
                return false;
            }

            return (realm.Name == _name && realm.Type == _type && realm.Slug == _slug);
        }

        public override int GetHashCode()
        {
            return _name.GetHashCode() ^ _type.GetHashCode() ^ _slug.GetHashCode();
        }

        public static bool operator ==(Realm a, Realm b)
        {
            // If both are null, or both are the same instance, return true.
            if (Object.ReferenceEquals(a, b))
                return true;

            // if one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            return (a.Equals(b));
        }

        public static bool operator !=(Realm a, Realm b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Creates a <see cref="Realm"/> object using an <see cref="XElement"/> as data.
        /// </summary>
        /// <param name="rlm">The <see cref="XElement"/> containg the realm data.</param>
        /// <returns>A <see cref="Realm"/> object containing all the data it was passed.</returns>
        public static Realm ReadRealm(XElement rlm)
        {
            Realm r;

            r = new Realm() {
                _name = rlm.Element("name").Value,
                _slug = rlm.Element("slug").Value,
                _type = (RealmType)Enum.Parse(typeof(RealmType), rlm.Element("type").Value.ToUpper()),
                _status = bool.Parse(rlm.Element("status").Value),
                _queue = bool.Parse(rlm.Element("queue").Value),
                _population = rlm.Element("population").Value
            };

            return r;
        }
    }
}