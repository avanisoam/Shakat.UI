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
            if (args.Length < 5)
            {
                Console.WriteLine("Invalid Input... Please try  again");
                return -1;
            }

            Console.WriteLine("Project Name: {0}", args[0]);
            Console.WriteLine("Shared Root: {0}", args[1]);
            Console.WriteLine("DTO Name: {0}", args[2]);
            Console.WriteLine("UI Root: {0}", args[3]);
            Console.WriteLine("Service Name: {0}", args[4]);
            Console.WriteLine("Service URL: {0}", args[5]);
            Console.WriteLine("Primary Key: {0}", args[6]);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine("1 : CreateInterfaceService");
            Console.WriteLine("2 : CreateService");
            Console.WriteLine("3 : CreateRazorPage");
            Console.WriteLine("4 : CreateRazorCsFile");
            Console.WriteLine("5 : RegisterInProgram");
            Console.WriteLine("9 : CreateUI");

            String s = Console.ReadLine();

            if (s == "1")
            {
                CreateInterfaceService(args[2], args[3], args[4]);
            }
            else if (s == "2")
            {
                CreateService(args[2], args[3], args[4],args[5], args[6]);
            }

            return 1;
        }

        private static void CreateInterfaceService(string dto, string uiRoot, string service)
        {
            try
            {
                InterfaceServiceTemplate template = new InterfaceServiceTemplate();

                StringBuilder response = template.GetTemplate(dto, service);

                Console.WriteLine(response);

                StreamWriter sw = new StreamWriter($"{uiRoot}/Services/Contracts/I{service}.cs");

                sw.Write(response);

                sw.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }

        private static void CreateService(string dto, string uiRoot, string service, string serviceUrl, string primaryKey)
        {
            try
            {
                ServiceTemplate template = new ServiceTemplate();

                StringBuilder response = template.GetTemplate(dto, service, serviceUrl, primaryKey);

                Console.WriteLine(response);

                StreamWriter sw = new StreamWriter($"{uiRoot}/Services/{service}.cs");

                sw.Write(response);

                sw.Close();
            }
            catch (Exception e)
            {

                Console.WriteLine("Exception: " + e.Message);
            }
        }

            public static string? FirstCharToLowerCase(this string? str)
        {
            if (!string.IsNullOrEmpty(str) && char.IsUpper(str[0]))
                return str.Length == 1 ? char.ToLower(str[0]).ToString() : char.ToLower(str[0]) + str[1..];

            return str;
        }
    }
}
