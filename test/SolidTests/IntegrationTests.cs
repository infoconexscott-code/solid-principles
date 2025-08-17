using System.IO;
using SolidLib;

namespace SolidTests
{
    [TestClass]
    public class IntegrationTests
    {
        [TestMethod]
        [TestCategory("Integration")]
        public void SaveReport_CreatesFilesAndDatabase()
        {
            var generator = new ReportGenerator();
            var json = generator.GenerateJsonReport(1);
            generator.SaveReport(json);

            Assert.IsTrue(File.Exists("report.txt"));
            Assert.IsTrue(File.Exists("reports.db"));

            File.Delete("report.txt");
            File.Delete("reports.db");
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void Exporter_UsesGeneratorOutput()
        {
            var generator = new ReportGenerator();
            var exporter = new ReportExporter();
            var report = generator.Generate(1);
            var exported = exporter.Export(1, report);
            Assert.AreEqual("PDF:PDF Report", exported);
        }
    }
}
