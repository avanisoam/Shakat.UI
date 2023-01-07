using Shakat.UIConsoleApp.Templates;
using System;
using System.IO;
using System.Text;

namespace Shakat.UIConsoleApp
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Invalid Input... Please try  again");
                return -1;
            }

            Console.WriteLine("Project Name: {0}", args[0]);
            Console.WriteLine("Shared Root: {0}", args[1]);
            Console.WriteLine("DTO Name: {0}", args[2]);
            Console.WriteLine("UI Root: {0}", args[3]);
            //Console.WriteLine("Service Name: {0}", args[4]);
            //Console.WriteLine("Service URL: {0}", args[5]);
            //Console.WriteLine("Primary Key: {0}", args[6]);

            var model = args[2].Trim();
            model = model.Substring(0, model.Length-3);

            Console.WriteLine($"Derived Model From Dto: {model}");

            //var url = $"https://localhost:44395/api/{model}";

            //var primaryKey = $"{model}Id";

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("1 : CreateInterfaceService");
            Console.WriteLine("2 : CreateService");
            Console.WriteLine("3 : CreateRazorPage");
            Console.WriteLine("4 : CreateRazorCsFile");
            Console.WriteLine("5 : RegisterInProgram");
            Console.WriteLine("6 : CreateUI");

            String s = Console.ReadLine();

            if (s == "1")
            {
                CreateInterfaceService(model, args[3]);
            }
            else if (s == "2")
            {
                CreateService(model,args[3]);
            }
            else if (s == "3")
            {
                CreateRazorPage(model, args[3]);
            }
            else if (s == "4")
            {
                CreateRazorCsFile(model, args[3]);
            }
            else if (s == "5")
            {
                RegisterInProgram(model, args[3]);
            }
            else if (s == "6")
            {
                CreateInterfaceService(model, args[3]);
                CreateService(model, args[3]);
                RegisterInProgram(model, args[3]);
                CreateRazorPage(model, args[3]);
                CreateRazorCsFile(model, args[3]);
            }

            return 1;
        }

        private static void CreateInterfaceService(string model, string uiRoot)
        {
            try
            {
                InterfaceServiceTemplate template = new InterfaceServiceTemplate();

                StringBuilder response = template.GetTemplate(model);

                Console.WriteLine(response);

                StreamWriter sw = new StreamWriter($"{uiRoot}/Services/Contracts/I{model}Service.cs");

                sw.Write(response);

                sw.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static void CreateService(string model, string uiRoot)
        {
            try
            {
                ServiceTemplate template = new ServiceTemplate();

                StringBuilder response = template.GetTemplate(model);

                Console.WriteLine(response);

                StreamWriter sw = new StreamWriter($"{uiRoot}/Services/{model}Service.cs");

                sw.Write(response);

                sw.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static void CreateRazorPage(string model, string uiRoot)
        {
            try
            {
                RazorComponentTemplate template = new RazorComponentTemplate();

                StringBuilder response = template.GetTemplate(model);

                Console.WriteLine(response);

                StreamWriter sw = new StreamWriter($"{uiRoot}/Pages/Admin/{model}.razor");

                sw.Write(response);

                sw.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static void CreateRazorCsFile(string model, string uiRoot)
        {
            try
            {
                RazorCsFileTemplate template = new RazorCsFileTemplate();

                StringBuilder response = template.GetTemplate(model);

                Console.WriteLine(response);

                StreamWriter sw = new StreamWriter($"{uiRoot}/Pages/Admin/{model}.razor.cs");

                sw.Write(response);

                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static void RegisterInProgram(string model, string uiRoot)
        {
            string text = File.ReadAllText($"{uiRoot}/Program.cs");
            text = text.Replace("#endregion DI End", $"builder.Services.AddScoped<I{model}Service, {model}Service>();{Environment.NewLine}#endregion DI End");
            File.WriteAllText($"{uiRoot}/Program.cs", text);
        }

        public static string? FirstCharToLowerCase(this string? str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

            return str;
        }
    }
}
