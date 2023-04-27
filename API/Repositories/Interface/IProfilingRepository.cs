using API.Models;

namespace API.Repositories.Interface
{
    public interface IProfilingRepository
    {
        IEnumerable<Profiling> GetAll();
        Profiling? GetById(string id);
        int insert(Profiling profiling);
        int update(Profiling profiling);
        int delete(string id);
    }
}
