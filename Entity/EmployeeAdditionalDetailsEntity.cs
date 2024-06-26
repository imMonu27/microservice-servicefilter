using Employee_Management_System.Common;
using Employee_Management_System.DTO;
using Employee_Management_System.Entity;
using Newtonsoft.Json;

namespace Employee_Management_System.Entity
{
    public class EmployeeAdditionalDetailsEntity : BaseEntity
    {

        [JsonProperty(PropertyName = "alternateEmail", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateEmail { get; set; }


        [JsonProperty(PropertyName = "alternateMobile", NullValueHandling = NullValueHandling.Ignore)]
        public string AlternateMobile { get; set; }


        [JsonProperty(PropertyName = "workInformation", NullValueHandling = NullValueHandling.Ignore)]
        public WorkInfo_ WorkInformation{ get; set; }


        [JsonProperty(PropertyName = "personalDetails", NullValueHandling = NullValueHandling.Ignore)]
        public PersonalDetails_ PersonalDetails { get; set; }


        [JsonProperty(PropertyName = "identityInformation", NullValueHandling = NullValueHandling.Ignore)]
        public IdentityInfo_ IdentityInformation { get; set; }
    }
}
public class EmployeeAdditionalFilter
{
    //Constructor
    public EmployeeAdditionalFilter()
    {
        filters = new List<Filter>();
        employeeAdditionalDetails = new List<EmployeeAdditionalDetailsDTO>();
    }
    public int page { get; set; }

    public int pageSize { get; set; }
    public int totalCount { get; set; }

    public List<Filter> filters { get; set; }

    public List<EmployeeAdditionalDetailsDTO> employeeAdditionalDetails { get; set; }
}