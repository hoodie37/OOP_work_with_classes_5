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
    class square: Shape
    {
        public Point p1;
        public Point p2;
        public Point p3;
        public Point p4;
        public int color;
        public int x;
        public int a = 100;
        public int y;

        public square(int dx, int dy)
        {
            a = 100;
            x = dx;
            y = dy;
            this.color = 1;
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

        public override bool mouseInShape(int dx, int dy)
        {

            if (Math.Abs((dx - x) + (dy - y)) + Math.Abs((dx - x) - (dy - y)) <= a)
            {
                return true;
            }
            else return false;
        }

        public override int GetColor()
        {
            return color;
        }

        public override void draw(Graphics g)
        {
            Pen pen;
            if (color == 1) pen = new Pen(Brushes.Blue);
            else if (color == 2)
                pen = new Pen(Brushes.Red);
            else if (color == 3)
                pen = new Pen(Brushes.Green);
            else if (color == 4)
                pen = new Pen(Brushes.Black);
            else pen = new Pen(Brushes.Yellow);
            p1 = new Point(x - a / 2, y - a / 2);
            p2 = new Point(x + a / 2, y - a / 2);
            p3 = new Point(x + a / 2, y + a / 2);
            p4 = new Point(x - a / 2, y + a / 2);
            Point[] Points = { p1, p2, p3 ,p4 };
            g.DrawPolygon(pen, Points);
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
            if ((x - a / 2) <= 0 || (x + a / 2) >= w || (y - a / 2) <= 0 || (y + a / 2) >= h)
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
