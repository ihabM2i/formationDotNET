using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace coursWPF.Classes
{
    public class Personne : INotifyPropertyChanged
    {
        private string nom;
        private string prenom;
        private string telephone;
        public string Nom
        {
            get => nom;
            set
            {
                nom = value;
                RaisePropertyChanged("Nom");
            }
        }
        public string Prenom
        {
            get => prenom;
            set
            {
                prenom = value;
                RaisePropertyChanged("Prenom");
            }
        }

        public string Telephone { get => telephone; set => telephone = value; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public override string ToString()
        {
            return Nom + " " + Prenom;
        }
    }
}
