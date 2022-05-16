﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public interface IGuitarRepository
    {
        Guitar[] GetAllByModelNumber(string modelNumber);

        Guitar[] GetAllByCompanyOrName(string companyOrName);
       
        Guitar GetById(int id);

        Guitar[] GetAllByIds(IEnumerable<int> guitarIds);
    }
}
