using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace T9Spelling
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath;
            string outputFilepath;

            //Parse input 
            if (args.Length != 2)
            {
                Console.WriteLine("Please enter input and output file path: <inputfile, outputfile>");
                Console.WriteLine("Also, you can set this paths as command line args");
                Console.WriteLine("Or press Enter for Exit\n");
                
                string[] paths = Console.ReadLine().Split(',');

                if (paths.Length != 2)
                {
                    Console.WriteLine("Wrong input. Program will be closed...");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    return;
                }

                inputFilePath = paths[0];
                outputFilepath = paths[1];
            }
            else
            {
                inputFilePath = args[0];
                outputFilepath = args[1];
            }

            convertFile(inputFilePath, outputFilepath);
            //convertFile(@"h:\Downloads\C-small-practice.in", @"h:\Downloads\C-small-practice.out");
            //convertFile(@"h:\Downloads\C-large-practice.in", @"h:\Downloads\C-large-practice.out");

        }

        static void convertFile(string inputFilePath, string outputFilePath)
        {
            List<string> result = new List<string>();

            CheckT9Spelling checkSpelling = new CheckT9Spelling();
            checkSpelling.buildDictionary();

            using (StreamReader fs = new StreamReader(inputFilePath))
            {
                int lineCount = Int32.Parse(fs.ReadLine());
                int lineNumber = 1;

                while (true)
                {
                    // Read line from file into temporary variable
                    string temp = fs.ReadLine();

                    // leave loop if reached end of file
                    if (temp == null)
                        break;

                    //Convert line and add it to result list
                    result.Add(String.Format("Case #{0}: {1}", lineNumber, checkSpelling.getPattern(temp)));

                    lineNumber++;
                }
            }

            //Store result to output file
            using (TextWriter tw = new StreamWriter(outputFilePath))
            {
                foreach (String s in result)
                    tw.WriteLine(s);
            }
        }

    }
}
