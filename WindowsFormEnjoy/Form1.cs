using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormEnjoy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            this.TopMost = true;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            this.lblDate.Text = System.DateTime.Now.ToString();
        }
    }
}
