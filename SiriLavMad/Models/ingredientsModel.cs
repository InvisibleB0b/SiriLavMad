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
        public int? id { get; set; }

        public string name { get; set; }

        public Mesurement measures { get; set; }




        public ingredientsModel()
        {

        }


    }
}
