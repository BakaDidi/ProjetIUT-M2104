﻿using System;
using System.IO;

namespace RhumGuybrush
{
    class Program
    {        
        static void Main(string[] args)
        {
            Console.WriteLine("Entrez le nom du fichier");
            string fichier = Console.ReadLine();
            Carte.Decryptage(fichier + ".chiffre");
        }
    }
}
