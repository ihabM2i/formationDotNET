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
            switch(choix)
            {
                case "1":
                    Console.Write("Dépôt initial : ((o)ui/ (n)on)");
                    string response = Console.ReadLine();
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
                    break;
                case "3":
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
    }
}
