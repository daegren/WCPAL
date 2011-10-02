using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// Character races.
    /// </summary>
    public class Race
    {
        private int _id;
        private int _mask;
        private String _name;
        private Side _side;

        public int Id { get { return _id; } }
        public int Mask { get { return _mask; } }
        public String Name { get { return _name; } }
        public Side Side { get { return _side; } }


        public Race() { }


        public static Race Dwarf
        {
            get
            {
                return new Race()
                {
                    _id = 3,
                    _mask = 4,
                    _name = "Dwarf",
                    _side = Side.Alliance
                };
            }
        }

        public static Race Tauren
        {
            get
            {
                return new Race()
                {
                    _id = 6,
                    _mask = 32,
                    _name = "Tauren",
                    _side = Side.Horde
                };
            }
        }

        public static Race Undead
        {
            get
            {
                return new Race()
                {
                    _id = 5,
                    _mask = 16,
                    _name = "Undead",
                    _side = Side.Horde
                };
            }
        }

        public static Race Orc
        {
            get
            {
                return new Race()
                {
                    _id = 2,
                    _mask = 2,
                    _name = "Orc",
                    _side = Side.Horde
                };
            }
        }

        public static Race Gnome
        {
            get
            {
                return new Race()
                {
                    _id = 7,
                    _mask = 64,
                    _name = "Gnome",
                    _side = Side.Alliance
                };
            }
        }

        public static Race Troll
        {
            get
            {
                return new Race()
                {
                    _id = 8,
                    _mask = 128,
                    _name = "Troll",
                    _side = Side.Horde
                };
            }
        }

        public static Race Goblin
        {
            get
            {
                return new Race()
                {
                    _id = 9,
                    _mask = 256,
                    _name = "Goblin",
                    _side = Side.Horde
                };
            }
        }

        public static Race Draenei
        {
            get
            {
                return new Race()
                {
                    _id = 11,
                    _mask = 1024,
                    _name = "Draenei",
                    _side = Side.Alliance
                };
            }
        }

        public static Race Worgen
        {
            get
            {
                return new Race()
                {
                    _id = 22,
                    _mask = 2097152,
                    _name = "Worgen",
                    _side = Side.Alliance
                };
            }
        }

        public static Race BloodElf
        {
            get
            {
                return new Race()
                {
                    _id = 10,
                    _mask = 512,
                    _name = "Blood Elf",
                    _side = Side.Horde
                };
            }
        }

        public static Race Human
        {
            get
            {
                return new Race()
                {
                    _id = 1,
                    _mask = 1,
                    _name = "Human",
                    _side = Side.Alliance
                };
            }
        }

        public static Race NightElf
        {
            get
            {
                return new Race()
                {
                    _id = 4,
                    _mask = 8,
                    _name = "Night Elf",
                    _side = Side.Alliance
                };
            }
        }

        internal static Race GetRace(string p)
        {
            // TODO: given an in represting the ID return the proper character race;
            throw new NotImplementedException();
        }
    }

    public enum Side
    {
        Alliance,
        Horde
    }
}
