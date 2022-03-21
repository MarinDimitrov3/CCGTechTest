using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Models
{
    public abstract class Model
    {
        public IEnumerable<IDictionary<string, dynamic>> Object { get; set; }
    }
}
