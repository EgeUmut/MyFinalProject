using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal: EfEntityRepositoryBase<Order,NorthWindContext>,IOrderDal
    {
    }
    // yeni tablo eklerken 3. ve son yapman gereken yer.
    // tabi base repo Ef class ı olduğu için direkt implement yapabiliyoruz
    //yoksa amele gibi yazarsın tekrardan
}
