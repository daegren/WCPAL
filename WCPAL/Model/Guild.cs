using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    /// <summary>
    /// A World of Warcraft Guild
    /// </summary>
    public class Guild
    {
        private string _name;
        private string _realm;
        private int _level;
        private int _members;
        private int _achPoints;
        private Emblem _emblem;

        /*

        public static Guild ReadGuild(XElement rlm)
        {
            
            Realm r;

            r = new Realm(
                rlm.Element("name").Value,
                rlm.Element("slug").Value,
                (RealmType)Enum.Parse(typeof(RealmType), rlm.Element("type").Value.ToUpper()),
                bool.Parse(rlm.Element("status").Value),
                bool.Parse(rlm.Element("queue").Value),
                rlm.Element("population").Value
            );

            return r;
            
        }
         */
    }
}
