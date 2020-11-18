using System;
using System.Text;

namespace CoursCSharpPartie1
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Déclaration de variable et opération
            //Déclarer des variables
            //pour déclarer une variable, on indique son type
            //int age = 33;
            //int a;
            //a = 30;
            //string nomComplet = "abadi ihab";
            //long l = 1000;
            //Rappel des types de variable
            //byte => 1 Octet -128 à 127
            //int => entier => 4 Octets (-2^31-1) à (2^31-1)
            //short => petit entier => 2 Octets
            //long => un grand entier => 8 Octets
            //u => unsigned, uint, ushort, ulong
            //char => un caractère
            //char c = 'a';
            //bool test = true;
            //Nombre float, double, decimal
            //float f = 30.5F;
            //double d = 40.2;
            //decimal dc = 10.3M;
            //Rappel opération mathématique
            //int a, ab;
            //double b, c;
            //a = 10;
            //b = 30;
            //c = a + b;
            //c = a - b;
            //c = a / b;
            //Opération incrémentation
            //ab = a++;
            ////a--;
            //ab = ++a;
            //string nom = "abadi";
            //string prenom = "ihab";
            //Console.WriteLine(nom + prenom);
            #endregion

            #region Structures conditionnelles
            //If else
            //int age = 33;
            //string result;
            //if (age >= 18)
            //    //Console.WriteLine("Majeur");
            //    result = "Majeur";
            //else
            //    //Console.WriteLine("Mineur");
            //    result = "Mineur";
            ////ternaire
            //result = (age >= 18) ? "Majeur" : "Mineur";
            //Switch
            //int mois = 1;
            //switch(mois)
            //{
            //    case 1:
            //        Console.WriteLine("Janvier");
            //        break;
            //    case 2:
            //        Console.WriteLine("Février");
            //        break;
            //    case 3:
            //        Console.WriteLine("Mars");
            //        break;
            //    case 4:
            //        Console.WriteLine("Avril");
            //        break;
            //    case 5:
            //        Console.WriteLine("Mai");
            //        break;
            //    default:
            //        Console.WriteLine("Erreur du mois");
            //        break;
            //}

            #endregion

            #region Instruction de lecture et ecriture en console
            //Pour afficher une ligne dans une console
            //Console.WriteLine("Bonjour ");
            //Console.Write("Tout ");
            //Console.Write("Monde");
            //Pour la lecture à partir d'une console
            /* Console.Write("Merci de saisir votre nom : ");
             string nom = Console.ReadLine();
             Console.WriteLine(nom);
             Console.WriteLine("Merci de saisir votre âge : ");
             int age = Convert.ToInt32(Console.ReadLine());
             Console.WriteLine(age);*/
            #endregion

            #region Structures itératives
            //Boucle for
            //for(int i=1; i <= 10; i++)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("=========");
            //for(int i=10; i > 0; i = i - 2)
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("==========");
            //for(char c='A'; c <= 'Z'; c++)
            //{
            //    Console.WriteLine(c);
            //}

            //Boucle while
            //int i = 10;
            //while (i < 10)
            //{
            //    Console.WriteLine(i);
            //    i++;
            //    //if (i == 5)
            //    //{
            //    //    i = 15;
            //    //}
            //}
            //string chaine = Console.ReadLine();
            //while(chaine != "0")
            //{
            //    Console.WriteLine("Merci de saisir une nouvelle chaine");
            //    chaine = Console.ReadLine();
            //}
            //do
            //{
            //    Console.WriteLine(i);
            //    i++;
            //} while (i < 10);
            //string chaine;
            //do
            //{
            //    chaine = Console.ReadLine();
            //} while (chaine != "0");
            #endregion

            #region correction serie 1
            //Correction exercice 1
            /*Console.Write("Merci de saisir un nombre : ");
            int nombre = Convert.ToInt32(Console.ReadLine());
            //En utilisant boucle for
            //for(int i=1; i<= nombre/2 + 1; i++)
            //{
            //    int somme = i;
            //    string chaine = nombre + " = " + i;
            //    for(int j=i+1; j <= nombre / 2 + 1; j++)
            //    {
            //        somme = somme + j;
            //        chaine += "+" + j;
            //        if (somme == nombre)
            //        {
            //            Console.WriteLine(chaine);
            //            break;
            //        }
            //    } 
            //}

            //En utilisant boucle while
            int i = 1;
            while( i <= nombre/2 + 1)
            {
                int somme = i;
                string chaine = nombre + " = " + i;
                int j = i + 1;
                while(j <= nombre / 2 + 1)
                {
                    somme = somme + j;
                    chaine += "+" + j;
                    if (somme == nombre)
                    {
                        Console.WriteLine(chaine);
                        break;
                    }
                    j++;
                }
                i++;
            }*/
            //Correction exercice 2
            //Console.OutputEncoding = Encoding.UTF8;
            //Console.Write("Merci de saisir votre âge : ");
            //int age = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Merci de saisir le dernier salaire : ");
            //decimal salaire = Convert.ToDecimal(Console.ReadLine());
            //Console.Write("Merci de saisir votre ancienneté : ");
            //int anciennete = Convert.ToInt32(Console.ReadLine());
            //decimal indemnite = 0;
            //if (anciennete <= 10)
            //{
            //    indemnite += anciennete * salaire / 2;
            //}
            //else
            //{
            //    indemnite += 10 * salaire / 2;
            //    indemnite += (anciennete - 10) * salaire;
            //}
            //if (age > 45)
            //{
            //    indemnite += (age < 50) ? 2 * salaire : 5 * salaire;
            //}
            //Console.WriteLine("Votre indemnité est de : " + indemnite + " €");

            //switch(anciennete)
            //{
            //    case int n when (n < 10):

            //        break;
            //    case int n when n >= 10:

            //        break;
            //}
            //Correction Ex 3
            //Console.Write("Nb enfants: ");
            //int nbChildrens = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Merci indiquer situation familiale 1/Celibataire 2/Marie: ");
            //int situation = Convert.ToInt32(Console.ReadLine());
            //Console.Write("Revenu imposable : ");
            //decimal imposable_salary = Convert.ToDecimal(Console.ReadLine());

            //decimal nb_parts = nbChildrens <= 2 ? (0.5M * nbChildrens) : (nbChildrens - 1);
            //nb_parts += situation;
            //decimal result = 0;

            //if (imposable_salary / nb_parts > 10064 && imposable_salary / nb_parts <= 27794)
            //{
            //    result = imposable_salary * 0.14M - 1408.96M * nb_parts;
            //}
            //else if (imposable_salary / nb_parts > 27794 && imposable_salary / nb_parts <= 74517)
            //{
            //    result = imposable_salary * 0.30M - 5856M * nb_parts;
            //}
            //else if (imposable_salary / nb_parts > 74517 && imposable_salary / nb_parts <= 157806)
            //{
            //    result = imposable_salary * 0.41M - 14052.87M * nb_parts;
            //}
            //else if (imposable_salary / nb_parts > 157806)
            //{
            //    result = imposable_salary * 0.45M - 20365.11M * nb_parts;
            //}
            //Console.Write(result);

            #endregion

            #region Tableaux
            //Création d'un tableau entier de 5 éléments 
            Console.WriteLine("Merci d'indiquer la taille du tableau");
            int taille = Convert.ToInt32(Console.ReadLine());
            int[] tabEntier = new int[taille];
            

            //Ecrire les valeurs d'un tableau
            for(int i = 0; i < tabEntier.Length; i++)
            {
                Console.WriteLine("Merci de saisir l'entier à la case : " + i);
                tabEntier[i] = Convert.ToInt32(Console.ReadLine());
            }

            //Afficher les valeurs d'un tableau
            for (int i = 0; i < tabEntier.Length; i++)
            {
                Console.WriteLine(tabEntier[i]);
            }
            #endregion
        }
    }
}
