using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        int totalOfCheckBoxesTicked;
        int countOfCheckBoxesTicked;
        int totalDiceRoll;
        const string scoreText = "Total rolled: ";
        const string welcomeText = "Welcome to Shut The Box!";
        int rollCount;

        public Form1()
        {
            InitializeComponent();
            lblTotalRoll.Text = welcomeText;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            countOfCheckBoxesTicked = 0;
            totalOfCheckBoxesTicked = 0;

            foreach (var chkBoxesChecked in Controls.OfType<CheckBox>())
            {
                if (chkBoxesChecked.Checked && chkBoxesChecked.Enabled)
                {
                    countOfCheckBoxesTicked += 1;

                    if (countOfCheckBoxesTicked >= 1 && countOfCheckBoxesTicked < 3)
                    {
                        string chkBoxNumberChecked = chkBoxesChecked.Text;
                        totalOfCheckBoxesTicked +=
                                    Convert.ToInt32(chkBoxNumberChecked.Substring(0, chkBoxesChecked.Text.Length));
                        //chkBoxesChecked.Enabled = false;
                    }
                }
            }

            if (countOfCheckBoxesTicked == 0)
            {
                MessageBox.Show("No move selected, please retry!", "Shut The Box!");
                //totalOfCheckBoxesTicked = 0;
            }

            if (countOfCheckBoxesTicked > 2)
            {
                MessageBox.Show("Too many numbers chosen - cheat!", "Shut The Box!");
                totalOfCheckBoxesTicked = 0;
            }

            if (totalOfCheckBoxesTicked == totalDiceRoll)
            {
                foreach (var chkBoxesChecked in Controls.OfType<CheckBox>())
                {
                    if (chkBoxesChecked.Checked)
                    {
                        chkBoxesChecked.Enabled = false;
                    }
                }

                btnRoll.Enabled = true;
                btnConfirm.Enabled = false;
                lblTotalRoll.Text = "Please roll again!";
            }
            else
            {
                MessageBox.Show($"The dice rolled totals {totalDiceRoll}. " +
                                $"The selections made total {totalOfCheckBoxesTicked}.", "Shut The Box!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            rollCount += 1;

            if (rollCount == 1)
            {
                chk1.Enabled = true;
                chk2.Enabled = true;
                chk3.Enabled = true;
                chk4.Enabled = true;
                chk5.Enabled = true;
                chk6.Enabled = true;
                chk7.Enabled = true;
                chk8.Enabled = true;
                chk9.Enabled = true;
                //chk10.Enabled = true;
                //chk11.Enabled = true;
                //chk12.Enabled = true;
            }


            btnConfirm.Enabled = true;

            Random random = new Random();

            int dice1 = random.Next(1, 7);
            int dice2 = random.Next(1, 7);
            totalDiceRoll = dice1 + dice2;

            lblTotalRoll.Text = scoreText + totalDiceRoll;
            btnRoll.Enabled = false;
        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            foreach (var chkBoxesChecked in Controls.OfType<CheckBox>())
            {
                chkBoxesChecked.Enabled = false;
                chkBoxesChecked.Checked = false;
                lblTotalRoll.Text = string.Empty;
                totalDiceRoll = 0;
                countOfCheckBoxesTicked = 0;
                rollCount = 0;
            }

            btnConfirm.Enabled = false;
            btnRoll.Enabled = true;
            lblTotalRoll.Text = welcomeText;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            foreach (var chkBoxesChecked in Controls.OfType<CheckBox>())
            {
                if (chkBoxesChecked.Checked && chkBoxesChecked.Enabled)
                {
                    //chkBoxesChecked.Enabled = true;
                    chkBoxesChecked.Checked = false;
                }
            }
        }
    }
}

