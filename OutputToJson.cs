using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace organization_test
{
    class OutputToJson
    {
        public static void SerializeToJson(string filePathXml, string filePathJson)
        {
            Organization org;
            Serializer Sr = new Serializer();

            
            org = Sr.DeserializeXml(typeof(Organization), filePathXml) as Organization;
            var NameTitleOrg = org.Employee.Select(p => p).ToList();
            var NameTitle = org.Units.Select(p => p).ToList();
            foreach (var orgemp in NameTitleOrg)
            {
                 org.nameField = "Platform Team";

            }
            foreach (var units in NameTitle)
            {
                foreach (var emp in units.employeeField)
                {
                    units.nameField = "Platform Team";

                    if (units.unitsField != null)
                    {
                        foreach (var unit in units.unitsField)
                        {
                            foreach (var uemp in unit.employeeField)
                            {
                                unit.nameField = "Maintenance Team";
                            }

                            if (unit.unitsField != null)
                            {
                                foreach (var sunit in unit.unitsField)
                                {
                                    foreach (var suemp in sunit.employeeField)
                                    {
                                         sunit.nameField = "Maintenance Team";
                                    }
                                }
                            }
                        }
                    }

                }

            }


            Sr.SerializeToJson(org, filePathJson);
        }
    }
}
