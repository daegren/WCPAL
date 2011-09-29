using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    public class Emblem
    {
        private int _icon;
        private string _iconColor;
        private int _border;
        private string _borderColor;
        private string _backgroundColor;

        public Emblem(int icon, string iconColor, int border, string borderColor, string backgroundColor)
        {
            _icon = icon;
            _iconColor = iconColor;
            _border = border;
            _borderColor = borderColor;
            _backgroundColor = backgroundColor;
        }

        public int Icon { get { return _icon; } set { _icon = value; } }
        public string IconColor { get { return _iconColor; } set { _iconColor = value; } }
        public int Border { get { return _border; } set { _border = value; } }
        public string BorderColor { get { return _borderColor; } set { _borderColor = value; } }
        public string BackgroundColor { get { return _backgroundColor; } set { _backgroundColor = value; } }

        public override bool Equals(object obj)
        {
            // if parameter is null return false
            if (obj == null)
                return false;

            // if parameter cannot be cast into a Realm return false
            Emblem r = obj as Emblem;
            if ((System.Object)r == null)
                return false;

            return Equals(r);
        }

        public bool Equals(Emblem realm)
        {
            // if paramter is null return false;
            if (realm == null)
            {
                return false;
            }

            return (_icon == realm.Icon && _iconColor == realm.IconColor && _border == realm.Border && _borderColor == realm.BorderColor && _backgroundColor == realm.BackgroundColor);
        }

        public override int GetHashCode()
        {
            return _iconColor.GetHashCode() ^ _borderColor.GetHashCode() ^ _backgroundColor.GetHashCode();
        }

        public static bool operator ==(Emblem a, Emblem b)
        {
            // If both are null, or both are the same instance, return true.
            if (Object.ReferenceEquals(a, b))
                return true;

            // if one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
                return false;

            return (a.Equals(b));
        }

        public static bool operator !=(Emblem a, Emblem b)
        {
            return !(a == b);
        }

        public static Emblem ReadEmblem(XElement emblem)
        {
            Emblem e;

            e = new Emblem(
                int.Parse(emblem.Element("icon").Value),
                emblem.Element("iconColor").Value,
                int.Parse(emblem.Element("border").Value),
                emblem.Element("borderColor").Value,
                emblem.Element("backgroundColor").Value
                );

            return e;
        }
    }
}
