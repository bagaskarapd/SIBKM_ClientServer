using API.Context;
using API.Models;
using API.Repositories.Interface;

namespace API.Repositories.Data
{
    public class AccountRepository : IAccountRepository
    {
        private readonly MyContext _context;

        public AccountRepository(MyContext context)
        {
            _context = context;
        }
        public IEnumerable<Account> GetAll()
        {
            return _context.Set<Account>().ToList();
        }

        public Account? GetById(int id)
        {
            return _context.Set<Account>().Find(id);
        }

        public int insert(Account account)
        {
            _context.Set<Account>().Add(account);
            return _context.SaveChanges();
        }

        public int update(Account account)
        {
            _context.Set<Account>().Update(account);
            return _context.SaveChanges();
        }
        public int delete(int id)
        {
            var account = GetById(id);
            if (account == null)
                return 0;
            _context.Set<Account>().Remove(account);
            return _context.SaveChanges();
        }
    }
}
