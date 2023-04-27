using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class UniversitieRepository : IUniversitieRepository
    {
        private readonly MyContext _context;

        public UniversitieRepository(MyContext context)
        {
            _context = context;
        }

        public IEnumerable<Universitie> GetAll()
        {
            return _context.Set<Universitie>().ToList();
        }

        public Universitie? GetById(int id)
        {
            return _context.Set<Universitie>().Find(id);        }

        public int Insert(Universitie universitie)
        {
            _context.Set<Universitie>().Add(universitie);
            return _context.SaveChanges();
        }

        public int Update(Universitie universitie)
        {
            _context.Set<Universitie>().Update(universitie);
            return _context.SaveChanges();
        }
        public int Delete(int id)
        {
            var universitie = GetById(id);
            if (universitie == null)
                return 0;
            _context.Set<Universitie>().Remove(universitie);
            return _context.SaveChanges();
        }
    }
}
