using e_sim_ultimate.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace e_sim_ultimate_2
{
    class Colouring
    {
        public string MainForm = "#505050";
        public string Shadow = "#808080";
        public string ClickCo = "#FFA500";

        void setColor(int x, ref List<Panel> a, ref List<Label> b, ref List<PictureBox> c, int color)
        {
            switch (color)
            {
                case 1:
                    a[x].BackColor = ColorTranslator.FromHtml(ClickCo);
                    b[x].BackColor = ColorTranslator.FromHtml(ClickCo);
                    c[x].BackColor = ColorTranslator.FromHtml(ClickCo);
                    break;

                case 2:
                    a[x].BackColor = ColorTranslator.FromHtml(Shadow);
                    b[x].BackColor = ColorTranslator.FromHtml(Shadow);
                    c[x].BackColor = ColorTranslator.FromHtml(Shadow);
                    break;

                case 3:
                    a[x].BackColor = ColorTranslator.FromHtml(MainForm);
                    b[x].BackColor = ColorTranslator.FromHtml(MainForm);
                    c[x].BackColor = ColorTranslator.FromHtml(MainForm);
                    break;
            }
        }
        
        void removeColor(int x, ref List<Panel> a, ref List<Label> b, ref List<PictureBox> c)
        {

            for (int i = 0; i < 7; i++)
            {
                if (a[i].BackColor == ColorTranslator.FromHtml(ClickCo))
                {
                    a[i].BackColor = ColorTranslator.FromHtml(MainForm);
                    b[i].BackColor = ColorTranslator.FromHtml(MainForm);
                    c[i].BackColor = ColorTranslator.FromHtml(MainForm);
                }
            }


        }

        void changeTabIndex(ref TabControl x, int y)
        {
            switch (y)
            {
                case 0:
                    x.SelectedIndex = y;
                    break;

                case 2:
                    x.SelectedIndex = y - 1;
                    break;

                case 3:
                    x.SelectedIndex = y - 1;
                    break;

                case 4:
                    x.SelectedIndex = y - 1;
                    break;

                case 5:
                    x.SelectedIndex = y - 1;
                    break;

                case 6:
                    x.SelectedIndex = y - 1;
                    break;

            }
        }

        public void click(int x, ref List<Panel> a, ref List<Label> b, ref List<PictureBox> c, ref TabControl d)
        {
            removeColor(x, ref a, ref b, ref c);
            setColor(x, ref a, ref b, ref c, 1);
            changeTabIndex(ref d, x);
        }

        public void enter(int x, ref List<Panel> a, ref List<Label> b, ref List<PictureBox> c)
        {
            a[x].Cursor = Cursors.Hand;

            if (a[x].BackColor != ColorTranslator.FromHtml(ClickCo))
            {
                setColor(x, ref a, ref b, ref c, 2);
            }

        }

        public void leave(int x, ref List<Panel> a, ref List<Label> b, ref List<PictureBox> c)
        {
            if (a[x].BackColor != ColorTranslator.FromHtml(ClickCo))
            {
                setColor(x, ref a, ref b, ref c, 3);
            }
        }


    }
}

