using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Models
{
    public class XmlModel : Model
    {
        public string XmlString { get { return JsonConvert.DeserializeXmlNode(JsonConvert.SerializeObject(XmlObject), "Root").OuterXml; } }
        public IDictionary<string, dynamic> XmlObject { get; }
        public XmlModel(IEnumerable<IDictionary<string, dynamic>> xmlObjectList)
        {
            XmlObject = new ExpandoObject();
            Object = xmlObjectList;
            XmlObject.Add("list", xmlObjectList);
        }
    }
}
