using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiriLavMad.Models
{
    public class GroceryListModel : ingredientsModel
    {
        private static int _id = 0;

        [Key]
        public int ID { get; set; } = _id;

       
        public List<ingredientsModel> ShoppingList { get; set; }

        public GroceryListModel()
        {
            
        }

        public GroceryListModel(int id)
        {
            ID = id;
            ShoppingList = new List<ingredientsModel>()
            {
            new ingredientsModel(1, "Eggs", "2pcs")
            };
        
         }


        public void AddIngredients(ingredientsModel value)
        {
            ShoppingList.Add(value);
        }

        public override string ToString()
        {
            return $"{base.ToString()}, ShoppingList: {ShoppingList}";
        }
    }
}
