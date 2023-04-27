using API.Models;

namespace API.Repositories.Interface
{
    public interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
        Role? GetById(int id);
        int insert(Role role);
        int update(Role role);
        int delete(int id);
    }
}
