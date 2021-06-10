using System;
using System.Collections.Generic;
using System.IO;

namespace RhumGuybrush
{
    abstract class Carte
    {
        private static List<Parcelle> List_Parcelles = new List<Parcelle>();
        private static List<char> List_Carac_Parcelle = new List<char>();

        public static void Ecriture(string chemin, Unite[,] tab_Unite)
        {
            using (StreamWriter fichierDestination = new StreamWriter(chemin + ".chiffre"))
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (j == 9)
                        {
                            Console.Write("{0}", tab_Unite[i, j].Val_Frontieres);
                            fichierDestination.Write("{0}", tab_Unite[i, j].Val_Frontieres);
                        }
                        else
                        {
                            Console.Write("{0}:", tab_Unite[i, j].Val_Frontieres);
                            fichierDestination.Write("{0}:", tab_Unite[i, j].Val_Frontieres);
                        }
                    }
                    Console.Write("|");
                    fichierDestination.Write("|");
                }
            }
        }

        public static int[,] Lecture(string chemin)
        {
            int[,] tab_Crypte = new int[10, 10];
            int v = 0;
            string line;
            using (StreamReader sr = new StreamReader(chemin + ".chiffre"))
                line = sr.ReadLine();
            string[] tab_Temp = line.Split('|', ':');
            for (int j = 0; j < 10; j++)
            {
                for (int i = 0; i < 10; i++)
                {
                    tab_Crypte[j, i] = Convert.ToInt32(tab_Temp[v]);
                    v++;
                }
            }
            return tab_Crypte;
        }

        public static void Affichage(string chemin, Unite[,] tab_Unite)
        {
            using (StreamWriter fichierDestination = new StreamWriter(chemin + ".clair"))
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (tab_Unite[i, j].Nom == 'M')
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write(tab_Unite[i, j].Nom);
                            Console.ResetColor();
                        }
                        else
                        {
                            if (tab_Unite[i, j].Nom == 'F')
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.Write(tab_Unite[i, j].Nom);
                                Console.ResetColor();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(tab_Unite[i, j].Nom);
                                Console.ResetColor();
                            }
                        }
                        fichierDestination.Write(tab_Unite[i, j].Nom);
                    }
                    Console.WriteLine("");
                    fichierDestination.WriteLine("");
                }
                Console.ResetColor();
            }
        }

        public static void Affiche_List_Parcelles(char compteur_Nom, Unite[,] tab_Unite, string chemin)
        {
            Remplissage_Carac_Parcelle(compteur_Nom);
            Incrementation_nb_Unite_Parcelle(compteur_Nom, tab_Unite);
            Affichage(chemin, tab_Unite);
            Affiche_Parcelles();
        }


        public static void Moyenne_Taille_Parcelles()
        {
            float somme = 0;
            foreach (Parcelle i in List_Parcelles)
            {
                somme += i.Nb_Unites;
            }
            somme /= List_Parcelles.Count;
            Console.WriteLine("");
            Console.WriteLine("Aire moyenne : {0}", Math.Round(somme, 2));
        }

        public static void Taille_Parcelles(char parcelle_nom)
        {
            if ((parcelle_nom - 'a') > List_Parcelles.Count)
            {
                Console.WriteLine("Parcelle {0} : inexistante", parcelle_nom);
                Console.WriteLine("Taille de la parcelle {0} : 0 unites", parcelle_nom);
            }
            else
            {
                Console.WriteLine("Taille de la parcelle {0} : {1} unites", parcelle_nom, List_Parcelles[parcelle_nom - 'a'].Nb_Unites);
            }
            
        }

        public static void Affiche_List_Parcelles_Sup_Valeur(int valeur)
        {
            bool flag = false;
            Console.WriteLine("Parcelles de taille supérieure ou égale à {0} : ", valeur);
            foreach (Parcelle i in List_Parcelles)
            {
                if (i.Nb_Unites >= valeur)
                {
                    Console.WriteLine("Parcelle {0}: {1} unites", i.Nom, i.Nb_Unites);
                    flag = true;
                }
            }
            if (!flag)
            {
                Console.WriteLine("Aucune parcelle");
            }
            Console.WriteLine("");
        }

        public static void Affiche_Parcelles()
        {
            foreach (Parcelle i in List_Parcelles)
            {
                Console.WriteLine("Parcelle {0} - {1} unites", i.Nom, i.Nb_Unites);

                foreach (Unite j in i.List_Unite)
                {
                    Console.Write("({0},{1})  ", j.Pos_x, j.Pos_y);
                }

                Console.WriteLine("");
            }
        }

        public static char[,] Remplissage_Tableau(string chemin, char[,] tab_Carte)
        {
            string line;
            using (StreamReader sr = new StreamReader(chemin + ".clair"))
                while ((line = sr.ReadLine()) != null)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        for (int j = 0; j < 10; j++)
                        {
                            tab_Carte[i, j] = line[j];
                        }
                        line = sr.ReadLine();
                    }
                }
            return tab_Carte;
        }

        public static void Remplissage_Carac_Parcelle(char compteur_Nom)
        {
            for (char carac = 'a'; carac <= compteur_Nom; carac++)
            {
                List_Carac_Parcelle.Add(carac);
                List_Parcelles.Add(new Parcelle(carac));
            }
        }

        public static void Vide_Carac_Parcelle()
        {
            List_Carac_Parcelle.Clear();
            List_Parcelles.Clear();
        }

        public static void Incrementation_nb_Unite_Parcelle(char compteur_Nom, Unite[,] tab_Unite)
        {
            foreach (char carac in List_Carac_Parcelle)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (carac == tab_Unite[i, j].Nom)
                        {
                            List_Parcelles[carac - 'a'].Parcelle_increment(tab_Unite[i, j]);     /// Le - 'a' permet de retirer la valeur 97 à carac pour obtenir l'indice dans la liste (a = 0 | b = 1 ...)
                        }
                    }
                }
            }
        }

        public static void Cryptage(string chemin)
        {
            {
                char[,] tab_Carte = new char[10, 10];
                Unite[,] tab_Unite = new Unite[10, 10];
                uint valFrontieres = 0;
                tab_Carte = Remplissage_Tableau(chemin, tab_Carte);

                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (i != 0) // vérifie au Nord si i != 0
                        {
                            if (tab_Carte[i, j] != tab_Carte[i - 1, j])
                            {
                                valFrontieres += 1;
                            }
                        }
                        else
                        {
                            valFrontieres += 1;
                        }

                        if (j != 0) // vérifie à l'Ouest si j != 0
                        {
                            if (tab_Carte[i, j] != tab_Carte[i, j - 1])
                            {
                                valFrontieres += 2;
                            }
                        }
                        else
                        {
                            valFrontieres += 2;
                        }

                        if (i != 9) // vérifie au Sud si i != 9
                        {
                            if (tab_Carte[i, j] != tab_Carte[i + 1, j])
                            {
                                valFrontieres += 4;
                            }
                        }
                        else
                        {
                            valFrontieres += 4;
                        }

                        if (j != 9) // vérifie à l'Est si j != 9
                        {
                            if (tab_Carte[i, j] != tab_Carte[i, j + 1])
                            {
                                valFrontieres += 8;
                            }
                        }
                        else
                        {
                            valFrontieres += 8;
                        }

                        tab_Unite[i, j] = new Unite(tab_Carte[i, j], valFrontieres);
                        valFrontieres = 0;
                    }
                }
            }
        }
        public static void Decryptage(string chemin)
        {
            Unite[,] tab_Unite = new Unite[10, 10];
            char[,] tab_carte = new char[10, 10];
            int compteur_list_parcelle = 0;
            bool a_is_set = false;
            char compteur_Nom = 'a';
            int[,] tab_Crypte = Lecture(chemin);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((tab_Crypte[i, j] - 64) >= 0 && (tab_Crypte[i, j] - 64) < 16)
                    {
                        tab_Crypte[i, j] -= 64;
                        tab_Unite[i, j] = new Unite('M');
                    }
                    else
                    {
                        if ((tab_Crypte[i, j] - 32) >= 0 && (tab_Crypte[i, j] - 32) < 16)
                        {
                            tab_Crypte[i, j] -= 32;
                            tab_Unite[i, j] = new Unite('F');
                        }

                        else
                        {
                            if ((tab_Crypte[i, j] - 8) >= 0)
                            {
                                tab_Crypte[i, j] -= 8;
                            }

                            if ((tab_Crypte[i, j] - 4) >= 0)
                            {

                                tab_Crypte[i, j] -= 4;
                            }

                            if ((tab_Crypte[i, j] - 3) >= 0)
                            {
                                if (!a_is_set)
                                {
                                    tab_Unite[i, j] = new Unite(compteur_Nom, i, j);
                                    a_is_set = true;
                                }
                                else
                                {
                                    compteur_Nom++;
                                    tab_Unite[i, j] = new Unite(Recursive_Check(ref compteur_Nom, i, j, tab_Crypte, tab_Unite), i, j);
                                }
                            }
                            else
                            {
                                if ((tab_Crypte[i, j] - 2) < 0)     /// Quand on rencontre une unite que l'on connaît déjà à gauche
                                {
                                    tab_Unite[i, j] = new Unite(tab_Unite[i, j - 1].Nom, i, j);

                                }
                                else        /// Quand on rencontre une unite que l'on connaît déjà en haut
                                {
                                    tab_Unite[i, j] = new Unite(tab_Unite[i - 1, j].Nom, i, j);
                                }
                            }
                        }
                    }
                }
                
            }
            Affiche_List_Parcelles(compteur_Nom, tab_Unite, chemin);
            Moyenne_Taille_Parcelles();
            Affiche_List_Parcelles_Sup_Valeur(4);
            Taille_Parcelles('o');
            Vide_Carac_Parcelle();

            static char Recursive_Check(ref char default_char, int pos_x, int pos_y, int[,] tab_Val, Unite[,] tab_Unite)
            {
                bool frontiere_Droite = false;
                bool frontiere_Haut = false;
                bool frontiere_Gauche = false;

                if (pos_y + 1 < 10)
                {
                    int valeur_test = tab_Val[pos_x, pos_y + 1];
                    if ((valeur_test - 8) >= 0)
                    {
                        valeur_test -= 8;
                        frontiere_Droite = true;
                    }

                    if ((valeur_test - 4) >= 0)
                    {
                        valeur_test -= 4;
                    }

                    if (valeur_test - 2 >= 0)
                    {
                        frontiere_Gauche = true;
                        valeur_test -= 2;
                        return default_char;
                    }

                    if ((valeur_test - 1) >= 0)
                    {
                        valeur_test -= 1;
                        frontiere_Haut = true;
                    }

                    if (frontiere_Haut && !frontiere_Droite)
                    {
                        return Recursive_Check(ref default_char, pos_x, pos_y + 1, tab_Val, tab_Unite);
                    }

                    if (!frontiere_Haut)
                    {
                        default_char--;
                        return tab_Unite[pos_x - 1, pos_y + 1].Nom;
                    }
                    return default_char;
                }

                return default_char;
            }

        }


    }
}