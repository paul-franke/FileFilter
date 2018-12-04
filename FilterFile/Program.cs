using System;
using System.Collections.Generic;
using System.Linq;

namespace FilterFile
{
    public class FilterFile
    {
        public static void Main(string[] args)
        {
            List<string> tempFilter;
            List<string> filter = new List<string>();

            if (args.Length == 1 && (args[0].Equals("-h")    ||
                                     args[0].Equals("-?")    ||
                                     args[0].Equals("?")     ||
                                     args[0].Equals("-help") ||
                                     args[0].Equals("help")    ))
            {
                Console.WriteLine("This program can be used to filter out a series of consecutive lines.");
                Console.WriteLine("This text to be filtered is supplied via StdIn.");
                Console.WriteLine("This text to be filtered out is read from a file.");
                Console.WriteLine("");
                Console.WriteLine("Note: All white space is ignored");
                Console.WriteLine("");
                Console.WriteLine("Sample: FilterFile -f filter.txt < FileToBeFiltered.txt.");
                Console.WriteLine("");
                Console.WriteLine("Pre run contents:");
                Console.WriteLine("FileToBeFiltered.txt               filter.txt");
                Console.WriteLine("");
                Console.WriteLine("1");
                Console.WriteLine("2 2                                 2 2");
                Console.WriteLine("3 3  3                              3 3 3");
                Console.WriteLine("4 4   4    4 ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Post run contents:");
                Console.WriteLine("FileToBeFiltered.txt               filter.txt");
                Console.WriteLine("");
                Console.WriteLine("1                                   2 2");
                Console.WriteLine("4 4   4    4                        3 3 3");
                return;
            }

            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Please redirect input from a file to be filtered.");
                return;
            }

            try
            {
                if (args.Length != 2 && !args[0].Equals("-f")) throw new ArgumentException();
                tempFilter = System.IO.File.ReadAllLines(args[1]).ToList();
            }
            catch
            {
                Console.WriteLine("This program requires '-f <filter.txt>'.");
                Console.WriteLine("The File <filter.txt> contains text that will be filtered from input supplied via StdIn.");
                return;
            }

            if (tempFilter.Count == 0)
            {
                Console.WriteLine($"File {args[1]} is empty.");
                return;
            }

            foreach (string line in tempFilter)
            {
                filter.Add(line.Replace(" ", ""));
            }

            string s;
            List<string> iouOutput = new List<string>();

            string[] compareFilter = filter.ToArray();
            while ((s = Console.ReadLine()) != null)
            {
                if (s.Replace(" ", "").Equals(compareFilter[iouOutput.Count]))
                {
                    iouOutput.Add(s);
                    if (filter.Count == iouOutput.Count)    // only a complete filter qualifies
                    {
                        iouOutput.Clear();                  // This is the filter action.
                    }
                }
                else
                {
                    foreach (var line in iouOutput) Console.WriteLine(line);
                    iouOutput.Clear();
                    Console.WriteLine(s);
                }
            }
            foreach (var line in iouOutput) Console.WriteLine(line);
        }
    }
}