using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1
{
    class Salarie
    {
        #region attribut
        string matricule;
        string categorie;
        string service;
        string nom;
        decimal salaire;
        static int compteur = 0;
        #endregion

        #region propriété
        public string Matricule { get => matricule; set => matricule = value; }
        public string Categorie { get => categorie; set => categorie = value; }
        public string Service { get => service; set => service = value; }
        public string Nom { get => nom; set => nom = value; }
        public decimal Salaire { get => salaire; set => salaire = value; }

        public static int Compteur {get => compteur;}
        #endregion

        #region constructeur
        public Salarie()
        {
            Console.WriteLine("Constructeur par défaut");
            compteur++;
        }

        public Salarie(string matricule, string categorie, string service, string nom, decimal salaire)
        {
            Matricule = matricule;
            Categorie = categorie;
            Service = service;
            Nom = nom;
            Salaire = salaire;
            Console.WriteLine("Constructeur 2");
            compteur++;
        }
        #endregion


        #region 
        public void CalculerSalaire()
        {
            Console.WriteLine("Le salaire de " + Nom + " est de " + Salaire + " euros");
        }

        public static void ResetCompteur()
        {
            compteur = 0;
        }
        #endregion
        ~Salarie()
        {
            Console.WriteLine("Déstructeur");
        }

    }
}
