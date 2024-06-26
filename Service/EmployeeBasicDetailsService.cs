using Employe_Management_System.Common;
using Employee_Management_System.Common;
using Employee_Management_System.CosmosDB;
using Employee_Management_System.DTO;
using Employee_Management_System.Entity;
using Employee_Management_System.Interface;
using Newtonsoft.Json;

namespace Employee_Management_System.Service
{
    public class EmployeeBasicDetailsService : IEmployeeBasicDetails
    {
        public readonly ICosmosDBService _cosmosDBService;

        public EmployeeBasicDetailsService(ICosmosDBService cosmosDBService)
        {
            _cosmosDBService = cosmosDBService;
        }

        //ADD

        public async Task<EmployeeBasicDetailsDTO> AddEmployee(EmployeeBasicDetailsDTO employeeDetails)
        {
            EmployeeBasicDetailsEntity employee= new EmployeeBasicDetailsEntity();
            employee.Salutory = employeeDetails.Salutory;
            employee.FirstName = employeeDetails.FirstName;
            employee.MiddleName = employeeDetails.MiddleName;
            employee.LastName = employeeDetails.LastName;
            employee.NickName = employeeDetails.NickName;
            employee.Email = employeeDetails.Email;
            employee.Mobile = employeeDetails.Mobile;
            employee.EmployeeId = employeeDetails.EmployeeId;
            employee.Role = employeeDetails.Role;
            employee.ReportingManagerUId = Guid.NewGuid().ToString();
            employee.ReportingManagerName = employeeDetails.ReportingManagerName;
            employee.Address = employeeDetails.Address;
          
            employee.DateOfBirth = employeeDetails.DateOfBirth;
           employee.DateOfJoining = employeeDetails.DateOfJoining;


            employee.Intialize(true, Credentials.EmployeeDocumentType, "mohit", "mohit");


            var response = await _cosmosDBService.AddEmployee(employee);

            var responseModel = new EmployeeBasicDetailsDTO();
            responseModel.UId = response.UId;
            responseModel.Salutory = response.Salutory;
            responseModel.FirstName = response.FirstName;
            responseModel.MiddleName = response.MiddleName;
            responseModel.LastName = response.LastName;
            responseModel.NickName = response.NickName;
            responseModel.Email = response.Email;
            responseModel.Mobile = response.Mobile;
            responseModel.EmployeeId= response.Id;
            responseModel.Role = response.Role;
            responseModel.ReportingManagerUId = response.ReportingManagerUId;
            responseModel.ReportingManagerName = response.ReportingManagerName;
            responseModel.Address = response.Address;
           responseModel.DateOfBirth = response.DateOfBirth;
            responseModel.DateOfJoining = response.DateOfJoining;


            return responseModel;

        }

        //GetAll

      public async Task<List<EmployeeBasicDetailsDTO>> GetAllEmployee()
        {
            var employees = await _cosmosDBService.GetAllEmployee();

            var employeeBasicDetailsDTOs = new List<EmployeeBasicDetailsDTO>();
            foreach (var employee in employees)
            {
                var employeeDetails = new EmployeeBasicDetailsDTO();
                employeeDetails.UId = employee.UId;
                employeeDetails.Salutory = employee.Salutory;
                employeeDetails.FirstName = employee.FirstName;
                employeeDetails.MiddleName = employee.MiddleName;
                employeeDetails.LastName = employee.LastName;
                employeeDetails.NickName = employee.NickName;
                employeeDetails.Email = employee.Email;
                employeeDetails.Mobile = employee.Mobile;
                employeeDetails.EmployeeId = employee.Id;
                employeeDetails.Role = employee.Role;
                employeeDetails.ReportingManagerUId = employee.ReportingManagerUId;
                employeeDetails.ReportingManagerName = employee.ReportingManagerName;
                employeeDetails.Address = employee.Address;
                employeeBasicDetailsDTOs.Add(employeeDetails);


            }
            return employeeBasicDetailsDTOs;
        }

        //Getbyuid
        public async Task<EmployeeBasicDetailsDTO> GetEmployeeByUId(string UId)
        {
            var response = await _cosmosDBService.GetEmployeeByUId(UId);

            var employeeDetails = new EmployeeBasicDetailsDTO();
            employeeDetails.UId=response.UId;
            employeeDetails.Salutory = response.Salutory;
            employeeDetails.FirstName = response.FirstName;
            employeeDetails.MiddleName = response.MiddleName;
            employeeDetails.LastName = response.LastName;
            employeeDetails.NickName = response.NickName;
            employeeDetails.Email = response.Email;
            employeeDetails.Mobile = response.Mobile;
            employeeDetails.EmployeeId = response.Id;
            employeeDetails.Role = response.Role;
            employeeDetails.ReportingManagerUId = response.ReportingManagerUId;
            employeeDetails.ReportingManagerName = response.ReportingManagerName;
            employeeDetails.Address = response.Address;


            return employeeDetails;
        }

