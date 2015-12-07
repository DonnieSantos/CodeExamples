namespace MergeSort
{
    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public int Length { get { return (Next != null) ? Next.Length + 1 : 1; } }

        public Node(int value)
        {
            Value = value;
        }

        public Node Get(int N)
        {
            Node node = this;

            for (int i = 0; i < N; i++)
            {
                node = node.Next;
            }

            return node;
        }

        public Node Divide()
        {
            int length = this.Length;
            int mid = length / 2;
            Node walker = this;
            Node lastNodeInFirstList = null;

            for (int i = 0; i < mid; i++)
            {
                if (i == mid - 1) lastNodeInFirstList = walker;
                walker = walker.Next;
            }

            lastNodeInFirstList.Next = null;
            return walker;
        }

        public static Node Smaller(Node node1, Node node2)
        {
            if (node1 == null) return node2;
            if (node2 == null) return node1;
            return (node1.Value < node2.Value) ? node1 : node2;
        }
    }
}