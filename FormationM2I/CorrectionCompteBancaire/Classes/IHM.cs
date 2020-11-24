using System;
using System.Collections.Generic;
using System.Text;

namespace CorrectionCompteBancaire.Classes
{
    class IHM
    {
        private Banque banque;

        public void Start()
        {
            banque = new Banque();
            ActionPrincipal();
        }

        private void MenuPrincipal()
        {
            Console.WriteLine("1----Création compte");
            Console.WriteLine("2----Effectuer un dépôt");
            Console.WriteLine("3----Effectuer un retrait");
            Console.WriteLine("4----Afficher opération et solde");
            Console.WriteLine("5----Calcule Interet");
        }

        private void MenuCreationCompte()
        {
            Console.WriteLine("1---Compte courant");
            Console.WriteLine("2---Compte Epargne");
            Console.WriteLine("3---Compte Payant");
        }

        private void ActionPrincipal()
        {
            string choix;
            do
            {
                MenuPrincipal();
                choix = Console.ReadLine();
                Console.Clear();
                switch (choix)
                {
                    case "1":
                        ActionCreationCompte();
                        break;
                    case "2":
                        ActionDepot();
                        break;
                    case "3":
                        ActionRetrait();
                        break;
                    case "4":
                        ActionAffichage();
                        break;
                    case "5":
                        ActionCalculeInteret();
                        break;
                }
            } while (choix != "0");
        }
        private Client ActionCreationClient()
        {
            Console.Write("Nom : ");
            string nom = Console.ReadLine();
            Console.Write("Prénom : ");
            string prenom = Console.ReadLine();
            Console.Write("Téléphone : ");
            string telephone = Console.ReadLine();
            return new Client(nom, prenom, telephone);
        }
        private void ActionCreationCompte()
        {
            Console.WriteLine("======Création de compte======");
            MenuCreationCompte();
            string choix = Console.ReadLine();
            Compte compte = null;
            Client client = ActionCreationClient();
            string response = "";
            switch (choix)
            {
                case "1":
                    Console.Write("Dépôt initial : ((o)ui/ (n)on)");
                    response = Console.ReadLine();
                    if(response == "o")
                    {
                        Console.Write("Solde : ");
                        decimal soldeInitial = Convert.ToDecimal(Console.ReadLine());
                        compte = new Compte(client, soldeInitial);
                    }
                    else
                    {
                        compte = new Compte(client);
                    }
                    break;
                case "2":
                    Console.Write("Taux Interet : ");
                    decimal taux = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Dépôt initial : ((o)ui/ (n)on)");
                    response = Console.ReadLine();
                    if (response == "o")
                    {
                        Console.Write("Solde : ");
                        decimal soldeInitial = Convert.ToDecimal(Console.ReadLine());
                        compte = new CompteEpargne(client, taux, soldeInitial);
                    }
                    else
                    {
                        compte = new CompteEpargne(client, taux);
                    }
                    break;
                case "3":
                    Console.Write("Cout opération : ");
                    decimal cout = Convert.ToDecimal(Console.ReadLine());
                    Console.Write("Dépôt initial : ((o)ui/ (n)on)");
                    response = Console.ReadLine();
                    if (response == "o")
                    {
                        Console.Write("Solde : ");
                        decimal soldeInitial = Convert.ToDecimal(Console.ReadLine());
                        compte = new ComptePayant(client, cout, soldeInitial);
                    }
                    else
                    {
                        compte = new ComptePayant(client, cout);
                    }
                    break;
            }
            if(compte != null)
            {
                banque.Comptes.Add(compte);
                Console.WriteLine("Compte bancaire crée avec le numéro " + compte.Numero);
            }
        }

        private void ActionDepot()
        {
            Compte compte = ActionChercherCompte();
            if (compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }else
            {
                Console.Write("Montant du dépôt : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                if(compte.Depot(montant))
                {
                    Console.WriteLine("Dépôt effectué, nouveau solde " + compte.Solde);
                }
                else
                {
                    Console.WriteLine("Erreur dépôt");
                }
            }
        }

        private void ActionRetrait()
        {
            Compte compte = ActionChercherCompte();
            if (compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            else
            {
                Console.Write("Montant du retrait : ");
                decimal montant = Convert.ToDecimal(Console.ReadLine());
                if (compte.Retrait(montant))
                {
                    Console.WriteLine("Retrait effectué, nouveau solde " + compte.Solde);
                }
                else
                {
                    Console.WriteLine("Erreur retrait");
                }
            }
        }
        private void ActionAffichage()
        {
            Compte compte = ActionChercherCompte();
            if(compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            else {
                Console.WriteLine("=======Solde et opération========");
                Console.WriteLine(compte);
            }
        }

        private Compte ActionChercherCompte()
        {
            Console.Write("Numéro de compte : ");
            int numero = Convert.ToInt32(Console.ReadLine());
            Compte compte = banque.GetCompteById(numero);
            return compte;
        }

        private void ActionCalculeInteret()
        {
            Compte compte = ActionChercherCompte();
            if (compte == null)
            {
                Console.WriteLine("Aucun compte avec ce numéro");
            }
            else
            {
                if(compte is CompteEpargne compteEpargne)
                {
                    compteEpargne.CalculeInteret();
                }
                else
                {
                    Console.WriteLine("Ce n'est pas un compte epargne");
                }
            }
        }
    }
}
