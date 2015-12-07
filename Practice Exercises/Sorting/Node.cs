namespace Sorting
{
    public class Node
    {
        public int Val { get; set; }
        public Node Next { get; set; }

        public Node(int val)
        {
            Val = val;
        }

        public int Length
        {
            get { return (Next == null) ? 1 : Next.Length + 1; }
        }

        public Node BubbleSort()
        {
            Node head = this;
            int length = this.Length;

            for (int i = 0; i < length; i++)
            {
                Node walker = head;

                while (walker.Next != null)
                {
                    if (walker.Val > walker.Next.Val)
                    {
                        if (walker == head)
                        {
                            head = walker.Next;
                            walker.Next = head.Next;
                            head.Next = walker;
                            walker = head;
                            walker = walker.Next;
                        }
                        else
                        {
                            Node previous = getPrevious(walker, head);
                            previous.Next = walker.Next;
                            walker.Next = previous.Next.Next;
                            previous.Next.Next = walker;
                        }
                    }
                    else walker = walker.Next;
                }
            }

            return head;
        }

        private Node getPrevious(Node node, Node head)
        {
            Node walker = head;

            while (walker != null)
            {
                if (walker.Next == node)
                {
                    return walker;
                }

                walker = walker.Next;
            }

            return null;
        }

        public Node MergeSort()
        {
            return this;
        }
    }
}