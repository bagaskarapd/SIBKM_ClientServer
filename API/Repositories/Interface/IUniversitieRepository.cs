using API.Models;

namespace API.Repositories.Interface
{
    public interface IUniversitieRepository
    {
        IEnumerable<Universitie> GetAll();
        Universitie? GetById(int id);
        int Insert(Universitie universitie);
        int Update(Universitie universitie);
        int Delete(int id);
    }
}
