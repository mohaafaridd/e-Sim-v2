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
    class TwoClickers
    {
        public void emptyTheBox(ref TextBox a, string text)
        {
            if (a.Text == text)
            {
                a.Text = "";
                a.ForeColor = Color.Black;
            }

        }

        public void fillIfEmpty(ref TextBox a, string text)
        {
            if (a.Text == "")
            {
                a.Text = text;
                a.ForeColor = Color.Gray;
            }

        }

        public bool checkEmpty(List<TextBox> x)
        {
            double num;
            for (int i = 0; i < 8; i++)
            {
                if (!double.TryParse(x[i].Text, out num) || x[i].Text == "")
                {
                    MessageBox.Show("fill all the boxes");
                    return true;
                }
            }
            return false;
        }

        double gold = 0;

        void gold_Calculator(ref List<TextBox> list)
        {
            gold = 0;
            gold += double.Parse(list[0].Text);
            gold += double.Parse(list[1].Text) * double.Parse(list[7].Text);

            list[9].Text = gold.ToString();
        }

        int needed_food = 0;
        int needed_gift = 0;
        int needed_weapons = 0;

        void neededF(ref List<TextBox> list, CheckBox motivating, NumericUpDown medkits)
        {
            needed_food = 0;
            needed_food += int.Parse(list[2].Text);
            needed_food += Convert.ToInt32(medkits.Value) * 10;

            if (motivating.Checked == true)
            {
                needed_food += int.Parse(list[7].Text) * 5;
            }
            list[11].Text = needed_food.ToString();
        }

        void neededG(ref List<TextBox> list, NumericUpDown medkits)
        {
            needed_gift = 0;
            needed_gift += int.Parse(list[3].Text);
            needed_gift += Convert.ToInt32(medkits.Value) * 10;

            list[12].Text = needed_gift.ToString();
        }

        void neededW(ref List<TextBox> list)
        {
            double temp = 0;
            needed_weapons = 0;
            temp += needed_food * 5;
            temp += needed_gift * 5;
            temp += (needed_gift + needed_food) * double.Parse(list[8].Text) * 5 / 100;
            needed_weapons = Convert.ToInt32(temp);
            list[13].Text = needed_weapons.ToString();
        }

        public void needed_Supplies(ref List<TextBox> x, CheckBox a, NumericUpDown b)
        {
            gold_Calculator(ref x);
            neededF(ref x, a, b);
            neededG(ref x, b);
            neededW(ref x);
        }

        //Supply = needed food / gift / weapon which is a global var here :)
        void counter_function(ref List<TextBox> list, int supply, int supply_Price, int affordable_supply, int final_price)
        {
            int C = 0;
            double P = 0;

            for (int i = 0; i < supply; i++)
            {
                gold -= double.Parse(list[supply_Price].Text);

                if (gold <= 0)
                {
                    gold += double.Parse(list[supply_Price].Text);
                    break;
                }

                C++;
                P += double.Parse(list[supply_Price].Text);
            }

            list[affordable_supply].Text = Convert.ToSingle(C).ToString();
            list[final_price].Text = Convert.ToSingle(P).ToString();
        }

        public void getAffordableandPrice(ref List<TextBox> list)
        {
            counter_function(ref list, needed_food, 4, 14, 17);
            counter_function(ref list, needed_gift, 5, 15, 18);
            counter_function(ref list, needed_weapons, 6, 16, 19);

            list[10].Text = Convert.ToSingle(gold).ToString();
        }
    }
}
