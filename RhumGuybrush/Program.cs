using System;
using System.IO;

namespace RhumGuybrush
{
    class Program
    {
        static void Main(string[] args)
        {

            string reponse;
            string reponse;
            string reponse;
            string reponse;
            do
            {
                Console.WriteLine("Quel mode voulez vous choisir ? Entrez \"D\" pour le mode déchiffrage et \"C\" pour le chiffrage. Pour quitter, entrez \"Q\"");
                reponse = Console.ReadLine();
                if (reponse == "C")
                {
                    Console.WriteLine("");
                    Console.WriteLine("Entrez le nom du fichier");
                    string fichier = Console.ReadLine();
                    Console.WriteLine("");
                    Carte.Cryptage(fichier);
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else
                {
                    if (reponse == "D")
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Entrez le nom du fichier");
                        string fichier = Console.ReadLine();
                        Console.WriteLine("");
                        Carte.Decryptage(fichier);
                        Console.WriteLine("");
                        Console.WriteLine("");
                        
                        Console.WriteLine("Voulez vous afficher la les coordonées et le nombre d'unites de toutes les parcelles ? (Y/N)");
                        reponse = Console.ReadLine();
                        if(reponse == "Y")
                        {
                                Affiche_Parcelles();
                        }
                        Console.WriteLine("Voulez vous afficher la les coordonées et le nombre d'unites d'une parcelles cible ? (Y/N)");
                        reponse = Console.ReadLine();
                        if(reponse == "Y")
                        {
                                Console.WriteLine("Entrez le nom de la parcelle à cibler");
                                reponse = Console.ReadLine();
                                Taille_Parcelles(reponse);
                        }
                        Console.WriteLine("Voulez vous afficher les parcelles plus grandes qu'une taille choisi ? (Y/N)");
                        reponse = Console.ReadLine();
                        if(reponse == "Y")
                        {
                                Console.WriteLine("Entrez la taille minimum des parcelles à cibler");
                                reponse = Console.ReadLine();
                                Affiche_List_Parcelles_Sup_Valeur(int valeur);
                        }
                        Console.WriteLine("Voulez vous afficher la taille moyenne des parcelles ? (Y/N)");
                        reponse = Console.ReadLine();
                        if(reponse == "Y")
                        {
                                Moyenne_Taille_Parcelles();
                        }


                     reponse = Console.ReadLine();

                        

                    }

                    else
                    {
                        if (reponse == "Q")
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Vous êtes un petit plaisantin, recommencez :)");
                            Console.WriteLine("");
                        }
                    }

                }
            }
            while (reponse != "C" | reponse != "D");


        }
    }
}
