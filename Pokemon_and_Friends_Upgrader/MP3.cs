using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pokemon_and_Friends_Upgrader
{
    class MP3
    {
        public string sPath;
        public string sName;

        public MP3(string sPath)
        {
            this.sPath = sPath;
            this.sName = sPath.Split('\\')[sPath.Split('\\').Length - 1];
        }

        public override string ToString()
        {
            return sName;
        }
    }
}
