using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakat.UIConsoleApp.Interface
{
    public interface ITemplate
    {
        StringBuilder GetTemplate(string dto, string service = "", string serviceUrl = "", string primaryKey = "");
    }
}
