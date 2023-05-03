using API.Models;
using API.ViewModels;

namespace API.Repositories.Interface
{
    public interface IEmployeeRepository : IGeneralRepository<Employee, string>
    {
        int Register(RegisterVM registerVM);
        bool Login(LoginVM loginVm);
    }
}
