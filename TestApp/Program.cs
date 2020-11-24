using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;
using SiriLavMad.Models;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Indkøbtsliste!");
            
            GroceryListModel Test = new GroceryListModel(0);

            Test.AddIngredients(new ingredientsModel("Diary", "Milk", "1L", DateTime.Now));


            foreach (ingredientsModel VARIABLE in Test.ShoppingList)
            {
                Console.WriteLine(VARIABLE);
            }


            RecipeModel ting = new RecipeModel("Pasta");

            foreach (ingredientsModel ingredients in ting.ShoppingList)
            {
                Test.ShoppingList.Add(ingredients);
            }

            Console.WriteLine("Ny indkøbsliste");
            Test.ShoppingList.ForEach(Console.WriteLine);
            Console.ReadKey();


        }
    }
}
