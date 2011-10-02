using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// Specific Character Talent
    /// </summary>
    public class Talent
    {
        private bool _selected;

        public bool Selected
        {
            get { return _selected; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
        }
        private string _icon;

        public string Icon
        {
            get { return _icon; }
        }
        private string _build;

        public string Build
        {
            get { return _build; }
        }
        private List<TalentTree> _trees;

        public List<TalentTree> Trees
        {
            get { return _trees; }
        }
        private GlyphSet _glyphs;

        public GlyphSet Glyphs
        {
            get { return _glyphs; }
        }


        internal static List<Talent> ReadTalent(System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }
    }
}
