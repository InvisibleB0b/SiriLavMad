using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SiriLavMad.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiriLavMad.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {


        private static readonly string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiriDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private static readonly string baseUrl = "https://api.spoonacular.com/";

        private static readonly string authKey = "dd889d3d0f6b432398898660844abbb1";

        // GET: api/<RecipeController>
        [HttpGet]
        [Route("History")]
        public List<Recipe> GetHistory()
        {
            List<Recipe> r = new List<Recipe>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $@"SELECT TOP 5 Id, Title FROM Recipes ORDER BY Last_Made DESC";
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Recipe insRecipe = new Recipe()
                    {
                        LastMade = (DateTime)reader["Last_Made"],
                        RecipeId = (int)reader["Id"],
                        RecipeTitle = (string)reader["Title"]
                    };

                    r.Add(insRecipe);
                }
                command.Connection.Close();
            }

            r.Add(new Recipe() { LastMade = DateTime.Now, RecipeTitle = "Hej Stefan", RecipeId = 2054 });


            return r;
        }

        [HttpGet]
        [Route("getspecific/{id}")]
        public Recipe GetSingleRecipe(string id)
        {
            Recipe r = new Recipe();


            return r;
        }


    }
}
