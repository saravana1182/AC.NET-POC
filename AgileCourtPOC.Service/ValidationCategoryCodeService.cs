using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Service.Interface;

namespace AgileCourtPOC.Service
{
    public class ValidationCategoryCodeService :IValidationCategoryCodeService
    {

        private IRepository<ValidationCategoryCode, int> _validationCategoryCodeRepository;
        public ValidationCategoryCodeService(IRepository<ValidationCategoryCode,int> validationCategoryCodeRepository)
        {
            _validationCategoryCodeRepository = validationCategoryCodeRepository;
        }
          
        public ValidationCategoryCode Get(int id)
        {
            return _validationCategoryCodeRepository.Get(id);
        }

        public void Create(ValidationCategoryCode code)
        {
            _validationCategoryCodeRepository.Upsert(code);
        }

        public void Update(ValidationCategoryCode code)
        {
            _validationCategoryCodeRepository.Upsert(code);
        }

        public IEnumerable<ValidationCategoryCode> Get()
        {
            return _validationCategoryCodeRepository.Get();
        }
        public IEnumerable<ValidationCategoryCode> GetByGroupCode(int groupCodeId)
        {
            return _validationCategoryCodeRepository.Get(_=>_.ValidationMasterCategoryCodeRefId == groupCodeId);
        }

    }
}
