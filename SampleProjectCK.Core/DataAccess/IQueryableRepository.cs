using SampleProjectCK.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProjectCK.Core.DataAccess
{
    public interface IQueryableRepository<T> where T : class, IEntity, new()
    {
        /*Select işlemleri için IQueryable yapıyoruz.*/
        IQueryable<T> Table { get; }
    }
}
