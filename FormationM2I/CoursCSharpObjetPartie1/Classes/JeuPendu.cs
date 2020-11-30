using System;
using System.Collections.Generic;
using System.Text;

namespace CoursCSharpObjetPartie1.Classes
{
    public class JeuPendu
    {
        private IGenerateur generateur;
        private string motATrouve;
        private int nbreEssai;
        private string masque;
        public JeuPendu(IGenerateur g)
        {
            generateur = g;
            motATrouve = g.Generer();
            nbreEssai = 10;
        }

        public int NbreEssai { get => nbreEssai; }
        public string Masque { get => masque; }

        public bool TestChar(char c)
        {
            throw new Exception("en cours de dev");
        }

        public bool TestWin()
        {
            throw new Exception("en cours de dev");
        }

        public void GenererMasque()
        {
            throw new Exception("en cours de dev");
        }
    }
}
