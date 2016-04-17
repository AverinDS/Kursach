using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Coursework.Forms;

namespace Coursework.Forms
{
    public partial class FormAdditionalFunc : Form
    {
        public FormAdditionalFunc()
        {
            InitializeComponent();
        }

        private void FormAdditionalFunc_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.ShowDialog();
        }
    }
}
