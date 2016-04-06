using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;

namespace AgileCourtPOC.Data.Interfaces
{
    public interface IValidationCodeRepository :IRepository<ValidationCode, int>
    {

        IEnumerable<ValidationCode> Get();
        IEnumerable<ValidationCode> GetByCodeType(int codeType);
        ValidationCode GetById(string code);
    }
}
