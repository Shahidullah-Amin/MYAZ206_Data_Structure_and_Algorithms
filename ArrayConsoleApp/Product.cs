using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayConsoleApp
{
    public class Product
    {
        public int Id { get; set; }
        public string? CompanyName { get; set; }
        public string? ProductName { get; set; }
        public float Price { get; set; }
        public string? ProductDescription{ get; set; }

        public override string ToString()
        {
            return $"{this.Id, -5} {this.ProductName , -30} {this.CompanyName,-15} {this.CompanyName}";
        }

    }
}
