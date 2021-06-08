using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    class Unite
    {
        private uint val_Frontieres;
        private bool plantable;
        private char type_Unite; // M --> Mer | F --> Forêt | T --> Terre

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

        public uint Val_Frontieres
        {
            get => val_Frontieres;
        }


    }
}
