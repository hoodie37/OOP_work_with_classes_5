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
    class triangle: Shape
    {
        public Point p1;
        public Point p2;
        public Point p3;
        public int color;
        public int x,y;
        public int a = 100;
        public int k;
        public Point[] points;

        public triangle(int dx,int dy)
        {
            a = 100;
            x = dx;
            y = dy;
            this.color = 1;
            //p1 = new Point(x, y - 2 * k);
            //p2 = new Point(x - a, y + k);
            //p3 = new Point(x + a, y + k);
        }

        public override void SwitchColor(string c)
        {
            if (c == "Зелёный")
                color = 3;
            else if (c == "Синий")
                color = 1;
            else if (c == "Красный")
                color = 2;
            else if (c == "Чёрный")
                color = 4;
            else color = 5;
        }

        public override void Select()
        {
            if (color == 2)
                color = 1;
            else color = 2;
        }

        override public bool mouseInShape(int dx, int dy)
        {

            Point p = new Point(dx, dy);
            k = Convert.ToInt32(a / Math.Sqrt(3));
            p1 = new Point(x, y - 2 * k);
            p2 = new Point(x - a / 2, y + k);
            p3 = new Point(x + a / 2, y + k);
            bool flag = false;
            if (func(p1, p2, p3) == func( p1, p2, p) + func( p1, p, p3) + func(p2,p,p3))
           // if(func(p,p1,p2,p3))1
            {
                flag = true;
            }
            return flag;
        }


        public int func(Point p1, Point p2, Point p3)
        {
            ////int tag = Convert.ToInt32(Math.Sqrt(3));
            ////if (l.Y >= p.Y && (l.Y - p.Y >= tag * (l.X - p.X)) && (m.Y - p.Y <= tag * (m.X - p.X))) return true;
            ////else return false;
            //int f = (p.Y - l.Y) * (m.X - l.X) - (p.X - l.X) * (m.Y - l.Y);
            //int g = (k.Y - l.Y) * (m.X - l.X) - (k.X - l.X) * (m.Y - l.Y);
            //if (f * g >= 0)
            //    return true;
            //else return false;
            return Math.Abs((p1.X - p3.X) * (p2.Y - p3.Y) + (p2.X - p3.X) * (p3.Y - p1.Y));
        }

        public override int GetColor()
        {
            return color;
        }

        public override void draw(Graphics g)
        {
            k = Convert.ToInt32(a / Math.Sqrt(3));
            Pen pen;
            if (color == 1) pen = new Pen(Brushes.Blue);
            else if (color == 2)
                pen = new Pen(Brushes.Red);
            else if (color == 3)
                pen = new Pen(Brushes.Green);
            else if (color == 4)
                pen = new Pen(Brushes.Black);
            else pen = new Pen(Brushes.Yellow);
            p1 = new Point(x, y - 2 * k);
            p2 = new Point(x - a, y + k);
            p3 = new Point(x + a, y + k);
            points = new Point[3] { p1, p2, p3 };

            g.DrawPolygon(pen, points);
        }

        public override void move(int dx, int dy, int w, int h)
        {
            if (color == 2)
            {
                x = x + dx;
                y = y + dy;
                if (check(w, h) == false)
                {
                    x = x - dx;
                    y = y - dy;
                }
            }
        }

        public override bool check(int w, int h)
        {
            if ((x - a) <= 0 || (y - 2 * k) <= 0 || (x + a) >= w || (y + k) >= h)
                return false;
            else return true;
        }

        public override void sizeMove(int i, int w, int h)
        {
            a = a + 2 * i;
            if (check(w, h) == false)
            {
                a = a - 2 * i;
            }
            if (a < 0)
            {
                a = a - 2 * i;
            }
        }
    }
}
