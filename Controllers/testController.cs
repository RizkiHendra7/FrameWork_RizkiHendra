using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RizkiHendraFrameWork.BussLogic;
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
    public class testController : ControllerBase
    {
        private testBL _testBL;
        public testController()
        {
            _testBL = new testBL();
        }

        [HttpPost]
        [ProducesResponseType(typeof(testAttachment_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(testAttachment_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(testAttachment_Request))]
        public IActionResult exampleAttachment([FromForm] clsReturnApi apiDat)
        { 
            var file = apiDat.attachmentData;
            apiDat.objResponseData = _testBL.testAttachment(file);
            return Ok(apiDat);
        }

        [HttpPost]
        [ProducesResponseType(typeof(exampleGenerateExcel_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(exampleGenerateExcel_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(exampleGenerateExcel_Request))]
        public IActionResult exampleGenerateExcel(clsReturnApi apiDat)
        { 
            apiDat.objResponseData = _testBL.exampleGenerateExcel();
            return Ok(apiDat);
        }

        [HttpPost]
        [ProducesResponseType(typeof(exampleSendEmail_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(exampleSendEmail_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(exampleSendEmail_Request))]
        public IActionResult exampleSendEmail(clsReturnApi apiDat)
        {
            JObject resultDat = JObject.Parse(apiDat.objRequestData.ToString());
            var dt = JsonConvert.DeserializeObject<mailModel>(resultDat.ToString());
            apiDat.objResponseData = _testBL.exampleSendEmail(dt);
            return Ok(apiDat);
        }
    }
}
