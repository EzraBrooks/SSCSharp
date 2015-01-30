using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BetterSSC32
{
    public partial class FirstRun : Form
    {
        public FirstRun()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //TODO invalidate user input if greater than 32 or less than 1
            Application.Run(new MainForm(Convert.ToInt32(numberOfServosEntry.Text)));
        }
    }
}
