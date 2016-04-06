using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileCourtPOC.WebAPI.Error
{
    public class ValidationError
    {
        private IList<Error> _validationErrorlist;

        public ValidationError()
        {
            _validationErrorlist = new List<Error>();
        }

        public void Add(string errorId, string errorMessage)
        {
            _validationErrorlist.Add(new Error() { Id = errorId, Message = errorMessage });
        }

        public IList<Error> Get()
        {
            return _validationErrorlist;
        }

    }

    public class Error
    {
        public string Id { get; set; }
        public string Message { get; set; }
    }
        
   

    public interface IValidationError
    {
        void AddError(string errorID, string errorMessage);

        IEnumerable<Error> Get();

    }
}