using CCGTechTest.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCGTechTest.Helpers
{
    public class CsvLinesReaderFromFile : ILinesReader
    {
        public readonly string FileName;

        public CsvLinesReaderFromFile(string filename)
        {
            FileName = filename;
        }

        public IList<string[]> GetLines()
        {
            var csv = new List<string[]>();
            var lines = File.ReadAllLines(FileName);
            foreach (string line in lines)
                csv.Add(line.Split(','));
            return csv;
        }
    }
}
