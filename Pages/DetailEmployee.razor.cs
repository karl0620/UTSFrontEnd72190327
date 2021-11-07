using System.Threading.Tasks;
using Blazor.Models;
using Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages
{
    public partial class DetailEmployee
    {
        [Parameter]
        public string id { get; set;}
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public Employee Employee { get; set; } = new Employee();
        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Employee = await EmployeeService.GetById(int.Parse(id));
        }
    }
}