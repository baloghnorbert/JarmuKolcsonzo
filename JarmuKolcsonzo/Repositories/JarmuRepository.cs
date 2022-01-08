using JarmuKolcsonzo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JarmuKolcsonzo.Repositories
{
    public class JarmuRepository : GenericRepository<jarmu,JKContext>
    {
        public JarmuRepository(JKContext context) : base(context)
        {
        }

        public List<jarmu> GetAll(string search = null)
        {
            var query =_context.jarmu
                .Include(x => x.tipus).AsQueryable();
            // Ha a keresőszónak van értéke
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();
                query = query.Where(x =>
                    x.rendszam.ToLower().Contains(search) ||
                    x.tipus.megnevezes.ToLower().Contains(search));
            }
            return query.ToList();
        }
    }
}
