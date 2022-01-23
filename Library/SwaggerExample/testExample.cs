using Microsoft.AspNetCore.Http;
using RizkiHendraFrameWork.Common.Library;
using RizkiHendraFrameWork.Common.ORM.Model.Custom;
using RizkiHendraFrameWork.Common.ORM.Model.SQL;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RizkiHendraFrameWork.Library.SwaggerExample
{

    #region test Attachment
    internal class testAttachment_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            { 
                objRequestData = null
            };
        }
    }


    internal class testAttachment_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = "URL ATTACHMENT"
            };
        }
    }
    #endregion

    #region test excel
    internal class exampleGenerateExcel_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objRequestData = null
            };
        }
    }


    internal class exampleGenerateExcel_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = "URL ATTACHMENT"
            };
        }
    }
    #endregion


    #region test Email
    internal class exampleSendEmail_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objRequestData = new mailModel()
                {
                    txtFrom = "rizkihendra7@gmail.com",
                    txtSubject ="[Testing Email]",
                    txtSmtp = "127.0.0.0[YOUR IP SMPTP]",
                    txtTo ="dummy@gmail.com",
                    listTxtCC = new List<string>()
                    {
                         "Dummy1@gmail.com",
                         "Dummy2@gmail.com"
                    },
                    txtBody ="Email only for testing when u have smptp server"
                }
            };
        }
    }


    internal class exampleSendEmail_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = "URL ATTACHMENT"
            };
        }
    }
    #endregion
}
