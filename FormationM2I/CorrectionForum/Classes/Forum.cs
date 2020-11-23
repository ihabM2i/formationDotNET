using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionForum.Classes
{
    class Forum
    {
        string nom;
        DateTime dateCreation;
        List<Nouvelle> nouvelles;
        List<Abonne> abonnes;
        Moderateur moderateur;

        public string Nom { get => nom; set => nom = value; }
        public DateTime DateCreation { get => dateCreation; }
        public List<Nouvelle> Nouvelles { get => nouvelles; set => nouvelles = value; }
        public List<Abonne> Abonnes { get => abonnes; set => abonnes = value; }
        public Moderateur Moderateur { get => moderateur; set => moderateur = value; }

        public Forum(string nom)
        {
            Nouvelles = new List<Nouvelle>();
            Abonnes = new List<Abonne>();
            Nom = nom;
            dateCreation = DateTime.Now;
        }

        public override string ToString()
        {
            return $"{Nom}, {DateCreation}";
        }
    }
}
