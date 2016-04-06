using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Domain;
using System.Data.Entity;

namespace AgileCourtPOC.Data.Repository
{
    public class ValidationCodeRepository : AgileCourtRepository<ValidationCode,int>,IValidationCodeRepository
    {


        private AgileCourtDBContext _context;
      
        public ValidationCodeRepository(AgileCourtDBContext context):base(context)
        {
            _context = context;
        }

        public IEnumerable<ValidationCode> Get()
        {
             var dbset=_context.Set<ValidationCode>();

            return dbset.ToList();
        }

        public IEnumerable<ValidationCode> GetByCodeType(int codeType)
        {
            _context.Configuration.LazyLoadingEnabled = false;
            var dbset = _context.Set<ValidationCode>();
            return dbset.Where(x => x.ValidationCategoryCodeRefID == codeType).ToList();
        }

        public ValidationCode GetById(string code)
        {
            _context.Configuration.LazyLoadingEnabled = false;
            var dbset = _context.Set<ValidationCode>();

            return dbset.Where(x => x.Code==code).FirstOrDefault();
        }

        public override ValidationCode GetById(int id)
        {
            _context.Configuration.LazyLoadingEnabled = false;
            var dbset = _context.Set<ValidationCode>();

            return dbset.Where(x=>x.Id==id).FirstOrDefault();
        }
    }
}
