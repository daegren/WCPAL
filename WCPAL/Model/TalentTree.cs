using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// A Character's Talent Tree
    /// </summary>
    public class TalentTree
    {
        private string _points;

        public string Points
        {
            get { return _points; }
        }
        private int _total;

        public int Total
        {
            get { return _total; }
        }
    }
}
