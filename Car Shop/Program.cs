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
            List<Car> carreader = new List<Car>();
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
                newcar.FComm = string.Format("{0:C}", newcar.total);
                Carbuild.Append(newcar.FComm + "\r\n");
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
                string[] obj;
                string line;
                while ((line = SR.ReadLine()) != null)
                {
                    obj = line.Split(';');
                    Car secondCar = new Car();
                    secondCar.Make = obj[0];
                    secondCar.Model = obj[1];
                    secondCar.Color = obj[2];
                    secondCar.RegNo = obj[3];
                    secondCar.Cost = obj[4];
                    secondCar.FComm = obj[5];
                    carreader.Add(secondCar);
                }
            }
            string text = File.ReadAllText(filePath);
            Console.WriteLine(text);
            
            using (var con = new SqlConnection(SQLhelper.CnnVal("Carsdb")))
            {
                con.Open();
                foreach (var obj in carreader)
                {
                    using (var cmd = new SqlCommand("If NOT EXISTS(select RegNo from Car where RegNo = @RegNo) insert into Car(Make, Model, Color, RegNo, Cost, Commission) Values(@Make, @Model, @Color, @RegNo, @Cost, @Commission) ", con))
                    {
                        cmd.Parameters.Add("@Make", SqlDbType.VarChar).Value = obj.Make;
                        cmd.Parameters.Add("@Model", SqlDbType.VarChar).Value = obj.Model;
                        cmd.Parameters.Add("@Color", SqlDbType.VarChar).Value = obj.Color;
                        cmd.Parameters.Add("@RegNo", SqlDbType.VarChar).Value = obj.RegNo;
                        cmd.Parameters.Add("@Cost", SqlDbType.VarChar).Value = obj.Cost;
                        cmd.Parameters.Add("@Commission", SqlDbType.VarChar).Value = obj.FComm;
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
