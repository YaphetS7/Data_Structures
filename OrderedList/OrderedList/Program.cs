using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures
{
    public class Node<T>
    {
        public T value;
        public Node<T> next, prev;
        public Node(T _value)
        {
            value = _value;
            next = null;
            prev = null;
        }
    }

    public class OrderedList<T>
    {
        public Node<T> head, tail;
        private bool _ascending;
        private int count;
        public OrderedList(bool asc)
        {
            count = 0;
            head = null;
            tail = null;
            _ascending = asc;
        }

        public int Compare(T v1, T v2)
        {
            if (typeof(T) == typeof(String))
            {
                string s1 = Convert.ToString(v1);
                string s2 = Convert.ToString(v2);
                int i1 = 0, i2 = 0, j1 = s1.Length, j2 = s2.Length;
                while(s1[i1] == ' ')
                {
                    i1++;
                }
                while (s1[j1 - 1] == ' ')
                {
                    j1--;
                }
                while (s2[i2] == ' ')
                {
                    i2++;
                }
                while (s2[j2 - 1] == ' ')
                {
                    j2--;
                }
                return String.Compare(s1.Substring(i1, j1 - i1), s2.Substring(i2, j2 - i2));
            }
            else
            {
                double temp1 = Convert.ToDouble(v1);
                double temp2 = Convert.ToDouble(v2);
                if (temp1 < temp2)
                    return -1;
                if (temp1 > temp2)
                    return 1;
                else
                    return 0;
            }
        }

        public void Add(T value)
        {
            int x;
            if (_ascending)
                x = 1;
            else
                x = -1;
            Node<T> newnode = new Node<T>(value);
            if (count == 0)
            {
                head = newnode;
                tail = newnode;
                count = 1;
                return;
            }
            if (Compare((head.value), value) == 0)
            {
                newnode.next = head;
                head.prev = newnode;
                head = newnode;
                count++;
                return;
            }
            if (Compare(tail.value, value) == 0)
            {
                newnode.prev = tail;
                tail.next = newnode;
                tail = newnode;
                count++;
                return;
            }
            Node<T> node = head;
            if (Compare(node.value, value) == x)
            {
                head.prev = newnode;
                newnode.next = head;
                head = newnode;
                count++;
                return;
            }
            while (node != null && Compare(node.value, value) == -x && Compare(node.value, value) != 0)
            {
                node = node.next;
            }
            if (node == null)
            {
                tail.next = newnode;
                newnode.prev = tail;
                tail = newnode;
                count++;
                return;
            }
            if (count == 1)
            {
                tail = newnode;
                head.next = tail;
                tail.prev = head;
                count++;
                return;
            }
            node = node.prev;
            newnode.next = node.next;
            newnode.prev = node;
            node.next = newnode;
            node = newnode.next;
            node.prev = newnode;
            count++;



        }

        public Node<T> Find(T val)
        {
            Node<T> node = head;
            string value = Convert.ToString(val);
            while(node != null)
            {
                string temp = Convert.ToString(node.value);
                if (temp == value)
                    break;
                node = node.next;
            }
            return node;
        }

        public void Delete(T val)
        {
            Node<T> node = Find(val);
            if (node == null)
                return;
            if (count == 1)
            {
                head = null;
                tail = null;
                count = 0;
                return;
            }
            if (count == 2)
            {
                if (node == head)
                {
                    head = head.next;
                    head.prev = null;
                }
                else
                {
                    tail = tail.prev;
                    tail.next = null;
                }
                count = 1;
                return;
            }
            if (node == head)
            {
                head = head.next;
                head.prev = null;
                count--;
                return;
            }
            if (node == tail)
            {
                tail = tail.prev;
                tail.next = null;
                count--;
                return;
            }
            node.prev.next = node.next;
            node.next.prev = node.prev;
            count--;
        }

        public void Clear(bool asc)
        {
            _ascending = asc;
            count = 0;
            head.next = null;
            head = null;
            tail.prev = null;
            tail = null;
        }

        public int Count()
        {
            return count;
        }

        public List<Node<T>> GetAll() 
        {
            List<Node<T>> r = new List<Node<T>>();
            Node<T> node = head;
            while (node != null)
            {
                r.Add(node);
                node = node.next;
            }
            return r;
        }
    }

}
