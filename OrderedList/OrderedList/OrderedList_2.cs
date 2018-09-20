using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderedList
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
    public class OrderedList
    {
        public Node head;
        public Node tail;
        public bool g;
        public OrderedList(bool check)
        {
            g = check;
            head = null;
            tail = null;
        }
        public void PrintList() // out
        {
            Console.WriteLine();
            Node node;
            node = head;
            while (node != null)
            {
                Console.Write(node.value + "\t");
                node = node.next;
            }
        }
        private void AddFirst(int item)
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
        private void AddLast(int add) // add node to end of list
        {
            Node item = new Node(add);
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
        public void Add(int add) 
        {
            Node node;
            if (head != null)
            {
                node = head;
                while (check(add, node.value))
                {
                    if (node.next != null)
                        node = node.next;
                    else
                        break;

                }
                if (g)
                {
                    if (node == head)
                    {
                        if (node.value >= add)
                            AddFirst(add);
                        else
                        {
                            if (node.next != null)
                                add_after(node.value, add);
                            else
                                AddLast(add);
                        }
                    }
                    else
                    if (node == tail)
                    {

                        if (node.value >= add)
                            add_after(node.prev.value, add);
                        else
                            AddLast(add);
                    }
                    else
                    {
                        if (node.value <= add)
                            add_after(node.value, add);
                        else
                            add_after(node.prev.value,add);
                    }
                }
                else
                {
                    if (node == head)
                    {
                        if (node.value <= add)
                            AddFirst(add);
                        else
                            add_after(node.value, add);
                    }
                    else
                    if (node == tail)
                    {
                       
                        if (node.value >= add)
                            AddLast(add);
                        else
                            add_after(node.prev.value, add);
                    }
                    else
                    {
                        if (node.value <= add)
                            add_after(node.prev.value, add);
                        else
                            add_after(node.next.value,add);
                    }
                }
            }
            else
            {
                node = new Node(add);
                head = node;
                node.prev = null;
                node.next = null;
                tail = head;
                tail.next = null;
                tail.prev = null;
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
        public Node find(int val) // find node with value = val
        {
            Node node;
            node = head;
            while (check(val, node.value))
            {
                if (node.next != null)
                    node = node.next;
                else
                    break;

            }
            return node.prev;
        }
        public bool check(int add, int x)
        {
            if (g)
                return (add >= x);
            else
                return (add <= x);
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
    }
    public class Strs : OrderedList
    {
        bool g;
        LinkedList<string> list = new LinkedList<string>();
        public Strs(bool x) : base(x)
        {
            g = x;
        }
        public string del_(string str)
        {
            string result = "";
            char[] q = new char[str.Length + 1];
            for (int i = 0; i < str.Length; i++)
                q[i] = str[i];
            for (int j = 0; j < str.Length; j++)
                if (q[j] != ' ')
                   result = result + q[j];
            return result;
        }
        public void Addstr(string s)
        {
            del_(s);
        }

        
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            OrderedList list = new OrderedList(true);
            list.Add(100);
            
            list.Add(1230);
            
            list.Add(0);
            
            list.Add(23);
           
            list.Add(200);
            
            list.Add(1000);
            
            list.Add(1);
            
            list.Add(69);
         
            list.Add(1000);
            
            list.Add(55);
            list.PrintList();
           
        }
    }
}

