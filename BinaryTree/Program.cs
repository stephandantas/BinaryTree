using System;

namespace BinaryTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution tree = new Solution();
            Node root = null;

            Console.WriteLine("Type the total of nodes: ");
            int totalNodes = Convert.ToInt32(Console.ReadLine());
            int data;

            while (totalNodes-- > 0)
            {
                Console.WriteLine("Type a number: ");
                data = Convert.ToInt32(Console.ReadLine());
                root = tree.Insert(root, data);
            }

            int height = tree.GetHeight(root);

            Console.WriteLine($"The result is: {height}");
        }
    }

    class Solution
    {
        public Node Insert(Node root, int data)
        {
            if (root == null)
            {
                return new Node(data);
            }
            else
            {
                Node cur;
                if (data <= root.Data)
                {
                    cur = Insert(root.Left, data);
                    root.Left = cur;
                }
                else
                {
                    cur = Insert(root.Right, data);
                    root.Right = cur;
                }

                return root;
            }
        }

        public int GetHeight(Node root)
        {
            //The first root is never null, so it wont pass here in the first time
            if (root == null)
                return -1;

            int heightLeft = GetHeight(root.Left);
            int heightRight = GetHeight(root.Right);
            int highestSide = Math.Max(heightLeft, heightRight);

            return 1 + highestSide;
        }
    }

    class Node
    {
        public int Data { get; }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public Node(int d)
        {
            Data = d;
            Left = null;
            Right = null;
        }
    }
}
