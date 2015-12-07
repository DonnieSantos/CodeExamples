using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sorting;

namespace SortingTests
{
    [TestClass]
    public class NodeTests
    {
        private Node N1;
        private Node N2;
        private Node N3;
        private Node N4;
        private Node N5;
        
        [TestInitialize]
        public void Init()
        {
            N1 = new Node(5);
            N2 = new Node(4);
            N3 = new Node(2);
            N4 = new Node(3);
            N5 = new Node(1);

            N1.Next = N2;
            N2.Next = N3;
            N3.Next = N4;
            N4.Next = N5;
            N5.Next = null;
        }

        [TestMethod]
        public void TestBubbleSort()
        {
            Node head = N1;
            head = head.BubbleSort();

            Assert.AreEqual(1, head.Val);
            Assert.AreEqual(2, head.Next.Val);
            Assert.AreEqual(3, head.Next.Next.Val);
            Assert.AreEqual(4, head.Next.Next.Next.Val);
            Assert.AreEqual(5, head.Next.Next.Next.Next.Val);
        }

        [TestMethod]
        public void TestMergeSort()
        {
            //Node head = N1;
            //head = head.MergeSort();

            //Assert.AreEqual(1, head.Val);
            //Assert.AreEqual(2, head.Next.Val);
            //Assert.AreEqual(3, head.Next.Next.Val);
            //Assert.AreEqual(4, head.Next.Next.Next.Val);
            //Assert.AreEqual(5, head.Next.Next.Next.Next.Val);
        }
    }
}