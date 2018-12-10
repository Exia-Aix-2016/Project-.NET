using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Collections.Generic;
namespace ModelTest
{
    [TestClass]
    public class TaskProcessorTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }

        [TestMethod]
        public void TestProcess()
        {
            Model.TaskProcessor  taskProcessor = new Model.TaskProcessor();

            bool task1executed = false, task2executed = false;

           

            Model.Task task = new Model.Task(null, 10, (Void) =>
            {
                task1executed = true;
            });

            Model.Task task2 = new Model.Task(null, 20, (Void) =>
            {
                task2executed = true;
            });
           

            taskProcessor.AddTask(task);
            taskProcessor.AddTask(task2);

            Assert.AreEqual(2, taskProcessor.Size, "not equal");

            Assert.IsNotNull(taskProcessor.CurrentTask, "is null");

            
            for (int i = 0; i < 32; i++) taskProcessor.Process();
            

            Assert.AreEqual(0, taskProcessor.Size, "not equal");

            Assert.AreEqual(0, task.TickRemaining, "Task");
            Assert.AreEqual(0, task2.TickRemaining, "Task2");

            Assert.IsTrue(task1executed);
            Assert.IsTrue(task2executed);



        }
        [TestMethod]
        public void TestSink()
        {
            Model.Sink sink = new Model.Sink(5);

            sink.AddItem(new Model.WasheableTool(Model.ToolsType.Cutlery, Model.WashRequirement.Sink, Model.CleaningStatus.DIRTY));
            sink.AddItem(new Model.WasheableTool(Model.ToolsType.Cutlery, Model.WashRequirement.Sink,  Model.CleaningStatus.DIRTY));

            Assert.AreEqual(2, sink.Size, "Number of item in Sink doesn't match (2)");

            List<Model.WasheableTool> washeableTools = sink.WashingTools();

            Assert.AreEqual(2, washeableTools.Count, "Number of washeableTools return by washingTools method doesn't match (2)");

            if(!washeableTools.TrueForAll(item => item.CleaningStatus == Model.CleaningStatus.CLEAN))
            {
                Assert.Fail("Items aren't Rinsed");
            }
        }
    }
}
