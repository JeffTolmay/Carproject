using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Office.Core;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections;
using System.Data;

namespace Car_Shop
{
    class Program
    {
        static void Main(string[] args)
        {   //Variables
            List<string> CarInfo = new List<string>();
            string filePath = @"C:\Users\jtolmay\Desktop\Tester.csv";
            Car newcar = new Car();
            StringBuilder Carbuild = new StringBuilder();
            Console.WriteLine("Welcome to Car Storage \r\nPlease enter the Car's details below:");
            float Commision = .05f;
            List<string> carreader = new List<string>();
            //Trying to get correct input from user
            try
            {   //Make input
                Console.WriteLine("Please enter your car's Make: ");
                newcar.Make = Console.ReadLine();
                while (newcar.Make == "")
                {
                    Console.WriteLine("Please enter your car's Make: ");
                    newcar.Make = Console.ReadLine();
                }
                CarInfo.Add(newcar.Make);
                Carbuild.Append(newcar.Make + ";");
                Console.WriteLine("You entered: " + newcar.Make + ".");
                //Model input
                Console.WriteLine("Please enter you car's Model: ");
                newcar.Model = Console.ReadLine();
                while (newcar.Model == "")
                {
                    Console.WriteLine("Please enter you car's Model: ");
                    newcar.Model = Console.ReadLine();
                }
                CarInfo.Add(newcar.Model);
                Carbuild.Append(newcar.Model + ";");
                Console.WriteLine("You entered: " + newcar.Model + ".");
                //Color input
                Console.WriteLine("Please enter your car's color: ");
                newcar.Color = Console.ReadLine();
                while (newcar.Color == "")
                {
                    Console.WriteLine("Please enter your car's color: ");
                    newcar.Color = Console.ReadLine();
                }
                CarInfo.Add(newcar.Color);
                Carbuild.Append(newcar.Color + ";");
                Console.WriteLine("You entered: " + newcar.Color + ".");
                //RegNo input
                Console.WriteLine("Please enter your car's registration number: ");
                newcar.RegNo = Console.ReadLine();
                while (newcar.RegNo == "")
                {
                    Console.WriteLine("Please enter your car's registration number: ");
                    newcar.RegNo = Console.ReadLine();
                }
                CarInfo.Add(newcar.RegNo);
                Carbuild.Append(newcar.RegNo + ";");
                Console.WriteLine("You entered: " + newcar.RegNo + ".");
                //Amount input
                Console.WriteLine("Please enter the amount(Numeric Value): ");
                newcar.Cost = Console.ReadLine();
                //making sure it is a integer
                while ((!CheckCost(newcar)))
                {
                    //Console.WriteLine("Please enter the amount: ");
                    //newcar.Cost = Console.ReadLine();
                }
                newcar.Comm = float.Parse(newcar.Cost);

                CarInfo.Add(newcar.Cost);
                string mytotalcost = string.Format("{0:C}", newcar.Comm);
                Carbuild.Append(mytotalcost + ";");
                Console.WriteLine("You entered: " + newcar.Cost + ".");
                newcar.total = newcar.Comm * Commision;                 //Calculation
                string mytotal = string.Format("{0:C}", newcar.total);
                Carbuild.Append(mytotal + "\r\n");

            }
            catch (Exception ex)
            {

                Console.WriteLine("You have not entered the correct information please restart the program!!! ");
                Carbuild.Clear(); // Empty stringbuilder if not all info is correct.
            }
            //Writing to CSV file
            File.AppendAllText(filePath, Carbuild.ToString());
            //Reading CSV to list.
            using (var SR = new StreamReader(filePath))
            {
                while (SR.Peek() >= 0)
                    carreader.Add(SR.ReadLine());
            }
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);
            Console.ReadLine();

            using (var con = new SqlConnection(SQLhelper.CnnVal("Carsdb")))
            {
                con.Open();
                using (var cmd = new SqlCommand("insert into Car(Make, Model, Color, RegNo) Values(@Make, @Model, @Color, @RegNo)", con))
                {
                    cmd.Parameters.Add("@Make", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Model", SqlDbType.VarChar);
                    cmd.Parameters.Add("@Color", SqlDbType.VarChar);
                    cmd.Parameters.Add("@RegNo", SqlDbType.VarChar);
                    foreach (var obj in carreader)
                    {
                        cmd.Parameters["@Make"].Value = obj;
                        var rowsAffected = cmd.ExecuteNonQuery();
                    }
                }
                
            }
                
        }

        
        private static bool CheckCost(Car newcar)
        {
            try
            {
                while (newcar.Cost == "" || newcar.Comm < 0)
                {
                    Console.WriteLine("Please enter the amount(Numeric Value): ");
                    newcar.Cost = Console.ReadLine();
                    return false;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

    }
}
