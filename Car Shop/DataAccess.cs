using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Car_Shop
{
    class DataAccess
    {
        public List<Car> GetCar(string Make)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(SQLhelper.CnnVal("Carsdb")))
            {
                var output = connection.Query<Car>($"select * from Car").ToList();
                return output;
            }
        }
    }
}
