using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Models
{
    public class JsonModel : Model
    {
        public string JsonString { get { return JsonConvert.SerializeObject(Object); }}
        public JsonModel(IEnumerable<IDictionary<string, dynamic>> jsonObject)
        {
            Object = jsonObject;    
        }
    }
}
