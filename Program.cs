using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Reflection;

namespace organization_test
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "organization xml.txt file Back end test.txt";
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.FullName;
            string filePathXml = Path.Combine(projectDirectory, fileName);
            string filePathJson = Path.Combine(projectDirectory, "organization.json");

            PrintDetails.PrOrganization(filePathXml);
            OutputToJson.SerializeToJson(filePathXml, filePathJson);

        }
    }
}
