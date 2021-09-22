using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Calc
{
    public partial class Form1 : Form
    {

        double num1 = 0;
        double num2 = 0;

        int op = 0;
        string total;

        public Form1()
        {
            InitializeComponent();
        }

        private void res_Click(object sender, EventArgs e)
        {

            num2 = double.Parse(z.Text);

            if (op == 1)
            {
                total = Convert.ToString(num1 + num2);
                z.Text = "";
                z.Text = total;
            }

            if (op == 2)
            {
                total = Convert.ToString(num1 - num2);
                z.Text = "";
                z.Text = total;
            }

            if (op == 3)
            {
                total = Convert.ToString(num1 * num2);
                z.Text = "";
                z.Text = total;
            }

            if (op == 4)
            {
                total = Convert.ToString(num1 / num2);
                z.Text = "";
                z.Text = total;
            }

            if (op == 5)
            {
                double pot = 1;
                for (int i = 1; i <= num2; i++)
                {
                    pot = num1 * pot;
                }

                total = Convert.ToString(pot);
                z.Text = total;
            }
        }





        private void suma_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(z.Text);
            z.Text = "";
            op = 1;

        }


        private void resta_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(z.Text);
            z.Text = "";
            op = 2;
        }

        private void multi_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(z.Text);
            z.Text = "";
            op = 3;
        }

        private void divi_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(z.Text);
            z.Text = "";
            op = 4;
        }

        private void pot_Click(object sender, EventArgs e)
        {
            num1 = double.Parse(z.Text);
            z.Text = "";
            op = 5;
        }

        private void z_TextChanged(object sender, EventArgs e)
        {

        }

        private void bt1_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "1";
        }

        private void bt2_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "2";
        }

        private void bt3_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "3";
        }

        private void bt4_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "4";
        }

        private void bt5_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "5";
        }

        private void bt6_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "6";
        }

        private void bt7_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "7";
        }

        private void bt8_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "8";
        }

        private void bt9_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "9";
        }

        private void bt0_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + "0";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            z.Text = "";
        }

        private void punto_Click(object sender, EventArgs e)
        {
            z.Text = z.Text + ".";
        }

        private void neg_Click(object sender, EventArgs e)
        {
            z.Text = "-"+ z.Text;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
