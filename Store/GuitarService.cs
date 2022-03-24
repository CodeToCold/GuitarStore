using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class GuitarService
    {
        private readonly IGuitarRepository guitarRepository;

        
        public GuitarService(IGuitarRepository guitarRepository)
        {
            this.guitarRepository = guitarRepository;
        }
        
       
        public Guitar[] GetAllByQuery(string query)
        {
            if (Guitar.IsModelNumber(query))
                return guitarRepository.GetAllByModelNumber(query);

            return guitarRepository.GetAllByCompanyOrName(query);
        }           
    }
}
