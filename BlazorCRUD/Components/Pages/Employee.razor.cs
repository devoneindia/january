
using BlazorCRUD.Contexts;
using BlazorCRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorCRUD.Components.Pages
{
    public partial class Employee
    {
        public List<UserDetail>? Employees { get; set; }
        protected async override Task OnInitializedAsync()
        {
            await GetEmployees();
        }

        private async Task GetEmployees()
        {
            using (EmployeeDbContext employeeDbContext = new EmployeeDbContext())
            {
                Employees = await employeeDbContext.UserDetails.ToListAsync();
            }
        }

        public async Task AddUser()
        {
            UserDetail newUser = new UserDetail();
            newUser.UserName = RandomName(random.Next(5,50));
            newUser.Address = RandomName(random.Next(5, 50)) + " " + RandomName(random.Next(5, 50)) + " "  +RandomName(random.Next(5, 50));
            newUser.CellNumber = random.Next(100000000, 999999999).ToString();
            newUser.EmailId = random.Next(100000000, 999999999).ToString();
            using (EmployeeDbContext employeeDbContext = new EmployeeDbContext())
            {
                employeeDbContext.UserDetails.Add(newUser);
                employeeDbContext.SaveChanges();
            }
            await GetEmployees();
        }

        private Random random = new Random();

        private string? RandomName(int length)
        {
            string alphabetArray = @"ABCDEFGHIJKLMNOPQRSTUVEWXZabcdefghijklmnopqrstuvewxz";
            string newWord = string.Empty;
            for (int i = 0; i < length; i++)
            {
                newWord = newWord+ alphabetArray[random.Next(0,alphabetArray.Length-1)];   
            }
            return newWord;
        }
    }
}
