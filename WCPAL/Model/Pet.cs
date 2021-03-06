﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    /// <summary>
    /// A <see cref="CharacterClass.Hunter"/>s Pet and its statistics
    /// </summary>
    public class Pet
    {
        private string _name;
        private int _creature;
        private bool _selected;
        private int _slot;

        public Pet(string name, int creature, bool selected, int slot)
        {
            _name = name;
            _creature = creature;
            _selected = selected;
            _slot = slot;
        }

        public Pet ReadPet(XElement e)
        {
            Pet p;

            p = new Pet(
                e.Element("name").Value,
                int.Parse(e.Element("creature").Value),
                bool.Parse(e.Element("selected").Value),
                int.Parse(e.Element("slot").Value)
                );

            return p;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Creature
        {
            get { return _creature; }
        }

        public bool Selected
        {
            get { return _selected; }
        }

        public int Slot
        {
            get { return _slot; }
        }

        internal static List<Pet> ReadPets(XElement xElement)
        {
            throw new NotImplementedException();
        }
    }
}
