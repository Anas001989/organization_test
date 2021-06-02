using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace organization_test
{
    class Serializer
    {

        public object DeserializeXml(Type dataType, string filePath)
        {
            object obj = null;

            XmlSerializer xmlSerializer = new XmlSerializer(dataType);
            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();

            }
            else { Console.WriteLine("no file"); }

            return obj;
        }

        public void SerializeToJson(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath)) File.Delete(filePath);
            StreamWriter swr = new StreamWriter(filePath);
            JsonWriter jswr = new JsonTextWriter(swr);

            jsonSerializer.Serialize(jswr, data);
            jswr.Close();
            swr.Close();
        }
    }
}
