using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2D_Range_Tree 
{
    public class Interval //in 2d interval is a point
    {
        public int x, y;
        public Interval(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    public class IntervalNode
    {
        public IntervalNode left = null, right = null;
        public int value; //value is max of x at List intervals
        public List<Interval> intervals; //sorted by y-coordinate
        public IntervalNode()
        {

        }
        public void AddList(List<Interval> list)
        {
            intervals = SortByY(list, true);
        }
        public List<Interval> Find_Points_In_Rectangle(Interval segment_x, Interval segment_y)
        {
            List<Interval> result = new List<Interval>();
            int index = B_Search(intervals, 0, intervals.Count - 1, segment_y.y);
            for (int i = 0; i <= index; i++)
                if (Contains(intervals[i], segment_x, segment_y))
                    result.Add(intervals[i]);


            return result;
        }
        private bool Contains(Interval point, Interval segment_x, Interval segment_y)
        {
            int x1 = segment_x.x;
            int x2 = segment_x.y;
            int y1 = segment_y.x;
            int y2 = segment_y.y;
            return (x1 <= point.x && point.x <= x2 && y1 <= point.y && point.y <= y2);
        }
        public static int B_Search(List<Interval> list, int l, int r, int value) 
        {
            while (l <= r)
            {
                int mid = (l + r) / 2;
                if (list[mid].y == value)
                    return mid;
                if (list[mid].y > value)
                {
                    return mid;
                }
                else
                {
                    l = mid + 1;
                }
            }
            return list.Count - 1;
        }
        public static List<Interval> SortByY(List<Interval> list, bool check)
        {
            int cnt = list.Count;
            List<Interval> interval = new List<Interval>();
            foreach (Interval i in list)
                interval.Add(i);
            List<Interval> result = new List<Interval>();
            while (result.Count < cnt)
            {
                int min = int.MaxValue;
                Interval temp = interval[0];
                for (int i = 0; i < interval.Count; i++)
                {
                    int a;
                    if (check)
                        a = interval[i].y;
                    else
                        a = interval[i].x;
                    if (a < min)
                    {
                        temp = interval[i];
                        min = a;
                    }
                }
                result.Add(temp);
                interval.Remove(temp);
            }
            return result;
        }
    }
    public class RangeTree
    {
        public IntervalNode root;
        public List<Interval> sorted_list = new List<Interval>(); //sorted by x-coordinate
        public RangeTree(List<Interval> list)
        {
            sorted_list = IntervalNode.SortByY(list, false);
            Build(0, sorted_list.Count - 1, root);
        }
        public List<Interval> Q(Interval interval1, Interval interval2) //find all points at rectangle [x1, x2]x[y1,y2]
        {
            IntervalNode node = Find_Max(interval1.y);
           
            List<Interval> result = node.Find_Points_In_Rectangle(interval1, interval2);
            return result;
        }
        private IntervalNode Find_Max(int x) //Find the Node with x-coordinate == x
        {
            IntervalNode node = root;
            while (node != null)
            { 
                if (node.value == x)
                    break;
                if (x > node.value && node.right == null)
                    return node;
                if (x > node.value)
                    node = node.right;
                else
                {

                    node = node.left;
                }
            }
            return node;
        }
        private IntervalNode Build(int l, int r, IntervalNode node)
        {
            if (l > r)
                return null;
            int mid = (r + l) / 2;
            int value = sorted_list[mid].x;
            node = new IntervalNode();
            if (l == r)
            {
                node.value = value;
            }
           

            List<Interval> list = new List<Interval>();
            for (int i = 0; i < sorted_list.Count; i++)
            {
                if (sorted_list[i].x <= value)
                    list.Add(sorted_list[i]);
            }

            node.AddList(list);
            node.value = value;
            
            if (l == 0 && r == sorted_list.Count - 1)
                root = node;

            node.left = Build(l, mid - 1, node.left);
            node.right = Build(mid + 1, r, node.right);

            return node;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Interval x = new Interval(0, 10);
            Interval y = new Interval(0, 10);
            Interval a = new Interval(0, 1);
            Interval b = new Interval(2, 4);
            Interval c = new Interval(3, 7);
            Interval d = new Interval(1, 1);
            Interval e = new Interval(2, 3);
            Interval f = new Interval(4, 0);
            Interval g = new Interval(0, 3);
            
            List<Interval> list = new List<Interval>() {a, b, c, d, e, f, g };
            RangeTree tree = new RangeTree(list);
            List<Interval> ans = tree.Q(x, y);
         
            for (int i = 0; i < ans.Count; i++)
            {
                Console.WriteLine("[" + ans[i].x + ";" + ans[i].y + "]");
            }

        }
    }
}
