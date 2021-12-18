using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor72190280.Models;
using Blazor72190280.Services;
using Microsoft.AspNetCore.Components;

namespace Blazor72190280.Pages
{
    public partial class AddEmployee
    {
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        [Inject]
        public IDepartmentService DepartmentService { get; set; }
        public List<Department> Departments { get; set; } = new List<Department>();
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string Id{ get; set; }

        protected async override Task OnInitializedAsync()
        {
            Departments = (await DepartmentService.GetAll()).ToList();
        }

        protected async Task HandleValidSubmit(){
            Employee.PhotoPath = "images/Profile-picture.jpg";
            Employee results = await EmployeeService.Add(Employee);
            NavigationManager.NavigateTo("employeepage");
        }
    }
}