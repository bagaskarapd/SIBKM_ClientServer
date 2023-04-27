using API.Models;

namespace API.Repositories.Interface
{
    public interface IEducationRepository
    {
        IEnumerable<Education> GetAll();
        Education? GetById(int id);
        int insert(Education education);
        int update(Education education);
        int delete(int id);
    }
}
