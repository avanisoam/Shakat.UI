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
        public StringBuilder GetTemplate(string model, Dictionary<string, Dictionary<string, string>> keyValuePairs)
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
            
            ", "{", "}", model, dtoObject);

            // add the filepath of each tree to the class we're building
            foreach (var props in keyValuePairs)
            {
                sourceBuilder.AppendFormat(@"
            <dt class = ""col-sm-2"">
               {6} - {5}
            </dt>
            <dd class = ""col-sm-12"">
                <div class=""form-group"">
                    <input @bind=""new{2}Object.{4}"" />
                    <span asp-validation-for=""Name"" class=""text-danger""></span>
                </div>
            </dd>
", "{", "}", model, dtoObject, props.Key, props.Value.First().Key, props.Value.First().Value);

                //sourceBuilder.AppendLine($@"Console.WriteLine(@""{props.Key} - {props.Value}"");");
            }

            sourceBuilder.AppendFormat(@"
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
", "{", "}", model, dtoObject);

            foreach (var props in keyValuePairs)
            {
                sourceBuilder.AppendFormat(@"
            <dt class = ""col-sm-2"">
               {6}
            </dt>
            <dd class = ""col-sm-12"">
                 <div class=""form-group"">
                    <input @bind=""editItem.{4}"" />
                    <span asp-validation-for=""Name"" class=""text-danger""></span>
                </div>
            </dd>
", "{", "}", model, dtoObject, props.Key, props.Value.First().Key, props.Value.First().Value);

            }

            sourceBuilder.AppendFormat(@"
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
", "{", "}", model, dtoObject);

            foreach (var props in keyValuePairs)
            {
                sourceBuilder.AppendFormat(@"
            <dt class = ""col-sm-2"">
               {6}
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.{4}
            </dd>
", "{", "}", model, dtoObject, props.Key, props.Value.First().Key, props.Value.First().Value);

            }

            sourceBuilder.AppendFormat(@"
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
", "{", "}", model, dtoObject);

            foreach (var props in keyValuePairs)
            {
                sourceBuilder.AppendFormat(@"
            <dt class = ""col-sm-2"">
               {6}
            </dt>
            <dd class = ""col-sm-10"">
                @editItem.{4}
            </dd>
", "{", "}", model, dtoObject, props.Key, props.Value.First().Key, props.Value.First().Value);

            }

            sourceBuilder.AppendFormat(@"
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
", "{", "}", model, dtoObject);

            foreach (var props in keyValuePairs)
            {
                sourceBuilder.AppendFormat(@"
                <th>{6}</th>
", "{", "}", model, dtoObject, props.Key, props.Value.First().Key, props.Value.First().Value);

            }

            sourceBuilder.AppendFormat(@"
                <th></th>
            </tr>
        </thead>
        <tbody>
            @foreach (var item in {3}s)
            {0}
                <tr>
", "{", "}", model, dtoObject);

            foreach (var props in keyValuePairs)
            {
                sourceBuilder.AppendFormat(@"
                    <td>@item.{4}</td>
", "{", "}", model, dtoObject, props.Key, props.Value.First().Key, props.Value.First().Value);

            }

            sourceBuilder.AppendFormat(@"
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
