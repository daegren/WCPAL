using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WCPAL
{
    class GeneralUtilites
    {
        internal static DateTime ConvertFromUnixTimestamp(string timestamp)
        {
            DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0); //create datetime at UNIX epoch
            // trim extra 0's off end of string
            int a = -1;
            for (int i = timestamp.Length - 1; i > 0; i--)
            {
                int n = int.Parse(timestamp[i].ToString());
                if (n > 0)
                {
                    a = i + 1;
                    break;
                }
            }
            double d = double.Parse(timestamp.Substring(0, a));
            return origin.AddSeconds(d);
        }
    }
}
