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
            string documentFolder = @"C:\temp\doc.csv";
            string creatFolder = @"C:\temp\out";
            string product;
            double price;
            int unity;

            try
            {
                bool existe = File.Exists(documentFolder);
              
                {
                    if (existe == true)
                    {
                        Directory.CreateDirectory(creatFolder);
                    }

                    string[] lines = File.ReadAllLines(documentFolder);

                    using (StreamWriter sw = File.AppendText(@"C:\temp\out\summary.csv"))
                    {

                        Console.WriteLine("O documento se encontra na pasta: " + documentFolder);
                        Directory.CreateDirectory(creatFolder);
                        Console.WriteLine("Pasta 'out' criada em: " + creatFolder);


                        Console.WriteLine(creatFolder+@"\summary.csv foi criado");
                        for (int i = 0; i < lines.Length; i++)
                        {

                            string separatelines = lines[i];

                            string[] separetelinesarray = separatelines.Split(',');

                            //Product's name
                            product = separetelinesarray[0];
                            //Product's price
                            price = Convert.ToDouble(separetelinesarray[1], CultureInfo.InvariantCulture);
                            //Product's unity
                            unity = Convert.ToInt32((separetelinesarray[2]));

                            double totalPrice = price * unity;

                            string text = product + " " + totalPrice.ToString("F2", CultureInfo.InvariantCulture);
                            sw.WriteLine(text);
                        }
                    }


                }
                
            }

            catch (IOException e)
            {
                Console.WriteLine("Ocorreu um erro: ");
                Console.WriteLine(e.Message);
            }


        }

    }
}


