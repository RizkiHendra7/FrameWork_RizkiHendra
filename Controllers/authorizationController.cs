using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RizkiHendraFrameWork.BussLogic.Custom;
using RizkiHendraFrameWork.Common.Library;
using RizkiHendraFrameWork.Common.ORM.Model.Custom;
using RizkiHendraFrameWork.Common.ORM.Model.SQL;
using RizkiHendraFrameWork.Library.SwaggerExample;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace RizkiHendraFrameWork.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class authorizationController : ControllerBase
    { 

        [HttpPost]
        [ProducesResponseType(typeof(changeActiveRole_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(changeActiveRole_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(changeActiveRole_Request))]
        public IActionResult changeActiveRole(clsReturnApi apiDat)
        {

            JObject resultDat = JObject.Parse(apiDat.objRequestData.ToString());
            var dt = JsonConvert.DeserializeObject<mRole>(resultDat.ToString());
            apiDat.objResponseData = tokenBL.changeActiveRole(dt);
            return Ok(apiDat);
        }

        [HttpPost]
        [ProducesResponseType(typeof(authenticate_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(authenticate_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(authenticate_Request))]
        public IActionResult Authenticate(clsReturnApi apiDat)
        {
            JObject resultDat = JObject.Parse(apiDat.objRequestData.ToString());
            var dt = JsonConvert.DeserializeObject<AuthenticateRequest>(resultDat.ToString());
            apiDat.objResponseData = tokenBL.Authenticate(dt);
            return Ok(apiDat);
        }
    }
}
