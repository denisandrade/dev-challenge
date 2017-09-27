using System;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using SocialMediaIntegration.Application.Interface;
using NLog;
using System.Web.Http.Cors;
using SocialMediaIntegration.WebApi.Validators;

namespace SocialMediaIntegration.WebApi.Controllers
{
    public class SocialMediaController : ApiController
    {
        private readonly ISocialMediaAppService _socialMediaAppService;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public SocialMediaController(ISocialMediaAppService socialMediaAppService)
        {
            _socialMediaAppService = socialMediaAppService;
        }

        [HttpGet]
        [Route("twitter/{tag}")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GetTwitter(string tag)
        {
            try
            {
                SocialMediaValidator.TagValidator(tag);

                var response = _socialMediaAppService.GetTwitter(tag);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ArgumentException ar)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ar.Message);
            }
            catch (Exception ex)
            {
                var errorGuid = Guid.NewGuid().ToString();
                LogError(errorGuid, ex);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, string.Format("Internal Error - {0} Error: {1}", errorGuid, ex.Message));
            }
        }

        [HttpGet]
        [Route("searches")]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public HttpResponseMessage GetSearches()
        {
            try
            {
                var response = _socialMediaAppService.GetCachedSearches();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (ArgumentException ar)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ar.Message);
            }
            catch (Exception ex)
            {
                var errorGuid = Guid.NewGuid().ToString();
                LogError(errorGuid, ex);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, string.Format("Internal Error - {0} Error: {1}", errorGuid, ex.Message));
            }
        }

        private void LogError(string errorGuid, Exception ex)
        {
            var errorObj = new
            {
                Guid = errorGuid,
                Date = DateTime.Now,
                Request = Request.RequestUri.OriginalString,
                Exception = ex.ToString(),
            };

            logger.Error(errorObj);
        }
    }
}