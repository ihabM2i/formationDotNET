using System;

namespace CoursCSharpObjetPartie1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region cours POO
            //Personne p1 = new Personne();
            ////p1.nom = "abadi";
            ////p1.prenom = "ihab";
            ////Adresse a = new Adresse();
            ////a.adresse = "tilleul";
            ////a.ville = "Tourcoing";
            ////p1.adresse = a;
            ////Console.WriteLine(p1.nom + " " + p1.prenom);
            ////p1.SetNom("abadi");
            //p1.Nom = "abadi";
            //p1.Prenom = "ihab";
            //p1.Afficher();
            //Console.WriteLine(p1.Nom + " "+ p1.Prenom);
            //Personne p2 = new Personne();
            ////p2.nom = "tata";
            ////p2.prenom = "toto";
            ////Console.WriteLine(p2.nom + " " + p2.prenom);
            ////Start Gc
            //GC.Collect();
            //p2.Afficher();



            //Personne p3 = new Personne("titi", "minet", 50);
            //p3.Afficher();
            //Personne p4 = Personne.CreatePersonne("tata", "toto", 20);
            //Console.WriteLine(Personne.compteur);

            #endregion
            #region Correction exercice 1 poo
            /*Salarie s1 = new Salarie();
            s1.Nom = "s1";
            s1.Categorie = "c1";
            s1.Matricule = "m1";
            s1.Service = "sv1";
            s1.Salaire = 2000;

            Salarie s1bis = new Salarie("tttt");

            Salarie s2 = new Salarie("m2", "c2", "sv2", "s2" , 3000);
           
            Console.WriteLine("Le nombre de salariés : " + Salarie.Compteur);
            Salarie.ResetCompteur();
            Salarie s3 = new Salarie("m3", "c3", "sv3", "s3", 4000);
            Salarie[] tabSalarie = new Salarie[] { s1, s2, s3 };

            for(int i=0; i < tabSalarie.Length; i++)
            {
                tabSalarie[i].CalculerSalaire();
            }
            Console.WriteLine("Le nombre de salariés : " + Salarie.Compteur);
            GC.Collect();*/
            #endregion

            #region coursPOO héritage
            /*Etudiant e = new Etudiant();
            e.Nom = "nom e1";
            e.Prenom = "prenom e1";
            e.Age = 20;
            e.Niveau = 3;
            e.Afficher();
            //e.AfficherEtudiant();
            Personne e2 = new Etudiant("nom e2", "prenom e2", 21, 4);
            e2.Afficher();
            Personne s1 = new Salarie();
            Personne[] personnes = new Personne[] { e2, s1 };

            foreach(Personne p in personnes)
            {
                Console.WriteLine(p.GetType());
            }
            //Console.WriteLine(e2.GetType());
            //e2.AfficherEtudiant();*/
            #endregion

            #region Correction tp 1 héritage
            //IHM ihm = new IHM();
            //ihm.Start();
            #endregion

            #region suite coursPOO héritage
            //object c = new object();
            Personne p = new Etudiant("abadi", "ihab", 33, 4);
            Console.WriteLine(p.ToString());
            #endregion
        }
    }
}
