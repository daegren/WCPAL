using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    public class GuildMember
    {
        private string _name;
        private string _realm;
        private int _level;
        private int _members;
        private int _achPoints;
        private Emblem _emblem;

        public GuildMember(string name, string realm, int level, int members, int achPoints, Emblem emblem)
        {
            _name = name;
            _realm = realm;
            _level = level;
            _members = members;
            _achPoints = achPoints;
            _emblem = emblem;
        }

        public string Name { get { return _name; } }
        public string Realm { get { return _realm; } }
        public int Level { get { return _level; } }
        public int Members { get { return _members; } }
        public int AcheivmentPoints { get { return _achPoints; } }
        public Emblem Emblem { get { return _emblem; } }

        public static GuildMember ReadGuildMember(XElement xGuildMember)
        {
            GuildMember gm = new GuildMember(
                xGuildMember.Element("name").Value,
                xGuildMember.Element("realm").Value,
                int.Parse(xGuildMember.Element("level").Value),
                int.Parse(xGuildMember.Element("members").Value),
                int.Parse(xGuildMember.Element("achievementPoints").Value),
                Emblem.ReadEmblem(xGuildMember.Element("emblem"))
                );

            return gm;
        }
    }
}
