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
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace BetterSSC32
{
    class ServoController
    {
        public SerialPort port;
        public int[] pulseWidths;
        
        public ServoController()
        {
            port = new SerialPort("COM1");
            portSetup();
        }

        public ServoController(string port)
        {
            this.port = new SerialPort(port);
            portSetup();
        }

        private void portSetup()
        {
            //TODO add variable baud rate
            port.BaudRate = 115200;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.Handshake = Handshake.None;
        }

        public void sendCommand(string command)
        {
            Console.Write("Attempting to write " + command + " to port " + port.PortName + ".\n");
            try {
                port.Open();
                port.Write(command + (char) 13);
            }
            catch (Exception e)
            {
                Console.Write("An error occurred. Exiting and writing error to console.\n" + e);
            }
        }

        public void populatePulseWidths(int numberOfServos)
        {
            if (numberOfServos > 32)
            {
                numberOfServos = 32;
                Console.Write("Too many servos passed to initialiseServos! Using 32 instead.");
            }
            pulseWidths = new int[numberOfServos];
            for (int i = 0; i < numberOfServos; i++)
            {
                port.Open();
                port.Write("QP"+ i + (char) 13);
                pulseWidths[i] = Convert.ToInt32(port.ReadLine());
            }
        }

        public void setServoPosition(int servoPort, int position)
        {
            string command = "#" + servoPort + "P" + position;
            sendCommand(command);
        }

        public void setServoPosition(int servoPort, int position, int speed)
        {
            string command = "#" + servoPort + "P" + position + "S" + speed;
            sendCommand(command);
        }
    }
}
