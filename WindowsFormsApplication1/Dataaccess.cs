using Car_Shop;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class DataAccess 
    {
        public List<Car> GetCar(string Make)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("CarprojectDB")))
            {
                var output = connection.Query<Car>($"select * from Car where Make = '{Make}'").ToList();
                return output;
            }
        }
    }
}
