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

    }
}
