using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace WCPAL
{
    public class Appearance
    {
        private int _faceVariation;
        private int _skinColor;
        private int _hairVariation;
        private int _hairColor;
        private int _featureVariation;
        private bool _showHelm;
        private bool _showCloak;

        public Appearance(int faceVariation, int skinColor, int hairVariation, int featureVariation, bool showHelm, bool showCloak)
        {
            _faceVariation = faceVariation;
            _skinColor = skinColor;
            _hairVariation = hairVariation;
            _featureVariation = featureVariation;
            _showHelm = showHelm;
            _showCloak = showCloak;
        }

        public static Appearance ReadAppearance(XElement e)
        {
            Appearance a;

            a = new Appearance(
                int.Parse(e.Element("faceVariation").Value),
                int.Parse(e.Element("skinColor").Value),
                int.Parse(e.Element("hairVariation").Value),
                int.Parse(e.Element("hairColor").Value),
                bool.Parse(e.Element("showHelm").Value),
                bool.Parse(e.Element("showCloak").Value)
                );

            return a;
        }

        public int FaceVariation
        {
            get { return _faceVariation; }
        }
       
        public int SkinColor
        {
            get { return _skinColor; }
        }
        
        public int HairVariation
        {
            get { return _hairVariation; }
        }
        
        public int HairColor
        {
            get { return _hairColor; }
        }
        
        public int FeatureVariation
        {
            get { return _featureVariation; }
        }

        public bool ShowHelm
        {
            get { return _showHelm; }
        }
        
        public bool ShowCloak
        {
            get { return _showCloak; }
        }
    }
}
