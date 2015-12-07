using MergeSort;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class MergeSortTests
    {
        [TestMethod]
        public void DivideOddList()
        {
            int[][] lists = MergeSort.MergeSort.Divide(new int[] { 1, 2, 3, 4, 5 });

            Assert.AreEqual(2, lists[0].Length);
            Assert.AreEqual(1, lists[0][0]);
            Assert.AreEqual(2, lists[0][1]);

            Assert.AreEqual(3, lists[1].Length);
            Assert.AreEqual(3, lists[1][0]);
            Assert.AreEqual(4, lists[1][1]);
            Assert.AreEqual(5, lists[1][2]);
        }

        [TestMethod]
        public void DivideEvenList()
        {
            int[][] lists = MergeSort.MergeSort.Divide(new int[] { 1, 2, 3, 4, 5, 6 });

            Assert.AreEqual(3, lists[0].Length);
            Assert.AreEqual(1, lists[0][0]);
            Assert.AreEqual(2, lists[0][1]);
            Assert.AreEqual(3, lists[0][2]);

            Assert.AreEqual(3, lists[1].Length);
            Assert.AreEqual(4, lists[1][0]);
            Assert.AreEqual(5, lists[1][1]);
            Assert.AreEqual(6, lists[1][2]);
        }

        [TestMethod]
        public void DivideListWithTwoElements()
        {
            int[][] lists = MergeSort.MergeSort.Divide(new int[] { 1, 2 });

            Assert.AreEqual(1, lists[0].Length);
            Assert.AreEqual(1, lists[0][0]);

            Assert.AreEqual(1, lists[1].Length);
            Assert.AreEqual(2, lists[1][0]);
        }

        [TestMethod]
        public void MergeSortedLists()
        {
            int[] list1 = new int[] { 10, 20, 30 };
            int[] list2 = new int[] { 15, 25, 35 };
            int[] mergedList = MergeSort.MergeSort.MergeSortedLists(list1, list2);

            Assert.AreEqual(6, mergedList.Length);
            Assert.AreEqual(10, mergedList[0]);
            Assert.AreEqual(15, mergedList[1]);
            Assert.AreEqual(20, mergedList[2]);
            Assert.AreEqual(25, mergedList[3]);
            Assert.AreEqual(30, mergedList[4]);
            Assert.AreEqual(35, mergedList[5]);
        }

        [TestMethod]
        public void MergeSortedListsFirstLonger()
        {
            int[] list1 = new int[] { 10, 20, 30, 100, 101, 102 };
            int[] list2 = new int[] { 15, 25, 35 };
            int[] mergedList = MergeSort.MergeSort.MergeSortedLists(list1, list2);

            Assert.AreEqual(9, mergedList.Length);
            Assert.AreEqual(10, mergedList[0]);
            Assert.AreEqual(15, mergedList[1]);
            Assert.AreEqual(20, mergedList[2]);
            Assert.AreEqual(25, mergedList[3]);
            Assert.AreEqual(30, mergedList[4]);
            Assert.AreEqual(35, mergedList[5]);
            Assert.AreEqual(100, mergedList[6]);
            Assert.AreEqual(101, mergedList[7]);
            Assert.AreEqual(102, mergedList[8]);
        }

        [TestMethod]
        public void MergeSortedListsSecondLonger()
        {
            int[] list1 = new int[] { 10, 20, 30 };
            int[] list2 = new int[] { 15, 25, 35, 100, 101, 102 };
            int[] mergedList = MergeSort.MergeSort.MergeSortedLists(list1, list2);

            Assert.AreEqual(9, mergedList.Length);
            Assert.AreEqual(10, mergedList[0]);
            Assert.AreEqual(15, mergedList[1]);
            Assert.AreEqual(20, mergedList[2]);
            Assert.AreEqual(25, mergedList[3]);
            Assert.AreEqual(30, mergedList[4]);
            Assert.AreEqual(35, mergedList[5]);
            Assert.AreEqual(100, mergedList[6]);
            Assert.AreEqual(101, mergedList[7]);
            Assert.AreEqual(102, mergedList[8]);
        }
    }
}