namespace MyBookStore.Common.constant
{
    public enum ExceptionEnum
    {
        OK,
        
        INVALID_REQUEST_DATA,
        RESOURCE_NOT_EXIST,
        RESOURCE_DUPLICATED,
        NO_PERMISSION,
        SERVER_INTERNAL_ERROR,

        BOOK_ALREADY_RESERVED,
        USERNAME_OR_PASSWORD_INCORRECT
    }

    public static class ExceptionEnumExtensions
    {
        public static string GetString(this ExceptionEnum e)
        {
            switch (e)
            {
                case ExceptionEnum.OK:
                    return "Ok";
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
                case ExceptionEnum.RESOURCE_DUPLICATED:
                    return "Duplicated record!";
                default:
                    return "Unknown exception";
            }
        }
        
        public static int GetStatusCode(this ExceptionEnum e)
        {
            switch (e)
            {
                case ExceptionEnum.OK:
                    return MyConstant.OK;
                case ExceptionEnum.USERNAME_OR_PASSWORD_INCORRECT:
                    return MyConstant.PERMISSION_DENIED;
                case ExceptionEnum.BOOK_ALREADY_RESERVED:
                    return MyConstant.BOOK_ALREADY_RESERVED_CODE;
                case ExceptionEnum.SERVER_INTERNAL_ERROR:
                    return MyConstant.INTERNAL_ERROR;
                case ExceptionEnum.NO_PERMISSION:
                    return MyConstant.PERMISSION_DENIED;
                case ExceptionEnum.RESOURCE_NOT_EXIST:
                    return MyConstant.RESOURCE_NOT_FOUND;
                case ExceptionEnum.INVALID_REQUEST_DATA:
                    return MyConstant.REQUEST_EXCEPTION;
                case ExceptionEnum.RESOURCE_DUPLICATED:
                    return MyConstant.RESOURCE_DUPLICATED;
                default:
                    return MyConstant.UNKNOWN_EXCEPTION_CODE;
            }
        }
    }
}