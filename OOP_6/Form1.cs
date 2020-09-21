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
    public partial class Form1 : Form
    {
        MyList l = new MyList();
       
        public Form1()
        {
            InitializeComponent();
            
           
        }

        /////////////////////////// ВАЖНЫЕ СОБЫТИЯ \\\\\\\\\\\\\\\\\\\\\\\\\\\\

        private void pBox_MouseClick(object sender, MouseEventArgs e)
        {
            int flag = 0;
            if (radioBSelect.Checked == true)
            { 
                for (l.First(); l.Eol(); l.Next())
                {
                    if (l.GetObj().mouseInShape(e.X, e.Y) == true)
                    {
                        l.GetObj().Select();
                        flag = 1;
                        pBox.Select();
                        break;
                    }
                }

                if (flag != 1)
                {

                    l.add(cBoxShape.Text, e.X, e.Y);
                }
               
            }
            else for (l.First(); l.Eol(); l.Next())
                {
                    if (l.GetObj().mouseInShape(e.X, e.Y) == true)
                    {
                        l.GetObj().SwitchColor(cBoxColor.Text);
                    }
                    
                }
            this.Refresh();
            pBox.Select();
        }

        
        private void buttonDelete_Click(object sender, EventArgs e)
        {
            for (l.First(); l.Eol(); l.Next())
            {
                if (l.GetObj().GetColor() == 2)
                {
                    l.delete(l.GetObj());
                }
                if (l.nalichie() == true && l.GetNextNode() == null)
                {

                    if (l.GetHeadObj().GetColor() == 2)
                    {
                        l.delete(l.GetHeadObj());
                    }
                }

            }
            this.Refresh();
            pBox.Select();
        }

        private void pBox_KeyDown(object sender, KeyEventArgs e)
        {

            //////////////ДВИЖЕНИЕ\\\\\\\\\\\\\\\\\
            if (e.KeyCode == Keys.W)
            {

                for (l.First(); l.Eol(); l.Next())
                {
                        l.GetObj().move(0, -1, pBox.Size.Width, pBox.Size.Height);
                }
              }

            if (e.KeyCode == Keys.S)
            {
                for (l.First(); l.Eol(); l.Next())
                {
                    l.GetObj().move(0, 1, pBox.Size.Width, pBox.Size.Height);
                }
            }
            if (e.KeyCode == Keys.A)
            {
                for (l.First(); l.Eol(); l.Next())
                {
                    l.GetObj().move(-1, 0, pBox.Size.Width, pBox.Size.Height);
                }
            }
            if (e.KeyCode == Keys.D)
            {
                for (l.First(); l.Eol(); l.Next())
                {
                    l.GetObj().move(1, 0, pBox.Size.Width, pBox.Size.Height);
                }
            }

            //////////////УДАЛЕНИЕ ЧЕРЕЗ DEL\\\\\\\\\\\\\\\\\
            if (e.KeyCode == Keys.Delete)
            {
                for (l.First(); l.Eol(); l.Next())
                {
                    if (l.GetObj().GetColor() == 2)
                    {
                        l.delete(l.GetObj());
                    }
                    if (l.nalichie() == true && l.GetNextNode() == null)
                    {

                        if (l.GetHeadObj().GetColor() == 2)
                        {
                            l.delete(l.GetHeadObj());
                        }
                    }
                }
            }


            //////////////УВЕЛИЧЕНИЕ И УМЕНЬШЕНИЕ\\\\\\\\\\\\\\\\\
            if (e.KeyCode == Keys.Oemplus)
            {
                for (l.First(); l.Eol(); l.Next())
                {
                    if (l.GetObj().GetColor() == 2)
                    {
                        l.GetObj().sizeMove(1, pBox.Size.Width, pBox.Size.Height);
                    }
                }
            }
            if (e.KeyCode == Keys.OemMinus)
            {
                for (l.First(); l.Eol(); l.Next())
                {
                    if (l.GetObj().GetColor() == 2)
                    {
                        l.GetObj().sizeMove(-1, pBox.Size.Width, pBox.Size.Height);
                    }
                }
            }


            this.Refresh();
        }

        /////////////////////////// НЕ ОЧЕНЬ ВАЖНЫЕ СОБЫТИЯ \\\\\\\\\\\\\\\\\\\\\\\\\\\\

        private void pBox_MouseMove(object sender, MouseEventArgs e)
        {
            label1.Text = e.X.ToString();
            label2.Text = e.Y.ToString();
            pBox.Select();
        }

        private void pBox_Paint(object sender, PaintEventArgs e)
        {
            for (l.First(); l.Eol(); l.Next())
            {
                l.GetObj().draw(e.Graphics);
            }
            pBox.Select();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cBoxShape.SelectedItem = "Круг";
            cBoxColor.SelectedItem = "Синий";
            radioBSelect.Select();
            pBox.KeyDown += new KeyEventHandler(pBox_KeyDown); 
            pBox.Select();
        }

       
    }
}

