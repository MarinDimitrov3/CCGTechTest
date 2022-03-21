using CCGTechTest.Generators;
using CCGTechTest.Helpers;
using CCGTechTest.Interfaces;

Console.WriteLine("Enter file path: ");
var filePath = Console.ReadLine();
ILinesReader linesReader = new CsvLinesReaderFromFile(filePath);

var csvModelGen = new CsvModelGenerator(linesReader);
var model = csvModelGen.GenerateCSVModel();

var jModel = new JsonModelGenerator().GenerateJsonFromCSVModel(model);
var xModel = new XmlModelGenerator().GenerateXmlFromCSVModel(model);

Console.WriteLine(jModel.JsonString);
Console.WriteLine();
Console.WriteLine(xModel.XmlString);

