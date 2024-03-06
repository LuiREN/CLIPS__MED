using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFormsExample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AutoFormsExample autoFormsExample = new AutoFormsExample();
            autoFormsExample.Show();
            this.Hide();
        }
    }
}
