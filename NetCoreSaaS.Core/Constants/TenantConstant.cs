namespace NetCoreSaaS.Core.Constants
{
    public class TenantConstant
    {
        public const string LocalServer = "(localdb)\\mssqllocaldb";
        public const string LocalDbConnectionString = @"Server={NCS_DbServer};Database={NCS_DbName};Trusted_Connection=True;MultipleActiveResultSets=true";
    }
}
