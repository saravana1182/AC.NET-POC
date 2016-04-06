using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Data;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Service.Interface;

namespace AgileCourtPOC.Service
{
    public class ValidationCodeService:IValidationCodeService
    {

        private IRepository<ValidationCode, int> _validationCodeRepository;
        public ValidationCodeService(IRepository<ValidationCode,int> validationCodeRepository)
        {
            _validationCodeRepository = validationCodeRepository;
        }

        public void Create(ValidationCode code)
        {
            _validationCodeRepository.Upsert(code);
        }

        public IEnumerable<ValidationCode> Get()
        {
            throw new NotImplementedException();
        }

        public ValidationCode Get(int id)
        {
            return _validationCodeRepository.Get(id);
        }

       
        public void Update(ValidationCode code)
        {
            _validationCodeRepository.Upsert(code);
        }

        public IEnumerable<ValidationCode> GetByCodeType(int codeType)
        {
            return _validationCodeRepository.Get(_ => _.ValidationCategoryCodeRefID == codeType);
        }

        public ValidationCode GetByCode(string code)
        {
            return _validationCodeRepository.Get(_ => _.Code == code).FirstOrDefault();
        }
    }
}
