using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    /// <summary>
    /// A player Character in World of Warcraft
    /// </summary>
    public class Character
    {
        private int _lastModified;
        private string _name;
        private string _realm;
        private CharacterClass _class;
        private Race _race;
        private Gender _gender;
        private int _level;
        private int _achievementPoints;
        private string _thumbnail;

        private GuildMember _guild;
        private Stats _stats;
        private List<Talent> _talents;
        private ItemSet _items;
        private List<Reputation> _reputation;
        private List<Title> _titles;
        private ProfessionSet _professions;
        private Appearance _appearance;
        private List<int> _companions;
        private List<int> _mounts;
        private List<Pet> _pets;
        private AchievementMap _achievements;
        private Progression _progression;
        private List<int> _quests;
        private PvpMap _pvpStats;

        public DateTime LastModified { get { return new DateTime(_lastModified); } }
        public String Name { get { return _name; } }
        public String Realm { get { return _realm; } }
        public CharacterClass Class { get { return _class; } }
        public Race Race { get { return _race; } }
        public Gender Gender { get { return _gender; } }
        public int Level { get { return _level; } }
        public int AchievementPoints { get { return _achievementPoints; } }
        public String Thumbnail { get { return _thumbnail; } }

        public GuildMember Guild { get { return _guild; } }
        public Stats Stats { get { return _stats; } }
        public List<Talent> Talents { get { return _talents; } }
        public ItemSet Items { get { return _items; } }
        public List<Reputation> Reputations { get { return _reputation; } }
        public List<Title> Titles { get { return _titles; } }
        public ProfessionSet Professions { get { return _professions; } }
        public Appearance Appearance { get { return _appearance; } }
        public List<int> Companions { get { return _companions; } }
        public List<int> Mounts { get { return _mounts; } }
        public List<Pet> Pets { get { return _pets; } }
        public AchievementMap Achievements { get { return _achievements; } }
        public Progression Progression { get { return _progression; } }
        public List<int> Quests { get { return _quests; } }
        public PvpMap PvpStats { get { return _pvpStats; } }

        public static Character ReadCharacter(XElement cha)
        {
            Character c;

            c = new Character()
            {
                _achievementPoints = int.Parse(cha.Element("achievementPoints").Value),
                _class = CharacterClass.GetClass(cha.Element("class").Value),
                _gender = (Gender)int.Parse(cha.Element("gender").Value),
                _lastModified = int.Parse(cha.Element("lastModified").Value),
                _level = int.Parse(cha.Element("level").Value),
                _name = cha.Element("name").Value,
                _race = Race.GetRace(cha.Element("race").Value),
                _realm = cha.Element("realm").Value,
                _thumbnail = cha.Element("thumbnail").Value,

                _guild = GuildMember.ReadGuildMember(cha.Element("guild")),
                _stats = Stats.ReadStat(cha.Element("stats")),
                _talents = Talent.ReadTalent(cha.Element("talents")),
                _items = ItemSet.ReadItemSet(cha.Element("items")),
                _reputation = Reputation.ReadReputations(cha.Element("reputation")),
                _titles = Title.ReadTitles(cha.Element("titles")),
                _professions = ProfessionSet.ReadProfessionSet(cha.Element("professions")),
                _appearance = Appearance.ReadAppearance(cha.Element("appearance")),
                _pets = Pet.ReadPets(cha.Element("pets")),
                _achievements = AchievementMap.ReadAchiements(cha.Element("achievments")),
                _progression = Progression.ReadProgression(cha.Element("progression")),
                _pvpStats = PvpMap.ReadPvpMap(cha.Element("pvp"))
            };

            if (cha.Element("companions") != null)
                c._companions = GetList(cha.Element("companions"));
            if (cha.Element("mounts") != null)
                c._mounts = GetList(cha.Element("mounts"));
            if (cha.Element("quests") != null)
                c._quests = GetList(cha.Element("quests"));

            return c;
        }

        private static List<int> GetList(XElement xElement)
        {
            throw new NotImplementedException();
        }
    }
}
