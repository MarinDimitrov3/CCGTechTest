using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Models
{
    public class CsvModel : Model
    {
        public IEnumerable<string> Columns  { get;}
        public CsvModel(IEnumerable<string> columns, IEnumerable<IDictionary<string, dynamic>> rows)
        {
            Columns = columns;
            Object = rows;
        }
    }
}
