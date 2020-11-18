using System;

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
            int i = 10;
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
            string chaine;
            do
            {
                chaine = Console.ReadLine();
            } while (chaine != "0");
            #endregion
        }
    }
}
