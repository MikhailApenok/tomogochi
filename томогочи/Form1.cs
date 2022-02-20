using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace томогочи
{
    partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            init_game();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public void init_scale(Label lbl_cur, Label lbl_max, Scale scale )
        {
            lbl_cur.Text = scale.currect_value.ToString();
            lbl_max.Text = scale.max_value.ToString();
        } 
        void init_game()
        {
            new Settings();
            init_scale(lblEatCur, lblEatMax, Settings.eat);
            init_scale(lblSleepCur, lblSleepMax, Settings.sleep);
            init_scale(lblHappyCur, lblHappyMax, Settings.happy);
            init_scale(lblHPCur, lblHPMax, Settings.hp);
            init_scale(lblClearCur, lblClearMax, Settings.clear);

            lblGameOver.Visible = false;
        }
    }
}
