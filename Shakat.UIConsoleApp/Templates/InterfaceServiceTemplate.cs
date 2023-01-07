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
        public StringBuilder GetTemplate(string model, Dictionary<string, Dictionary<string, string>> keyValuePairs = null)
        {
            string dtoObject = $"{model}Dto".FirstCharToLowerCase();

            StringBuilder sourceBuilder = new StringBuilder(@"");
            
            sourceBuilder.AppendFormat(@"
using Shakat.Shared.Models;

namespace Shakat.UI.Services.Contracts
{0}
    public interface I{2}Service
    {0}
        Task<IEnumerable<{2}Dto>> GetAll();

        Task<{2}Dto> GetById(int id);
        Task<{2}Dto> Create({2}Dto {3});
        Task<{2}Dto> Update({2}Dto {3});
        Task<{2}Dto> Delete(int id);
    {1}
{1}
 ", "{", "}", model, dtoObject);

            return sourceBuilder;
        }
    }
}
