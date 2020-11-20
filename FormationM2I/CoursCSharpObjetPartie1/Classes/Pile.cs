using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    class Pile<T>
    {
        T[] elements;
        int taille;
        int compteur = 0;

        public Pile(int t)
        {
            taille = t;
            elements = new T[taille];
        }

        public void Empiler(T element)
        {
            if(compteur < taille)
            {
                elements[compteur] = element;
                compteur++;
            }
        }

        public void Depiler()
        {
            if(compteur > 0)
            {
                elements[compteur - 1] = default(T);
                compteur--;
            }
        }

        public T Get(int index)
        {
            return elements[index];
        }
    }
}
