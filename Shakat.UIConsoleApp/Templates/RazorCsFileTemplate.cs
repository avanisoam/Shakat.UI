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
        public StringBuilder GetTemplate(string model)
        {
            string dtoObject = $"{model}Dto".FirstCharToLowerCase();
            
            StringBuilder sourceBuilder = new StringBuilder(@"");

            sourceBuilder.AppendFormat(@"
using Microsoft.AspNetCore.Components;
using Shakat.Shared.Models;
using Shakat.UI.Services.Contracts;

namespace Shakat.UI.Pages.Admin
{0}
    public partial class {2}
    {0}
        [Inject]
        public I{2}Service {2}Service {0} get; set; {1}

        [Inject]
        NavigationManager MyNavigationManager {0} get; set; {1}

        public IEnumerable<{2}Dto> {3}s {0} get; set; {1} = new List<{2}Dto>();

        public {2}Dto? editItem {0} get; set; {1}

        public {2}Dto new{2}Object {0} get; set; {1} = new();

        protected override async Task OnInitializedAsync()
        {0}
            {3}s = await {2}Service.GetAll();
        {1}

        public async Task AddItem()
        {0}
            await {2}Service.Create(new{2}Object);

            new{2}Object = new();

            {3}s = await {2}Service.GetAll();

            MyNavigationManager.NavigateTo(""admin/{3}"");
        {1}

        public async Task UpdateItem()
        {0}
            if (editItem is not null)
            {0}
                await {2}Service.Update(editItem);
            {1}

            {3}s = await {2}Service.GetAll();

            MyNavigationManager.NavigateTo(""admin/{3}"");

        {1}

        public async Task DeleteItem(int id)
        {0}
            await {2}Service.Delete(id);

            {3}s = await {2}Service.GetAll();

            MyNavigationManager.NavigateTo(""admin/{3}"");
        {1}

    {1}
{1}

", "{", "}", model, dtoObject);

            return sourceBuilder;
        }
    }
}