        //update

        public async Task<EmployeeBasicDetailsDTO> UpdateEmployee(EmployeeBasicDetailsDTO employeeDetails)
        {
            var existingEmployee = await _cosmosDBService.GetEmployeeByUId(employeeDetails.UId);
            existingEmployee.Active = false;
            existingEmployee.Archived = true;
            await _cosmosDBService.ReplaceAsync(existingEmployee);

            existingEmployee.Intialize(false, Credentials.EmployeeDocumentType, "Mohit", "Mohit");



            existingEmployee.Salutory = employeeDetails.Salutory;
            existingEmployee.FirstName = employeeDetails.FirstName;
            existingEmployee.MiddleName = employeeDetails.MiddleName;
            existingEmployee.LastName = employeeDetails.LastName;
            existingEmployee.NickName = employeeDetails.NickName;
            existingEmployee.Email = employeeDetails.Email;
            existingEmployee.Mobile = employeeDetails.Mobile;
            existingEmployee.EmployeeId = employeeDetails.EmployeeId;
            existingEmployee.Role = employeeDetails.Role;
            existingEmployee.ReportingManagerUId = employeeDetails.ReportingManagerUId;
            existingEmployee.ReportingManagerName = employeeDetails.ReportingManagerName;
            existingEmployee.Address = employeeDetails.Address;

            var response = await _cosmosDBService.AddEmployee(existingEmployee);

            var responseModel = new EmployeeBasicDetailsDTO
            {
            UId = response.UId,
            Salutory = response.Salutory,
            FirstName = response.FirstName,
            MiddleName = response.MiddleName,
            LastName = response.LastName,
            NickName = response.NickName,
            Email = response.Email,
            Mobile = response.Mobile,
           EmployeeId = response.Id,
            Role = response.Role,
            ReportingManagerUId = response.ReportingManagerUId,
            ReportingManagerName = response.ReportingManagerName,
            Address = response.Address,


        };
            return responseModel;


        }
        //delete
        public async Task<string> DeleteEmployee(string uId)
        {
      
            var employee = await _cosmosDBService.GetEmployeeByUId(uId);
            employee.Active = false;
            employee.Archived = true;
            await _cosmosDBService.ReplaceAsync(employee);

            employee.Intialize(false, Credentials.EmployeeDocumentType, "mohit", "mohit");
            employee.Archived = true;

            

            var response = await _cosmosDBService.AddEmployee(employee);

            return "Record Deleted Successfully";

        }
        //find 

        public async Task<List<EmployeeBasicDetailsDTO>> GetEmployeeByRole(string role)
        {
            var allEmploye = await GetAllEmployee();

            var filteredList = allEmploye.FindAll(a => a.Role == role);

            return filteredList;
        }


        //Filter
        public async Task<EmployeeFilter> GetEmployeebypagination(EmployeeFilter employeeFilter)
        {
            EmployeeFilter response =new EmployeeFilter();

            var check = employeeFilter.filters.Any(a => a.FieldName == "role");
                var role = "";
            if(check)
            {
                 role = employeeFilter.filters.Find(a => a.FieldName == "role").FieldValue;
            }
             var employees= await GetAllEmployee();
            response.totalCount = employees.Count;
            response.page=employeeFilter.page;
            response.pageSize=employeeFilter.pageSize;




            var s = employeeFilter.pageSize * (employeeFilter.page - 1);

            employees = employees.Skip(s).Take(employeeFilter.pageSize).ToList();

            foreach(var employee in employees)
            {
                response.employeeBasicDetails.Add(employee);
            }
            return response;
        }

       
        //microservice
        public async Task<EmployeeBasicDetailsDTO> postbymicroservice(EmployeeBasicDetailsDTO employeeDto)
        {
            var serialize = JsonConvert.SerializeObject(employeeDto);
            var reqObject = await HttpClientHelper.MakePostRequest(Credentials.employeurl, Credentials.addemployeEndpoint, serialize);
            var responceObject = JsonConvert.DeserializeObject<EmployeeBasicDetailsDTO>(reqObject);
            return responceObject;
        }

      

        public async Task<List<EmployeeBasicDetailsDTO>> GetAllMicroService()
        {
            var reqObject = await HttpClientHelper.MakeGetRequest(Credentials.employeurl, Credentials.getAllEndpoint);
            var responseObject = JsonConvert.DeserializeObject<List<EmployeeBasicDetailsDTO>>(reqObject);
            return responseObject;
        }

        public async Task<EmployeeBasicDetailsDTO> GetByIdMicroService(string uid)
        {
            var id = JsonConvert.SerializeObject(uid);
            var reqObj = await HttpClientHelper.MakeGetByIdRequest(Credentials.employeurl,Credentials.getByIdEndpoint, id);
            var responceObj = JsonConvert.DeserializeObject<EmployeeBasicDetailsDTO>(reqObj);
            return responceObj;
        }

       
    }
}
