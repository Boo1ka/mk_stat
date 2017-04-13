﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mk_stat
{
    public partial class Form1 : Form
    {
        int p1_score = 0;
        int p2_score = 0;
        String r_score = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void score_change(int player, char end)
        {
            if ((comboBox1.SelectedItem == null) || (comboBox2.SelectedItem == null))
            {
                MessageBox.Show("Не выбраны герои!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (player == 1)
            {
                p1_score++;
                p1_text_score.Text = p1_score.ToString();
                r_score += "1:0 ";
            } else {
                p2_score++;
                p2_text_score.Text = p2_score.ToString();
                r_score += "0:1 ";
            }
            switch (end)
            {
                case 'F':
                    r_score += "F;";
                    break;
                case 'B':
                    r_score += "B;";
                    break;
                case 'R':
                    r_score += "R;";
                    break;
            }
            if (p1_score == 5 || p2_score == 5)
            {
                if (MessageBox.Show("Победил " + (p1_score == 5 ? comboBox1.SelectedItem : comboBox2.SelectedItem) + "\n" + "Добавить результаты боя в архив?", "Конец боя", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(@"results.txt", true))
                    {
                        file.WriteLine(comboBox1.SelectedItem.ToString() + " - " + comboBox2.SelectedItem.ToString() + ' ' + p1_score + ':' + p2_score + '(' + r_score.Substring(0,r_score.Length - 1) + ')');
                    }
                    p1_score = 0;
                    p2_score = 0;
                    p1_text_score.Text = "0";
                    p2_text_score.Text = "0";
                    r_score = "";
                    comboBox1.SelectedItem = null;
                    comboBox2.SelectedItem = null;
                }
            }
        } 
        private void p1_f_Click(object sender, EventArgs e)
        {
            score_change(1,'F');
        }

        private void p2_f_Click(object sender, EventArgs e)
        {
            score_change(2,'F');
        }

        private void p1_b_Click(object sender, EventArgs e)
        {
            score_change(1,'B');
        }

        private void p2_b_Click(object sender, EventArgs e)
        {
            score_change(2,'B');
        }

        private void p1_r_Click(object sender, EventArgs e)
        {
            score_change(1,'R');
        }

        private void p2_r_Click(object sender, EventArgs e)
        {
            score_change(2,'R');
        }
    }
}
