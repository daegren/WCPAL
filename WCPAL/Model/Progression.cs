using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL.Model
{
    public class Progression
    {
        private List<Raid> _raids;

        public Progression(List<Raid> raids)
        {
            _raids = raids;
        }

        static public Progression ReadProgression(XElement e)
        {
            Progression p;

            List<Raid> r = new List<Raid>();

            foreach (XElement x in e.Elements("raids"))
            {
                r.Add(Raid.ReadRaids(x));
            }

            p = new Progression(r);

            return p;
        }

        public List<Raid> Raids
        {
            get { return _raids; }
        }
    }
}
