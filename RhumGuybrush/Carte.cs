using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace RhumGuybrush
{
    abstract class Carte
    {
        public static void Cryptage(string chemin)
        {

            using (StreamReader sr = new StreamReader(chemin))
            {
                char[,] tab_Carte = new char[10, 10];
                Unite[,] tab_Unite = new Unite[10, 10];
                int i;
                int j;
                uint valFrontieres = 0;
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    for (i = 0; i < 10; i++)
                    {
                        for (j = 0; j < 10; j++)
                        {
                            tab_Carte[i, j] = line[j];
                        }
                        line = sr.ReadLine();
                    }
                }

                for (i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        Console.WriteLine("tab2D[{0},{1}] = {2}", i, j, tab_Carte[i, j]);

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
                for (i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        Console.Write("{0} |", tab_Unite[i, j].Val_Frontieres);
                    }
                }
            }
        }

        public static void Decryptage(string chemin)
        {
            Unite[,] tab_Unite = new Unite[10, 10];
            char[,] tab_carte = new char[10, 10];
            int[,] tab_Crypte = new int[10, 10];
            int v = 0;
            bool a_is_set = false;
            char type_Unite;
            char compteur_Nom = 'a';
            uint valFrontieres = 0;
            string line;

            using (StreamReader sr = new StreamReader(chemin))
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
                                    tab_Unite[i, j] = new Unite(compteur_Nom);
                                    a_is_set = true;
                                }
                                else
                                {
                                    compteur_Nom++;
                                    ///tab_Unite[i, j] = new Unite(compteur_Nom);
                                    ///
                                    tab_Unite[i, j] = new Unite(Recursive_Check(compteur_Nom, i, j, tab_Crypte, tab_Unite));
                                } 
                            }
                            else
                            {
                                if ((tab_Crypte[i, j] - 2) < 0)
                                {
                                    tab_Unite[i, j] = new Unite(tab_Unite[i, j - 1].Nom);
                                }
                                else
                                {
                                    tab_Unite[i, j] = new Unite(tab_Unite[i - 1, j].Nom);
                                }
                            }
                        }
                    }
                    
                }
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("{0} |", tab_Unite[i, j].Nom);
                }
                Console.WriteLine("");
            }
        }

        static char Recursive_Check(char default_char, int pos_x, int pos_y, int[,] tab_Val, Unite[,] tab_Unite)
        {

            bool frontiere_Droite = false;
            bool frontiere_Haut = false;

            if (pos_y + 1 < 10)
            {
                if ((tab_Val[pos_x, pos_y + 1] - 8) >= 0)
                {
                    tab_Val[pos_x, pos_y + 1] -= 8;
                    frontiere_Droite = true;
                }

                if ((tab_Val[pos_x, pos_y + 1] - 4) >= 0)
                {
                    tab_Val[pos_x, pos_y + 1] -= 4;
                }

                if ((tab_Val[pos_x, pos_y + 1] - 2) >= 0)
                {
                    tab_Val[pos_x, pos_y + 1] -= 2;
                    return default_char;
                }

                if ((tab_Val[pos_x, pos_y + 1] - 1) >= 0)
                {
                    tab_Val[pos_x, pos_y + 1] -= 1;
                    frontiere_Haut = true;
                }

                if (frontiere_Haut && !frontiere_Droite)
                {
                    Recursive_Check(default_char, pos_x, pos_y + 1, tab_Val, tab_Unite);
                }

                if (!frontiere_Haut)
                {
                    return tab_Unite[pos_x - 1, pos_y + 1].Nom;
                }

                return default_char;
            }
            return default_char;

        }
    }
}