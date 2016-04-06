using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AgileCourtPOC.WebAPI;
using AgileCourtPOC.WebAPI.Controllers;
using Microsoft.Practices.Unity;
using AgileCourtPOC.Utilities;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Domain;
using System.Linq;
using System.Collections.Generic;

namespace AgileCourtPOC.WebAPI.Tests.Controllers
{
    [TestClass]
    public class ValidationCategoryCodesControllerTest
    {

        private IValidationCategoryCodeRepository _validationcodeRepository;

        [TestInitialize]
        public void Initialize()
        {
            var container = new UnityContainer();

            container.RegisterType<IValidationCategoryCodeRepository, ValidationCategoryCodeTestRepository>();

            _validationcodeRepository = container.Resolve<IValidationCategoryCodeRepository>();
        }


     

    }

    internal class ValidationCategoryCodeTestRepository : IValidationCategoryCodeRepository,IRepository<ValidationCategoryCode,int>
    {

        private static IList<ValidationCategoryCode> codes = new List<ValidationCategoryCode>();

        public ValidationCategoryCodeTestRepository()
        {
            codes.Add(new ValidationCategoryCode
            {
                Id=1,
                Code="CC",
                Description="Court Code"

            });

            codes.Add(new ValidationCategoryCode
            {
                Id = 2,
                Code = "LC",
                Description = "Location Code"

            });


        }


        public void Create(ValidationCategoryCode entity)
        {
            codes.Add(entity);
        }

        public void Delete(ValidationCategoryCode entity)
        {
            codes.Remove(entity);
        }

        public IEnumerable<ValidationCategoryCode> Get()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationCategoryCode> GetActiveCodes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ValidationCategoryCode> GetByGroupCode(int groupCodeId)
        {
            throw new NotImplementedException();
        }

        public ValidationCategoryCode GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<ValidationCategoryCode> Read()
        {
            return codes.AsQueryable();
        }

        public void Update(ValidationCategoryCode entity)
        {
            var code = codes.FirstOrDefault(x => x.Id == entity.Id);
            codes.Remove(code);
            codes.Add(code);
        }
    }
}
