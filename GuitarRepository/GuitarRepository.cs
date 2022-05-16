using System.Linq;

namespace Store.Memory
{
    public class GuitarRepository : IGuitarRepository
    {
        private readonly Guitar[] guitars = new[]
        {
            new Guitar("Gibson", 1, "NUM 12312-12312", "Telecaster", "Gibson description stub", 10.5m),
            new Guitar("Ibanez", 2, "NUM 12312-12313", "Telecaster", "Ibanez description stub", 20.6m),
            new Guitar("Auchan", 3, "NUM 12312-12314", "Stratocaster", "OMG! It exists!", 0.7m)
        };

        public Guitar[] GetAllByCompanyOrName(string query)
        {
            return guitars.Where(guitar => guitar.Company.Contains(query) ||
                                           guitar.ModelName.Contains(query))
                              .ToArray();
        }

        public Guitar[] GetAllByIds(IEnumerable<int> guitarIds)
        {
            var foundGuitars = from guitar in guitars
                               join guitarId in guitarIds on guitar.Id equals guitarId
                               select guitar;

            return foundGuitars.ToArray();
        }

        public Guitar[] GetAllByModelNumber(string modelNumber)
        {
            return guitars.Where(guitar => guitar.ModelNumber.Contains(modelNumber))
                                .ToArray();
        }

        public Guitar GetById(int id)
        {
            return guitars.Single(guitar => guitar.Id == id);
        }
    }
}