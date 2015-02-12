/*
    SSCSharp: a C# library for SSC-32 Servo Controllers.
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
using System.IO.Ports;

/// <summary>
/// SSCSharp is a simple way to communicate with a Lynxmotion SSC-32 servo controller in C#.
/// </summary>
/// <remarks>
/// This program was initially developed for the Technology Infrastructure Lab at Capitol Technology University, where we
/// needed a better way to control SSC-32-based robotics equipment than the software Lynxmotion ships.
/// </remarks>

namespace SSCSharp{
    public class ServoController
    {
        /// <summary>
        /// "port" stores the SerialPort object that the instantiated ServoController object is connected to.
        /// "pulseWidths" stores the positions of the servos connected to the controller.
        /// </summary>
        private SerialPort port;
        private int[] pulseWidths;

        /// <summary>
        /// The constructor for a ServoController object.
        /// </summary>
        /// <param name="port">The name of the port you want to connect to, as a string.</param>
        public ServoController(string port)
        {
            this.port = new SerialPort(port);
            portSetup();
        }

        /// <summary>
        /// portSetup is a private method called when a ServoController object is instantiated or when the port is changed.
        /// It deals with setting the necessary attributes on the SerialPort object to communicate with the SSC-32.
        /// The port, by default, is set to 115.2k baud, but you can change that with setBaudRate. <seealso cref="setBaudRate"/>
        /// </summary>
        private void portSetup()
        {
            port.BaudRate = 115200;
            port.Parity = Parity.None;
            port.StopBits = StopBits.One;
            port.DataBits = 8;
            port.Handshake = Handshake.None;
        }

        /// <summary>
        /// A simple method for sending a command to the servo controller. It handles the opening, writing to, and closing of
        /// the port, as well as appending ASCII character 13 to the command so the SSC-32 registers the end of the command.
        /// </summary>
        /// <param name="command">The command sent to the controller, in string form.</param>
        public void sendCommand(string command)
        {
            //Attempt to write command to serial port
            try
            {
                port.Open();
                port.Write(command + (char)13);
                port.Close();
            }
            catch (Exception e)
            {
                Console.Write("An error occurred. Exiting and writing error to console.\n" + e);
            }
        }

        public SerialPort Port
        {
            get
            {
                return this.port;
            }
            set
            {
                port = value;
                portSetup();
            }
        }

        /// <summary>
        /// Gets the serial port name for the instance.
        /// </summary>
        public string PortName
        {
            get
            {
                return this.port.PortName;
            }
        }

        /// <summary>
        /// Gets or sets the baud rate of the serial port for the instance.
        /// </summary>
        public int BaudRate
        {
            get
            {
                return port.BaudRate;
            }
            set
            {
                port.BaudRate = value;
            }
        }

        /// <summary>
        /// Set the position of a servo without specifying speed or time.
        /// </summary>
        /// <param name="servoPort">The port on the SSC-32 that the desired servo is connected to.</param>
        /// <param name="position">The position (and pulse width) you wish to set the servo to.</param>
        public void setServoPosition(int servoPort, int position)
        {
            string command = "#" + servoPort + "P" + position;
            sendCommand(command);
        }

        /// <summary>
        /// Set the position of a servo with a specified time.
        /// </summary>
        /// <param name="servoPort">The port on the SSC-32 that the desired servo is connected to.</param>
        /// <param name="position">The position (and pulse width), 0-2500, you wish to set the servo to.</param>
        /// <param name="time">The desired rotation time in milliseconds.</param>
        public void setServoPosition(int servoPort, int position, int time)
        {
            string command = "#" + servoPort + "P" + position + "T" + time;
            sendCommand(command);
        }

        /// <summary>
        /// Sets multiple servos to one position.
        /// </summary>
        /// <param name="servoPorts">A list of servos to set to the desired position.</param>
        /// <param name="position">The desired position (and pulse width) you wish to set the servos to.</param>
        public void setServoPositions(int[] servoPorts, int position)
        {
            string command = "";
            foreach (int servoPort in servoPorts)
            {
                command += "#" + servoPort + "P" + position;
            }
            sendCommand(command);
        }
    }
}