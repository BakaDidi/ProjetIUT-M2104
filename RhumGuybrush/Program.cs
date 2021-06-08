using System;
using System.IO;

namespace RhumGuybrush
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tab_carte = new char[10, 10];
            Unite[,] tab_Unite = new Unite[10, 10];
            int i;
            int j;
            uint valFrontieres = 0;
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    for (i = 0; i < 10; i++)
                    {
                        for (j = 0; j < 10; j++)
                        {
                            tab_carte[i, j] = line[j];
                        }
                        line = sr.ReadLine();
                    }
                }

                for (i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        Console.WriteLine("tab2D[{0},{1}] = {2}", i, j, tab_carte[i, j]);

                        if (i != 0) // vérifie au Nord si i != 0
                        {
                            if (tab_carte[i, j] != tab_carte[i - 1, j])
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
                            if (tab_carte[i, j] != tab_carte[i, j - 1])
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
                            if (tab_carte[i, j] != tab_carte[i + 1, j])
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
                            if (tab_carte[i, j] != tab_carte[i, j + 1])
                            {
                                valFrontieres += 8;
                            }
                        }
                        else
                        {
                            valFrontieres += 8;
                        }

                        tab_Unite[i, j] = new Unite(tab_carte[i, j], valFrontieres);
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
    }
}
