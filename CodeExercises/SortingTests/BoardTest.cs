using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tron;

namespace SortingTests
{
    [TestClass()]
    public class BoardTest
    {
        [TestMethod()]
        public void GetLongestPathTest1()
        {
            var mazeDef = new int[12, 12]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,1,1,1,1,0,0,0,0,0,0,0 },
                { 0,1,0,1,0,0,0,1,1,1,1,0 },
                { 0,1,0,0,0,0,0,0,0,0,1,0 },
                { 0,1,1,0,0,0,0,0,0,0,1,0 },
                { 0,1,1,1,1,1,1,1,1,1,1,0 },
                { 0,1,1,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,1,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,1,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,1,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,1,1,1,1,1,0 },
                { 0,0,0,0,0,0,0,0,0,0,1,0 }
            };

            Board board = new Board(mazeDef);
            int result = board.GetLongestPath(1, 1, 2, 7);
            Assert.AreEqual(19, result);
        }

        [TestMethod()]
        public void GetLongestPathTest2()
        {
            var mazeDef = new int[12, 12]
            {
                { 0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,1,1,1,1,0,0,0,0,0,0,0 },
                { 0,1,0,1,0,0,0,1,1,1,1,0 },
                { 0,1,0,0,0,0,0,0,0,0,1,0 },
                { 0,1,1,0,0,0,0,0,0,0,1,0 },
                { 0,1,1,1,1,1,1,1,1,1,1,0 },
                { 0,1,1,0,0,0,0,0,0,0,0,0 },
                { 0,0,1,1,0,0,0,0,0,0,0,1 },
                { 0,0,0,1,1,0,0,0,0,0,0,1 },
                { 0,0,0,0,1,1,0,0,0,0,0,1 },
                { 0,0,0,0,0,1,1,1,1,1,1,1 },
                { 0,0,0,0,0,0,0,0,0,1,1,1 }
            };

            Board board = new Board(mazeDef);
            int result = board.GetLongestPath(1, 1, 7, 10);
            Assert.AreEqual(24, result);
        }
    }
}