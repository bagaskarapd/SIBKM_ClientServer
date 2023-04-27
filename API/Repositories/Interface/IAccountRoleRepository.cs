using API.Models;

namespace API.Repositories.Interface
{
    public interface IAccountRoleRepository
    {
        IEnumerable<AccountRole> GetAll();
        AccountRole? GetById(int id);
        int insert(AccountRole accountRole);
        int update(AccountRole accountRole);
        int delete(int id);
    }
}
