using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;

namespace AgileCourtPOC.Service.Interface
{
    public interface IValidationCategoryCodeService
    {
        IEnumerable<ValidationCategoryCode> Get();
        IEnumerable<ValidationCategoryCode> GetByGroupCode(int groupCodeId); 

        ValidationCategoryCode Get(int Id);

        void Create(ValidationCategoryCode code);

        void Update(ValidationCategoryCode code);

    }
}
