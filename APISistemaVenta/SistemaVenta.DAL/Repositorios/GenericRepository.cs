using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.DAL.Repositorios.Contrato;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace SistemaVenta.DAL.Repositorios
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbventaContext _dbContext;
        public GenericRepository(DbventaContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Create(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Delete(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Remove(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> Get(Expression<Func<T, bool>> filtro)
        {
            try
            {
                T modelo = await _dbContext.Set<T>().FirstOrDefaultAsync(filtro);
                return modelo;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IQueryable<T>> Query(Expression<Func<T>> filtro = null)
        {
            try
            {
                IQueryable<T> query = filtro == null ? _dbContext.Set<T>() : _dbContext.Set<T>().Where(filtro);
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> Update(T modelo)
        {
            try
            {
                _dbContext.Set<T>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
