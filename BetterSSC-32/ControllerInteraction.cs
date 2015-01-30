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
using System.IO.Ports;
using System.Windows.Forms;

namespace BetterSSC32
{
    class ControllerInteraction
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Application.Run(new FirstRun());
            }
            else
            {
                if (args[0] == "--help")
                {
                    Console.WriteLine("How to use BetterSSC32 in command-line mode: ");
                    Console.WriteLine(".\\BetterSSC-32.exe --send [COM port] [command]");
                }
                else if (args[0] == "--send")
                {
                    string port = args[1];
                    string command = args[2];
                    sendCommand(port, command);
                }
            }
        }
        public static void sendCommand(string port, string command)
        {
            SerialPort armPort = new SerialPort(port);
            armPort.BaudRate = 115200;
            armPort.Parity = Parity.None;
            armPort.StopBits = StopBits.One;
            armPort.DataBits = 8;
            armPort.Handshake = Handshake.None;
            Console.Write("Attempting to write " + command + " to port " + armPort.PortName + ".\n");
            try {
                armPort.Open();
                armPort.Write(command + (char) 13);
            }
            catch (Exception e)
            {
                Console.Write("An error occurred. Exiting and writing error to console.\n" + e);
            }
        }
    }
}