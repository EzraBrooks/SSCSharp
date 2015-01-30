using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Forms;

namespace RobotArm_CSharp
{
    class SerialInteraction
    {
        static void Main(string[] args)
        {
            Application.Run(new MainForm());
        }
        public static void send(string command, string port)
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