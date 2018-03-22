using System.Collections.Generic;

namespace BusinessService.DTOs
{
    public class OperationResult
    {
        public OperationResult()
        {
            Errors = new List<string>();
        }

        public void Fail(string reason)
        {
            Errors.Add(reason);
        }

        public bool Succeeded => Errors.Count == 0;      
        public List<string> Errors { get; set; }
    }

    public class OperationResult<TResult> : OperationResult
    {
        public virtual TResult Value { get; set; }
    }
}
