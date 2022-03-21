using CCGTechTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Generators
{
    public class JsonModelGenerator
    {
        public JsonModel GenerateJsonFromCSVModel(CsvModel csvModel)
        {
            return new JsonModel(csvModel.Object);
        }

        public JsonModel GenerateJsonFromXmlModel(XmlModel xmlModel)
        {
            return new JsonModel(xmlModel.Object);
        }
    }
}
