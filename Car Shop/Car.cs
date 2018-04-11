using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public string RegNo { get; set; }
        public string Cost { get; set; }
        public float total { get; set; }
        public float Comm { get; set; }
        public string FComm { get; set; }

        public static bool CheckCost(Car newcar)
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
