using Caisse.Classes;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace CaisseWPF.ViewModels
{
    public class VenteControlViewModel : ViewModelBase
    {
        private Panier panier;
        private ObservableCollection<Produit> produits;
        private int code;

        public Panier Panier { get => panier; set => panier = value; }
        public ObservableCollection<Produit> Produits { get => produits; set => produits = value; }
        public int Code { get => code; set => code = value; }
        public decimal Total { get => Panier.Total; }

        public ICommand AddCommand { get; set; }

        public ICommand ConfirmCommand { get; set; }

        public ICommand UpdateCommand { get; set; }

        public VenteControlViewModel()
        {
            Panier = new Panier();
            Produits = new ObservableCollection<Produit>(Panier.Produits);
            AddCommand = new RelayCommand(ActionAddCommand);
            ConfirmCommand = new RelayCommand(ActionConfirmCommand);
            UpdateCommand = new RelayCommand(ActionUpdateCommand);
        }


        private void ActionAddCommand()
        {
            Produit p = DataBase.Instance.GetProduitById(Code);
            if (p != null)
            {
                Panier.AddProduit(p);
                Produits.Add(p);
                DataBase.Instance.DescStock(p.Id);
                RaisePropertyChanged("Total");
            }
            else
            {
                MessageBox.Show("Aucun produit avec cet id");
            }
        }

        private void ActionConfirmCommand()
        {
            if (DataBase.Instance.SavePanier(Panier))
            {
                MessageBox.Show("Panier validé");
                Panier = new Panier();
                Produits = new ObservableCollection<Produit>(Panier.Produits);
                RaisePropertyChanged("Produits");
                RaisePropertyChanged("Total");
                
            }
            else
            {
                MessageBox.Show("Erreur serveur");
            }
        }

        private void ActionUpdateCommand()
        {
            DataBase.Instance.UpdateDataBase();
            MessageBox.Show("Mise à jour effectuée");
        }
    }
}
