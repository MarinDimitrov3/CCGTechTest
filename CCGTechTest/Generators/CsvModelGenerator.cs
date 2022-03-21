using CCGTechTest.Interfaces;
using CCGTechTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Generators
{
    public class CsvModelGenerator
    {
        private readonly ILinesReader _linesReader;

        public CsvModelGenerator(ILinesReader linesReader)
        {
            _linesReader = linesReader;
        }
        public CsvModel GenerateCSVModel()
        {
            var lines = _linesReader.GetLines();
            return GenerateCsvModelFromLines(lines);
        }

        private CsvModel GenerateCsvModelFromLines(string[] lines)
        {
            var csv = new List<string[]>();
            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');
            var nestedListObject = new List<IDictionary<string, dynamic>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var rowObject = GetNestedCsvObject(csv[i], properties);
                nestedListObject.Add(rowObject);
            }

            return new CsvModel(properties, nestedListObject);

        }

        private IDictionary<string,dynamic> GetNestedCsvObject(string[] line, string[] properties)
        {
            var nestedProperties = properties.Select(x => x.Split('_')).ToArray();
            var rowObject = new ExpandoObject() as IDictionary<string, dynamic>;
            for (int j = 0; j < properties.Length; j++)
            {
                var nestedObj = rowObject;
                for (int k = 0; k < nestedProperties[j].Length; k++)
                {
                    if (k == nestedProperties[j].Length - 1)
                    {
                        nestedObj.Add(nestedProperties[j][k], line[j]);
                    }
                    else
                    {
                        var newObj = new Dictionary<string, dynamic>();
                        if (!nestedObj.ContainsKey(nestedProperties[j][k]))
                        {
                            nestedObj.Add(nestedProperties[j][k], newObj);
                        }
                        nestedObj = nestedObj[nestedProperties[j][k]] as IDictionary<string, dynamic>;
                    }
                }
            }
            return rowObject;
        }
    }
}
