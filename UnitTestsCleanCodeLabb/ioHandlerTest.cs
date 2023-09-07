using CleanCodeLabb.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestsCleanCodeLabb
{
    [TestClass]
    public class ioHandlerTest
    {
        [TestInitialize]
        public void CreateIoHandlerAndSetFileStrategy()
        {
            ioHandler handler = new ioHandler(new FileService());
        }
    }
}
