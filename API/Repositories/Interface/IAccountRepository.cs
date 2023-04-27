using API.Models;

namespace API.Repositories.Interface
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAll();
        Account? GetById(int id);
        int insert(Account account);
        int update(Account account);
        int delete(int id);
    }
}
