using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    class Voiture
    {
        string model;
        string marque;


        public Voiture(string model)
        {
            Model = model;
        }
        public Voiture(string model, string marque) : this(model)
        {
           
            Marque = marque;
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (value.Length > 3)
                    model = value;
                else
                    //throw new Exception("Erreur model");
                    Console.WriteLine("Erreur");
            }
        }
        public string Marque { get => marque; set => marque = value; }

        //public string getModel()
        //{
        //    return Model;
        //}

        //public void setModel(string model)
        //{
        //    this.Model = model;
        //}

    }
}
