using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// Reputation standing with a specific faction.
    /// </summary>
    public class Reputation
    {
        private int _id;

        public int Id
        {
            get { return _id; }
        }
        private string _name;

        public string Name
        {
            get { return _name; }
        }
        private ReputationStanding _standing;

        public ReputationStanding Standing
        {
            get { return _standing; }
        }
        private int _value;

        public int Value
        {
            get { return _value; }
        }
        private int _max;

        public int Max
        {
            get { return _max; }
        }

        internal static List<Reputation> ReadReputations(System.Xml.Linq.XElement xElement)
        {
            throw new NotImplementedException();
        }
    }
}
