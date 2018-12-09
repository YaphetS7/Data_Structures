using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AST
{
    public class Node
    {
        public Node left = null, right = null, parent = null;
        public char value;
        public bool IsValue = false;
        public string translation = "";
        public int interpretation;
    }
    public class AST
    {
        List<ANode> token_list = new List<ANode>();
        public Node node = new Node();
        public Node root = new Node();
        public AST(string s)
        {
            root = node;
            Parser parser = new Parser();
            token_list = parser.Parse(s);
            for (int i = 0; i < token_list.Count; i++)
            {
                if (token_list[i].token_value == '(')
                {
                    Node temp = new Node();
                    node.left = temp;
                    temp.parent = node;
                    node = node.left;
                    continue;
                }
                if (token_list[i].token_value == ')')
                {
                    if (node.parent != null)
                        node = node.parent;
                    continue;
                }
                if (token_list[i].token_value == '*' || token_list[i].token_value == '/' || token_list[i].token_value == '+' || token_list[i].token_value == '-')
                {
                    Node temp = new Node();
                    node.value = token_list[i].token_value;
                    node.IsValue = false;
                    node.right = temp;
                    temp.parent = node;
                    node = node.right;
                    continue;
                }
                node.value = token_list[i].token_value;
                node.IsValue = true;
                node = node.parent;
            }
        }
        public void PrintResult()
        {
            Console.WriteLine(root.translation + " = " + root.interpretation);
        }
        public void Calc(Node node)
        {
            if (node.left.IsValue && node.right.IsValue && !node.IsValue)
            {
                string a = node.left.translation;
                string b = node.right.translation;
                if (a.Length == 0)
                    a = node.left.value + "";
                if (b.Length == 0)
                    b = node.right.value + "";
                int first = node.left.interpretation;
                int second = node.right.interpretation;
                if (first == 0)
                    first = Convert.ToInt32(node.left.value + "");
                if (second == 0)
                    second = Convert.ToInt32(node.right.value + "");
                if (node.value == '+')
                    node.interpretation = first + second;
                if (node.value == '-')
                    node.interpretation = first - second;
                if (node.value == '*')
                    node.interpretation = first * second;
                if (node.value == '/')
                    node.interpretation = first / second;
                node.translation = "(" + a + node.value + b + ")";
                node.IsValue = true;
                if (node == root)
                    return;
                else
                {
                    Calc(node.parent);
                }

            }
            if (node.left != null && !node.left.IsValue)
                Calc(node.left);
            if (node.right != null && !node.right.IsValue)
                Calc(node.right);

        }
        public void PrintAST(Node node)
        {
            Console.Write(node.value + "\t");
            if (node.left != null)
                PrintAST(node.left);
            if (node.right != null)
                PrintAST(node.right);
        }
    }
    public class ANode
    {
        public string token_type;
        public char token_value;
        public ANode(string token_type, char token_value)
        {
            this.token_type = token_type;
            this.token_value = token_value;
        }
    }

    public class Parser
    {

        List<char> list = new List<char>();

        private void InsertL(int i)
        {
            bool check = false;
            while (i > 0)
            {
                if (list[i - 1] == '/' || list[i - 1] == '*' || list[i - 1] == '+' || list[i - 1] == '-')
                {
                    list.Insert(i, '(');
                    check = true;
                    break;
                }
                else
                {
                    if (list[i - 1] == ')')
                    {
                        int cnt = 1;
                        while (cnt != 0)
                        {
                            i--;
                            if (list[i - 1] == ')')
                                cnt++;
                            if (list[i - 1] == '(')
                                cnt--;
                        }
                    }
                    else
                        i--;
                }
            }
            if (!check)
                list.Insert(0, '(');
        }
        private void InsertR(int i)
        {
            bool check = false;
            while (i < list.Count - 1)
            {
                if (list[i + 1] == '/' || list[i + 1] == '*' || list[i + 1] == '+' || list[i + 1] == '-')
                {
                    list.Insert(i + 1, ')');
                    check = true;
                    break;
                }
                else
                {
                    if (list[i + 1] == '(')
                    {
                        int cnt = 1;
                        while (cnt != 0)
                        {
                            i++;
                            if (list[i + 1] == '(')
                                cnt++;
                            if (list[i + 1] == ')')
                                cnt--;
                        }
                    }
                    else
                        i++;
                }
            }
            if (!check)
                list.Add(')');
        }
        public List<ANode> Parse(string s)
        {
            for (int i = 0; i < s.Length; i++)
            {
                list.Add(s[i]);
            }
            ParseDel();
            List<ANode> result = new List<ANode>();
            foreach (char a in list)
            {
                string type;
                char value;
                if (a == '(' || a == '(')
                {
                    type = "скобка";
                    value = a;
                    ANode token0 = new ANode(type, value);
                    result.Add(token0);
                    continue;
                }
                if (a == '+' || a == '*' || a == '/' || a == '-')
                {
                    type = "операция";
                    value = a;
                    ANode token1 = new ANode(type, value);
                    result.Add(token1);
                    continue;
                }
                type = "цифра";
                value = a;
                ANode token2 = new ANode(type, value);
                result.Add(token2);
            }
            return result;
        }
        private void ParseDel()
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i] == '/')
                {
                    InsertL(i);
                    InsertR(i + 1);
                    i += 2;
                }
            ParsePow();
        }
        private void ParsePow()
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i] == '*')
                {
                    InsertL(i);
                    InsertR(i + 1);
                    i += 2;
                }

            ParseDiff();
        }
        private void ParseDiff()
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i] == '-')
                {
                    InsertL(i);
                    InsertR(i + 1);
                    i += 2;
                }

            ParsePlus();
        }

        private void ParsePlus()
        {
            for (int i = 0; i < list.Count; i++)
                if (list[i] == '+')
                {
                    InsertL(i);
                    InsertR(i + 1);
                    i += 2;
                }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            AST tree = new AST("7+3+5+6+9-2+3*7-9*4");
            tree.Calc(tree.root);
            tree.PrintResult();
            
            
        }
    }
}
