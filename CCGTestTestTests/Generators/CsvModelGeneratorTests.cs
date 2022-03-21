using CCGTechTest.Generators;
using CCGTechTest.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.IO;
using System.Linq;

namespace CCGTestTestTests.Generators
{
    [TestClass]
    public class CsvModelGeneratorTests
    {
        private Mock<ILinesReader> _mockLinesReader;

        private string[] CsvModelFile()
        {
            var csv = new string[3];
            csv[0] = "person_name_firstName,person_name_lastName,address_city,address_postCode,address_line1,address_line2";
            csv[1] = "Marin,Dimitrov,Nottingham,NG7 5QJ,293a,Radford Boulevard";
            csv[2] = "Stefan,Coates,Manchester,M14AX,117,Oxford Street";

            return csv;
        }
        public CsvModelGeneratorTests()
        {
            _mockLinesReader = new Mock<ILinesReader>();
            _mockLinesReader.Setup(x => x.GetLines()).Returns(CsvModelFile());
        }

        [TestMethod]
        public void GenerateCSVModelTests()
        {
            var csvModelGenerator = new CsvModelGenerator(_mockLinesReader.Object);

            var csvModel = csvModelGenerator.GenerateCSVModel();
            var csvModelObject = csvModel.Object.ToList();

            Assert.IsNotNull(csvModel);
            Assert.AreEqual(csvModelObject.Count, 2);
            Assert.AreEqual(csvModelObject[0].Count, 2);
            Assert.AreEqual(csvModelObject[0]["person"]["name"]["firstName"], "Marin");
            Assert.AreEqual(csvModelObject[1]["person"]["name"]["lastName"], "Coates");
            Assert.AreEqual(csvModelObject[0]["address"]["postCode"], "NG7 5QJ");
            Assert.AreEqual(csvModelObject[1]["address"]["line2"], "Oxford Street");

        }
    }
}