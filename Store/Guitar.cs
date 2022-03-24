using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Store
{
    public class Guitar
    {
        public string Company { get; }

        public string ModelNumber { get; }
        
        public string ModelName { get; }

        public int Id { get; }



        public Guitar (string company, int id, string modelNumber, string modelName)
        {
            Company = company;
            Id = id;
            ModelNumber = modelNumber;
            ModelName = modelName;
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