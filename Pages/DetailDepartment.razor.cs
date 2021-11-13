using System.Threading.Tasks;
using Blazor.Models;
using Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages
{
    public partial class DetailDepartment
    {
        [Parameter]
        public string id { get; set;}
        public Department Department { get; set; } = new Department();
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        protected override async Task OnInitializedAsync()
        {
            id = id ?? "1";
            Department = await DepartmentService.GetById(int.Parse(id));
        }
    }
}