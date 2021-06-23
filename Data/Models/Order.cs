using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GreenAtom.Data.Models
{
    public class Order:BaseModel
    {
        public DateTime OrderTime { get; set; }
        public List<Product> Products { get; set; }
        public double SumPrice
        {
            get
            {
                double sum = 0;
                for (int i = 0; i < Products.Count; i++)
                {
                    sum += Products[i].Price;
                }
                return sum;
            }
        }
    }
}
