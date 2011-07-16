using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL.Model
{
    public class ProfessionSet
    {
        private List<Profession> _primary;
        private List<Profession> _secondary;

        public ProfessionSet(List<Profession> primary, List<Profession> secondary)
        {
            _primary = primary;
            _secondary = secondary;
        }

        static public ProfessionSet ReadProfessionSet(XElement e)
        {
            ProfessionSet ps;

            List<Profession> p = new List<Profession>();
            List<Profession> s = new List<Profession>();

            foreach (XElement x in e.Elements("primary"))
            {
                p.Add(Profession.ReadProfession(x));
            }

            foreach (XElement x in e.Elements("secondary"))
            {
                s.Add(Profession.ReadProfession(x));
            }

            ps = new ProfessionSet(
                p,
                s
                );

            return ps;

        }

        public List<Profession> Primary
        {
            get { return _primary; }
        }

        public List<Profession> Secondary
        {
            get { return _secondary; }
        }
    }
}
