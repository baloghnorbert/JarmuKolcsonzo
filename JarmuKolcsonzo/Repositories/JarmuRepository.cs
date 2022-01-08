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

        public List<jarmu> GetAll(string search = null, 
                                  string sortBy = null,
                                  bool ascending = true,
                                  int page =1,
                                  int itemsPerPage = 20)
        {
            var query =_context.jarmu
                .Include(x => x.tipus).AsQueryable();
            // Ha a keresőszónak van értéke
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower();

                //ha a kkresési kulcsszó szám
                int.TryParse(search, out int dij);

                //Ha dátumra is keresek
                DateTime.TryParse(search, out DateTime datum);


                query = query.Where(x =>
                    x.rendszam.ToLower().Contains(search) ||
                    x.dij.Equals(dij) ||
                    x.szerviz_datum.Equals(datum) ||
                    x.tipus.megnevezes.ToLower().Contains(search));
            }
            return query.ToList();
        }
    }
}
