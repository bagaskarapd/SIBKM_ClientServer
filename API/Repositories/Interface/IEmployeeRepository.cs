using API.Models;

namespace API.Repositories.Interface
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetAll();
        Employee? GetById(int id);
        int insert(Employee employee);
        int update(Employee employee);
        int delete(int id);
    }
}
