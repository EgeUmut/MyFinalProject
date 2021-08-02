using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal: IEntityRepository<Order>
    {
    }
    // yeni bir tablo eklerken ikinci yapman gereken yer
    // Dal interface eklemen lazım
}
