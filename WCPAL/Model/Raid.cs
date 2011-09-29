using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    public class Raid
    {
        private string _name;
        private int _normal;
        private int _heroic;
        private int _id;
        private List<Boss> _bosses;

        public Raid(int id, string name, int normal, int heroic, List<Boss> bosses)
        {
            _id = id;
            _name = name;
            _normal = normal;
            _heroic = heroic;
            _bosses = bosses;
        }

        public static Raid ReadRaids(XElement e)
        {
            Raid r;

            List<Boss> b = new List<Boss>();

            foreach (XElement x in e.Elements("bosses"))
            {
                b.Add(Boss.ReadBoss(x));
            }

            r = new Raid(
                int.Parse(e.Element("id").Value),
                e.Element("name").Value,
                int.Parse(e.Element("normal").Value),
                int.Parse(e.Element("heroic").Value),
                b
                );

            return r;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Normal
        {
            get { return _normal; }
        }

        public int Heroic
        {
            get { return _heroic; }
        }

        public int Id
        {
            get { return _id; }
        }

        public List<Boss> Bosses
        {
            get { return _bosses; }
        }


    }
}
