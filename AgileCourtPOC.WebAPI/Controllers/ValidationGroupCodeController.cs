using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AgileCourtPOC.Data.Interfaces;
using AgileCourtPOC.Service.Interface;
using AgileCourtPOC.WebAPI.Models;
using NLog;

namespace AgileCourtPOC.WebAPI.Controllers
{
   
    public class ValidationGroupCodeController : ApiController
    {
       
        public IValidationGroupCodeService _validationGroupCodeService;
        private readonly ILogger _logger;
        public ValidationGroupCodeController(IValidationGroupCodeService validationGroupCodeService,ILogger logger)
        {
            _logger = logger;
            _validationGroupCodeService = validationGroupCodeService;
        }
        public HttpResponseMessage Get()
        {
            try
            {
                var validationGroupCodeList = _validationGroupCodeService.Get();

                if (validationGroupCodeList == null || validationGroupCodeList.Count() == 0)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                var validationGroupCodeListViewModel = validationGroupCodeList.Select(
                     x => new ValidationGroupCodeViewModel()
                     {
                         Code = x.Code,
                         Description = x.Description,
                         Id = x.Id

                     }
                     ).AsParallel();

                return Request.CreateResponse(HttpStatusCode.OK, new { ValidationGroupCodes = validationGroupCodeListViewModel });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error occured while processing the request");
            }
           
        }
        
    }
}
