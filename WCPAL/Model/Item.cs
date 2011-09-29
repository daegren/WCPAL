using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    public class Item
    {
        private string _icon;
        private int _id;
        private string _name;
        private EquipmentSlot _slot;
        private Quality _quality;
        private int _enchant;
        private List<int> _gems;
        private List<int> _sets;

        public string Icon { get { return _icon; } }
        public int Id { get { return _id; } }
        public string Name { get { return _name; } }
        public EquipmentSlot Slot { get { return _slot; } }
        public Quality Quality { get { return _quality; } }
    }
}
