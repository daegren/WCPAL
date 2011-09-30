using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// Set of Glyphs
    /// </summary>
    public class GlyphSet
    {
        private List<Glyph> _prime;

        public List<Glyph> Prime
        {
            get { return _prime; }
        }
        private List<Glyph> _major;

        public List<Glyph> Major
        {
            get { return _major; }
        }
        private List<Glyph> _minor;

        public List<Glyph> Minor
        {
            get { return _minor; }
        }
    }
}
