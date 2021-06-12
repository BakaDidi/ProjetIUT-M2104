using System;
using System.Collections.Generic;
using System.Text;

namespace RhumGuybrush
{
    /// <summary>
    /// Classe parcelle: modélise une parcelle 
    /// </summary>
    class Parcelle
    {
        #region Attributs

        /// <summary>
        /// Nom de la parcelle
        /// </summary>
        private char nom;

        /// <summary>
        /// Nombre d'unités constituant la parcelle
        /// </summary>
        private uint nb_Unites;

        /// <summary>
        /// Liste des unités constituant la parcelle 
        /// </summary>
        private List<Unite> list_Unite = new List<Unite>();

        #endregion

        #region Accesseurs
        /// <summary>
        /// Accesseur en lecture de l'attribut Nom
        /// </summary>
        public char Nom
        {
            get => nom;
        }
        /// <summary>
        /// Accesseur en lecture de l'attribut Nb_Unites
        /// </summary>
        public uint Nb_Unites
        {
            get => nb_Unites;
        }
        /// <summary>
        /// Accesseur en lecture de l'attribut List_Unite
        /// </summary>
        public List<Unite> List_Unite
        {
            get => list_Unite;
        }
        #endregion

        #region Constructeurs
        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        /// <param name="nom2">Nom de la parcelle</param>
        public Parcelle(char nom2)
        {
            if (nom2 != 'F' && nom2 != 'M') // Si il s'agit bien d'une parcelle et pas d'une zone de forêt / mer 
                nom = nom2;
        }
        #endregion

        #region Méthode
        /// <summary>
        /// Incrémente le nombre d'unite à chaque unite ajoutée à la liste d'unite de la parcelle
        /// </summary>
        /// <param name="unite">Une unite de la carte</param>
        public void Parcelle_increment(Unite unite)
        {
            list_Unite.Add(unite);
            nb_Unites++;
        }
        #endregion
    }
}
