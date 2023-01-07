using Shakat.UIConsoleApp.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakat.UIConsoleApp.Templates
{
    public class RazorComponentTemplate : ITemplate
    {
        public StringBuilder GetTemplate(string model)
        {
            string dtoObject = $"{model}Dto".FirstCharToLowerCase();

            StringBuilder sourceBuilder = new StringBuilder(@"");

            sourceBuilder.AppendFormat(@"
@page ""/admin/{2}/{0}Action?{1}/{0}Id:int?{1}""

<h3>Admin - {2}</h3>

@if (Id > 0)
{0}
   editItem = {3}s.Single(i => i.{2}Id == Id);
{1}

@if ({3}s == null)
{0}
    <p><em>Loading...</em></p>
{1}

else if (Action == ""Create"")
{0}
    <h1>Create</h1>
    <hr />

   <div>
        <dl class=""row"">
            
            <dt class = ""col-sm-2"">
               Vehicle Origin
            </dt>
            <dd class = ""col-sm-12"">
                <div class=""form-group"">
                    <input @bind=""new{2}Object.Origin"" />
                    <span asp-validation-for=""Name"" class=""text-danger""></span>
                </div>
            </dd>
            <dt class = ""col-sm-2"">
               Vehicle Type Id
            </dt>
            <dd class = ""col-sm-12"">
                <div class=""form-group"">
                    <input @bind=""new{2}Object.{2}Id"" />
                    <span asp-validation-for=""Name"" class=""text-danger""></span>
                </div>
            </dd>
            
        </dl>
        <button class=""btn btn-success"" @onclick=""AddItem"">Add</button>
    </div>

    <br />
     <div>
            <NavLink href=""admin/{2}"">Back to List</NavLink>
    </div>
{1}

else if (Action == ""Edit"")
{0}
    <h1>Edit</h1>
    <hr />

    <div>
        <dl class=""row"">
            <dt class = ""col-sm-2"">
                Id
            </dt>
            <dd class = ""col-sm-12"">
                @editItem.{2}Id
            </dd>
            <dt class = ""col-sm-2"">
               Vehicle Origin
            </dt>
            <dd class = ""col-sm-12"">
                <div class=""form-group"">
                    <input @bind=""editItem.Origin"" />
                    <span asp-validation-for=""Name"" class=""text-danger""></span>
                </div>
            </dd>
             <dt class = ""col-sm-2"">
               Vehicle Type Id
            </dt>
            <dd class = ""col-sm-12"">
                 <div class=""form-group"">
                    <input @bind=""editItem.{2}Id"" />
                    <span asp-validation-for=""Name"" class=""text-danger""></span>
                </div>
            </dd>
         </dl>
        <div class=""form-group"">
            <button class=""btn btn-primary"" @onclick=""UpdateItem"">
                Save
            </button>
        </div>
    </div>

    <br />
     <div>
            <NavLink href=""admin/{2}"">Back to List</NavLink>
    </div>
{1}

else if (Action == ""Details"")
{0}
    <h1>Details</h1>
    <hr />
    <br />
    <div>
         <dl class=""row"">
            <dt class = ""col-sm-2"">
                Id
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.{2}Id
            </dd>
            <dt class = ""col-sm-2"">
               Vehicle Origin
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.Origin
            </dd>
             <dt class = ""col-sm-2"">
               Vehicle Type Id
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.{2}Id
            </dd>
        </dl>
    </div>
     <div>
            <NavLink href=""admin/{2}"">Back to List</NavLink>
    </div>
{1}

else if (Action == ""Delete"")
{0}
    <h1>Delete</h1>
    <hr />

     <h3>Are you sure you want to delete this?</h3>

     <div>
         <hr />
          <dl class=""row"">
            <dt class = ""col-sm-2"">
                Id
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.{2}Id
            </dd>
            <dt class = ""col-sm-2"">
               Vehicle Sub Type
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.Origin
            </dd>
             <dt class = ""col-sm-2"">
               Vehicle Type Id
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.{2}Id
            </dd>
        </dl>
     </div>
    <div>
         <button class=""btn btn-danger"" 
          @onclick=""@(async () => await DeleteItem(editItem.{2}Id))"">
            Delete
          </button>
     </div>

    <br />
     <div>
            <NavLink href=""admin/{2}"">Back to List</NavLink>
    </div>
{1}

else
{0}
<p>
        <NavLink href=""admin/{2}/Create"">Create New</NavLink>
    </p>
    <table class=""table"">
        <thead>
            <tr>
                <th>Vehicle Id</th>
                <th>Vehicle Type</th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in {3}s)
            {0}
                <tr>
                    <td>@item.{2}Id</td>
                    <td>@item.Origin</td>
                    <td>
                        <NavLink href=""@($""admin/{2}/Edit/{0}item.{2}Id{1}"")"">Edit</NavLink> | 
                        <NavLink href=""@($""admin/{2}/Details/{0}item.{2}Id{1}"")"">Details</NavLink> | 
                        <NavLink href=""@($""admin/{2}/Delete/{0}item.{2}Id{1}"")"">Delete</NavLink>                        
                    </td>
                </tr>
            {1}
        </tbody>
    </table>
{1}
@code {0}
    [Parameter]
    public string? Action {0} get; set; {1}

    [Parameter]
    public int? Id {0} get; set; {1}
{1}", "{", "}", model, dtoObject);

            return sourceBuilder;
        }
    }
}
