using System;
using System.IO;

namespace RhumGuybrush
{
    class Program
    {
        static void Main(string[] args)
        {

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
