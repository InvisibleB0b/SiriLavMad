using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using SiriLavMad.Models;

namespace SiriLavMad
{
    public class ManageRecipes
    {
        public int ExecuteNonQueryFacility(string queryString)
        {
            int rowsAffected = (-1);
            string connectionString =
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiriDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                rowsAffected = command.ExecuteNonQuery();
                command.Connection.Close();

            }

            return rowsAffected;

        }

        public bool Create(Recipe obj)
        {
            int rowsAffected =
                ExecuteNonQueryFacility($"INSERT INTO Recipes (Id,Title,Last_made) VALUES ({obj.Id},'{obj.Title}','{DateTime.Now}')");
            return (rowsAffected == 1);
        }




    }
}
