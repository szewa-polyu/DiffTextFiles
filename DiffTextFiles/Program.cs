using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiffTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: DiffTextFiles.exe file1 file2");
                Console.ReadKey();
                return;
            }

            try
            {
                string file1 = File.ReadAllText(args[0]);
                string file2 = File.ReadAllText(args[1]);

                int diffIdx = CompareFiles(file1, file2);
                Console.WriteLine("Diff Index: " + diffIdx);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            Console.ReadKey();
        }

        static int CompareFiles(string file1, string file2)
        {
            int diffIdx = 0;
            int minFileLength = Math.Min(file1.Length, file2.Length);

            while (diffIdx < minFileLength)
            {
                if (file1[diffIdx] != file2[diffIdx])
                {
                    break;
                }
                diffIdx++;
            }

            Console.WriteLine("Diff characters: " + file1[diffIdx] + ", " + file2[diffIdx]);

            return diffIdx;
        }
    }
}
