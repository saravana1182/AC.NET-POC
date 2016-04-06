using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Service.Interface;
using AgileCourtPOC.Data.Interfaces;

namespace AgileCourtPOC.Service
{
    public class ValidationGroupCodeService : IValidationGroupCodeService
    {
        private IRepository<ValidationGroupCode, int> _validationGroupCodeRepository;
       
        public ValidationGroupCodeService(IRepository<ValidationGroupCode,int> validationGroupCodeRepository)
        {
            _validationGroupCodeRepository = validationGroupCodeRepository;
        }
        public IEnumerable<ValidationGroupCode> Get()
        {
            return _validationGroupCodeRepository.Get();
        }

        public ValidationGroupCode Get(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
