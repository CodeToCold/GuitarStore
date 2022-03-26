using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Store
{
    public class Guitar
    {
        public int Id { get; }

        public string Company { get; }

        public string ModelNumber { get; }
        
        public string ModelName { get; }

        public string Description { get;  }

        public decimal Price { get; }



        public Guitar (string company, int id, string modelNumber, string modelName, string description, decimal price)
        {
            Company = company;
            Id = id;
            ModelNumber = modelNumber;
            ModelName = modelName;
            Description = description;
            Price = price;
        }

        internal static bool IsModelNumber(string s)
        {
            if (s == null)
                return false;

            s = s.Replace("-", "")
                 .Replace(" ", "");
                

            return Regex.IsMatch(s, "^NUM\\d{10}$");
        }

    }
}