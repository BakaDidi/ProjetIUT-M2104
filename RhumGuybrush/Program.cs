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
            for (i = 0; i < 3; i++)
            {
                for (j = 0; j < 2; j++)
                {
                    Console.WriteLine("tab2D[{0},{1}] = {2}", i, j, tab1[i, j]);
                }
            }
            // Create an instance of StreamReader to read from a file.
            // The using statement also closes the StreamReader.
            using (StreamReader sr = new StreamReader("file.txt"))
            {
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    Console.WriteLine(line);

                }
            }
        }
    }
}
