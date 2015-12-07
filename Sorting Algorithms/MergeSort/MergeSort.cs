namespace MergeSort
{
    public class MergeSort
    {
        public static int[] DivideAndSort(int[] list)
        {
            if (list.Length == 1) return list;
            int[][] lists = Divide(list);
            lists[0] = DivideAndSort(lists[0]);
            lists[1] = DivideAndSort(lists[1]);
            return MergeSortedLists(lists[0], lists[1]);
        }

        public static int[] MergeSortedLists(int[] list1, int[] list2)
        {
            int newListLength = list1.Length + list2.Length;
            int[] mergedList = new int[newListLength];

            int index1 = 0;
            int index2 = 0;

            for (int i = 0; i < newListLength; i++)
            {
                if (index1 == list1.Length) mergedList[i] = list2[index2++];
                else if (index2 == list2.Length) mergedList[i] = list1[index1++];
                else mergedList[i] = (list1[index1] < list2[index2]) ? list1[index1++] : list2[index2++];
            }

            return mergedList;
        }

        public static int[][] Divide(int[] list)
        {
            int mid = list.Length / 2;
            int[][] twoLists = new int[2][];
            twoLists[0] = new int[mid];
            twoLists[1] = new int[list.Length - mid];
            for (int i = 0; i < mid; i++) twoLists[0][i] = list[i];
            for (int i = mid; i < list.Length; i++) twoLists[1][i - mid] = list[i];
            return twoLists;
        }
    }
}