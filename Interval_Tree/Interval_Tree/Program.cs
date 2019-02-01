using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interval_Tree
{ 

    public class Interval
    {
        public int start, end;
        public Interval(int start, int end)
        {
            this.start = start;
            this.end = end;
        }
    }
    public class IntervalNode
    {
        public IntervalNode parent = null, left = null, right = null;
        public int min, max, point;
        public List<Interval> leftIntervals, rightIntervals;
        public IntervalNode(List<Interval> intervals)
        {
          
            leftIntervals = IntervalTree.SortByLeft(intervals, true);
            rightIntervals = IntervalTree.SortByLeft(intervals, false);
            min = leftIntervals[0].start;
            max = rightIntervals[rightIntervals.Count - 1].end;
        }
        
    }
    public class IntervalTree
    {
        public IntervalNode root;
        public int min, max;
        public List<Interval> intervals_l;
        public List<Interval> intervals_r;
        public IntervalTree(List<Interval> list)
        {
            intervals_l = SortByLeft(list, true);
            intervals_r = SortByLeft(list, false);
            min = intervals_l[0].start;
            max = intervals_r[intervals_r.Count - 1].end;
            Build(min, max, root);
        }
        public List<Interval> Q(int point, IntervalNode node)
        {

            if (point < node.leftIntervals[0].start)
                return Q(point, node.left);
            if (point > node.rightIntervals[node.rightIntervals.Count - 1].end)
                return Q(point, node.right);
            List<Interval> result = new List<Interval>();
            for (int i = 0; i < node.leftIntervals.Count; i++)
            {
                if (Contains(point, node.leftIntervals[i]))
                    result.Add(node.leftIntervals[i]);
            }
            return result;
        }
        public void PrintL(IntervalNode node)
        {
            Console.Write(node.point + "\t");
            if (node.left != null)
                PrintL(node.left);
            if (node.right != null)
                PrintL(node.right);
        }
        private IntervalNode Build(int l, int r, IntervalNode node)
        {
            if (l >= r)
                return null;
            int mid = (l + r) / 2, i;
            List<Interval> list = new List<Interval>();

            for (i = 0; i < intervals_l.Count; i++)
            {
                if (mid < intervals_l[i].start)
                    break;
                if (Contains(mid, intervals_l[i]))
                    list.Add(intervals_l[i]);
            }
            node = new IntervalNode(list);
            node.point = mid;
            if (l == min && r == max)
                root = node;

            node.left = Build(l, mid - 1, node.left);
            node.right = Build(mid + 1, r, node.right);

            return node;
        }
        private bool Contains(int point, Interval interval)
        {
            return (interval.start <= point && point <= interval.end);
        }
        public static List<Interval> SortByLeft(List<Interval> list, bool check)
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
                        a = interval[i].start;
                    else
                        a = interval[i].end;
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
    class Program
    {
        static void Main(string[] args)
        {
            Interval interval = new Interval(0, 5);
            Interval interval2 = new Interval(4, 6);
            Interval interval3 = new Interval(8, 10);
            List<Interval> list = new List<Interval>();
            list.Add(interval);
            list.Add(interval2);
            list.Add(interval3);
            IntervalTree tree = new IntervalTree(list);
            List<Interval> ans = tree.Q(6, tree.root);

            for (int i = 0; i < ans.Count; i++)
            {
                Console.WriteLine("[" + ans[i].start + ";" + ans[i].end + "]");
            }
            
        }
    }
  
}
