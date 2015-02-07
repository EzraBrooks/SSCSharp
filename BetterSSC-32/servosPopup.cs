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
    public partial class servosPopup : Form
    {
        public servosPopup()
        {
            InitializeComponent();
        }

        private void confirmButton_Click(object sender, EventArgs e)
        {
            if (servoCountEntry.Text != "")
            {
                mainWindow.numberOfServos = Convert.ToInt32(servoCountEntry.Text);
                DialogResult = DialogResult.OK;
            }
        }

        private void servoCountEntry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                confirmButton.PerformClick();
            }
        }
    }
}
