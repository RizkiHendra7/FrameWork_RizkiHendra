using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RizkiHendraFrameWork.BussLogic.Master;
using RizkiHendraFrameWork.Common.Library;
using RizkiHendraFrameWork.Common.ORM.Model.SQL;
using RizkiHendraFrameWork.Library.SwaggerExample;
using Swashbuckle.AspNetCore.Filters;
using System.Net;

namespace RizkiHendraFrameWork.Controllers.Master
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class mUserController : ControllerBase
    {
        private mUserBL mUserBL;
        public mUserController()
        {
            mUserBL = new mUserBL();
        }

        [HttpPost]
        [ProducesResponseType(typeof(getAllData_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(getAllData_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(getAllData_Request))]
        public IActionResult getAllData(clsReturnApi apiDat)
        {

            JObject resultDat = JObject.Parse(apiDat.objRequestData.ToString());
            var dt = JsonConvert.DeserializeObject<clsPagingModelRequest>(resultDat.ToString());
            apiDat.objResponseData = mUserBL.GetAllData(dt);
            return Ok(apiDat);
        }


        [HttpPost]
        [ProducesResponseType(typeof(getDataById_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(getDataById_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(getDataById_Request))]
        public IActionResult getDataById(clsReturnApi apiDat)
        {

            JObject resultDat = JObject.Parse(apiDat.objRequestData.ToString());
            var dt = JsonConvert.DeserializeObject<mUser>(resultDat.ToString());
            apiDat.objResponseData = mUserBL.GetDataById(dt.txtUserId);
            return Ok(apiDat);
        }


        [HttpPost]
        [ProducesResponseType(typeof(save_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(save_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(save_Request))]
        public IActionResult save(clsReturnApi apiDat)
        {

            JObject resultDat = JObject.Parse(apiDat.objRequestData.ToString());
            var dt = JsonConvert.DeserializeObject<mUser>(resultDat.ToString());
            apiDat.objResponseData = mUserBL.Insert(dt);
            return Ok(apiDat);
        }


        [HttpPost]
        [ProducesResponseType(typeof(delete_Response), (int)HttpStatusCode.OK)]
        [SwaggerResponseExample((int)HttpStatusCode.OK, typeof(delete_Response))]
        [SwaggerRequestExample(typeof(clsReturnApi), typeof(delete_Request))]
        public IActionResult delete(clsReturnApi apiDat)
        {

            JObject resultDat = JObject.Parse(apiDat.objRequestData.ToString());
            var dt = JsonConvert.DeserializeObject<mUser>(resultDat.ToString());
            apiDat.objResponseData = mUserBL.Delete(dt.txtUserId);
            return Ok(apiDat);
        }





    }
}
