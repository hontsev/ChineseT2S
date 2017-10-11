using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ChineseT2S;

namespace TestForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string ori = textBox1.Text;
            try
            {
                textBox2.Text = T2SUtility.ToSimplified(ori);
            }
            catch(Exception ex)
            {
                textBox2.Text = ex.Message;
            }
        }
    }
}
