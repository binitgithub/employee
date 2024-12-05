using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using employee.Models;

namespace employee.Repositories
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetAllEmpAsync();
        Task<Employee> GetByIdAsync(int id);
        Task<Employee> CreateEmpAsync(Employee employee);
        Task<Employee> UpdateEmpAsync(int id, Employee employee);
        Task<Employee> DeleteEmpAsync (int id);
    }
}