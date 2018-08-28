using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList2
{
    public class Node
    {
        public int value;
        public Node next, prev;
        public Node(int x)
        {
            value = x;
            next = null;
        }


    }
    public class LinkedList2
    {
        public Node head;
        public Node tail;
        public LinkedList2()
        {
            head = null;
            tail = null;
        }
        public void PrintList() // out
        {
            Node node;
            node = head;
            while (node != null)
            {
                Console.Write(node.value + "\t");
                node = node.next;
            }
        }

        public void Add(Node item) // add node to end of list
        {
            if (head == null)
            {
                head = item;
                item.prev = null;
                item.next = null;
            }
            else
            {
                tail.next = item;
                item.prev = tail;
            }
            tail = item;
        }

        public Node find(int val) // find node with value = val
        {
            Node node;
            node = head;
            while (node != null)
            {
                if (node.value == val)
                    return node;
                node = node.next;
            }
            return null;
        }
        public void Del(int item) // delete only one node, which element equals item
        {
            Node node, temp;
            node = find(item);

            if (node == head)
            {
                temp = node.next;
                node = null;
                head = temp;
                head.prev = null;
            }
            else
               if (node == tail)
               {
                   temp = node.prev;
                   temp.next = null;
                   tail = temp;
               }
            else
            {
                node = node.prev;
                temp = node.next.next;
                node.next = temp;
                temp.prev = node;
            }
        }

        public void add_after(int x, int item) // add after x(value) item
        {
            Node node, newnode, temp;
            temp = null;
            node = head;
            node = find(x);
            temp = node.next;
            newnode = new Node(item);
            node.next = newnode;
            newnode.next = temp;
            temp.prev = newnode;
            newnode.prev = node;
 
        }

        public void AddFirst(int item)
        {
            Node node, temp, add;
            add = new Node(item);
            temp = null;
            node = add;
            node.next = head;
            node = node.next;
            node.prev = add;
            while (node != null)
            {
                temp = node;
                node = node.next;
                if (node != null)
                   node.prev = temp;
            }
            head = add;
            tail = temp;
        }
        class Program
        {
            static void Main(string[] args)
            {
                List<int> list = new List<int>();
                LinkedList2 s1 = new LinkedList2();
                s1.Add(new Node(5));
                s1.Add(new Node(30));
                s1.Add(new Node(15));
                s1.Add(new Node(20));
                s1.Add(new Node(10));
                Console.WriteLine("LinkedList:");
                s1.PrintList();
                Console.WriteLine();
                Console.WriteLine("Add 100 after 30");
                s1.add_after(30, 100);
                s1.PrintList();
                Console.WriteLine();
                Console.WriteLine("Add zero to first");
                s1.AddFirst(0);
                s1.PrintList();
                Console.WriteLine();
                Console.WriteLine("Delete 15 from the LinkedList");
                s1.Del(15);
                s1.PrintList();
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
