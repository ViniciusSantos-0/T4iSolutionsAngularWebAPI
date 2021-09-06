using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using T4i_WebAPI.model;

namespace T4i_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Projeto[]> GetAllProjetosAsync(bool includeWorks = false)
        {
            IQueryable<Projeto> query = _context.projetos;

            if (includeWorks)
            {
               query = query.Include(pe => pe.projetoWorks)
                             .ThenInclude(ad => ad.works)
                            .ThenInclude(d => d.dev);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.id);

            return await query.ToArrayAsync();
        }
        public async Task<Projeto> GetProjetoAsyncById(int projetoId, bool includeWorks)
        {
            IQueryable<Projeto> query = _context.projetos;

            if (includeWorks)
            {
                query = query.Include(a => a.projetoWorks)
                             .ThenInclude(ad => ad.works)
                             .ThenInclude(d => d.dev);
            }

            query = query.AsNoTracking()
                         .OrderBy(projeto => projeto.id)
                         .Where(projeto => projeto.id == projetoId);

            return await query.FirstOrDefaultAsync();
        }
      // public async Task<Works[]> GetAllWorksAsyncByProjetos(bool includeWorks){}
        public async Task<Projeto[]> GetProjetosAsyncByWorksId(int worksId, bool includeWorks)
        {
            IQueryable<Projeto> query = _context.projetos;

            if (includeWorks)
            {
                query = query.Include(p => p.projetoWorks)
                             .ThenInclude(ad => ad.works)
                             .ThenInclude(d => d.dev);
            }

            query = query.AsNoTracking()
                         .OrderBy(projeto => projeto.id)
                         .Where(projeto => projeto.projetoWorks.Any(ad => ad.worksId == worksId));

            return await query.ToArrayAsync();
        }

        public async Task<Dev[]> GetDevsAsyncByProjetoId(int projetoId, bool includeWorks)
        {
            IQueryable<Dev> query = _context.dev;

            if (includeWorks)
            {
                query = query.Include(p => p.works);
            }

           query = query.AsNoTracking()
                         .OrderBy(projeto => projeto.id)
                         .Where(projeto => projeto.works.Any(d =>
                            d.projetoWorks.Any(ad => ad.projetoId == projetoId)));

            return await query.ToArrayAsync();
        }

        public async Task<Dev[]> GetAllDevsAsync(bool includeWorks = true)
        {
            IQueryable<Dev> query = _context.dev;

            if (includeWorks)
            {
                query = query.Include(c => c.works);
            }

            query = query.AsNoTracking()
                         .OrderBy(dev => dev.id);

            return await query.ToArrayAsync();
        }
        public async Task<Dev> GetDevAsyncById(int devid, bool includeWorks = true)
        {
            IQueryable<Dev> query = _context.dev;

            if (includeWorks)
            {
                query = query.Include(pe => pe.works);
            }

            query = query.AsNoTracking()
                         .OrderBy(dev => dev.id)
                         .Where(dev => dev.id == devid);

            return await query.FirstOrDefaultAsync();
        }
    }
}
