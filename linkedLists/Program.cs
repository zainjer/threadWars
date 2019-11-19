using System;
using System.Threading;

namespace linkedLists
{
    class Program
    {
        public static String ta = "Thread_A";
        public static String tb = "Thread_B";
        public static String tc = "Thread_C";
        public static String td = "Thread_D";
        public static int numberOfChilds = 1000;
        static void Main(string[] args)
        {
            Console.WriteLine("\t\tJUNGLE OF THE BUS!\nThis is the war of Threads");
            Console.Read();
            Node parent = new Node();
            Thread tA = new Thread(new ThreadStart(Program.T_a));
            Thread tB = new Thread(new ThreadStart(Program.T_b));
            Thread tC = new Thread(new ThreadStart(Program.T_c));
            Thread tD = new Thread(new ThreadStart(Program.T_d));
            tA.Start();
            tB.Start();
            tC.Start();
            tD.Start();
            parent.addChilds(numberOfChilds,"Main_Thread");
            Console.ReadLine();
            Console.WriteLine("\t\tJUNGLE OF THE BUS!\nThis is the war of Threads");
            Console.ReadLine();


        }
        
        public static void T_a()
        {
            try
            {
                Node parent = new Node();
                parent.addChilds(numberOfChilds, ta);
            }
            catch (Exception ex)
            {
                // log errors
            }
        }
        public static void T_b()
        {
            try
            {      
                Node parent = new Node();
                parent.addChilds(numberOfChilds, tb);
            }
            catch (Exception ex)
            {
                // log errors
            }
        }
        public static void T_c()
        {
            try
            {
                Node parent = new Node();
                parent.addChilds(numberOfChilds, tc);
            }
            catch (Exception ex)
            {
                // log errors
            }
        }
        public static void T_d()
        {
            try
            {
                Node parent = new Node();
                parent.addChilds(numberOfChilds, td);
            }
            catch (Exception ex)
            {
                // log errors
            }
        }

    }

    public class Node
    {
        Node head { get; set; }
        Node tail { get; set; }

        public string name { get; set; }

        public Node addChild(String childname)
        {
            Node child = new Node();
            this.tail = child;
            child.head = this;
            child.name = childname;
            return child;
        }
        public void goForward(string threadName)
        {
            int len = goForward(this,0,threadName);
        }         

        int goForward(Node node,int length,string threadName)
        {
            if (node.tail != null)
            {
                Console.WriteLine(threadName+" child "+length);
                goForward(node.tail,length+1,threadName);
            }
            else
            {
                Console.Write(threadName+"  ");
                Console.Write(length-1);
                return length;
            }
            return length;
        }
        public void addChilds(int number,string threadName)
        {
         addChilds(number, this, threadName); 
        }

        public void addChilds(int number, Node currentNode,string threadName)
        {
            try
            {
                if (number >= 0)
                {
                    Node child = new Node();
                    child.name = "" + number;
                    currentNode.tail = child;
                    child.head = currentNode;
                    Console.WriteLine(threadName + " Child #" + child.name);
                    addChilds(number - 1, child, threadName);
                }
                else
                {
                    Console.WriteLine("End of list for "+threadName);
                    return;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            
        }

    }
}
