using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    /// <summary>
    /// Classe Unite: modélise une unite
    /// </summary>
    class Unite
    {
        #region Attributs
        /// <summary>
        /// Valeur représentant les frontières de l'unite (en utilisant le système base puissance de 2) 
        /// </summary>
        private uint val_Frontieres;

        /// <summary>
        /// Nom de l'unite
        /// </summary>
        private char nom;

        /// <summary>
        /// Position x de l'unite sur la carte
        /// </summary>
        private int pos_x;

        /// <summary>
        /// Position y de l'unite sur la carte
        /// </summary>
        private int pos_y;

        #endregion

        #region Accesseurs
        /// <summary>
        /// Accesseur en lecture de l'attribut val_Frontieres
        /// </summary>
        public uint Val_Frontieres
        {
            get => val_Frontieres;
        }

        /// <summary>
        /// Accesseur en lecture de l'attribut nom
        /// </summary>
        public char Nom
        {
            get => nom;
            set => nom = value;
        }

        /// <summary>
        /// Accesseur en lecture de l'attribut pos_x
        /// </summary>
        public int Pos_x
        {
            get => pos_x;
        }

        /// <summary>
        /// Accesseur en lecture de l'attribut pos_y
        /// </summary>
        public int Pos_y
        {
            get => pos_y;
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe <see cref="Unite"/>
        /// </summary>
        /// <param name="lettre_Unite">Lettre représentant l'unite dans la carte en clair</param>
        /// <param name="val_Frontieres2">Valeur représentant les frontières de l'unite</param>
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

        /// <summary>
        /// Constructeur de la classe <see cref="Unite"/>
        /// </summary>
        /// <param name="val_Frontieres2">Valeur représentant les frontières de l'unite</param>
        public Unite(uint val_Frontieres2)
        {
            val_Frontieres = val_Frontieres2;
        }

        /// <summary>
        /// Constructeur de la classe <see cref="Unite"/>
        /// </summary>
        /// <param name="nom2">Nom de l'unite</param>
        public Unite(char nom2)
        {
            nom = nom2;
        }

        /// <summary>
        /// Constructeur de la classe <see cref="Unite"/>
        /// </summary>
        /// <param name="nom2">Nom de l'unite</param>
        /// <param name="pos_x2">Position x de l'unite sur la carte</param>
        /// <param name="pos_y2"> Position y de l'unite sur la carte</param>
        public Unite(char nom2, int pos_x2, int pos_y2)
        {
            nom = nom2;
            pos_x = pos_x2;
            pos_y = pos_y2;
        }

        #endregion
    }
}
