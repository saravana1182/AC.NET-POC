using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;

namespace AgileCourtPOC.Service.Interface
{
    public interface IValidationGroupCodeService
    {

       
        IEnumerable<ValidationGroupCode> Get();

        ValidationGroupCode Get(int Id);

        
    }
}
