using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    class Parcelle
    {
        private char nom;
        private uint nb_Unites;
        private List<Unite> list_Unite = new List<Unite>();

        public Parcelle(char nom2)
        {
            if (nom2 != 'F' && nom2 != 'M')
                nom = nom2;
        }

        public void Parcelle_increment(Unite unite)
        {
            list_Unite.Add(unite);
            nb_Unites++;
        }

        public char Nom
        {
            get => nom;
        }

        public uint Nb_Unites
        {
            get => nb_Unites;
        }

        public List<Unite> List_Unite
        {
            get => list_Unite;
        }
    }
}
