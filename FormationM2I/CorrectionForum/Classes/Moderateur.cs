using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionForum.Classes
{
    class Moderateur : Abonne
    {
        public Moderateur(string n, string p, int a, string e, Forum f) : base(n,p, a,e, f)
        {

        }

        public bool SupprimerNouvelle(int id)
        {
            Nouvelle nouvelle = null;
            foreach(Nouvelle n in Forum.Nouvelles)
            {
                if(n.Id == id)
                {
                    nouvelle = n;
                    break;
                }
            }
            if(nouvelle != null)
            {
                return Forum.Nouvelles.Remove(nouvelle);
            }
            return false;
        }

        public bool BannirAbonne(string email)
        {
            Abonne abonne = null;
            foreach(Abonne a in Forum.Abonnes)
            {
                if(a.Email == email)
                {
                    abonne = a;
                    break;
                }
            }
            if(abonne != null)
                return Forum.Abonnes.Remove(abonne);
            return false;
        }

        public void AjouterAbonne(Abonne a)
        {
            Forum.Abonnes.Add(a);
        }
    }
}
