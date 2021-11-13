using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor.Models;

namespace Blazor.Services
{
    public class EmployeeService : IEmployeeService
    {
        private HttpClient _httpClient;
        public EmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var resultsEmps = await _httpClient.GetFromJsonAsync<IEnumerable<Employee>>("api/Employees");
            return resultsEmps;
        }

        public async Task<Employee> GetById(int id)
        {
            var resultsEmp = await _httpClient.GetFromJsonAsync<Employee>($"api/Employees/{id}");
            return resultsEmp;
        }
    }
}