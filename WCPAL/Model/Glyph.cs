using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    public class Glyph
    {
        private int _id;

        public int Id
        {
            get { return _id; }
        }
        private int _itemId;

        public int ItemId
        {
            get { return _itemId; }
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
    }
}
