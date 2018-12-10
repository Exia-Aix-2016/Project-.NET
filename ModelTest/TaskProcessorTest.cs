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
    }
}
