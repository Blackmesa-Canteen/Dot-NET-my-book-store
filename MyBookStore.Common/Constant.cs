namespace MyBookStore.Common
{
    /**
     * Author: Xiaotian Li
     * Description: Constants for project common usage
     */
    public class Constant
    {
        // Role id
        public const int ADMIN_ROLE = 0;
        public const int CUSTOMER_ROLE = 1;
        
        // status codes
        public const string OK = "200";
        public const string REQUEST_EXCEPTION = "400";
        public const string RESOURCE_NOT_FOUND = "404";
        public const string PERMISSION_DENIED = "403";
        public const string INTERNAL_ERROR = "500";
        
        public const string UNKNOWN_EXCEPTION_CODE = "1000";
        public const string BOOK_ALREADY_RESERVED_CODE = "1001";
    }
}