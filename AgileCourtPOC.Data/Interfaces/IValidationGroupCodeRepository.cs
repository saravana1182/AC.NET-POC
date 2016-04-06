using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;

namespace AgileCourtPOC.Data.Interfaces
{
    public interface IValidationGroupCodeRepository :IRepository<ValidationGroupCode,int>
    {
        IEnumerable<ValidationGroupCode> Get();
    }
}   
