WCPAL
==========
The World of Warcraft Community Portal API Library (WCPAL) is a C# .net library designed to make connecting to the API exposed by Blizzard Inc simple and straight forward.

This is currently under heavy development and will be fairly unstable until it is finished. Currently you may use the API library to collect realm information.

Documentation
==========

You can view the technical documentation for this project at http://daegren.github.com/WCPAL

Sample
==========

    using System;
    using WCPAL.Model;
    
    namespace WCPAL_Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                WoWPlatform wp = new WoWPlatform();
                String realmName = "Llane";
          
                Realm r = wp.GetRealmStatus(realmName);
          
                Console.println(realmName + "'s current status is: " + r.Status ? "Online" : "Offline");
            }
        }
    }