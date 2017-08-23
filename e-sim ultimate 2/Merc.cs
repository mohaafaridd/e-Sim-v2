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

namespace e_sim_ultimate_2
{
    class Merc
    {
        int[] before = { 0, 0, 0, 0 };
        int[] after_ = { 0, 0, 0, 0 };
        double[] price = { 0, 0, 0, 0 };

        public void easyAcc(int x, string y, ref Label a, ref TextBox a1, ref TextBox a2, ref TextBox a3)
        {
            a.Text = y;

            a1.Text = before[x].ToString();
            a2.Text = after_[x].ToString();
            a3.Text = price[x].ToString();
        }

        public void assignB(int x, ref TextBox a)
        {
            before[x] = int.Parse(a.Text);
        }

        public void assignA(int x, ref TextBox a)
        {
            after_[x] = int.Parse(a.Text);
        }

        public void assignP(int x, ref TextBox a)
        {
            price[x] = double.Parse(a.Text);
        }


        public void action(List<TextBox> x)
        {
            if (x[0].Text == "" || x[1].Text == "")
            {
                MessageBox.Show("Fill the necessary fields which are marked with *");
            }
            else
            {
                double kkPP = double.Parse(x[0].Text); // 1 Million dmg price
                double dmg = double.Parse(x[1].Text); // dmg done
                double BH; // number of BHs
                double meds; // number of meds used

                if (x[2].Text == "")
                    BH = 0;
                else
                    BH = double.Parse(x[2].Text);

                if (x[2].Text == "")
                    meds = 0;
                else
                    meds = double.Parse(x[2].Text);

                // - Total share
                double YourShare = (kkPP * dmg) + (BH * 5);
                x[4].Text = YourShare.ToString();

                // - Expenses
                double exFood;
                double exGift;

                exFood = before[0] - after_[0];
                exFood += meds * 10;
                exFood *= price[0];

                exGift = before[1] - after_[1];
                exGift += meds * 10;
                exGift *= price[1];

                double exWEQ5 = (before[2] - after_[2]) * price[2];
                double exWEQ1 = (before[3] - after_[3]) * price[3];
                double total = exFood + exGift + exWEQ1 + exWEQ5;
                x[5].Text = total.ToString();

                // - Net
                x[6].Text = (YourShare - total).ToString();
            }
        }
    }
}
