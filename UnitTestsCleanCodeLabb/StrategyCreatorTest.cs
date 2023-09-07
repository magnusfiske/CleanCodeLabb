using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanCodeLabb;
using CleanCodeLabb.Interfaces;
using CleanCodeLabb.GameLogic;
using CleanCodeLabb.IO;

namespace UnitTestsCleanCodeLabb
{
    [TestClass]
    public class StrategyCreatorTest
    {
        [TestMethod]
        public void TestGameStrategyFactory()
        {
            List<IGuessingGameStrategy> actual = StrategyCreator.CreateGameStrategies();

            Assert.AreEqual(2, actual.Count);
            Assert.IsInstanceOfType(actual[0], typeof(MasterMindStrategy));
            Assert.IsInstanceOfType(actual[1], typeof(MooGameStrategy));
        }

        [TestMethod]
        public void TestIoStrategyFactory() 
        {
            List<IIoService> actual = StrategyCreator.CreateIoStrategies();

            Assert.AreEqual(2, actual.Count);
            Assert.IsInstanceOfType(actual[0], typeof(FileService));
            Assert.IsInstanceOfType(actual[1], typeof(MongoDAO));
        }
    }
}
