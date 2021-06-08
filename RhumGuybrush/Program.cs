using System;
using System.IO;

namespace RhumGuybrush
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] tab1 = new char[10, 10];
            int i, j;
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    for (i = 0; i < 10; i++)
                    {
                        for (j = 0; j < 10; j++)
                        {
                            tab1[i, j] = line[j]; 
                        }
                        line = sr.ReadLine();
                    }
                }

                for (i = 0; i < 10; i++)
                {
                    for (j = 0; j < 10; j++)
                    {
                        Console.WriteLine("tab2D[{0},{1}] = {2}", i, j, tab1[i, j]);
                    }
                }
            }
        }
    }
}
