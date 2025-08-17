using System;
using System.IO;
using SolidConsole;

namespace SolidTests
{
    [TestClass]
    public class EndToEndTests
    {
        [TestMethod]
        [TestCategory("EndToEnd")]
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
