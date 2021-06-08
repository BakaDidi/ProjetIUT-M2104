using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    class Unite
    {
        private uint nb_Frontieres;
        private bool plantable;
        private char type_Unite; // M --> Mer | F --> Forêt | T --> Terre

        public Unite(char lettre_Unite, uint nb_Frontieres2)
        {
            nb_Frontieres = nb_Frontieres2;

            if (lettre_Unite == 'M')
            {
                nb_Frontieres += 64;
                plantable = false;
            }

            if (lettre_Unite == 'F')
            {
                nb_Frontieres += 32;
                plantable = false;
            }
            else
            {
                plantable = true;
            }
        }

    }
}
