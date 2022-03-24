using System.Linq;

namespace Store.Memory
{
    public class GuitarRepository : IGuitarRepository
    {
        private readonly Guitar[] guitars = new[]
        {
            new Guitar("Gibson", 1, "NUM 12312-12312", "Telecaster"),
            new Guitar("Ibanez", 2, "NUM 12312-12313", "Telecaster"), 
            new Guitar("Auchan", 3, "NUM 12312-12314", "Stratocaster")
        };

        public Guitar[] GetAllByCompanyOrName(string query)
        {
            return guitars.Where(guitar => guitar.Company.Contains(query) ||
                                           guitar.ModelName.Contains(query))
                              .ToArray();
        }

        public Guitar[] GetAllByModelNumber(string modelNumber)
        {
            return guitars.Where(guitar => guitar.ModelNumber.Contains(modelNumber))
                                .ToArray();
        }      
    }
}