using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace organization_test
{
    class PrintDetails
    {

        public static void PrOrganization(string filePath)
        {
            Organization org;
            Serializer Sr = new Serializer();
            org = Sr.DeserializeXml(typeof(Organization), filePath) as Organization;
            var NameTitleOrg = org.Employee.Select(p => p).ToList();
            var NameTitle = org.Units.Select(p => p).ToList();
            foreach (var orgemp in NameTitleOrg)
            {
                Console.WriteLine(" * Name: {0}, Title: {1}, Organization: {2}\n", orgemp.valueField, orgemp.titleField, org.nameField);

            }
            foreach (var units in NameTitle)
            {
                foreach (var emp in units.employeeField)
                {
                    Console.WriteLine(" * Name: {0}, Title: {1}, Unit: {2}\n", emp.valueField, emp.titleField, units.nameField);

                    if (units.unitsField != null)
                    {
                        foreach (var unit in units.unitsField)
                        {
                            foreach (var uemp in unit.employeeField)
                            {
                                Console.WriteLine(" * Name: {0}, Title: {1}, Unit: {2}\n", uemp.valueField, uemp.titleField, unit.nameField);
                            }

                            if (unit.unitsField != null)
                            {
                                foreach (var sunit in unit.unitsField)
                                {
                                    foreach (var suemp in sunit.employeeField)
                                    {
                                        Console.WriteLine(" * Name: {0}, Title: {1}, Unit: {2}\n", suemp.valueField, suemp.titleField, sunit.nameField);
                                    }
                                }
                                }
                            }
                    }
                   
                }
                
            }
        }
    }
}
