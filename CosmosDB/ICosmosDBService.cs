
using Employee_Management_System.DTO;
using Employee_Management_System.Entity;

namespace Employee_Management_System.CosmosDB
{
    public interface ICosmosDBService
    {
        Task<EmployeeBasicDetailsEntity> AddEmployee(EmployeeBasicDetailsEntity employeeDetails);
     Task<List<EmployeeBasicDetailsEntity>> GetAllEmployee();

        Task<EmployeeBasicDetailsEntity> GetEmployeeByUId(string UId);

        Task ReplaceAsync(dynamic employee);


        Task<EmployeeAdditionalDetailsEntity> Add_AdditionalData(EmployeeAdditionalDetailsEntity employeeDetails);


        Task<List<EmployeeAdditionalDetailsEntity>> GetAllEmployeeAdditionalData();

       Task<EmployeeAdditionalDetailsEntity> GetEmployeeAdditionalDataByUId(string uId);
    }
}
