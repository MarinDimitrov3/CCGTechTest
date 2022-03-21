using CCGTechTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Generators
{
    public class XmlModelGenerator
    {
        public XmlModel GenerateXmlFromCSVModel(CsvModel csvModel)
        {
            return new XmlModel(csvModel.Object);
        }

        public XmlModel GenerateXmlFromJson(JsonModel jsonModel)
        {
            return new XmlModel(jsonModel.Object);
        }
    }
}
