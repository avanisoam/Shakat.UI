using Shakat.UIConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakat.UIConsoleApp.Templates
{
    public class RazorCsFileTemplate : ITemplate
    {
        public StringBuilder GetTemplate(string dto, string service = "", string serviceUrl = "", string primaryKey = "")
        {
            string dtoObject = dto.FirstCharToLowerCase();

            StringBuilder sourceBuilder = new StringBuilder(@"");

            sourceBuilder.AppendFormat(@"");

            return sourceBuilder;
        }
    }
}
