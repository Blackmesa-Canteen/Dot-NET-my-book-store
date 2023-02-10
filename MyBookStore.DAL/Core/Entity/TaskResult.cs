using System.Collections.Generic;

namespace MyBookStore.DAL.Entity
{
    /**
     * Author: Xiaotian Li
     *
     * Task Result object for CRUD commands
     */
    public class TaskResult
    {
        private List<string> _error_info_list;

        public TaskResult()
        {
            _error_info_list = new List<string>();
        }

        public bool HasErrors()
        {
            return _error_info_list.Count > 0;
        }
        
        public List<string> GetErrorList()
        {
            return _error_info_list;
        }

        public void AddErrorInfo(string errorInfo)
        {
            _error_info_list.Add(errorInfo);
        }

        public void AddErrorInfo(IEnumerable<string> errorInfoEnum)
        {
            _error_info_list.AddRange(errorInfoEnum);
        }
    }
}