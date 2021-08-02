using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess
{
    // T ye gelebilecek değerleri kısıtlamak için generic constraint ekliyoruz
    // where T:class referans tip olabilir demek , IEntity yazarsan sadece IEntity referansı olan classları kabul eder
    //Yani IEntity olabilir ya da IEntity referans eden bir nesne olabilir
    // new() :  sadece newlenebilen referanslar kabul edilebilir.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        List<T> GetAll(Expression<Func<T,bool>> filter=null);

        T Get(Expression<Func<T,bool>> filter);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);

    }
}
