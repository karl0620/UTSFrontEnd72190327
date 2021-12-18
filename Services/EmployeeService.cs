using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Blazor72190280.Models;
using System.Text.Json;

namespace Blazor72190280.Services
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

        public async Task<Employee> Update(int id, Employee employee){
            var response = await _httpClient.PutAsJsonAsync($"api/Employees/{id}",employee);
            if(response.IsSuccessStatusCode){
                return await JsonSerializer.DeserializeAsync<Employee>(await response.Content.ReadAsStreamAsync());
            }else{
                throw new Exception("Gagal Update");
            }
        }

        public async Task<Employee> Add(Employee obj){
            var response = await _httpClient.PostAsJsonAsync($"api?Employees",obj);
            if(response.IsSuccessStatusCode){
                return await JsonSerializer.DeserializeAsync<Employee>(
                    await response.Content.ReadAsStreamAsync()
                );
            }
            else{
                throw new Exception("Gagal Tambah Data Employee");
            }
        }
    }
}