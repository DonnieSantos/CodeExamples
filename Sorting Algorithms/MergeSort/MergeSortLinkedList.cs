namespace MergeSort
{
    public class MergeSortLinkedList
    {
        public static Node DivideAndSort(Node node)
        {
            if (node.Length == 1) return node;
            Node secondList = node.Divide();
            node = DivideAndSort(node);
            secondList = DivideAndSort(secondList);
            return MergeSortedLists(node, secondList);
        }

        public static Node MergeSortedLists(Node list1, Node list2)
        {
            Node root = Node.Smaller(list1, list2);
            Node walker = new Node(0);
            walker.Next = root;

            while (list1 != null || list2 != null)
            {
                Node nextNode = Node.Smaller(list1, list2);
                walker.Next = nextNode;

                if (nextNode == list1) list1 = list1.Next;
                else if (nextNode == list2) list2 = list2.Next;

                walker = walker.Next;
            }

            return root;
        }
    }
}