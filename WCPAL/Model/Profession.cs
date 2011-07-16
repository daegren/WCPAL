using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL.Model
{
    public class Profession
    {
        private int _id;
        private string _name;
        private string _icon;
        private int _rank;
        private int _max;
        private List<int> _recipes;

        public Profession(int id, string name, string icon, int rank, int max, List<int> recipes)
        {
            _id = id;
            _name = name;
            _icon = icon;
            _rank = rank;
            _max = max;
            _recipes = recipes;
        }

        internal static Profession ReadProfession(XElement e)
        {
            Profession p;

            List<int> i = new List<int>();

            foreach (XElement x in e.Elements("recipies"))
            {
                i.Add(int.Parse(x.Value));
            }

            p = new Profession(
                int.Parse(e.Element("id").Value),
                e.Element("name").Value,
                e.Element("icon").Value,
                int.Parse(e.Element("rank").Value),
                int.Parse(e.Element("max").Value),
                i
                );

            return p;
        }

        public int Id
        {
            get { return _id; }
        }

        public string Name
        {
            get { return _name; }
        }

        public string Icon
        {
            get { return _icon; }
        }

        public int Rank
        {
            get { return _rank; }
        }

        public int Max
        {
            get { return _max; }
        }

        public List<int> Recipies
        {
            get { return _recipes; }
        }
    }
}
