namespace MyBookStore.Common.constant
{
    /**
     * Author: Xiaotian Li
     * Description: Constants for project common usage
     */
    public static class MyConstant
    {
        // Role id
        public const int ADMIN_ROLE = 0;
        public const int CUSTOMER_ROLE = 1;
        
        // cookie name
        public const string JWT_COOKIE = "jwt";
        
        // config name
        public const string JWT_KEY_CONFIG = "Jwt:Key";
        public const string JWT_ISSUER_CONFIG = "Jwt:Issuer";
        public const string JWT_AUDIENCE_CONFIG = "Jwt:Audience";
        
        // status codes
        public const int OK = 200;
        public const int REQUEST_EXCEPTION = 400;
        public const int RESOURCE_NOT_FOUND = 404;
        public const int PERMISSION_DENIED = 403;
        public const int INTERNAL_ERROR = 500;
        
        public const int UNKNOWN_EXCEPTION_CODE = 1000;
        public const int BOOK_ALREADY_RESERVED_CODE = 1001;
        public const int RESOURCE_DUPLICATED = 1002;
    }
}