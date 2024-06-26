using Employe_Management_System.Service_Folder;
using Employee_Management_System.DTO;
using Employee_Management_System.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Employee_Management_System.Controllers
{

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeAdditionalDetailsController: Controller
    {
        private readonly IEmployeeAdditionalDetails _employeeAdditionalDetails;

        public EmployeeAdditionalDetailsController(IEmployeeAdditionalDetails employeeAdditionalDetails)
        {
            _employeeAdditionalDetails = employeeAdditionalDetails;
        }

        [HttpPost]

        public async Task<EmployeeAdditionalDetailsDTO> Add_AdditionalData(EmployeeAdditionalDetailsDTO employeeAdditinalDetailsDTO)
        {
            var response = await _employeeAdditionalDetails.Add_AdditionalData(employeeAdditinalDetailsDTO);
            return response;
        }

        [HttpGet]

        public async Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalData()
        {
            var response = await _employeeAdditionalDetails.GetAllEmployeeAdditionalData();
            return response;
        }

       [HttpGet]

        public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDataByUId(string UId)
        {
            var response = await _employeeAdditionalDetails.GetEmployeeAdditionalDataByUId(UId);
            return response;
        }


        [HttpPost]
        public async Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeAdditionalDetailsDTO)
        {
            var response = await _employeeAdditionalDetails.UpdateAdditionalData(employeeAdditionalDetailsDTO);
            return response;
        }

        [HttpPost]
        public async Task<string> DeleteEmployeeAdditional(string UId)
        {
            var response = await _employeeAdditionalDetails.DeleteEmployeeAdditional(UId);
            return response;
        }

        [HttpPost]
        public async Task<IActionResult> PostByMicroService(EmployeeAdditionalDetailsDTO AdditionalEmployee)
        {
            var responce = await _employeeAdditionalDetails.PostByMicroService(AdditionalEmployee);
            return Ok(responce);
        }

        [HttpGet]
        public async Task<List<EmployeeAdditionalDetailsDTO>> GetAllBymicro()
        {
            var responce = await _employeeAdditionalDetails.GetAllBymicro();
            return responce;
        }

        [HttpPost]
        [ServiceFilter(typeof(EmployeeAdditionalFilter))]
        public async Task<EmployeeAdditionalFilter> GetAllEmployeebyServiceFilter(EmployeeAdditionalFilter employeeAdditionnalFilter)
        {
            var response = await _employeeAdditionalDetails.GetAllEmployeebyServiceFilter(employeeAdditionnalFilter);
            return response;
        }

    }
}
