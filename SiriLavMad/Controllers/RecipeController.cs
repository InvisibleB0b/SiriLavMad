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


        public static string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SiriDB; Integrated Security = True; Connect Timeout = 30; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        // GET: api/<RecipeController>
        [HttpGet]
        [Route("History")]
        public List<Recipe> GetHistory()
        {
            List<Recipe> r = new List<Recipe>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                string queryString = $@"SELECT * FROM Recipes ORDER BY Last_Made DESC";
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

            return r;
        }

        // POST api/<RecipeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecipeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
