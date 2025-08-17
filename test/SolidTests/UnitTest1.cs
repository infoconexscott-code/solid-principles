using SolidLib;

namespace SolidTests
{
    [TestClass]
    public class ReportGeneratorUnitTests
    {
        [TestMethod]
        [TestCategory("Unit")]
        public void Generate_ReturnsPdfReport()
        {
            var generator = new ReportGenerator();
            var report = generator.Generate(1);
            Assert.AreEqual("PDF Report", report);
        }
        
        [TestMethod]
        [TestCategory("Unit")]
        public void Exporter_ReturnsPrefixedReport()
        {
            var exporter = new ReportExporter();
            var result = exporter.Export(1, "PDF Report");
            Assert.AreEqual("PDF:PDF Report", result);
        }
    }
}
