namespace MyBookStore.Domain.Command
{
    /**
     * author: xiaotian li
     */
    public interface ICommand
    {
        /**
         * Is the command valid or not.
         * based on data validation result.
         */
        bool IsValid();
    }
}