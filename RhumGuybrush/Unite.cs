using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    class Unite
    {
        private uint val_Frontieres;
        private char nom;
        private int pos_x;
        private int pos_y;

        public Unite(char lettre_Unite, uint val_Frontieres2)
        {
            val_Frontieres = val_Frontieres2;

            if (lettre_Unite == 'M')
            {
                val_Frontieres += 64;
            }

            if (lettre_Unite == 'F')
            {
                val_Frontieres += 32;
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
    }
}
