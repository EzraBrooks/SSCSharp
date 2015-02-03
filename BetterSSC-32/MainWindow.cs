/*
    Better SSC-32: a better Windows application for SSC-32 Servo Controllers.
    Copyright (C) 2015 Ezra Brooks

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

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
    public partial class mainWindow : Form
    {
        ServoController controller = new ServoController("COM3");
        public mainWindow()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.setServoPositions(new int[6] { 0, 1, 2, 3, 4, 5 }, 1500);
            trackBar1.Value = 1500;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.setServoPositions(new int[6] { 0, 1, 2, 3, 4, 5 }, 0);
            trackBar1.Value = 0;
        }

        private void trackBar_Scroll(object sender, System.EventArgs e)
        {
            if ((sender as System.Windows.Forms.TrackBar).Value >= 500)
            {
                controller.setServoPosition(1, (sender as System.Windows.Forms.TrackBar).Value);
            }
            else
            {
                controller.setServoPosition(1, 0);
            }
        }
    }
}
