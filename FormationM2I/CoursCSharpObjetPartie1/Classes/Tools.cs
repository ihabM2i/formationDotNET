using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    public class Tools
    {
        public bool IsBissextile(int annee)
        {
            //if(annee%4 == 0)
            //{
            //    if(annee%100 == 0 && annee%400 != 0)
            //    {
            //        return false;
            //    }
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            return (annee % 4 == 0 && !(annee % 100 == 0 && annee % 400 != 0));
        }
    }
}
