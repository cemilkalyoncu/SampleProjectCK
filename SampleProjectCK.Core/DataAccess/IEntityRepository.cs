using SampleProjectCK.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Core.DataAccess
{
    /*Kısıltlama T'ye "class": referans tip olmalı yalnız 
    abstract ve interface'lerde referans tip bu yüzden 
    "new()" olmayacağı için bu kısıltlamayı yapıyoruz.*/ 
    public interface IEntityRepository<T> where T : class, IEntity, new()
    {
        /*Linq.Expression ile istek listenin tümünü ya da
         filtereye göre listelenmesi ve null da gelebilir*/
        List<T> GetList(Expression<Func<T, bool>> filter = null);
        //Tek bir nesne döndürebilirim belirtilen tipte filter yardımıyla
        T Get(Expression<Func<T, bool>> filter);
        //Eklediğimiz nesneyi de eklediğimiz halde döndürüyoruz.
        T Add(T entity);
        T Update(T entity);
        //Bir nesne gönderip o nesnenin primarykey' e göre silinecek
        void Delete(T entity);

    }
}
