using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Models;
using Blazor.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor.Pages
{
    public partial class EditEmployee
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService Employeeservice { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id{ get; set; }

        protected async override Task OnInitializedAsync()
        {
            Employee = await Employeeservice.GetById(int.Parse(Id));
            Departments = (await DepartmentService.GetAll()).ToList();
        }

        protected async Task HandleValidSubmit(){
            Employee results = await Employeeservice.Update(int.Parse(Id), Employee);
            NavigationManager.NavigateTo("employeepage");
        }
    }
}