using System.Linq;

namespace Store.Memory
{
    public class GuitarRepository : IGuitarRepository
    {
        private readonly Guitar[] guitars = new[]
        {
            new Guitar("Gibson", 1),
            new Guitar("Ibanez", 2),
            new Guitar("Auchan", 3)
        };

        public Guitar[] GetAllByQuery(string query)
        {
            return guitars.Where(guitar => guitar.Name.Contains(query)).ToArray();
        }
    }
}