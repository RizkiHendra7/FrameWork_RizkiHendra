using RizkiHendraFrameWork.Common.Library;
using RizkiHendraFrameWork.Common.ORM.Model.Custom;
using RizkiHendraFrameWork.Common.ORM.Model.SQL;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace RizkiHendraFrameWork.Library.SwaggerExample
{
    #region getAllData
    internal class getAllData_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objRequestData = new clsPagingModelRequest
                {
                    intPage = 1,
                    intLength = 10,
                    txtSearch = "rizki",
                    txtSortBy = "txtUserName",
                    bitAscending = true
                }
            };
        }
    }
    internal class getAllData_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = true
            };
        }
    }
    #endregion

    #region getDataById
    internal class getDataById_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objRequestData = new mUser()
                {
                    txtUserId = clsRijndael.Encrypt(1.ToString()) 
                }
            };
        }
    }


    internal class getDataById_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = new mUser
                {
                    txtUserId = clsRijndael.Encrypt(1.ToString()),
                    txtUserName ="rizki.pamungkas",
                    txtFullName = "Rizki Hendra Putra"
                }
            };
        }
    }
    #endregion

    #region save
    internal class save_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objRequestData = new mUser()
                { 
                    txtUserName = "rizki.pamungkas",
                    txtFullName = "Rizki Hendra Putra" 
                }
            };
        }
    }


    internal class save_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = new mUser
                {
                    txtUserName = "rizki.pamungkas",
                    txtFullName = "Rizki Hendra Putra",
                    txtUserId = clsRijndael.Encrypt(1.ToString())
                }
            };
        }
    }
    #endregion

    #region delete
    internal class delete_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objRequestData = new mUser()
                {
                    txtUserId = clsRijndael.Encrypt(1.ToString())
                }
            };
        }
    }


    internal class delete_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = true
            };
        }
    }
    #endregion


}
