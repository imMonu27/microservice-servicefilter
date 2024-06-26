using Employee_Management_System.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Interface
{
    public interface IEmployeeAdditionalDetails
    {
        Task<EmployeeAdditionalDetailsDTO> Add_AdditionalData(EmployeeAdditionalDetailsDTO employeeDetails);
        Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalData();

        Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDataByUId(string uId);

        Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeDetails);

        Task<string> DeleteEmployeeAdditional(string UId);
        Task<EmployeeAdditionalDetailsDTO> PostByMicroService(EmployeeAdditionalDetailsDTO AdditionalEmployee);
        Task<List<EmployeeAdditionalDetailsDTO>> GetAllBymicro();
        Task<EmployeeAdditionalFilter> GetAllEmployeebyServiceFilter(EmployeeAdditionalFilter employeeAdditionalFilter);
    }
}
