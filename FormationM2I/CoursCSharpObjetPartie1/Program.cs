using System;

namespace CoursCSharpObjetPartie1
{
    class Program
    {
        static void Main(string[] args)
        {
            Personne p1 = new Personne();
            //p1.nom = "abadi";
            //p1.prenom = "ihab";
            //Adresse a = new Adresse();
            //a.adresse = "tilleul";
            //a.ville = "Tourcoing";
            //p1.adresse = a;
            //Console.WriteLine(p1.nom + " " + p1.prenom);
            //p1.SetNom("abadi");
            p1.Nom = "abadi";
            p1.Afficher();
            Personne p2 = new Personne();
            //p2.nom = "tata";
            //p2.prenom = "toto";
            //Console.WriteLine(p2.nom + " " + p2.prenom);
            p2.Afficher();
            Personne p3 = new Personne("titi", "minet", 50);
            p3.Afficher();
        }
    }
}
