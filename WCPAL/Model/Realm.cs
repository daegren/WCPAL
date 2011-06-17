using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL.Model
{
    public class Realm
    {
        private String _name;
        private String _slug;
        private RealmType _type;
        private bool _status;
        private bool _queue;
        private String _population;
        private DateTime _lastUpdated;

        public Realm(string name, string slug, RealmType type, bool status, bool queue, string population)
        {
            _name = name;
            _slug = slug;
            _type = type;
            _status = status;
            _queue = queue;
            _population = population;
            _lastUpdated = DateTime.Now;
        }

        public String Name
        {
            get { return _name; }
        }

        public String Slug
        {
            get { return _slug; }
        }

        public RealmType Type
        {
            get { return _type; }
        }

        public bool Status
        {
            get { return _status; }
        }

        public bool Queue
        {
            get { return _queue; }
        }

        public String Population
        {
            get { return _population; }
        }

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

            return (a.Name == b.Name && a.Type == b.Type && a.Slug == b.Slug);
        }

        public static bool operator !=(Realm a, Realm b)
        {
            return !(a == b);
        }

    }
}