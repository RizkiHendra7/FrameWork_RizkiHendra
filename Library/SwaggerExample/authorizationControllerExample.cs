using RizkiHendraFrameWork.Common.Library;
using RizkiHendraFrameWork.Common.ORM.Model.Custom;
using RizkiHendraFrameWork.Common.ORM.Model.SQL;
using Swashbuckle.AspNetCore.Filters;
using System.Collections.Generic;

namespace RizkiHendraFrameWork.Library.SwaggerExample
{

    #region Authenticate

    internal class authenticate_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            { 
                bitSuccess = true,
                boolError = false,
                objRequestData = new AuthenticateRequest
                {
                    username = "rizki.pamungkas",
                    password = "P@ssw0rd"
                }
            };
        }
    }

    internal class authenticate_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            {
                objResponseData = new userSessoionModel
                {
                    userInfo = new mUser()
                    {
                        txtUserId = clsRijndael.Encrypt(231996.ToString()),
                        txtUserName = "Rizki.pamungkas1",
                    },
                    txtToken = "DUMMY-TOKEN",
                    activeRole = new mRole(),
                    listRole = new List<mRole>() 
                }
            };
        }
    }
    #endregion

    #region changeActiveRole
    internal class changeActiveRole_Request : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            { 
                objRequestData = new mRole()
                { 
                    txtRoleId = clsRijndael.Encrypt(123.ToString()),
                    txtRoleName = "ADMIN SUPER USER",
                    txtRoleCode = "AdminSU"
                } 
            };
        }
    }


    internal class changeActiveRole_Response : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            { 
                objResponseData =  true
            };
        }
    }
    #endregion





}
