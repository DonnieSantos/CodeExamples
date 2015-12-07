using MergeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MergeSortLinkedListTests
    {
        [TestMethod]
        public void SmallerTest()
        {
            Node node1 = new Node(10);
            Node node2 = new Node(20);
            Node smaller = Node.Smaller(node1, node2);
            Assert.AreEqual(10, smaller.Value);

            node1 = new Node(20);
            node2 = new Node(10);
            smaller = Node.Smaller(node1, node2);
            Assert.AreEqual(10, smaller.Value);

            node1 = null;
            node2 = new Node(10);
            smaller = Node.Smaller(node1, node2);
            Assert.AreEqual(10, smaller.Value);

            node1 = new Node(10);
            node2 = null;
            smaller = Node.Smaller(node1, node2);
            Assert.AreEqual(10, smaller.Value);
        }

        [TestMethod]
        public void NodeDivideEven()
        {
            Node N1 = new Node(1);
            Node N2 = new Node(2);
            Node N3 = new Node(3);
            Node N4 = new Node(4);
            Node N5 = new Node(5);
            Node N6 = new Node(6);

            N1.Next = N2;
            N2.Next = N3;
            N3.Next = N4;
            N4.Next = N5;
            N5.Next = N6;
            N6.Next = null;

            Node firstList = N1;
            Node secondList = N1.Divide();

            Assert.AreEqual(1, firstList.Value);
            Assert.AreEqual(2, firstList.Next.Value);
            Assert.AreEqual(3, firstList.Next.Next.Value);
            Assert.IsNull(firstList.Next.Next.Next);

            Assert.AreEqual(4, secondList.Value);
            Assert.AreEqual(5, secondList.Next.Value);
            Assert.AreEqual(6, secondList.Next.Next.Value);
            Assert.IsNull(secondList.Next.Next.Next);
        }

        [TestMethod]
        public void NodeDivideOdd()
        {
            Node N1 = new Node(1);
            Node N2 = new Node(2);
            Node N3 = new Node(3);
            Node N4 = new Node(4);
            Node N5 = new Node(5);

            N1.Next = N2;
            N2.Next = N3;
            N3.Next = N4;
            N4.Next = N5;
            N5.Next = null;

            Node firstList = N1;
            Node secondList = N1.Divide();

            Assert.AreEqual(1, firstList.Value);
            Assert.AreEqual(2, firstList.Get(1).Value);
            Assert.IsNull(firstList.Get(2));

            Assert.AreEqual(3, secondList.Value);
            Assert.AreEqual(4, secondList.Get(1).Value);
            Assert.AreEqual(5, secondList.Get(2).Value);
            Assert.IsNull(secondList.Get(3));
        }

        [TestMethod]
        public void NodeDivideTwo()
        {
            Node N1 = new Node(1);
            Node N2 = new Node(2);

            N1.Next = N2;
            N2.Next = null;

            Node firstList = N1;
            Node secondList = N1.Divide();

            Assert.AreEqual(1, firstList.Length);
            Assert.AreEqual(1, firstList.Value);
            Assert.AreEqual(2, secondList.Value);
            Assert.AreEqual(1, secondList.Length);

            Assert.IsNull(firstList.Next);
            Assert.IsNull(secondList.Next);
        }

        [TestMethod]
        public void MergeSortedLinkedLists()
        {
            Node list1 = new Node(10);
            list1.Next = new Node(20);
            list1.Next.Next = new Node(30);

            Node list2 = new Node(15);
            list2.Next = new Node(25);
            list2.Next.Next = new Node(35);

            Node mergedList = MergeSortLinkedList.MergeSortedLists(list1, list2);

            Assert.AreEqual(6, mergedList.Length);
            Assert.AreEqual(10, mergedList.Value);
            Assert.AreEqual(15, mergedList.Get(1).Value);
            Assert.AreEqual(20, mergedList.Get(2).Value);
            Assert.AreEqual(25, mergedList.Get(3).Value);
            Assert.AreEqual(30, mergedList.Get(4).Value);
            Assert.AreEqual(35, mergedList.Get(5).Value);
        }

        [TestMethod]
        public void MergeSortedLinkedListsSingleNodes()
        {
            Node list1 = new Node(10);
            Node list2 = new Node(15);

            Node mergedList = MergeSortLinkedList.MergeSortedLists(list1, list2);

            Assert.AreEqual(2, mergedList.Length);
            Assert.AreEqual(10, mergedList.Value);
            Assert.AreEqual(15, mergedList.Next.Value);
        }

        [TestMethod]
        public void MergeSortedLinkedListsFirstLonger()
        {
            Node list1 = new Node(10);
            list1.Next = new Node(20);
            list1.Next.Next = new Node(30);
            list1.Next.Next.Next = new Node(100);
            list1.Next.Next.Next.Next = new Node(101);
            list1.Next.Next.Next.Next.Next = new Node(102);

            Node list2 = new Node(15);
            list2.Next = new Node(25);
            list2.Next.Next = new Node(35);

            Node mergedList = MergeSortLinkedList.MergeSortedLists(list1, list2);

            Assert.AreEqual(9, mergedList.Length);
            Assert.AreEqual(10, mergedList.Value);
            Assert.AreEqual(15, mergedList.Get(1).Value);
            Assert.AreEqual(20, mergedList.Get(2).Value);
            Assert.AreEqual(25, mergedList.Get(3).Value);
            Assert.AreEqual(30, mergedList.Get(4).Value);
            Assert.AreEqual(35, mergedList.Get(5).Value);
            Assert.AreEqual(100, mergedList.Get(6).Value);
            Assert.AreEqual(101, mergedList.Get(7).Value);
            Assert.AreEqual(102, mergedList.Get(8).Value);
        }

        [TestMethod]
        public void MergeSortedLinkedListsSecondLonger()
        {
            Node list1 = new Node(10);
            list1.Next = new Node(20);
            list1.Next.Next = new Node(30);

            Node list2 = new Node(15);
            list2.Next = new Node(25);
            list2.Next.Next = new Node(35);
            list2.Next.Next.Next = new Node(100);
            list2.Next.Next.Next.Next = new Node(101);
            list2.Next.Next.Next.Next.Next = new Node(102);

            Node mergedList = MergeSortLinkedList.MergeSortedLists(list1, list2);

            Assert.AreEqual(9, mergedList.Length);
            Assert.AreEqual(10, mergedList.Value);
            Assert.AreEqual(15, mergedList.Get(1).Value);
            Assert.AreEqual(20, mergedList.Get(2).Value);
            Assert.AreEqual(25, mergedList.Get(3).Value);
            Assert.AreEqual(30, mergedList.Get(4).Value);
            Assert.AreEqual(35, mergedList.Get(5).Value);
            Assert.AreEqual(100, mergedList.Get(6).Value);
            Assert.AreEqual(101, mergedList.Get(7).Value);
            Assert.AreEqual(102, mergedList.Get(8).Value);
        }

        [TestMethod]
        public void TestMergeSortWithIntegers()
        {
            int[] list = new int[] { 6, 5, 3, 4, 0, 2, 1, 7, 9, 8 };
            list = MergeSort.DivideAndSort(list);

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, list[i]);
            }
        }

        [TestMethod]
        public void TestMergeSortWithNodes()
        {
            Node root = new Node(6);
            root.Next = new Node(5);
            root.Get(1).Next = new Node(3);
            root.Get(2).Next = new Node(4);
            root.Get(3).Next = new Node(0);
            root.Get(4).Next = new Node(2);
            root.Get(5).Next = new Node(1);
            root.Get(6).Next = new Node(7);
            root.Get(7).Next = new Node(9);
            root.Get(8).Next = new Node(8);

            root = MergeSortLinkedList.DivideAndSort(root);

            Node walker = root;

            for (int i = 0; i < 10; i++)
            {
                Assert.AreEqual(i, walker.Value);
                walker = walker.Next;
            }
        }
    }
}