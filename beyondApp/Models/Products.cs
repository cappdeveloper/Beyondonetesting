using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace beyondApp.Models
{
    public class Products
    {
        [Key]
        public int id { get; set; }

        public int product_id { get; set; }

        public string product_name { get; set; }

        public int stock_available { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
