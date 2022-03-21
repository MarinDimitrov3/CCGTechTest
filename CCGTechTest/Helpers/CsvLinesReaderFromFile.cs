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
        public string[] GetLines()
        {
            return File.ReadAllLines(FileName);
        }
    }
}
