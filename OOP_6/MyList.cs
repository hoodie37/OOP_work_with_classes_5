using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_6
{
    public class Node
    {
        public Shape data;
        public Node next;

        public Node(Shape value)
        {
            data = value;
        }
    }

    public class MyList
    {
        public Node Head;
        public Node Tail;
        public int count;
        public Node current;
        public MyList()
        {
            Head = null;
            Tail = null;
            current = Head;
            count = 0;
        }

        public MyList(Shape value)
        {
            var node = new Node(value);
            Head = node;
            current = Head;
            Tail = node;
            count++;
        }

        public MyList(Node node)
        {
            Head = node;
            Tail = node;
            current = Head;
            count++;
        }



        public Shape GetObj()
        {
            return current.data;
        }

        public bool Eol()
        {
            if (current == null)
                return false;

            return true;
        }

        public void First()
        {
            current = Head;
        }

        public void Next()
        {
            if (current != null)
                current = current.next;

        }

        public Node GetNode()
        {
            return current;
        }

        public Node GetNextNode()
        {
            return current.next;
        }

        public Shape GetHeadObj()
        {
            return Head.data;
        }

        public void add(string s,int dx,int dy)
       // public void add(Shape value)
        {
            if (s == "Круг")
            {
                var t = new Krug(dx, dy);
                var node = new Node(t);
                if (Head == null)
                {
                    Head = node;
                }
                else
                {
                    Tail.next = node;
                }
                Tail = node;
                current = Tail;
            }
            else if (s == "Треугольник")
            {
                var t = new triangle(dx, dy);
                var node = new Node(t);
                if (Head == null)
                {
                    Head = node;
                }
                else
                {
                    Tail.next = node;
                }
                Tail = node;
                current = Tail;
            }
            else
            {
                var t = new square(dx, dy);
                var node = new Node(t);
                if (Head == null)
                {
                    Head = node;
                }
                else
                {
                    Tail.next = node;
                }
                Tail = node;
                current = Tail;
            }
            count++;
        }




        public void delete(Shape value)
        {

            if (Head != null)
            {
                if (Head.data.Equals(value))
                {
                    if (current.next != Tail && current.next != null)
                    {
                        Head = Head.next;
                        count--;

                        current = Head;
                        return;
                    }
                    else
                    {
                        if (current.next == Tail)
                        {
                            Head = Tail;
                            current = Head;
                            count--;
                            return;
                        }
                        else
                        {
                            Head = null;
                            Tail = null;
                            current = null;
                            return;
                        }
                    }
                }

                current = Head.next;
                var pred = Head;

                while (current != null)
                {
                    if (current.data.Equals(value))
                    {
                        if (current == Tail && pred == Head)
                        {
                            Tail = Head;
                            current = Head;
                            current.next = null;
                            return;
                        }
                        if (current.next == null)
                        {
                            Tail = pred;
                            count--;
                            current = Tail;
                            current.next = null;
                            return;
                        }
                        else
                        {
                            pred.next = current.next;
                            count--;

                            current = pred;
                            return;
                        }
                    }
                    pred = current;
                    current = current.next;
                }
            }
            return;
        }

        public bool nalichie()
        {

            if (Head != null)
            {
                return true;
            }
            return false;
        }


    }
}
