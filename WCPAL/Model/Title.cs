﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    /// <summary>
    /// A World of Warcraft Title.
    /// </summary>
    public class Title
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
    }
}