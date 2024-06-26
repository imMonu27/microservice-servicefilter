namespace Employee_Management_System.Common
{
    public class Credentials
    {
        public static readonly string databaseName = Environment.GetEnvironmentVariable("databaseName");
        public static readonly string containerName = Environment.GetEnvironmentVariable("containerName");
        public static readonly string CosmosEndPoint = Environment.GetEnvironmentVariable("cosmosUrl");
        public static readonly string PrimaryKey = Environment.GetEnvironmentVariable("primaryKey");
        public static readonly string EmployeeDocumentType = "Employee";
        public static readonly string addemployeEndpoint = Environment.GetEnvironmentVariable("AddemployeEndpoint");
        public static readonly string employeurl = Environment.GetEnvironmentVariable("EmployeUrl");
        public static readonly string getAllEndpoint = Environment.GetEnvironmentVariable("GetAllEndpoint");
        public static readonly string getByIdEndpoint = Environment.GetEnvironmentVariable("GetByIdEndpoint");
        internal static readonly string PostAdditionalEndpoint = Environment.GetEnvironmentVariable("postAdditionalEndpoint");
        internal static readonly string getAddtionalAllEndpoint = Environment.GetEnvironmentVariable("GetAddtionalAllEndpoint");
    }
}
