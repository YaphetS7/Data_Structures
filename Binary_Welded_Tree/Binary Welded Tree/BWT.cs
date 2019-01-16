using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Welded_Tree
{
    public class Node
    {
        public Node left, right, parent;
        public bool isList = false;
        public int CntColor = 0;
        public int colorParent = 0, colorLeft = 0, colorRight = 0;
        public Node()
        {
            left = null;
            right = null;
            parent = null;
            colorParent = -1;
            colorLeft = -1;
            colorRight = -1;
        }
    }

    public class BinaryWeldedTree
    {
        Random rand = new Random();
        public int depth;
        public Node root1, root2;
        public Node[] first; // first array of Nodes (it contains tree)
        public Node[] second; // second...
        public int cntOfNodes = 1; 
        public int cntOfColors; 
        public BinaryWeldedTree(int depth, int cntOfColors)
        {
            this.cntOfColors = cntOfColors;
            this.depth = depth;
            int temp = 2;
            // CntOfNodes = Pow(2, depth + 1) - 1;
            for (int i = 1; i <= depth; i++)
            {
                cntOfNodes += temp;
                temp *= 2;
            }
            first = new Node[cntOfNodes];
            second = new Node[cntOfNodes];
            for (int i = 0; i < cntOfNodes; i++) //create nodes
            {
                first[i] = new Node();
                second[i] = new Node();
            }
            root1 = first[0];
            root2 = second[0];
            DoTree();
        }
        public int RandomWandering()
        {
            Node node = root1;
            int cntOfSteps = 0, x;
            while (node != root2)
            {
                if (node == root1)
                    x = rand.Next(1, 3);
                else
                    x = rand.Next(1, 4);
                
                if (x == 3 && node.parent != null)
                    node = node.parent;

                if (x == 2 && node.right != null)
                    node = node.right;
                
                if (x == 1 && node.left != null)
                    node = node.left;
                
                cntOfSteps++;
            }
            return cntOfSteps;
        }
        public int RandomMultiWandering()
        {
            int cntOfPoints = 1, cntOfSteps = 0;
            List<Node> list = new List<Node>();
            list.Add(root1);
            Node currNode = root1, newnode = null;
            while (currNode != root2)
            {
                for (int i = 0; i < cntOfPoints; i++)
                {
                    newnode = RandomStep(list[i]);
                    list[i] = newnode;
                    if (cntOfPoints < 16)
                        list.Add(newnode);
                    if (newnode == root2)
                        break;
                }
                cntOfSteps++;
                if (cntOfPoints < 16)
                {
                    cntOfPoints *= 2;
                }
                if (newnode == root2)
                    break;
                cntOfSteps++;
            }
            return cntOfSteps;
        }
        private Node RandomStep(Node node)
        {
            int temp;
            if (node == root1)
                temp = rand.Next(1, 3);
            else
                temp = rand.Next(1, 4);

            if (temp == 3 && node.parent != null)
                node = node.parent;

            if (temp == 2 && node.right != null)
                node = node.right;

            if (temp == 1 && node.left != null)
                node = node.left;
            return node;
        }
        //we just do: node = node.parent...(repeat while node.parent != root) and calc CntOfColor
        public List<Node> FindLenOfWay(int color)
        {
            int i;
            List<Node> list = new List<Node>();
            Node num1 = null, num2 = null;
            int index = cntOfNodes - (cntOfNodes + 1) / 2; //that is index of first list(in our arrays)
            for (i = index; i <= cntOfNodes - 1; i++)
            {
                CalcColors(i, color, true);
                CalcColors(i, color, false);
            }
            int min = first[index].CntColor + first[index].left.CntColor;
            for (i = index; i <= cntOfNodes - 1; i++)
            {
                if (first[i].CntColor + first[i].left.CntColor < min)
                {
                    min = first[i].CntColor + first[i].left.CntColor;
                    num1 = first[i];
                    num2 = first[i].left;
                }

                if (first[i].CntColor + first[i].right.CntColor < min)
                {
                    min = first[i].CntColor + first[i].right.CntColor;
                    num1 = first[i];
                    num2 = first[i].right;
                }
            }
            list.Add(num1);
            list.Add(num2);
            return list;
        }
        private void CalcColors(int index, int color, bool isFirst)
        {
            int starti = index;
            int cnt = 0;
            int i = index;
            while (i >= 0)
            {
                if (isFirst)
                {
                    if (first[i].colorParent == color)
                        cnt++;
                }
                else
                {
                    if (second[i].colorParent == color)
                        cnt++;
                }
                if (i % 2 == 0)
                    i = (i - 2) / 2;
                else
                    i = (i - 1) / 2;
            }
            if (isFirst)
                first[starti].CntColor = cnt;
            else
                second[starti].CntColor = cnt;
        }
        private void AddColors(Node node)
        {
            int a = node.colorParent;
            int b = node.colorLeft;
            int c = node.colorRight;
            if (node.isList)
            {
                if (node.left == null)
                    return;
                //Color of parent of lists second(bottom) tree
                int temp1 = node.left.colorParent;
                int temp2 = node.right.colorParent;
                //TRY TO UNDERSTAND IT BY YOURSELF
                while (a == b || b == c || a == c || b == 0 || c == 0 || b == -1 || c == -1 || temp1 == b || temp2 == c)
                {
                    b = rand.Next(1, cntOfColors + 1);
                    c = rand.Next(1, cntOfColors + 1);
                }
                node.colorLeft = b;
                node.colorRight = c;
                return;
            }
            //randomize colors
            while (a == b || b == c || a == c || b == 0 || c == 0 || b == -1 || c == -1)
            {
                b = rand.Next(1, cntOfColors + 1);
                c = rand.Next(1, cntOfColors + 1);
            }
            node.colorLeft = b;
            node.colorRight = c;

            if (node.left != null)
                node.left.colorParent = b;

            if (node.right != null)
                node.right.colorParent = c;
        }
        public void SetColors() //1, 2, 3, 4, ... etc :)
        {
            int i;
            first[0].colorLeft = 1;
            first[0].colorRight = 2;
            first[1].colorParent = 1;
            first[2].colorParent = 2;
            second[0].colorLeft = 1;
            second[0].colorRight = 2;
            second[1].colorParent = 1;
            second[2].colorParent = 2;
            for (i = 1; i < cntOfNodes; i++)
            {
                AddColors(second[i]);
            }

            for (i = 1; i < cntOfNodes; i++)
                AddColors(first[i]);
        }
        public void PRINT()
        {
            for (int i = 0; i < cntOfNodes; i++)
            {
                Console.Write(i + " узел: parent - " + first[i].colorParent + ", left child - " + first[i].colorLeft + ", right child - " + first[i].colorRight);
                Console.WriteLine();
            }
        }
        private void DoTree()
        {
            int i, index = 1;
            for (i = 0; i < cntOfNodes; i++)
            {
                int index1, index2;
                index1 = i * 2 + 1; //left child
                index2 = i * 2 + 2; //right child
                if (index1 < cntOfNodes)
                {
                    first[index1].parent = first[i];
                    second[index1].parent = second[i];
                    first[i].left = first[index1];
                    second[i].left = second[index1];
                }
                if (index2 < cntOfNodes)
                {
                    first[index2].parent = first[i];
                    second[index2].parent = second[i];
                    first[i].left = first[index2];
                    second[i].left = second[index2];
                }

            }

            for (i = 0; i < depth; i++) //calc the index of first list
            {
                index *= 2;
            }

            for (i = index - 1; i < cntOfNodes - 1; i++) //add link between lists of tree1 and tree2
            {
                first[i].isList = true;
                second[i].isList = true;
                first[i].left = second[i];
                first[i].right = second[i + 1];
            }
            first[i].left = second[index - 1];
            first[i].right = second[i];
            first[i].isList = true;
            second[i].isList = true;
        }
    }

    class BWT
    {
        static void Main(string[] args)
        {
            BinaryWeldedTree tree = new BinaryWeldedTree(3, 4);
            tree.SetColors();
            tree.PRINT();
            List<Node> list = tree.FindLenOfWay(1);
            //Console.WriteLine(list[0].CntColor + " " + list[1].CntColor); //print the cntOfColor of two lists
            int avg1 = 0, avg2 = 0;
            for (int i = 0; i < 1000000; i++)
            {
                int res1 = tree.RandomWandering();
                int res2 = tree.RandomMultiWandering();
                avg1 += res1;
                avg2 += res2;
            }
            avg1 /= 1000000;
            avg2 /= 1000000;
            Console.WriteLine(avg1); //print the average count of steps by using the algorihtm(with 1 point) 1 000 000 times
            Console.WriteLine(avg2); //print the average count of steps by using the second algorithm(with multiply points) 1 000 000 times
        }
    }
}
