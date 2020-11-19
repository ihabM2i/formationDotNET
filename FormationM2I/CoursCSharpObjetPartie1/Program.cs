using System;

namespace CoursCSharpObjetPartie1
{
    class Program
    {
        static void Main(string[] args)
        {
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

            Salarie s1 = new Salarie();
            s1.Nom = "s1";
            s1.Categorie = "c1";
            s1.Matricule = "m1";
            s1.Service = "sv1";
            s1.Salaire = 2000;
            

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
            GC.Collect();

        }
    }
}
