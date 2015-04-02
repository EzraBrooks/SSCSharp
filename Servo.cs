using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EzraBrooks.SSCSharp
{
    public class Servo
    {
        private int position = 0;
        private int servoPort;
        private int time = 0;
        private ServoController controller;

        /// <summary>
        /// Default constructor for a Servo.
        /// </summary>
        /// <param name="controller">The ServoController this Servo is attached to.</param>
        /// <param name="portNumber">The port number on the board this Servo is connected to.</param>
        public Servo(ServoController controller, int portNumber)
        {
            this.controller = controller;
            servoPort = portNumber;
        }

        /// <summary>
        /// Sets or gets the position (in pulse width) of the Servo.
        /// </summary>
        public int Position
        {
            get
            {
                return position;
            }
            set
            {
                //0 time is okay, because the servo controller can take more time to move if it has to
                controller.sendCommand("#" + servoPort + "P" + position + "T" + time);
                position = value;
            }
        }

        /// <summary>
        /// Sets or gets the movement time of the Servo.
        /// </summary>
        public int Time
        {
            get
            {
                return time;
            }
            set
            {
                time = value;
            }
        }
    }
}
