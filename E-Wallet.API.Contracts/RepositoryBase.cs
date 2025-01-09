using E_Wallet.API.Data;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using E_Wallet.API.Data.DBEntities;

namespace E_Wallet.API.Contracts
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public RepositoryBase(ApplicationDbContext context) => _context = context;
        public IQueryable<T> FindAll() => _context.Set<T>();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => _context.Set<T>().Where(expression);
        public void Create(T entity) => _context.Set<T>().Add(entity);
        public void Update(T entity) => _context.Set<T>().Update(entity);
        public void Delete(T entity) => _context.Set<T>().Remove(entity);
        public void ClearAll(Expression<Func<T, bool>> expression) => _context.Set<T>().RemoveRange(FindByCondition(expression));
        public void ClearAll() => _context.Set<T>().RemoveRange(_context.Set<T>());

    }
}
