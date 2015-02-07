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
using System.IO.Ports;

namespace BetterSSC32
{
    public partial class mainWindow : Form
    {
        // Assume first active serial port
        ServoController controller;
        public static int numberOfServos;
        private TrackBar[] servoSliders;
        private CheckBox[] servoInvertBoxes;

        public mainWindow()
        {
            if (SerialPort.GetPortNames().Length > 0)
            {
                controller = new ServoController(SerialPort.GetPortNames()[0]);
            }
            else
            {
                controller = new ServoController("COM1"); 
            }
            Form servoQueryWindow = new servosPopup();
            servoQueryWindow.ShowDialog(this);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.setServoPositions(new int[6] { 0, 1, 2, 3, 4, 5 }, 1500);
            for (int i = 0; i < servoSliders.Length; i++)
            {
                servoSliders[i].Value = 1500;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            controller.setServoPositions(new int[6] { 0, 1, 2, 3, 4, 5 }, 0);
            for (int i = 0; i < servoSliders.Length; i++)
            {
                servoSliders[i].Value = servoSliders[i].Minimum;
            }
        }

        private void trackBar_Scroll(object sender, System.EventArgs e)
        {
            string trackBarName = (sender as System.Windows.Forms.TrackBar).Name;
            int servoNumber = Convert.ToInt32(trackBarName.Substring(trackBarName.Length - 1));
            if ((sender as System.Windows.Forms.TrackBar).Value >= 500)
            {
                controller.setServoPosition(servoNumber, (sender as System.Windows.Forms.TrackBar).Value);
            }
            else
            {
                controller.setServoPosition(servoNumber, 0);
            }
        }

        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //invert maximum and minimum of trackbar to invert values
            string checkBoxName = (sender as System.Windows.Forms.CheckBox).Name;
            int servoNumber = Convert.ToInt32(checkBoxName.Substring(checkBoxName.Length - 1));
            this.SuspendLayout();
            if ((sender as CheckBox).Checked)
            {
                servoSliders[servoNumber].Maximum = 300;
                servoSliders[servoNumber].Minimum = 2500;
            }
            else
            {
                servoSliders[servoNumber].Maximum = 2500;
                servoSliders[servoNumber].Minimum = 300;
            }
            this.ResumeLayout();
        }

        private void refreshSerialPorts(object sender, EventArgs e)
        {
            serialPortSelector.Items.Clear();
            serialPortSelector.Items.AddRange(SerialPort.GetPortNames());
            if (serialPortSelector.FindStringExact(controller.getSerialPortName()) != -1)
            {
                serialPortSelector.SelectedIndex = serialPortSelector.FindStringExact(controller.getSerialPortName());
            }
        }

        private void chooseSerialPort(object sender, EventArgs e)
        {
            string portName = (sender as ComboBox).Items[(sender as ComboBox).SelectedIndex].ToString();
            controller.setSerialPort(portName);
        }
    }
}