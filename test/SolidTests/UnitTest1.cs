using System;
using System.IO;
using SolidLib;
using SolidConsole;

namespace SolidTests
{
    [TestClass]
    public class ReportTests
    {
        [TestMethod]
        public void Generate_ReturnsPdfReport()
        {
            var generator = new ReportGenerator();
            var report = generator.Generate(1);
            Assert.AreEqual("PDF Report", report);
        }

        [TestMethod]
        public void Main_WritesCompletionMessage()
        {
            using var sw = new StringWriter();
            Console.SetOut(sw);

            Program.Main(Array.Empty<string>());

            var output = sw.ToString();
            StringAssert.Contains(output, "Report generated");
        }
    }
}
