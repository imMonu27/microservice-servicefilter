using Employee_Management_System.DTO;
using Employee_Management_System.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Interface
{
    public interface IEmployeeBasicDetails
    {

        Task<EmployeeBasicDetailsDTO> AddEmployee(EmployeeBasicDetailsDTO employeeDetails);

       Task<List<EmployeeBasicDetailsDTO>> GetAllEmployee();

        Task<EmployeeBasicDetailsDTO> GetEmployeeByUId(string UId);

        Task<EmployeeBasicDetailsDTO> UpdateEmployee(EmployeeBasicDetailsDTO employeeDetails);

        Task<string> DeleteEmployee(string uId);

        Task<List<EmployeeBasicDetailsDTO>> GetEmployeeByRole(string role);

        Task<EmployeeFilter> GetEmployeebypagination(EmployeeFilter employeeFilter);
        Task<EmployeeBasicDetailsDTO> postbymicroservice(EmployeeBasicDetailsDTO employeeDto);
        Task<List<EmployeeBasicDetailsDTO>> GetAllMicroService();
        Task<EmployeeBasicDetailsDTO> GetByIdMicroService(string uid);
       
    }
}
