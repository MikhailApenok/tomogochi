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
            gameTimer.Interval = 1000 / Settings.speed;
            gameTimer.Start();
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
        bool is_die()
        {
            int cur_life = (
                Settings.eat.currect_value + 
                Settings.sleep.currect_value + 
                Settings.happy.currect_value + 
                Settings.clear.currect_value
                ) / 4;
            Settings.hp.currect_value = cur_life;
            if(
                Settings.eat.currect_value == 0 ||
                Settings.sleep.currect_value == 0 ||
                Settings.happy.currect_value == 0 ||
                Settings.clear.currect_value == 0
              )
            {
                Settings.hp.currect_value = 0;
                return true;
            }
            return false;
        }
        private void set_scales()
        {
            lblEatCur.Text = Settings.eat.currect_value.ToString();
            lblClearCur.Text = Settings.clear.currect_value.ToString();
            lblHappyCur.Text = Settings.happy.currect_value.ToString();
            lblSleepCur.Text = Settings.sleep.currect_value.ToString();
            lblHPCur.Text = Settings.hp.currect_value.ToString();
        }

        private void game_over_actions()
        {
            pbImage.BackgroundImage = Properties.Resources.умер;
            lblHPCur.Text = "0";
            lblGameOver.Visible = true;
            btnClear.Enabled = false;
            btnEat.Enabled = false;
            btnHappy.Enabled = false;
            btnSleep.Enabled = false;
        }

        private void btnEat_Click(object sender, EventArgs e)
        {
            Settings.eat = Settings.eat.add_value(Settings.add);
            Settings.clear = Settings.clear.sub_value(Settings.sub);
            Settings.happy = Settings.happy.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();

        }
        private void btnSleep_Click(object sender, EventArgs e)
        {
            Settings.sleep = Settings.sleep.add_value(Settings.add);
            Settings.eat = Settings.eat.sub_value(Settings.sub);
            Settings.clear = Settings.clear.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();

        }
        private void btnHappy_Click(object sender, EventArgs e)
        {
            Settings.happy = Settings.happy.add_value(Settings.add);
            Settings.sleep = Settings.sleep.sub_value(Settings.sub);
            Settings.eat = Settings.eat.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            Settings.clear = Settings.clear.add_value(Settings.add);
            Settings.happy = Settings.happy.sub_value(Settings.sub);
            Settings.sleep = Settings.sleep.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();
        }
        void generate_action(Random random)
        {
            List<Action> list = new List<Action>() { dec_eat, dec_clear, dec_sleep, dec_happy };
            int index = random.Next(list.Count);
            (list[index])();
        }
        void dec_clear()
        {
            Settings.clear.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();
        }
        void dec_eat()
        {
            Settings.eat.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();
        }
        void dec_sleep()
        {
            Settings.sleep.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();
        }
        void dec_happy()
        {
            Settings.happy.sub_value(Settings.sub);
            set_scales();
            Settings.is_gameover = is_die();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            if (Settings.is_gameover)
            {
                game_over_actions();
            }
            else
            {
                Random random = new Random();
                int is_action = random.Next(0,2);
                if(is_action == 1)
                {
                    generate_action(random);
                }
            }
        }
    }
}
