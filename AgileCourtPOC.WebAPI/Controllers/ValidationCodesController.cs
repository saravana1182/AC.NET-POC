using AgileCourtPOC.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgileCourtPOC.Domain;
using AgileCourtPOC.Service;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Service.Interface;
using NLog;

namespace AgileCourtPOC.WebAPI.Controllers
{
    public class ValidationCodesController : ApiController
    {
        
        private IValidationCodeService _validationCodeService;
        private readonly ILogger _logger;
        public ValidationCodesController(IValidationCodeService validationCodeService ,ILogger logger)
        {
            _logger = logger;
            _validationCodeService = validationCodeService;
        }
        // GET: api/ValidationCodes
        

        // GET: api/ValidationCodes/5

        [ActionName("GetById")]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                var validationCode = _validationCodeService.Get(id);

                if (validationCode == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, string.Format("No records found for {0}", id));
                }

                return Request.CreateResponse(HttpStatusCode.OK, new { ValidationCode = MapDomainToViewModel(validationCode) });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }
            

        }

        [ActionName("GetByCode")]
        public HttpResponseMessage GetByCode(string id)
        {

            try
            {
                var validationCode = _validationCodeService.GetByCode(id);

                if (validationCode == null)
                {
                   
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,string.Format("Validation code with id:{0} does not exist",id));
                }
                return Request.CreateResponse(HttpStatusCode.OK, new { ValidationCode = MapDomainToViewModel(validationCode) });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
            }

          

        }



        [ActionName("GetByCodeType")]
        public HttpResponseMessage GetByCodeType(int id)
        {
            var validationCodes = _validationCodeService.GetByCodeType(id);

            if(validationCodes==null || !validationCodes.Any())
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No records Found");
            }

            var validationCodesViewModel = validationCodes.Select(
              x => new ValidationCodeViewModel
              {
                  Code = x.Code,
                  Description = x.Description,
                  Id = x.Id,
                  BeginDate=x.BeginDate,
                  EndDate=x.EndDate,
                  ValidationCategoryCodeRefID=x.ValidationCategoryCodeRefID
                 
              }
              ).AsParallel();

            return Request.CreateResponse(HttpStatusCode.OK, new { ValidationCodes = validationCodesViewModel });


        }



        private ValidationCodeViewModel MapDomainToViewModel(ValidationCode validationCode)
        {
            return new ValidationCodeViewModel()
            {
                Id = validationCode.Id,
                Description = validationCode.Description,
                Code = validationCode.Code,
                BeginDate = validationCode.BeginDate,
                EndDate = validationCode.EndDate,
                ReportAs = validationCode.ReportAs,
                ValidationCategoryCodeRefID = validationCode.ValidationCategoryCodeRefID
                
        };

            
            
        }

        // POST: api/ValidationCodes
        public HttpResponseMessage Post([FromBody] ValidationCodeViewModel model)
        {

            var validationCode = MapViewModelToDomain(model);

            try
            {
                _validationCodeService.Create(validationCode);
                return Request.CreateResponse(HttpStatusCode.Created,"Successfully Saved");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to create");
            }      
       


        }

        public HttpResponseMessage Put([FromBody] ValidationCodeViewModel model)
        {

            var validationCode = MapViewModelToDomain(model);

            try
            {
                _validationCodeService.Update(validationCode);
                return Request.CreateResponse(HttpStatusCode.OK, "Successfully Saved");
            }
            catch (Exception)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to Update");
            }



        }

        private ValidationCode MapViewModelToDomain(ValidationCodeViewModel model)
        {
            return new ValidationCode()
            {
                Id = model.Id,
                Code = model.Code,
                Description = model.Description,
                BeginDate = Convert.ToDateTime(model.BeginDate),
                EndDate = Convert.ToDateTime(model.EndDate),
                ValidationCategoryCodeRefID = model.ValidationCategoryCodeRefID
            };
        }

        // PUT: api/ValidationCodes/5
        //public HttpResponseMessage Put(int id, [FromBody]ValidationCodeViewModel model)
        //{

        //    var validationCode = MapViewModelToDomain(model);

        //    try
        //    {
        //        _validationCodeService.Update(validationCode);
        //        return Request.CreateResponse(HttpStatusCode.Created, "Successfully Saved");
        //    }
        //    catch (Exception)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Failed to create");
        //    }
        //}

        // DELETE: api/ValidationCodes/5
        public void Delete(int id)
        {
        }
    }
}
