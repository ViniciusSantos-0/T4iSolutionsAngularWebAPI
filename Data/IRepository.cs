using System.Threading.Tasks;
using T4i_WebAPI.model;

namespace T4i_WebAPI.Data
{
    public interface IRepository
    {
        // Gerak
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        // Projeto
        Task<Projeto[]> GetAllProjetosAsync(bool incluideDev);
        Task<Projeto[]> GetProjetosAsyncByWorksId(int worksId, bool includeWorks);

        Task<Projeto> GetProjetoAsyncById(int projetoId, bool incluideDev);

        //Dev

        Task<Dev[]> GetAllDevsAsync(bool includeProjeto);
        Task<Dev> GetDevAsyncById(int devid, bool includeProjeto);

        Task<Dev[]> GetDevsAsyncByProjetoId(int projetoId, bool includeWorks);
    }
}