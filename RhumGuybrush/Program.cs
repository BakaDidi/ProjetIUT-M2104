﻿using System;
using System.IO;

namespace RhumGuybrush
{
    class Program
    {
        static void Main(string[] args)
        {

            char reponse_char;

            do
            {
                Console.WriteLine("Quel mode voulez vous choisir ? Entrez \"D\" pour le mode déchiffrage et \"C\" pour le chiffrage. Pour quitter, entrez \"Q\"");
                reponse_char = Convert.ToChar(Console.ReadLine());
                if (reponse_char == 'C')
                {
                    Console.WriteLine("\nEntrez le nom du fichier");
                    string fichier = Console.ReadLine();
                    Console.WriteLine("");
                    Carte.Cryptage(fichier);
                }
                else
                {
                    if (reponse_char == 'D')
                    {
                        Console.WriteLine("\nEntrez le nom du fichier");
                        string fichier = Console.ReadLine();
                        Console.WriteLine("");
                        Carte.Decryptage(fichier);
                        
                        Console.WriteLine("\n\nVoulez vous afficher la les coordonées et le nombre d'unites de toutes les parcelles ? (Y/N)");
                        reponse_char = Convert.ToChar(Console.ReadLine());
                        if (reponse_char == 'Y')
                        {
                            Console.WriteLine("");
                            Carte.Affiche_Parcelles();
                        }
                        Console.WriteLine("\nVoulez vous afficher la les coordonées et le nombre d'unites d'une parcelles cible ? (Y/N)");
                        reponse_char = Convert.ToChar(Console.ReadLine());
                        if (reponse_char == 'Y')
                        {
                            Console.WriteLine("\nEntrez le nom de la parcelle à cibler");
                            reponse_char = Convert.ToChar(Console.ReadLine());
                            Carte.Taille_Parcelles(reponse_char);
                        }
                        Console.WriteLine("\n\nVoulez vous afficher les parcelles plus grandes qu'une taille choisi ? (Y/N)");
                        reponse_char = Convert.ToChar(Console.ReadLine());
                        if (reponse_char == 'Y')
                        {
                            Console.WriteLine("\nEntrez la taille minimum des parcelles à cibler");
                            int valeur = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("");
                            Carte.Affiche_List_Parcelles_Sup_Valeur(valeur);
                        }
                        Console.WriteLine("\nVoulez vous afficher la taille moyenne des parcelles ? (Y/N)");
                        reponse_char = Convert.ToChar(Console.ReadLine());
                        if (reponse_char == 'Y')
                        {
                            Carte.Moyenne_Taille_Parcelles();
                            Console.WriteLine("");
                        }
                        Carte.Vide_Carac_Parcelle();
                    }

                    else
                    {
                        if (reponse_char == 'Q')
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("\nVous êtes un petit plaisantin, recommencez :)\n");
                        }
                    }

                }
            }
            while (reponse_char != 'C' | reponse_char != 'D' | reponse_char != 'Y' | reponse_char != 'N');


        }
    }
}
