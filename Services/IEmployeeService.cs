using System.Collections.Generic;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
    }
}