using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.WiewModel
{
    namespace Entities.WiewModel
    {
        public class SubProductViewModel:IWiew
        {
            public int Id { get; set; }
            public string ProductName { get; set; }
            public string CategoryName { get; set; }
            public short UnitsInStock { get; set; }
            public List<string> SubProducts { get; set; }

        }
    }
}
