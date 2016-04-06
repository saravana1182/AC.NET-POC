using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;

namespace AgileCourtPOC.Service.Interface
{
    public interface IValidationCodeService
    {

        void Create(ValidationCode baseValidationCode);
        IEnumerable<ValidationCode> Get();

        IEnumerable<ValidationCode> GetByCodeType(int codeType);
        
        ValidationCode Get(int Id);

        void Update(ValidationCode baseValidationCode);
        ValidationCode GetByCode(string code);
    }
}
