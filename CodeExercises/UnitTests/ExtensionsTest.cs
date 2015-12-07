using Exercise2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass()]
    public class ExtensionsTest
    {
        [TestMethod()]
        public void DefaultTest()
        {
            string output = "The crazy fox ran over the bridge.".ReverseWords();
            string expected = ".bridge the over ran fox crazy The";
            Assert.AreEqual(expected, output);
        }

        [TestMethod()]
        public void TestRetainPunctuationMarks()
        {
            string output = "One two,three!four?five.".ReverseWords();
            string expected = ".five?four!three,two One";
            Assert.AreEqual(expected, output);
        }
    }
}