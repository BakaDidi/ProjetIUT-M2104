using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    class Parcelle
    {
        private char nom;
        private uint nb_Unites;

        public Parcelle(char nom2)
        {
            if (nom2 != 'F' && nom2 != 'M')
                nom = nom2;
        }

        public void Parcelle_increment()
        {
            nb_Unites++;
        }
    }
}
