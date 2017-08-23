using e_sim_ultimate.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Net;

namespace e_sim_ultimate_2
{
    public partial class Form1 : Form
    {
        #region addition
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect, // x-coordinate of upper-left corner
            int nTopRect, // y-coordinate of upper-left corner
            int nRightRect, // x-coordinate of lower-right corner
            int nBottomRect, // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        #endregion

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            
        }

        void circPIC(PictureBox a)
        {
            System.Drawing.Drawing2D.GraphicsPath gp = new System.Drawing.Drawing2D.GraphicsPath();
            gp.AddEllipse(0, 0, a.Width - 3, a.Height - 3);
            Region rg = new Region(gp);
            a.Region = rg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 550;
            this.Height = 500;
            tabControl1.Width = 380;
            addLists();
            addGlobalFunctions();
            comboBox1.SelectedIndex = 0;
            C.click(0, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        #region Lists of slide panel
        void addLists()
        {
            add_slide_panels();
            add_slide_labels();
            add_slide_pics();
        }

        List<Panel> panel_List = new List<Panel>();
        void add_slide_panels()
        {
            panel_List.Add(slide_panel_home);
            panel_List.Add(slide_panel_slidein);
            panel_List.Add(slide_panel_equi);
            panel_List.Add(slide_panel_money);
            panel_List.Add(slide_panel_merc);
            panel_List.Add(slide_panel_loan);
            panel_List.Add(slide_panel_2click);
        }

        List<Label> label_List = new List<Label>();
        void add_slide_labels()
        {
            label_List.Add(Home);
            label_List.Add(slide_label_slidein);
            label_List.Add(slide_label_equi);
            label_List.Add(slide_label_money);
            label_List.Add(slide_label_merc);
            label_List.Add(slide_label_loan);
            label_List.Add(slide_label_2click);
        }

        List<PictureBox> Picturebox_List = new List<PictureBox>();
        void add_slide_pics()
        {
            Picturebox_List.Add(slide_pic_home);
            Picturebox_List.Add(slide_pic_slidein);
            Picturebox_List.Add(slide_pic_equi);
            Picturebox_List.Add(slide_pic_money);
            Picturebox_List.Add(slide_pic_merc);
            Picturebox_List.Add(slide_pic_loan);
            Picturebox_List.Add(slide_pic_2click);
        }
        #endregion

        #region Global functions
        void addGlobalFunctions()
        {
            centreHome();
            centreLabels();
            centreIcons();

            clearText();
        }
        void centreHome()
        {
            slide_pic_home.Location = new Point(((slide_panel_home.Width) / 2) - 20, 5);
        }
        void centreLabels()
        {
            int x = 15;
            for (int i = 0; i < 6; i++)
            {
                label_List[i].Location = new Point(((slide_panel_home.Width) / 2) - 20, x);
            }
        }
        void centreIcons()
        {
            int x = 10;
            for (int i = 1; i < 7; i++)
            {
                Picturebox_List[i].Location = new Point(((slide_panel_home.Width) / 10), x);
            }
        }

        void clearText()
        {
            label_1_addition.Text = "";
            label_1_decide.Text = "";
        }
        #endregion

        #region Only Numbers

        #region Equipment
        private void textbox_0_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Money

        private void textbox_1_gold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
         (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_1_buy_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_1_sell_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_1_common_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (radio_1_goal.Checked)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // only allow one decimal point
                if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }
            else if (radio_1_redo.Checked)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }

        private void radio_1_goal_Enter(object sender, EventArgs e)
        {
            textbox_1_common.Clear();
        }

        private void radio_1_redo_Enter(object sender, EventArgs e)
        {
            textbox_1_common.Clear();
        }


        #endregion

        #region Merc
        private void textbox_2_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_2_BH_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textbox_2_damage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_2_medkits_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textbox_2_before_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textbox_2_after_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textbox_2_price_limits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }


        #endregion

        #region Loan
        private void textbox_3_loan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_3_interest_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_3_duration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion

