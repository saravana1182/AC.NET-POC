using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Data;

namespace AgileCourtPOC.Data.Repository
{
    public class ValidationGroupCodeRepository: AgileCourtRepository<ValidationGroupCode,int>, IValidationGroupCodeRepository
    {

        private AgileCourtDBContext _context;
        public ValidationGroupCodeRepository(AgileCourtDBContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ValidationGroupCode> Get()
        {
            return _context.ValidationMasterCategoryCode.ToList();
        }

    }
}
