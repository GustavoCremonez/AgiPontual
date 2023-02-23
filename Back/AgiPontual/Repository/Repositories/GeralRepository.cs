using Repository.Contexts;
using Repository.Contracts;

namespace Repository.Repositories
{
    public class GeralRepository : IGeralRepository
    {
        private readonly PontualContext _context;

        public GeralRepository(PontualContext context)
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

    }
}
