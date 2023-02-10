namespace MyBookStore.Common
{
    public enum ExceptionEnum
    {
        INVALID_REQUEST_DATA,
        RESOURCE_NOT_EXIST,
        NO_PERMISSION,
        SERVER_INTERNAL_ERROR,

        BOOK_ALREADY_RESERVED,
        USERNAME_OR_PASSWORD_INCORRECT,
    }

    public static class ExceptionEnumExtensions
    {
        public static string GetString(this ExceptionEnum e)
        {
            switch (e)
            {
                case ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT:
                    return "Login ID or password incorrect!";
                case ExceptionEnum.BOOK_ALREADY_RESERVED:
                    return "Book has been reserved!";
                case ExceptionEnum.SERVER_INTERNAL_ERROR:
                    return "Server internal error. Contact IT department.";
                case ExceptionEnum.NO_PERMISSION:
                    return "No permission, please login with the valid user.";
                case ExceptionEnum.RESOURCE_NOT_EXIST:
                    return "Request result not found.";
                case ExceptionEnum.INVALID_REQUEST_DATA:
                    return "Invalid request data, please check data inputs.";
                default:
                    return "Unknown exception";
            }
        }
        
        public static string GetStatusCode(this ExceptionEnum e)
        {
            switch (e)
            {
                case ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT:
                    return Constant.PERMISSION_DENIED;
                case ExceptionEnum.BOOK_ALREADY_RESERVED:
                    return Constant.BOOK_ALREADY_RESERVED_CODE;
                case ExceptionEnum.SERVER_INTERNAL_ERROR:
                    return Constant.INTERNAL_ERROR;
                case ExceptionEnum.NO_PERMISSION:
                    return Constant.PERMISSION_DENIED;
                case ExceptionEnum.RESOURCE_NOT_EXIST:
                    return Constant.RESOURCE_NOT_FOUND;
                case ExceptionEnum.INVALID_REQUEST_DATA:
                    return Constant.REQUEST_EXCEPTION;
                default:
                    return Constant.UNKNOWN_EXCEPTION_CODE;
            }
        }
    }
}