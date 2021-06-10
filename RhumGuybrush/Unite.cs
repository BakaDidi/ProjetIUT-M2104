using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    class Unite
    {
        private uint val_Frontieres;
        private bool plantable;
        private char nom;
        private int pos_x;
        private int pos_y;
        private int numero_parcelle;

        public Unite(char lettre_Unite, uint val_Frontieres2)
        {
            val_Frontieres = val_Frontieres2;

            if (lettre_Unite == 'M')
            {
                val_Frontieres += 64;
                plantable = false;
            }

            if (lettre_Unite == 'F')
            {
                val_Frontieres += 32;
                plantable = false;
            }
            else
            {
                plantable = true;
            }
        }

        public Unite(uint val_Frontieres2)
        {
            val_Frontieres = val_Frontieres2;
        }

        public Unite(char nom2)
        {
            nom = nom2;
        }

        public Unite(char nom2, int pos_x2, int pos_y2)
        {
            nom = nom2;
            pos_x = pos_x2;
            pos_y = pos_y2;
            numero_parcelle = nom - 97;
        }

        public uint Val_Frontieres
        {
            get => val_Frontieres;
        }

        public char Nom
        {
            get => nom;
            set => nom = value;
        }
        public int Pos_x
        {
            get => pos_x;
        }
        public int Pos_y
        {
            get => pos_y;
        }

        public int Numero_parcelle
        {
            get => numero_parcelle;
        }
    }
}
