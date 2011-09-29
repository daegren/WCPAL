using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    public class Boss
    {
        private string _name;
        private int _normalKills;
        private int _heroicKills;
        private int _id;

        public Boss(int id, string name, int normalKills, int heroicKills)
        {
            _id = id;
            _name = name;
            _normalKills = normalKills;
            _heroicKills = heroicKills;
        }

        static public Boss ReadBoss(XElement e)
        {
            Boss b;

            b = new Boss(
                int.Parse(e.Element("id").Value),
                e.Element("name").Value,
                int.Parse(e.Element("normalKills").Value),
                int.Parse(e.Element("heroicKills").Value)
                );

            return b;
        }

        public int Id
        {
            get { return _id; }
        }

        public int HeroicKills
        {
            get { return _heroicKills; }
        }

        public int NormalKills
        {
            get { return _normalKills; }
        }

        public string Name
        {
            get { return _name; }
        }
    }
}
