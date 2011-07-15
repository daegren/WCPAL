using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL.Model
{
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
        private Stat _stats;
        private List<Talent> _talents;
        private ItemSet _items;
        private List<Reputation> _reputation;
        private List<Title> _titles;
        private ProfessionSet _professions;
        private Appearance _appearance;
        private List<int> _companions;
        private List<int> _mounts;
        private List<Pet> _pets;
        private Achievement _acheivements;

    }
}
