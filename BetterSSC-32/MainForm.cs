using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotArm_CSharp
{
    public partial class MainForm : Form
    {
        string command;
        string port;

        public MainForm()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            command = pulseWidthEntry.Text;
            SerialInteraction.send(command, port);
        }
    }
}
