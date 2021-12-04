using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FitnessAchievementForKids
{
    [TestClass]
    public class MemoryLoggerUnitTest
    {
        [TestMethod]
        public void Instantiate()
        {
            //Arrage
            var expectedType = typeof(ILogger);
            //Act
            MemoryLogger logger = new MemoryLogger();

            //Assert
            Assert.IsNotNull(logger);
            Assert.IsInstanceOfType(logger, expectedType);

        }

        [TestMethod]
        public async Task GetNoLogs()
        {
            //Arrange
            MemoryLogger logger = new MemoryLogger();
            Stopwatch stopWatch = new Stopwatch();
            int expectedCount = 0;
            double expectedDuration = 5; //sec

            //Act
            stopWatch.Start();
            IList<LogEntry> logs = await logger.GetAllLogs();
            stopWatch.Stop();

            //Assert
            Assert.IsTrue(expectedCount == logs.Count);
            Assert.IsTrue(stopWatch.Elapsed.TotalSeconds <= expectedDuration);

        }

        [TestMethod]
        public async Task LogValidEntry()
        {
            //Arrange
            MemoryLogger logger = new MemoryLogger();
            Stopwatch stopWatch = new Stopwatch();

            int expectedCount = 1;
            double expectedDuration = 5;
            string message = "Test Log";

            //Act
            stopWatch.Start();
            await logger.Log(LogLevel.Info, LogCategory.Server, "LogValidEntry" , message);
            stopWatch.Stop();

            IList<LogEntry> logs = await logger.GetAllLogs();

            //Assert
            Assert.IsTrue(expectedCount == logs.Count);
            Assert.IsTrue(logs[0].message == message);
            Assert.IsTrue(stopWatch.Elapsed.TotalSeconds <= expectedDuration);
        }
    }
}
