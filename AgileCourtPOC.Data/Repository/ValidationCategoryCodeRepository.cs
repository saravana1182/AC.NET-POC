using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AgileCourtPOC.Data;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Data.Interfaces;


namespace AgileCourtPOC.Data.Repository
{
    public class ValidationCategoryCodeRepository :  AgileCourtRepository<ValidationCategoryCode, int>, IValidationCategoryCodeRepository
    {

        private AgileCourtDBContext _context;
        public ValidationCategoryCodeRepository(AgileCourtDBContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<ValidationCategoryCode> Get()
        {
            return _context.ValidationCategoryCode.ToList();
        }

        public IEnumerable<ValidationCategoryCode> GetByGroupCode(int groupCodeId)
        {
            return _context.ValidationCategoryCode
                .Where(x => x.ValidationMasterCategoryCodeRefId == groupCodeId)
                .ToList();
        }

        
    }
}
