using Employe_Management_System.Common;
using Employee_Management_System.Common;
using Employee_Management_System.CosmosDB;
using Employee_Management_System.DTO;
using Employee_Management_System.Entity;
using Employee_Management_System.Interface;
using Newtonsoft.Json;

namespace Employee_Management_System.Service
{
    public class EmployeeAdditionalDetailsService : IEmployeeAdditionalDetails
    {
        public readonly ICosmosDBService _cosmosDBService;

        public EmployeeAdditionalDetailsService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }

        public async Task<EmployeeAdditionalDetailsDTO> Add_AdditionalData(EmployeeAdditionalDetailsDTO employeeDetails)
        {
            EmployeeAdditionalDetailsEntity employee = new EmployeeAdditionalDetailsEntity();
           employee.UId = employeeDetails.UId;
            employee.AlternateEmail = employeeDetails.AlternateEmail;
            employee.AlternateMobile = employeeDetails.AlternateMobile;
            employee.WorkInformation = employeeDetails.WorkInformation;
            employee.PersonalDetails = employeeDetails.PersonalDetails;
            employee.IdentityInformation = employeeDetails.IdentityInformation;

            employee.Intialize(true, Credentials.EmployeeDocumentType, "mohit", "mohit");

            var response = await _cosmosDBService.Add_AdditionalData(employee);

          
            var responseModel = new EmployeeAdditionalDetailsDTO();
            responseModel.UId = response.UId;
            responseModel.AlternateEmail = response.AlternateEmail;
            responseModel.AlternateMobile = response.AlternateMobile;
            responseModel.WorkInformation = response.WorkInformation;
            responseModel.PersonalDetails = response.PersonalDetails;
            responseModel.IdentityInformation = response.IdentityInformation;
            return responseModel;
        }


        public async Task<List<EmployeeAdditionalDetailsDTO>> GetAllEmployeeAdditionalData()
        {
            var employees = await _cosmosDBService.GetAllEmployeeAdditionalData();

            var employeeAdditionalDetailsDTOs = new List<EmployeeAdditionalDetailsDTO>();
            foreach (var employee in employees)
            {
                var employeeDetails = new EmployeeAdditionalDetailsDTO();
                employeeDetails.UId = employee.UId;
                employeeDetails.AlternateEmail = employee.AlternateEmail;
                employeeDetails.AlternateMobile = employee.AlternateMobile;
                employeeDetails.WorkInformation = employee.WorkInformation;
                employeeDetails.PersonalDetails = employee.PersonalDetails;
                employeeDetails.IdentityInformation = employee.IdentityInformation;

               
                employeeAdditionalDetailsDTOs.Add(employeeDetails);
            }
            return employeeAdditionalDetailsDTOs;
        }



        public async Task<EmployeeAdditionalDetailsDTO> GetEmployeeAdditionalDataByUId(string UId)
        {
            var response = await _cosmosDBService.GetEmployeeAdditionalDataByUId(UId);

            if (response != null)
            {
                var employeeDetails = new EmployeeAdditionalDetailsDTO();

                employeeDetails.UId = response.UId;
                employeeDetails.AlternateEmail = response.AlternateEmail;
                employeeDetails.AlternateMobile = response.AlternateMobile;
                employeeDetails.WorkInformation = response.WorkInformation;
                employeeDetails.PersonalDetails = response.PersonalDetails;
                employeeDetails.IdentityInformation = response.IdentityInformation;

                return employeeDetails;
            }
            else
            {
                throw new Exception("Response object is null.");
                
            }
        }


        public async Task<EmployeeAdditionalDetailsDTO> UpdateAdditionalData(EmployeeAdditionalDetailsDTO employeeDetails)
        {
            var existingEmployee = await _cosmosDBService.GetEmployeeAdditionalDataByUId(employeeDetails.UId);
            existingEmployee.Active = false;
            existingEmployee.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingEmployee);

            existingEmployee.Intialize(false, Credentials.EmployeeDocumentType, "mohit", "mohit");




            existingEmployee.UId = employeeDetails.UId;
            existingEmployee.AlternateEmail = employeeDetails.AlternateEmail;
            existingEmployee.AlternateMobile = employeeDetails.AlternateMobile;
            existingEmployee.WorkInformation = employeeDetails.WorkInformation;
            existingEmployee.PersonalDetails = employeeDetails.PersonalDetails;
            existingEmployee.IdentityInformation = employeeDetails.IdentityInformation;


            var response = await _cosmosDBService.Add_AdditionalData(existingEmployee);

            var responseModel = new EmployeeAdditionalDetailsDTO
            {
               UId = response.UId,
           AlternateEmail = response.AlternateEmail,
            AlternateMobile = response.AlternateMobile,
            WorkInformation = response.WorkInformation,
            PersonalDetails = response.PersonalDetails,
            IdentityInformation = response.IdentityInformation,



        };
            return responseModel;


        }
       public async Task<string> DeleteEmployeeAdditional(string employeeBasicDetailsUId)
        {

            var employee = await _cosmosDBService.GetEmployeeAdditionalDataByUId(employeeBasicDetailsUId);
            employee.Active = false;
            employee.Archived = true;
            await _cosmosDBService.ReplaceAsync(employee);

            employee.Intialize(false, Credentials.EmployeeDocumentType, "mohit", "mohit");
            employee.Archived = true;



            var response = await _cosmosDBService.Add_AdditionalData(employee);

            return "Record Deleted Successfully";

        }

        public async Task<EmployeeAdditionalDetailsDTO> PostByMicroService(EmployeeAdditionalDetailsDTO AdditionalEmployee)
        {
            var serialize = JsonConvert.SerializeObject(AdditionalEmployee);
            var reqObj = await HttpClientHelper.MakePostRequest(Credentials.employeurl, Credentials.PostAdditionalEndpoint, serialize);
            var responceObj = JsonConvert.DeserializeObject<EmployeeAdditionalDetailsDTO>(reqObj);
            return responceObj;
        }

        public async Task<List<EmployeeAdditionalDetailsDTO>> GetAllBymicro()
        {
            var reqobj = await HttpClientHelper.MakeGetRequest(Credentials.employeurl, Credentials.getAddtionalAllEndpoint); ;
            var responceObj = JsonConvert.DeserializeObject<List<EmployeeAdditionalDetailsDTO>>(reqobj);
            return responceObj;
        }

        public async Task<EmployeeAdditionalFilter> GetAllEmployeebyServiceFilter(EmployeeAdditionalFilter employeeAdditionalFilter)
        {
            EmployeeAdditionalFilter response = new EmployeeAdditionalFilter();

            var check = employeeAdditionalFilter.filters.Any(a => a.FieldName == "status");
            var status = "";
            if (check)
            {
                status = employeeAdditionalFilter.filters.Find(a => a.FieldName == "status").FieldValue;
            }
            var employees = await GetAllEmployeeAdditionalData();
            var filterRecord = employees.FindAll(a => a.Status == status);
            response.totalCount = employees.Count;
            response.page = employeeAdditionalFilter.page;
            response.pageSize = employeeAdditionalFilter.pageSize;




            var s = employeeAdditionalFilter.pageSize * (employeeAdditionalFilter.page - 1);

            employees = employees.Skip(s).Take(employeeAdditionalFilter.pageSize).ToList();

            foreach (var employee in employees)
            {
                response.employeeAdditionalDetails.Add(employee);
            }
            return response;
        }
    }
}
