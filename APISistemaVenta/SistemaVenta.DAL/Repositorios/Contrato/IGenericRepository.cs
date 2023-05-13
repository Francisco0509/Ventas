using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Repositorios.Contrato
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> Get(Expression<Func<T, bool>> filtro);
        Task<T> Create(T modelo);
        Task<bool> Update(T modelo);
        Task<bool> Delete(T modelo);
        Task<IQueryable<T>> Query(Expression<Func<T, bool>> filtro = null);
    }
}
