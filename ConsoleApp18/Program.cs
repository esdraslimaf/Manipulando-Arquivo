using System.IO;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ConsoleApp18
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("The file must contain on each line: Product name, price, unit.");
            Console.WriteLine("Ex: TV, 600.00, 2");
            Console.WriteLine();
            Console.Write(@"Enter file full path. Ex: C:\Temp\file.csv ");
            Console.WriteLine();
            string sourceFilePath = Console.ReadLine();
        
            try
            {
                string[] lines = File.ReadAllLines(sourceFilePath);

                string pathToNewFolder = Path.GetDirectoryName(sourceFilePath);
               
                Directory.CreateDirectory(pathToNewFolder+@"\out");

                string pathToCreateFile = pathToNewFolder + @"\out\summary.csv";

                using (StreamWriter sw = File.AppendText(pathToCreateFile))
                {                 
                    for (int i = 0; i < lines.Length; i++)
                    {

                        string separatelines = lines[i];

                        string[] separetelinesarray = separatelines.Split(',');

                        //Product's name
                        string product = separetelinesarray[0];
                        //Product's price
                        double price = Convert.ToDouble(separetelinesarray[1], CultureInfo.InvariantCulture);
                        //Product's unity
                        int unity = Convert.ToInt32((separetelinesarray[2]));

                        double totalPrice = price * unity;

                        string text = product + " " + totalPrice.ToString("F2", CultureInfo.InvariantCulture);
                        sw.WriteLine(text);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Successful");
                }


            }
            catch (IOException e)
            {
                Console.WriteLine();
                Console.WriteLine("Failed!! An error was ocurred: ");
                Console.WriteLine(e.Message);
            }
        }
    }
}

