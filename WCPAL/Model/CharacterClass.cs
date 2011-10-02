using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// The class of a character.
    /// </summary>
    public class CharacterClass
    {
        private int _id;
        private int _mask;
        private String _name;
        private PowerType _powerType;

        public int Id { get { return _id; } }
        public int Mask { get { return _mask; } }
        public String Name { get { return _name; } }
        public PowerType PowerType { get { return _powerType; } }

        public CharacterClass()
        {
        }

        public static CharacterClass Hunter 
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 3,
                    _mask = 4,
                    _name = "Hunter",
                    _powerType = PowerType.Focus
                };
            }
        }

        public static CharacterClass Rogue
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 4,
                    _mask = 8,
                    _name = "Rogue",
                    _powerType = PowerType.Energy
                };
            }
        }

        public static CharacterClass Warrior
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 1,
                    _mask = 1,
                    _name = "Warrior",
                    _powerType = PowerType.Rage
                };
            }
        }

        public static CharacterClass Paladin
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 2,
                    _mask = 2,
                    _name = "Paladin",
                    _powerType = PowerType.Mana
                };
            }
        }

        public static CharacterClass Shaman
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 7,
                    _mask = 64,
                    _name = "Shaman",
                    _powerType = PowerType.Mana
                };
            }
        }

        public static CharacterClass Mage
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 8,
                    _mask = 128,
                    _name = "Mage",
                    _powerType = PowerType.Mana
                };
            }
        }

        public static CharacterClass Priest
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 5,
                    _mask = 16,
                    _name = "Priest",
                    _powerType = PowerType.Mana
                };
            }
        }

        public static CharacterClass DeathKnight
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 6,
                    _mask = 32,
                    _name = "Death Knight",
                    _powerType = PowerType.Rune
                };
            }
        }

        public static CharacterClass Druid
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 11,
                    _mask = 1024,
                    _name = "Druid",
                    _powerType = PowerType.Mana
                };
            }
        }

        public static CharacterClass Warlock
        {
            get
            {
                return new CharacterClass()
                {
                    _id = 9,
                    _mask = 256,
                    _name = "Warlock",
                    _powerType = PowerType.Mana
                };
            }
        }

        internal static CharacterClass GetClass(string c)
        {
            // TODO: given an in represting the ID return the proper character class;
            throw new NotImplementedException();
        }
    }
}
