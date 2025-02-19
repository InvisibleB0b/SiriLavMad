﻿using Microsoft.AspNetCore.Mvc;
using SiriLavMad.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SiriLavMad.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RecipeController : ControllerBase
    {


        private static readonly string ConnectionString = "Server=tcp:recipeexam.database.windows.net,1433;Initial Catalog=recipeexamDB;Persist Security Info=False;User ID=adminuser;Password=Password1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        private static readonly string baseUrl = "https://api.spoonacular.com/";

        private static readonly string authKey = "dd889d3d0f6b432398898660844abbb1";

        private static bool Vegan = false;

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
                        id = (int)reader["Id"],
                        title = (string)reader["Title"]
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
                    var response = client.GetAsync($"recipes/{id}/information?apiKey={authKey}&includeNutrition=false").Result;
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

        [HttpGet]
        [Route("search/{title}")]
        public List<Recipe> GetSearchRecipe(string title)
        {
            SearchRecipe r = new SearchRecipe();

            HttpClientHandler handler = new HttpClientHandler();

            handler.UseDefaultCredentials = true;

            using (var client = new HttpClient(handler))
            {

                client.BaseAddress = new Uri(baseUrl);

                client.DefaultRequestHeaders.Clear();

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("*/*"));

                client.DefaultRequestHeaders.Connection.Add("keep-alive");
                string vegan;

                if (Vegan)
                {
                    vegan = "vegan";
                }
                else
                {
                    vegan = "";
                }

                try
                {
                    var response = client.GetAsync($"recipes/complexSearch?diet={vegan}&query={title}&number=5&apiKey={authKey}").Result;
                    if (response.IsSuccessStatusCode)
                    {
                        r = response.Content.ReadAsAsync<SearchRecipe>().Result;
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


            return r.results;
        }

        //POST: /recipe/
        [HttpPost]
        public void PostRecipe([FromBody] Recipe obj)
        {
            string queryString = $"INSERT INTO Recipes (Id,Title,Last_made) VALUES ({obj.id},'{obj.title}','{String.Format("{0:yyyy-MM-dd HH:mm:ss.ff}", DateTime.Now)}')";


            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
                command.Connection.Close();
            }

        }

        //POST: /recipe/
        [HttpPost]
        [Route("vegan/{obj}")]
        public void ChangeVegan(string obj)
        {
            if (obj == "Steak")
            {
                Vegan = false;
            }
            else if (obj == "Vegetable")
            {
                Vegan = true;
            }

        }



    }
}
