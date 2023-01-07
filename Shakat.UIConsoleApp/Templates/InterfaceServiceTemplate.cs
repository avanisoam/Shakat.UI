using Shakat.UIConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakat.UIConsoleApp.Templates
{
    public class InterfaceServiceTemplate : ITemplate
    {
        public StringBuilder GetTemplate(string dto, string service, string serviceUrl = "", string primaryKey = "")
        {
            string dtoObject = dto.FirstCharToLowerCase();

            StringBuilder sourceBuilder = new StringBuilder(@"");
            
            sourceBuilder.AppendFormat(@"
using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{0}
    public interface I{3}
    {0}
        Task<IEnumerable<{2}>> GetAll();
        Task<{2}> GetById(int id);
        Task<{2}> Create({2} {4});

        Task<{2}> Update({2} {4});

        Task<{2}> Delete(int id);
    {1}
{1}
 ", "{", "}", dto, service, dtoObject);

            return sourceBuilder;
        }
    }
}
