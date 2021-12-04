using System;
using Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FitnessAchievementForKids
{
    [TestClass]
    public class LoggingManagerUnitTest
    {

        [TestMethod]
        public void SetLogger() 
        {
            //Arrange
            LoggingManager loggingManager = new LoggingManager();
            ILogger memoryLogger = new MemoryLogger();

            //Act
            loggingManager.logger = memoryLogger; 

            //Assert
            Assert.IsTrue(loggingManager.logger == memoryLogger);

        }
    }
}
