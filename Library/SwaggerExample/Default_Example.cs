using RizkiHendraFrameWork.Common.Library;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RizkiHendraFrameWork.Library.SwaggerExample
{
    public class defaultModel
    { 
        public string txtPrograName { get; set; }
        public string txtCreator { get; set; }
        public DateTime dtCreated { get; set; }
    } 
    internal class Default_Example : IExamplesProvider<clsReturnApi>
    {
        public clsReturnApi GetExamples()
        {
            return new clsReturnApi
            { 
                objRequestData = new defaultModel()
                {
                    txtCreator = "RIZKI HENDRA PUTRA PAMUNGKAS",
                    txtPrograName ="RizkiHendraFrameworkNetCore",
                    dtCreated = Convert.ToDateTime("2020/12/12")
                }
            };
        }
    } 
}
