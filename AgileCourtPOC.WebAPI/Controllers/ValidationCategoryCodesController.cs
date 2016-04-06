using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgileCourtPOC.WebAPI.Models;
using AgileCourtPOC.Service;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Service.Interface;
using NLog;
namespace AgileCourtPOC.WebAPI.Controllers
{
    public class ValidationCategoryCodesController : ApiController
    {


       
        private IValidationCategoryCodeService _validationCategoryCodeService;
        private readonly ILogger _logger;

        public ValidationCategoryCodesController(IValidationCategoryCodeService validationCategoryCodeService, ILogger logger)
        {           
            _validationCategoryCodeService = validationCategoryCodeService;
            _logger = logger;
        }

        
        // GET: api/ValidationCodes
        [HttpGet]
        [ActionName("GetByGroupCode")]
        public HttpResponseMessage GetByGroupCode(int id)
        {
            try
            {
                var validationCategoryCodes = _validationCategoryCodeService.GetByGroupCode(id);

                if (validationCategoryCodes == null || validationCategoryCodes.Count() == 0)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Records found");
                }

                var validationCategoryCodesViewModel = validationCategoryCodes.Select(
                    x => new ValidationCategoryCodeViewModel
                    {
                        Code = x.Code,
                        Description = x.Description,
                        Id = x.Id
                    }
                    ).AsParallel();

                return Request.CreateResponse(HttpStatusCode.OK, new { ValidationCategoryCodes = validationCategoryCodesViewModel });
            }
            catch (Exception ex)
            {
                _logger.Error(ex,ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex);
            } 
        }

        // GET: api/ValidationCodes/5
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {

            try
            {
                var validationCategoryCode = _validationCategoryCodeService.Get(id);

                if (validationCategoryCode == null) return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No Records found"); ;
                var v = MapDomainModelToViewModel(validationCategoryCode);
                return Request.CreateResponse(HttpStatusCode.OK, new { ValidationCategoryCode = validationCategoryCode });
                //return MapDomainModelToViewModel(validationCategoryCode);
            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception);
            }
        }

        


        private ValidationCategoryCodeViewModel MapDomainModelToViewModel(ValidationCategoryCode validationCategoryCode)
        {

            return new ValidationCategoryCodeViewModel()
            {
                Code = validationCategoryCode.Code,
                Description = validationCategoryCode.Description,
                Id = validationCategoryCode.Id
            };

        }

        // POST: api/ValidationCodes
        public HttpResponseMessage Post([FromBody]ValidationCategoryCodeViewModel model)
        {
            try
            {
                var validationCategoryCode = MapViewModelToDomain(model);
                _validationCategoryCodeService.Create(validationCategoryCode);

                return Request.CreateResponse(HttpStatusCode.OK,true);

            }
            catch (Exception exception)
            {
                _logger.Error(exception, exception.Message);
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"Error occured while processing the request");

            }
            

        }

        private ValidationCategoryCode MapViewModelToDomain(ValidationCategoryCodeViewModel model,int id=0)
        {

            return new ValidationCategoryCode()
            {
                Code = model.Code,
                Description = model.Description,
                Id= id
            };

            
        }

        // PUT: api/ValidationCodes/5
        public void Put(int id, [FromBody]ValidationCategoryCodeViewModel model)
        {
            var validationCategoryCode = MapViewModelToDomain(model,id);
            
            _validationCategoryCodeService.Update(validationCategoryCode);
        }

        
    }
}
