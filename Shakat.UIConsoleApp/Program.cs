using Shakat.UIConsoleApp.Templates;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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

            string dtoFullPath = @"E:\2022\Shakat\Shakat.Shared\Shakat.Shared\bin\Debug\netstandard2.1\Shakat.Shared.dll";
            Assembly MyDALL = Assembly.LoadFrom(dtoFullPath);
            Type MyLoadClass = MyDALL.GetTypes().FirstOrDefault(t => t.Name == args[2]);
            object obj = Activator.CreateInstance(MyLoadClass);

            Dictionary<string, string> dict = new Dictionary<string, string>();

            foreach (var prop in obj.GetType().GetProperties())
            {
                Console.WriteLine("Name: {0} Type: {1} Value: {2}",
                    prop.Name, prop.PropertyType.Name, prop.GetValue(obj, null));

                dict.Add(prop.Name, prop.PropertyType.Name);
            }

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
                /*
                
                // https://stackoverflow.com/questions/57905333/how-to-get-class-type-from-cs-file-and-instantiate-it
                var a = Assembly.GetExecutingAssembly()
                    .GetTypes().Where(t => t.BaseType == typeof(InterfaceServiceTemplate));
                
                // https://learn.microsoft.com/en-us/dotnet/api/system.reflection.assembly.load?view=net-7.0
                string longName = "system, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
                Assembly assem = Assembly.Load(longName);
                if (assem == null)
                    Console.WriteLine("Unable to load assembly...");
                else
                    Console.WriteLine(assem.FullName);

                Assembly SampleAssembly;
                //SampleAssembly = Assembly.LoadFrom(@"E:\2022\Shakat\Shakat.Shared\Shakat.Shared\bin\Debug\netstandard2.1\Shakat.Shared.dll");
                SampleAssembly = Assembly.LoadFrom(@"Shakat.UIConsoleApp.dll");
                // Obtain a reference to a method known to exist in assembly.
                MethodInfo Method = SampleAssembly.GetTypes()[3].GetMethod("Main");
                // Obtain a reference to the parameters collection of the MethodInfo instance.
                ParameterInfo[] Params = Method.GetParameters();
                // Display information about method parameters.
                // Param = sParam1
                //   Type = System.String
                //   Position = 0
                //   Optional=False
                foreach (ParameterInfo Param in Params)
                {
                    Console.WriteLine("Param=" + Param.Name.ToString());
                    Console.WriteLine("  Type=" + Param.ParameterType.ToString());
                    Console.WriteLine("  Position=" + Param.Position.ToString());
                    Console.WriteLine("  Optional=" + Param.IsOptional.ToString());
                }

                Assembly MyDALL = Assembly.LoadFrom(@"E:\2022\Shakat\Shakat.Shared\Shakat.Shared\bin\Debug\netstandard2.1\Shakat.Shared.dll"); // DALL is name of my dll
                string name = model + "Dto";
                Type[] test = MyDALL.GetTypes();
                var test1 = test.FirstOrDefault(t => t.Name == name);
                Type MyLoadClass = MyDALL.GetType(name); // LoadClass is my class
                object obj = Activator.CreateInstance(test1);

                //Foo foo = new Foo { A = 1, B = "abc" };
                foreach (var prop in obj.GetType().GetProperties())
                {
                    Console.WriteLine("Name: {0} Type: {1} Value: {2}", 
                        prop.Name, prop.PropertyType.Name, prop.GetValue(obj, null));
                }

                */                

                CreateRazorPage(model, args[3], dict);
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
                CreateRazorPage(model, args[3], dict);
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

        private static void CreateRazorPage(string model, string uiRoot, Dictionary<string, string> keyValuePairs)
        {
            try
            {
                RazorComponentTemplate template = new RazorComponentTemplate();

                StringBuilder response = template.GetTemplate(model, keyValuePairs);

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
