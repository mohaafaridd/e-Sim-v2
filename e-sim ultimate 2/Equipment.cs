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
    class Equipment
    {
        public void change_colors(ref ComboBox z, ref ComboBox x, ref PictureBox y)
        {
            switch (z.SelectedIndex)
            {
                case 0:
                    y.Image = Resources.Bulletproof_Vest_96px_red;
                    break;
                case 1:
                    y.Image = Resources.Bulletproof_Vest_96px_Orange;
                    break;
                case 2:
                    y.Image = Resources.Bulletproof_Vest_96px_yello;
                    break;
                case 3:
                    y.Image = Resources.Bulletproof_Vest_96px_green;
                    break;
                case 4:
                    y.Image = Resources.Bulletproof_Vest_96px_purple;
                    break;
                default:
                    y.Image = Resources.Bulletproof_Vest_96px;
                    break;
            }
            add(ref z, ref x);
        }

        public void change_color_2(ref ComboBox z, ref ComboBox x, ref PictureBox y)
        {
            switch (z.SelectedIndex)
            {
                case 0:
                    switch (x.SelectedIndex)
                    {
                        case 0:
                            y.Image = Resources.Bulletproof_Vest_96px_Orange;
                            break;
                        case 1:
                            y.Image = Resources.Bulletproof_Vest_96px_yello;
                            break;
                        case 2:
                            y.Image = Resources.Bulletproof_Vest_96px_green;
                            break;
                        case 3:
                            y.Image = Resources.Bulletproof_Vest_96px_purple;
                            break;
                        case 4:
                            y.Image = Resources.Bulletproof_Vest_96px_blue;
                            break;
                    }
                    break;
                case 1:
                    switch (x.SelectedIndex)
                    {
                        case 0:
                            y.Image = Resources.Bulletproof_Vest_96px_yello;
                            break;
                        case 1:
                            y.Image = Resources.Bulletproof_Vest_96px_green;
                            break;
                        case 2:
                            y.Image = Resources.Bulletproof_Vest_96px_purple;
                            break;
                        case 3:
                            y.Image = Resources.Bulletproof_Vest_96px_blue;
                            break;

                    }
                    break;
                case 2:
                    switch (x.SelectedIndex)
                    {
                        case 0:
                            y.Image = Resources.Bulletproof_Vest_96px_green;
                            break;
                        case 1:
                            y.Image = Resources.Bulletproof_Vest_96px_purple;
                            break;
                        case 2:
                            y.Image = Resources.Bulletproof_Vest_96px_blue;
                            break;

                    }
                    break;
                case 3:
                    switch (x.SelectedIndex)
                    {
                        case 0:
                            y.Image = Resources.Bulletproof_Vest_96px_purple;
                            break;
                        case 1:
                            y.Image = Resources.Bulletproof_Vest_96px_blue;
                            break;

                    }
                    break;
                case 4:
                    switch (x.SelectedIndex)
                    {
                        case 0:
                            y.Image = Resources.Bulletproof_Vest_96px_blue;
                            break;

                    }
                    break;
            }
        }

        string[] arr = { "Q2", "Q3", "Q4", "Q5", "Q6" };

        void add(ref ComboBox z, ref ComboBox x)
        {
            x.Items.Clear();

            for (int i = z.SelectedIndex; i < 5; i++)
            {
                x.Items.Add(arr[i]);
            }

        }


        double toQ2(ref double equPrice, ref int totequ)
        {
            totequ *= 3;
            equPrice *= 3;
            equPrice += 0.3;
            return equPrice;
        }
        double toQ3(ref double equPrice, ref int totequ)
        {
            totequ *= 3;
            equPrice *= 3;
            equPrice += 1;
            return equPrice;
        }
        double toQ4(ref double equPrice, ref int totequ)
        {
            totequ *= 3;
            equPrice *= 3;
            equPrice += 3;
            return equPrice;
        }
        double toQ5(ref double equPrice, ref int totequ)
        {
            totequ *= 3;
            equPrice *= 3;
            equPrice += 9;
            return equPrice;
        }
        double toQ6(ref double equPrice, ref int totequ)
        {
            totequ *= 3;
            equPrice *= 3;
            equPrice += 27;
            return equPrice;
        }

        public void decide_equation(int first_index, int sec_index, ref double price, ref int tote)
        {
            switch (first_index)
            {
                case 0: // from q1
                    switch (sec_index)
                    {
                        case 0: // to q2
                            toQ2(ref price, ref tote);
                            break;
                        case 1: // to q3
                            toQ2(ref price, ref tote);
                            toQ3(ref price, ref tote);
                            break;
                        case 2: // to q4
                            toQ2(ref price, ref tote);
                            toQ3(ref price, ref tote);
                            toQ4(ref price, ref tote);
                            break;
                        case 3: // to q5
                            toQ2(ref price, ref tote);
                            toQ3(ref price, ref tote);
                            toQ4(ref price, ref tote);
                            toQ5(ref price, ref tote);
                            break;
                        case 4: // to q6
                            toQ2(ref price, ref tote);
                            toQ3(ref price, ref tote);
                            toQ4(ref price, ref tote);
                            toQ5(ref price, ref tote);
                            toQ6(ref price, ref tote);
                            break;
                    }
                    break;

                case 1: // from q2
                    switch (sec_index)
                    {
                        case 0: // to q3
                            toQ3(ref price, ref tote);
                            break;
                        case 1: // to q4
                            toQ3(ref price, ref tote);
                            toQ4(ref price, ref tote);
                            break;
                        case 2: // to q5
                            toQ3(ref price, ref tote);
                            toQ4(ref price, ref tote);
                            toQ5(ref price, ref tote);
                            break;
                        case 3: // to q6
                            toQ3(ref price, ref tote);
                            toQ4(ref price, ref tote);
                            toQ5(ref price, ref tote);
                            toQ6(ref price, ref tote);
                            break;
                    }
                    break;

                case 2: // from q3
                    switch (sec_index)
                    {
                        case 0: // to q4
                            toQ4(ref price, ref tote);
                            toQ5(ref price, ref tote);
                            break;
                        case 1: // to q5
                            toQ4(ref price, ref tote);
                            toQ5(ref price, ref tote);
                            break;
                        case 2: // to q6
                            toQ4(ref price, ref tote);
                            toQ5(ref price, ref tote);
                            toQ6(ref price, ref tote);
                            break;
                    }
                    break;

                case 3: // from q4
                    switch (sec_index)
                    {
                        case 0: // to q5
                            toQ5(ref price, ref tote);
                            break;
                        case 1: // to q6
                            toQ5(ref price, ref tote);
                            toQ6(ref price, ref tote);
                            break;
                    }
                    break;

                case 4: // from q5
                    switch (sec_index)
                    {
                        case 0: // to q6
                            toQ6(ref price, ref tote);
                            break;
                    }
                    break;
            }


        }
    }
}
