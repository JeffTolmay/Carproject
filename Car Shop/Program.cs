using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Car_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> CarInfo = new List<string>();
            string filePath = @"C:\Users\jtolmay\Desktop\Tester.xls";
            Car newcar = new Car();
            newcar.Make = " ";
            newcar.Model = " ";
            newcar.Color = " ";
            newcar.RegNo = " ";
            StringBuilder Carbuild = new StringBuilder();
            // Trying to quit when esc is pressed. TODO !!!
            //ConsoleKeyInfo esc;
            //esc = Console.ReadKey(true);

            //if (esc.Key == ConsoleKey.Escape)
            //{
            //    Environment.Exit(0);
            //}

            Console.WriteLine("Welcome to Car Storage \r\nPlease enter the Car's details below:");
            
            while(CarInfo.Count < 3)
            {
                
                Console.WriteLine("Please enter your car's Make: ");
                newcar.Make = Console.ReadLine();
                while (newcar.Make == "")
                {
                    Console.WriteLine("Please enter your car's Make: ");
                    newcar.Make = Console.ReadLine();
                }
                    CarInfo.Add(newcar.Make);
                    Carbuild.Append(newcar.Make + " ");
                    Console.WriteLine("You entered: " + newcar.Make + ".");

                Console.WriteLine("Please enter you car's Model: ");
                newcar.Model = Console.ReadLine();
                while (newcar.Model == "")
                {
                    Console.WriteLine("Please enter you car's Model: ");
                    newcar.Model = Console.ReadLine();
                }
                    CarInfo.Add(newcar.Model);
                    Carbuild.Append(newcar.Model + " ");
                    Console.WriteLine("You entered: " + newcar.Model + ".");
                
                Console.WriteLine("Please enter your car's color: ");
                newcar.Color = Console.ReadLine();
                while (newcar.Color == "")
                {
                    Console.WriteLine("Please enter your car's color: ");
                    newcar.Color = Console.ReadLine();
                }
                    CarInfo.Add(newcar.Color);
                    Carbuild.Append(newcar.Color + " ");
                    Console.WriteLine("You entered: " + newcar.Color + ".");

                Console.WriteLine("Please enter your car's registration number: ");
                newcar.RegNo = Console.ReadLine();
                while (newcar.RegNo == "")
                {
                    Console.WriteLine("Please enter your car's registration number: ");
                    newcar.RegNo = Console.ReadLine();
                }
                CarInfo.Add(newcar.RegNo);
                Carbuild.Append(newcar.RegNo + "\r\n");
                Console.WriteLine("You entered: " + newcar.RegNo + ".");

            }
            using (TextWriter sw = new StreamWriter(filePath, true))
            sw.Write(Carbuild.ToString());
            
        }
    }
}
