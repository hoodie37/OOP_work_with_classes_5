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
    public abstract class Shape
    {
        public abstract bool mouseInShape(int dx, int dy);


        public abstract void draw(Graphics g);
        public abstract void Select();
        public abstract void SwitchColor(string c);
        public abstract int GetColor();
        public abstract void move(int dx, int dy,int w,int h);
        public abstract bool check(int w, int h);
        //public abstract bool checkCreate(int w, int h);

        public abstract void sizeMove(int i,int w,int h);
    }
    //public class Shape
    //{
    //   public int x, y;
    //   public int color;
    //    public int a;
    //    public virtual bool mouseInShape(int dx, int dy) { return true ; }


    //    public virtual void draw(Graphics g) { }
    //    public virtual void Select() { }
    //    public virtual void SwitchColor(int c) { color = c; }
    //    public virtual int GetColor() { return color; }
    //    public virtual void move(int dx, int dy) {
    //        if (color == 2)
    //        {
    //            x = x + dx;
    //            y = y + dy;
    //        }
    //    }
    //    public virtual bool check(int w, int h) { return true ; }
    //    //public abstract bool checkCreate(int w, int h);

    //    public virtual void sizeMove(int i)
    //    {
    //        a = a + 2 * i;
    //        if (a < 0)
    //        {
    //            a = a - 2 * i;
    //        }
    //    }
    //}
}
