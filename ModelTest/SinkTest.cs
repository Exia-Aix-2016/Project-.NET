using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
namespace ModelTest
{
    [TestClass]
    public class SinkTest
    {
        [TestMethod]
        public void TestSink()
        {
            /*Model.Sink sink = new Model.Sink(5);

            sink.AddItem(new Model.WasheableTool(Model.ToolsType.Cutlery, Model.WashRequirement.Sink, Model.CleaningStatus.DIRTY));
            sink.AddItem(new Model.WasheableTool(Model.ToolsType.Cutlery, Model.WashRequirement.Sink, Model.CleaningStatus.DIRTY));

            Assert.AreEqual(2, sink.Size, "Number of item in Sink doesn't match (2)");
   
            List<Model.WasheableTool> washeableTools = sink.WashingTools();

            Assert.AreEqual(2, washeableTools.Count, "Number of washeableTools return by washingTools method doesn't match (2)");

            if (!washeableTools.TrueForAll(item => item.CleaningStatus == Model.CleaningStatus.CLEAN))
            {
                Assert.Fail("Items aren't Rinsed");
            }*/
        }
    }
}
