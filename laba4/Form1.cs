using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba4
{
    public partial class Form1 : Form
    {
        const double k = 0.02;
        Random rnd = new Random();
        double price, _money = 200;
        int days, i = 1, _possessions = 0;
        public Form1()
        {
            InitializeComponent();
            timer1.Enabled = true;
            timer1.Interval = 4000;
            Money.Text = _money + "$";
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            i = 1;

            chart1.Series[0].Points.Clear();
            

            price = (double)inputPrice.Value;

            days = (int)inputDays.Value;

            chart1.Series[0].Points.AddXY(0, price);

            timer1.Start();
        }

        private void Buy_Click(object sender, EventArgs e)
        {
            if (_money>= price)
            {
                noMoney.Visible = false;
                _money -= price;
                Money.Text = _money + "$";
                _possessions ++;
                Possessions.Text = _possessions.ToString();
            }
            else
            {
                noMoney.Visible = true;
            }
        }

        private void Sell_Click(object sender, EventArgs e)
        {
            if (_possessions>0)
            {
                _money += price;
                _possessions--;
                Money.Text = _money + "$";
                Possessions.Text = _possessions.ToString();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            price = price * (1 + k * (rnd.NextDouble() - 0.5));

            chart1.Series[0].Points.AddXY(i, price);

            i++;
            if (i == days) timer1.Stop();
        }
    }
}
