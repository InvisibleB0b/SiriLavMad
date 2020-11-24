using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SiriLavMad.Models
{
    public class ingredientsModel
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
       
        public string Amount { get; set; }


        public ingredientsModel(int id, string name, string amount)
        {
            Id = id;
            Name = name;
            Amount = amount;
        }

        public ingredientsModel()
        {
            
        }

        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Amount: {Amount}";
        }
    }
}
