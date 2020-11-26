using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
                        RecipeId = (int)reader["Id"],
                        RecipeTitle = (string)reader["Title"]
                    };

                    r.Add(insRecipe);
                }
                command.Connection.Close();
            }


            return r;
        }

        [HttpGet]
        [Route("getspecific/{id}")]
        public Recipe GetSingleRecipe(string id)
        {
            Recipe r = new Recipe();

            HttpClientHandler handler = new HttpClientHandler();

            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                client.DefaultRequestHeaders.Connection.Add("keep-alive");


                try
                {
                    var response = client.GetAsync($"recipes/1161745/information?apiKey={authKey}&includeNutrition=false").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        r = response.Content.ReadAsAsync<Recipe>().Result;
                    }
                    else
                    {
                        return null;
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }

            }


            return r;
        }


    }
}
