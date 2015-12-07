using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using XML.Properties;

namespace test
{
    [TestFixture]
    public class Class1
    {
        XML.demo a = new XML.demo();
        
        [Test]
        public void TestMethodA()
        {
            
            Assert.AreEqual(3, a.cong(1,2));
        }
    }
}
