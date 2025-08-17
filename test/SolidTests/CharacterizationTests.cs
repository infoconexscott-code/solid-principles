using System;
using SolidLib;

namespace SolidTests
{
    [TestClass]
    public class CharacterizationTests
    {
        [TestMethod]
        [TestCategory("Characterization")]
        public void GenerateJsonReport_ReturnsMalformedJson()
        {
            var generator = new ReportGenerator();
            var json = generator.GenerateJsonReport(1);
            Assert.AreEqual("{ 'type': 'PDF', 'content': 'Report'", json);
        }

        [TestMethod]
        [TestCategory("Characterization")]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SmsNotification_LongMessage_Throws()
        {
            var notification = new SmsNotification();
            notification.Send("This message is definitely too long");
        }
    }
}