        #region Two Clickers
        private void textbox_4_gold_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_4_salary_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_4_foodprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_4_giftprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_4_weaponprice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_4_avoidChance_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void textbox_4_limitfood_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textbox_4_limitgift_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textbox_4_duration_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }


        #endregion

        #endregion

        // Classes Declaration
        Colouring C = new Colouring();
        Equipment E = new Equipment();
        TwoClickers T = new TwoClickers();
        Merc M = new Merc();
        //Using Colouring

        #region Tabs colour changer

        #region Home
        private void slide_panel_home_Click(object sender, EventArgs e)
        {
            int x = 0;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        private void slide_panel_home_MouseEnter(object sender, EventArgs e)
        {
            int x = 0;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_home_MouseLeave(object sender, EventArgs e)
        {
            int x = 0;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_home_Click(object sender, EventArgs e)
        {
            int x = 0;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        private void slide_pic_home_MouseEnter(object sender, EventArgs e)
        {
            int x = 0;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_home_MouseLeave(object sender, EventArgs e)
        {
            int x = 0;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }


        #endregion

        #region Slider


        private void slide_panel_slidein_MouseEnter(object sender, EventArgs e)
        {
            int x = 1;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_slidein_MouseLeave(object sender, EventArgs e)
        {
            int x = 1;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }


        private void slide_label_slidein_MouseEnter(object sender, EventArgs e)
        {
            int x = 1;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);

        }

        private void slide_label_slidein_MouseLeave(object sender, EventArgs e)
        {
            int x = 1;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }



        private void slide_pic_slidein_MouseEnter(object sender, EventArgs e)
        {
            int x = 1;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_slidein_MouseLeave(object sender, EventArgs e)
        {
            int x = 1;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }
        #endregion

        #region Equipment
        //Panel
        private void slide_panel_equi_MouseEnter(object sender, EventArgs e)
        {
            int x = 2;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_equi_MouseLeave(object sender, EventArgs e)
        {
            int x = 2;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_equi_Click(object sender, EventArgs e)
        {
            int x = 2;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //label

        private void slide_label_equi_MouseEnter(object sender, EventArgs e)
        {
            int x = 2;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_equi_MouseLeave(object sender, EventArgs e)
        {
            int x = 2;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_equi_Click(object sender, EventArgs e)
        {
            int x = 2;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //picture
        private void slide_pic_equi_MouseEnter(object sender, EventArgs e)
        {
            int x = 2;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_equi_MouseLeave(object sender, EventArgs e)
        {
            int x = 2;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_equi_Click(object sender, EventArgs e)
        {
            int x = 2;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }
        #endregion

        #region Money
        //Panel
        private void slide_panel_money_MouseEnter(object sender, EventArgs e)
        {
            int x = 3;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_money_MouseLeave(object sender, EventArgs e)
        {
            int x = 3;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_money_Click(object sender, EventArgs e)
        {
            int x = 3;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //label

        private void slide_label_money_MouseEnter(object sender, EventArgs e)
        {
            int x = 3;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_money_MouseLeave(object sender, EventArgs e)
        {
            int x = 3;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_money_Click(object sender, EventArgs e)
        {
            int x = 3;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //picture
        private void slide_pic_money_MouseEnter(object sender, EventArgs e)
        {
            int x = 3;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_money_MouseLeave(object sender, EventArgs e)
        {
            int x = 3;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_money_Click(object sender, EventArgs e)
        {
            int x = 3;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }
        #endregion

        #region Mercenaries
        //Panel
        private void slide_panel_merc_MouseEnter(object sender, EventArgs e)
        {
            int x = 4;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_merc_MouseLeave(object sender, EventArgs e)
        {
            int x = 4;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_merc_Click(object sender, EventArgs e)
        {
            int x = 4;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //label

        private void slide_label_merc_MouseEnter(object sender, EventArgs e)
        {
            int x = 4;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_merc_MouseLeave(object sender, EventArgs e)
        {
            int x = 4;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_merc_Click(object sender, EventArgs e)
        {
            int x = 4;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //picture
        private void slide_pic_merc_MouseEnter(object sender, EventArgs e)
        {
            int x = 4;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_merc_MouseLeave(object sender, EventArgs e)
        {
            int x = 4;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_merc_Click(object sender, EventArgs e)
        {
            int x = 4;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }
        #endregion

        #region Loan
        // panel
        private void slide_panel_loan_MouseEnter(object sender, EventArgs e)
        {
            int x = 5;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_loan_MouseLeave(object sender, EventArgs e)
        {
            int x = 5;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_loan_Click(object sender, EventArgs e)
        {
            int x = 5;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //label

        private void slide_label_loan_MouseEnter(object sender, EventArgs e)
        {
            int x = 5;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_loan_MouseLeave(object sender, EventArgs e)
        {
            int x = 5;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_loan_Click(object sender, EventArgs e)
        {
            int x = 5;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //picture
        private void slide_pic_loan_MouseEnter(object sender, EventArgs e)
        {
            int x = 5;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_loan_MouseLeave(object sender, EventArgs e)
        {
            int x = 5;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_loan_Click(object sender, EventArgs e)
        {
            int x = 5;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }
        #endregion

        #region Two Clickers

        //Panel
        private void slide_panel_2click_MouseEnter(object sender, EventArgs e)
        {
            int x = 6;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_2click_MouseLeave(object sender, EventArgs e)
        {
            int x = 6;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_panel_2click_Click(object sender, EventArgs e)
        {
            int x = 6;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //label

        private void slide_label_2click_MouseEnter(object sender, EventArgs e)
        {
            int x = 6;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_2click_MouseLeave(object sender, EventArgs e)
        {
            int x = 6;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_label_2click_Click(object sender, EventArgs e)
        {
            int x = 6;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        //picture
        private void slide_pic_2click_MouseEnter(object sender, EventArgs e)
        {
            int x = 6;
            C.enter(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_2click_MouseLeave(object sender, EventArgs e)
        {
            int x = 6;
            C.leave(x, ref panel_List, ref label_List, ref Picturebox_List);
        }

        private void slide_pic_2click_Click(object sender, EventArgs e)
        {
            int x = 6;
            C.click(x, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }
        #endregion

        #endregion


        //---------
        //- Real stuff coding
        //---------

        #region  Equipment

        #region Comboboxes
        private void comb_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            E.change_colors(ref comb_from, ref comb_to, ref EQ1);
            EQ2.Image = Resources.Bulletproof_Vest_96px;
        }

        private void comb_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            E.change_color_2(ref comb_from, ref comb_to, ref EQ2);
        }

        #endregion

        #region Action
        private void button_0_ok_Click(object sender, EventArgs e)
        {
            if (comb_from.Text == "" || comb_to.Text == "")
                MessageBox.Show("Select your qualities please");

            else if (textbox_0_price.Text == "")
                MessageBox.Show("Please enter the price");

            else
            {
                double price = double.Parse(textbox_0_price.Text);
                int tot = 1;

                E.decide_equation(comb_from.SelectedIndex, comb_to.SelectedIndex, ref price, ref tot);
                textbox_0_cost.Text = price.ToString();
                textbox_0_totequ.Text = tot.ToString();
            }
        }
        #endregion

        #endregion

        #region Money

        #region Action

        private void button_1_ok_Click(object sender, EventArgs e)
        {
            if (textbox_1_gold.Text == "" || textbox_1_buy_price.Text == "" || textbox_1_sell_price.Text == "" || textbox_1_common.Text == "")
                MessageBox.Show("Fill the empty Boxes");
            else if (!radio_1_goal.Checked && !radio_1_redo.Checked)
                MessageBox.Show("Please, choose which mode you want to be on");
            else
            {
                // decalring vars
                double cGold = double.Parse(textbox_1_gold.Text); // current gold
                double bPrice = double.Parse(textbox_1_buy_price.Text); // buy price
                double sPrice = double.Parse(textbox_1_sell_price.Text); // sell price
                double goal = double.Parse(textbox_1_common.Text); // setting the goal
                double increment = bPrice * sPrice;

                // checking if prices are going up or not
                if (increment <= 1)
                {
                    MessageBox.Show("These prices will make you lose gold\nPlease change them.");
                }

                else
                {
                    if (radio_1_goal.Checked)
                    {
                        int x = 0; // redo times

                        while (goal >= cGold)
                        {
                            cGold *= increment;
                            x++;
                        }
                        double yy = cGold - goal;

                        label_1_addition.Text = "+ " + (Convert.ToInt32(yy)).ToString();
                        label_1_addition.ForeColor = Color.LightGreen;

                        label_1_decide.Text = "redo";
                        textbox_1_result.Text = Convert.ToInt32(x).ToString();
                    }
                    else
                    {
                        for (int i = 0; i < goal; i++)
                        {
                            cGold *= increment;
                        }
                        label_1_decide.Text = "gain";
                        label_1_addition.Text = "";

                        textbox_1_result.Text = Convert.ToInt32(cGold).ToString();
                    }
                }
            }
        }

        private void button_1_clear_Click(object sender, EventArgs e)
        {
            textbox_1_gold.Text = "";
            textbox_1_buy_price.Text = "";
            textbox_1_sell_price.Text = "";
            textbox_1_common.Text = "";
            textbox_1_result.Text = "";
            label_1_addition.Text = "";
            label_1_decide.Text = "";
        }


        #endregion
        private void radio_1_goal_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Goal";
        }

        private void radio_1_redo_CheckedChanged(object sender, EventArgs e)
        {
            label1.Text = "Redo";
        }

        #endregion

        #region Merc

        #region List of textboxes
        List<TextBox> texts = new List<TextBox>();
        void fill()
        {
            texts.Add(textbox_2_price); // 1 kk price     0
            texts.Add(textbox_2_damage); // damage done   1
            texts.Add(textbox_2_BH); // BH got            2
            texts.Add(textbox_2_medkits); // medkits used 3


            texts.Add(textbox_2_prize); //  gain          4
            texts.Add(textbox_2_expenses); // expenses    5
            texts.Add(textbox_2_profit); // final profit  6
        }

        #endregion

        #region Radiobox access
        private void q5FoodRadioBox_Click(object sender, EventArgs e)
        {
            M.easyAcc(0, "Limits", ref label_2_limits, ref textbox_2_before, ref textbox_2_after, ref textbox_2_price_limits);
        }

        private void q5GiftRadioBox_Click(object sender, EventArgs e)
        {
            M.easyAcc(1, "Limits", ref label_2_limits, ref textbox_2_before, ref textbox_2_after, ref textbox_2_price_limits);
        }

        private void q5WeaponRadioBox_Click(object sender, EventArgs e)
        {
            M.easyAcc(2, "Quantity", ref label_2_limits, ref textbox_2_before, ref textbox_2_after, ref textbox_2_price_limits);
        }

        private void q1WeaponRadioBox_Click(object sender, EventArgs e)
        {
            M.easyAcc(3, "Quantity", ref label_2_limits, ref textbox_2_before, ref textbox_2_after, ref textbox_2_price_limits);
        }

        #endregion

        #region Textbox decision maker
        private void textbox_2_before_TextChanged(object sender, EventArgs e)
        {
            if (textbox_2_before.Text != "")
            {
                if (q5FoodRadioBox.Checked)
                    M.assignB(0, ref textbox_2_before);

                else if (q5GiftRadioBox.Checked)
                    M.assignB(1, ref textbox_2_before);

                else if (q5WeaponRadioBox.Checked)
                    M.assignB(2, ref textbox_2_before);

                else if (q1WeaponRadioBox.Checked)
                    M.assignB(3, ref textbox_2_before);
            }
        }

        private void textbox_2_after_TextChanged(object sender, EventArgs e)
        {
            if (q5FoodRadioBox.Checked)
                M.assignA(0, ref textbox_2_after);

            else if (q5GiftRadioBox.Checked)
                M.assignA(1, ref textbox_2_after);

            else if (q5WeaponRadioBox.Checked)
                M.assignA(2, ref textbox_2_after);

            else if (q1WeaponRadioBox.Checked)
                M.assignA(3, ref textbox_2_after);
        }

        private void textbox_2_price_limits_TextChanged(object sender, EventArgs e)
        {
            if (q5FoodRadioBox.Checked)
                M.assignP(0, ref textbox_2_price_limits);

            else if (q5GiftRadioBox.Checked)
                M.assignP(1, ref textbox_2_price_limits);

            else if (q5WeaponRadioBox.Checked)
                M.assignP(2, ref textbox_2_price_limits);

            else if (q1WeaponRadioBox.Checked)
                M.assignP(3, ref textbox_2_price_limits);
        }
        #endregion

        #region Lose Focus
        private void textbox_2_before_Leave(object sender, EventArgs e)
        {
            if (textbox_2_before.Text == "")
                textbox_2_before.Text = "0";
        }

        private void textbox_2_after_Leave(object sender, EventArgs e)
        {
            if (textbox_2_after.Text == "")
                textbox_2_after.Text = "0";
        }

        private void textbox_2_price_limits_Leave(object sender, EventArgs e)
        {
            if (textbox_2_price_limits.Text == "")
                textbox_2_price_limits.Text = "0";
        }
        #endregion

        #region Action
        private void Action_Click(object sender, EventArgs e)
        {
            fill();
            M.action(texts);
        }

        #endregion

        #endregion

        #region Loan - no class needed

        #region Action
        private void button6_Click(object sender, EventArgs e)
        {
            if (textbox_3_loan.Text == "" || textbox_3_interest.Text == "" || textbox_3_duration.Text == "")
                MessageBox.Show("Fill all the gaps please.");
            else if (!radio_3_gold.Checked && !radio_3_precent.Checked)
                MessageBox.Show("Choose a mode to conintue");
            else
            {
                double ln = double.Parse(textbox_3_loan.Text);
                double inte = double.Parse(textbox_3_interest.Text);
                int days = int.Parse(textbox_3_duration.Text);
                double payment;

                if (radio_3_precent.Checked)
                {

                    inte /= 100;

                    payment = ln;
                    inte *= ln;
                    payment += (inte * days);
                    textbox_3_payment.Text = payment.ToString();
                }
                else
                {
                    inte *= days;
                    payment = ln + inte;
                    textbox_3_payment.Text = payment.ToString();
                }
            }
        }
        #endregion

        #endregion

        #region Two Clickers

        #region List of textboxes needed
        List<TextBox> twoClickers = new List<TextBox>();

        void twoClickersFiller()
        {
            twoClickers.Add(textbox_4_gold);       // 0
            twoClickers.Add(textbox_4_salary);     // 1
            twoClickers.Add(textbox_4_limitfood);  // 2
            twoClickers.Add(textbox_4_limitgift);  // 3

            twoClickers.Add(textbox_4_foodprice);  // 4
            twoClickers.Add(textbox_4_giftprice);  // 5
            twoClickers.Add(textbox_4_weaponprice);// 6

            twoClickers.Add(textbox_4_duration);   // 7
            twoClickers.Add(textbox_4_avoidChance);// 8

            twoClickers.Add(textbox_4_totalgold);  // 9
            twoClickers.Add(textbox_4_leftovers);  // 10

            twoClickers.Add(textbox_4_neededfood); // 11
            twoClickers.Add(textbox_4_neededgift); // 12
            twoClickers.Add(textbox_4_neededwea);  // 13

            twoClickers.Add(textbox_4_afffood);    // 14
            twoClickers.Add(textbox_4_affgift);    // 15
            twoClickers.Add(textbox_4_affweapon);  // 16

            twoClickers.Add(textbox_4_Pfood);      // 17
            twoClickers.Add(textbox_4_Pgift);      // 18
            twoClickers.Add(textbox_4_Pweapons);   // 19
        }

        #endregion

        #region Click and leave functions
        private void textbox_4_limitfood_Click(object sender, EventArgs e)
        {
            T.emptyTheBox(ref textbox_4_limitfood, "food");
        }

        private void textbox_4_limitfood_Leave(object sender, EventArgs e)
        {
            T.fillIfEmpty(ref textbox_4_limitfood, "food");
        }

        private void textbox_4_limitgift_Click(object sender, EventArgs e)
        {
            T.emptyTheBox(ref textbox_4_limitgift, "gift");
        }

        private void textbox_4_limitgift_Leave(object sender, EventArgs e)
        {
            T.fillIfEmpty(ref textbox_4_limitgift, "gift");
        }

        private void textbox_4_foodprice_Click(object sender, EventArgs e)
        {
            T.emptyTheBox(ref textbox_4_foodprice, "food");
        }

        private void textbox_4_foodprice_Leave(object sender, EventArgs e)
        {
            T.fillIfEmpty(ref textbox_4_foodprice, "food");
        }

        private void textbox_4_giftprice_Click(object sender, EventArgs e)
        {
            T.emptyTheBox(ref textbox_4_giftprice, "gift");
        }

        private void textbox_4_giftprice_Leave(object sender, EventArgs e)
        {
            T.fillIfEmpty(ref textbox_4_giftprice, "gift");
        }

        private void textbox_4_weaponprice_Click(object sender, EventArgs e)
        {
            T.emptyTheBox(ref textbox_4_weaponprice, "weapon");
        }

        private void textbox_4_weaponprice_Leave(object sender, EventArgs e)
        {
            T.fillIfEmpty(ref textbox_4_weaponprice, "weapon");
        }

        private void textbox_4_avoidChance_Click(object sender, EventArgs e)
        {
            T.emptyTheBox(ref textbox_4_avoidChance, "5");
        }

        private void textbox_4_avoidChance_Leave(object sender, EventArgs e)
        {
            if (textbox_4_avoidChance.Text == "" || double.Parse(textbox_4_avoidChance.Text) <= 5)
            {
                textbox_4_avoidChance.Text = "5";
                textbox_4_avoidChance.ForeColor = Color.Gray;
            }
        }

        #endregion

        #region Action
        private void button_4_ok_Click(object sender, EventArgs e)
        {
            textbox_4_gold.Focus();
            twoClickersFiller();

            if (!T.checkEmpty(twoClickers))
            {
                T.needed_Supplies(ref twoClickers, checkbox_4_motivating, numeric_4_medkits);
                T.getAffordableandPrice(ref twoClickers);
            }
        }

        #endregion

        #endregion

        //-----FUCKING SHIT TIMERS
        #region Timer
        bool shit = true;

        void minimizeSlide()
        {
            hideControls(tabControl1.SelectedIndex);
            int i = 3, yy = 1; ;
            while (panel1.Width != 65)
            {
                panel1.Width -= i;
                tabControl1.Left -= i;
                tabControl1.Width += i;
                //ESIM.Left += i;


                moving_to_centre();
                tabControl1.Refresh();
                panel1.Refresh();

                System.Threading.Thread.Sleep(1);
            }
            showControls(tabControl1.SelectedIndex);
            while (i < 15)
            {
                moving_tabs();
                tabControl1.Refresh();
                i++;
            }
            shit = false;
        }

        void maximizeSlide()
        {
            hideControls(tabControl1.SelectedIndex);
            int i = 3, yy = 1;
            while (panel1.Width != 185)
            {
                panel1.Width += i;
                tabControl1.Left += i;
                tabControl1.Width -= i;
                //ESIM.Left -= i;



                moving_to_centre();
                tabControl1.Refresh();
                panel1.Refresh();

                System.Threading.Thread.Sleep(1);
            }
            showControls(tabControl1.SelectedIndex);
            while (i < 15)
            {
                moving_tabs();
                tabControl1.Refresh();
                i++;
            }

            shit = true;
        }

        void moving_to_centre()
        {
            slide_pic_home.Location = new Point(panel1.Width / 2 - 20, 5);
            //PP.Location = new Point(((Facebook.Location.X + ESIM.Location.X) / 2), 30);
        }

        void moving_tabs()
        {
            TabPa();
            int o = 5;
            if (shit == true)
                for (int i = 0; i < 5; i++)
                {
                    foreach (Label l in a[i].Controls.OfType<Label>())
                        l.Left += o;
                    foreach (TextBox l in a[i].Controls.OfType<TextBox>())
                        l.Left += o;
                    foreach (Button l in a[i].Controls.OfType<Button>())
                        l.Left += o;
                    foreach (PictureBox l in a[i].Controls.OfType<PictureBox>())
                        l.Left += o;
                    foreach (RadioButton l in a[i].Controls.OfType<RadioButton>())
                        l.Left += o;
                    foreach (CheckBox l in a[i].Controls.OfType<CheckBox>())
                        l.Left += o;
                    foreach (ComboBox l in a[i].Controls.OfType<ComboBox>())
                        l.Left += o;
                    foreach (ProgressBar l in a[i].Controls.OfType<ProgressBar>())
                        l.Left += o;
                }
            if (shit == false)
                for (int i = 0; i < 5; i++)
                {
                    foreach (Label l in a[i].Controls.OfType<Label>())
                        l.Left -= o;
                    foreach (TextBox l in a[i].Controls.OfType<TextBox>())
                        l.Left -= o;
                    foreach (Button l in a[i].Controls.OfType<Button>())
                        l.Left -= o;
                    foreach (PictureBox l in a[i].Controls.OfType<PictureBox>())
                        l.Left -= o;
                    foreach (RadioButton l in a[i].Controls.OfType<RadioButton>())
                        l.Left -= o;
                    foreach (CheckBox l in a[i].Controls.OfType<CheckBox>())
                        l.Left -= o;
                    foreach (ComboBox l in a[i].Controls.OfType<ComboBox>())
                        l.Left -= o;
                    foreach (ProgressBar l in a[i].Controls.OfType<ProgressBar>())
                        l.Left -= o;
                }


        }

        void hideControls(int i)
        {
            TabPa();
            foreach (Label l in a[i].Controls.OfType<Label>())
                l.Hide();
            foreach (TextBox l in a[i].Controls.OfType<TextBox>())
                l.Hide();
            foreach (Button l in a[i].Controls.OfType<Button>())
                l.Hide();
            foreach (PictureBox l in a[i].Controls.OfType<PictureBox>())
                l.Hide();
            foreach (RadioButton l in a[i].Controls.OfType<RadioButton>())
                l.Hide();
            foreach (CheckBox l in a[i].Controls.OfType<CheckBox>())
                l.Hide();
            foreach (ComboBox l in a[i].Controls.OfType<ComboBox>())
                l.Hide();
            foreach (ProgressBar l in a[i].Controls.OfType<ProgressBar>())
                l.Hide();
            foreach (NumericUpDown l in a[i].Controls.OfType<NumericUpDown>())
                l.Hide();
        }

        void showControls(int i)
        {
            TabPa();
            foreach (Label l in a[i].Controls.OfType<Label>())
                l.Show();
            foreach (TextBox l in a[i].Controls.OfType<TextBox>())
                l.Show();
            foreach (Button l in a[i].Controls.OfType<Button>())
                l.Show();
            foreach (PictureBox l in a[i].Controls.OfType<PictureBox>())
                l.Show();
            foreach (RadioButton l in a[i].Controls.OfType<RadioButton>())
                l.Show();
            foreach (CheckBox l in a[i].Controls.OfType<CheckBox>())
                l.Show();
            foreach (ComboBox l in a[i].Controls.OfType<ComboBox>())
                l.Show();
            foreach (ProgressBar l in a[i].Controls.OfType<ProgressBar>())
                l.Show();
            foreach (NumericUpDown l in a[i].Controls.OfType<NumericUpDown>())
                l.Show();
        }

        List<TabPage> a = new List<TabPage>();

        void TabPa()
        {
            a.Add(tabPage1);
            a.Add(tabPage2);
            a.Add(tabPage3);
            a.Add(tabPage4);
            a.Add(tabPage5);
            a.Add(tabPage6);
        }

        private void slide_panel_slidein_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 5)
            {
                if (shit == true)
                {
                    minimizeSlide();
                }
                else
                {
                    maximizeSlide();
                }
            }

        }

        private void slide_label_slidein_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 5)
            {
                if (shit == true)
                {
                    minimizeSlide();
                }
                else
                {
                    maximizeSlide();
                }
            }
        }

        private void slide_pic_slidein_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex != 5)
            {
                if (shit == true)
                {
                    minimizeSlide();
                }
                else
                {
                    maximizeSlide();
                }
            }
        }
        #endregion

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                case 1:
                    break;

                case 2:
                    radio_1_goal.Focus();
                    break;

                case 3:
                    q5FoodRadioBox.Focus();
                    break;

                case 4:
                    radio_3_gold.Focus();
                    break;

                case 5:
                    if (shit == true)
                        minimizeSlide();
                    break;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        
        

        #region Theme Manager
        void ColorfulICO()
        {
            slide_pic_2click.Image = Resources.CTwo_Fingers_96px;
            slide_pic_equi.Image = Resources.CBulletproof_Vest_96px;
            slide_pic_home.Image = Resources.CHome_96px;
            slide_pic_loan.Image = Resources.CApprove_96px;
            slide_pic_merc.Image = Resources.CGun_96px;
            slide_pic_money.Image = Resources.CMoney_Bag_96px;
            slide_pic_slidein.Image = Resources.CSorting_Arrows_Horizontal_96px;
            pictureBox1.Image = Resources.CRequest_Money_96px;
            pictureBox14.Image = Resources.CRequest_Money_96px;
        }
        void ColorlessICO()
        {
            slide_pic_2click.Image = Resources.MTwo_Fingers_96px;
            slide_pic_equi.Image = Resources.MBulletproof_Vest_96px;
            slide_pic_home.Image = Resources.MHome_96px;
            slide_pic_loan.Image = Resources.MApprove_96px;
            slide_pic_merc.Image = Resources.Gun_40px;
            slide_pic_money.Image = Resources.MMoney_Bag_96px;
            slide_pic_slidein.Image = Resources.MSorting_Arrows_Horizontal_96px;
            pictureBox1.Image = Resources.MRequest_Money_96px;
            pictureBox14.Image = Resources.MRequest_Money_96px;
        }

        void blackTheme()
        {
            ColorlessICO();
            string a = "#505050";
            string b = "#808080";
            string c = "#FFA500";

            C.MainForm = a;
            C.Shadow = b;
            C.ClickCo = c;

            panel1.BackColor = Color.FromArgb(80, 80, 80);
            panel2.BackColor = Color.FromArgb(80, 80, 80);
            panel4.BackColor = Color.FromArgb(80, 80, 80);

            tabPage1.BackColor = Color.FromArgb(48, 48, 48);

            foreach (Panel l in panel1.Controls.OfType<Panel>())
            {
                l.BackColor = ColorTranslator.FromHtml(a);

                foreach (Label x in l.Controls.OfType<Label>())
                    x.BackColor = ColorTranslator.FromHtml(a);

                foreach (PictureBox m in l.Controls.OfType<PictureBox>())
                    m.BackColor = ColorTranslator.FromHtml(a);
            }


            foreach (TabPage l in tabControl1.Controls.OfType<TabPage>())
                l.BackColor = Color.FromArgb(48, 48, 48);

            foreach (TabPage l in tabControl1.Controls.OfType<TabPage>())
            {
                l.BackColor = Color.FromArgb(48, 48, 48);

                foreach (Label m in l.Controls.OfType<Label>())
                    m.ForeColor = Color.White;

                foreach (RadioButton m in l.Controls.OfType<RadioButton>())
                    m.ForeColor = Color.White;

                foreach (CheckBox m in l.Controls.OfType<CheckBox>())
                    m.ForeColor = Color.White;

                foreach (Panel m in l.Controls.OfType<Panel>())
                    m.BackColor = Color.FromArgb(80, 80, 80);
                    
            }


            panel1.Refresh();
        }

        void ColorFulish(string a, string b, string c)
        {
            C.MainForm = a;
            C.Shadow = b;
            C.ClickCo = c;

            panel1.BackColor = ColorTranslator.FromHtml(a);
            panel2.BackColor = ColorTranslator.FromHtml(a);

            foreach (Panel l in panel1.Controls.OfType<Panel>())
            {
                l.BackColor = ColorTranslator.FromHtml(a);

                foreach (Label x in l.Controls.OfType<Label>())
                    x.BackColor = ColorTranslator.FromHtml(a);

                foreach (PictureBox m in l.Controls.OfType<PictureBox>())
                    m.BackColor = ColorTranslator.FromHtml(a);
            }

            foreach (TabPage l in tabControl1.Controls.OfType<TabPage>())
            {
                l.BackColor = Color.WhiteSmoke;

                foreach (Label m in l.Controls.OfType<Label>())
                    m.ForeColor = Color.Black;

                foreach (RadioButton m in l.Controls.OfType<RadioButton>())
                    m.ForeColor = Color.Black;

                foreach (CheckBox m in l.Controls.OfType<CheckBox>())
                    m.ForeColor = Color.Black;

                foreach (Panel m in l.Controls.OfType<Panel>())
                    m.BackColor = ColorTranslator.FromHtml(a);

            }
        }

         void blueTheme()
        {
            ColorfulICO();

            string a = "#1f4788";
            string b = "#3399FF";
            string c = "#1b70f9";

            ColorFulish(a, b, c);

            panel1.Refresh();

        }

        void greenTheme()
        {
            ColorfulICO();
            string a = "#397249";
            string b = "#628B61";
            string c = "#9CB770";

            ColorFulish(a, b, c);

            panel1.Refresh();
        }

        void redTheme()
        {
            ColorfulICO();
            string a = "#bb0000";
            string b = "#d2d2d2";
            string c = "#EBB035";

            ColorFulish(a, b, c);

            panel1.Refresh();
        }

        #endregion

        private void close_label_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void close_label_MouseEnter(object sender, EventArgs e)
        {
            close_label.ForeColor = Color.Gray;
            close_label.Cursor = Cursors.Hand;
        }

        private void close_label_MouseLeave(object sender, EventArgs e)
        {
            close_label.ForeColor = Color.White;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    blackTheme();
                    break;

                case 1:
                    blueTheme();

                    break;

                case 2:
                    greenTheme();

                    break;

                case 3:
                    redTheme();

                    break;
            }
            C.click(0, ref panel_List, ref label_List, ref Picturebox_List, ref tabControl1);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.facebook.com/moha.khamis2");
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.paypal.me/MohammedFarid1");
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.linkedin.com/in/mohamedkhamis8/");
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            Process.Start("https://suna.e-sim.org/profile.html?id=345790");
        }

        private void pictureBox5_MouseEnter(object sender, EventArgs e)
        {
            pictureBox5.Cursor = Cursors.Hand;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Cursor = Cursors.Hand;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Cursor = Cursors.Hand;
        }

        private void pictureBox9_MouseEnter(object sender, EventArgs e)
        {
            pictureBox9.Cursor = Cursors.Hand;
        }

        private void pictureBox8_MouseEnter(object sender, EventArgs e)
        {
            pictureBox8.Cursor = Cursors.Hand;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Gray;
            label7.Cursor = Cursors.Hand;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.White;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Process.Start("https://youtu.be/DkTL2dUS-Ws");
        }
    }
}