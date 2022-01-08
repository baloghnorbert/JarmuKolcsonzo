using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzo.Repositories
{
    public class GenericRepository<TEntity, TContext> :
        IGenericRepository<TEntity> 
        where TEntity : class // egy táblát jelöl
        where TContext : DbContext // db kapcsolat
    {
        protected TContext _context; // Adatbázis kapcsolatot jelöl, generikus
        public GenericRepository(TContext context)
        {
            _context = context;
        }
        public List<TEntity> GetAll()
        {
            // Bármilyen típusú táblát visszaad
            return _context.Set<TEntity>().ToList();
        }
        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            // a rekordot módosítottnak jelöli
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            var entity = _context.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
            }
        }
    }
}
