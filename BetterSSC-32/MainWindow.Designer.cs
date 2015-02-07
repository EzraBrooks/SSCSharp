namespace BetterSSC32
{
    partial class mainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.serialPortSelector = new System.Windows.Forms.ComboBox();
            this.serialPortRefresh = new System.Windows.Forms.Button();
            //
            // Instantiate TrackBars for all registered servos
            //
            servoSliders = new System.Windows.Forms.TrackBar[numberOfServos];
            for (int i = 0; i < numberOfServos; i++)
            {
                servoSliders[i] = new System.Windows.Forms.TrackBar();
                servoSliders[i].LargeChange = 100;
                servoSliders[i].Location = new System.Drawing.Point(25 + (100 * i), 15);
                servoSliders[i].Maximum = 2500;
                servoSliders[i].Minimum = 300;
                servoSliders[i].Name = "servoSlider" + i;
                servoSliders[i].Orientation = System.Windows.Forms.Orientation.Vertical;
                servoSliders[i].Size = new System.Drawing.Size(90, 615);
                servoSliders[i].SmallChange = 10;
                servoSliders[i].TabIndex = i;
                servoSliders[i].TickFrequency = 50;
                servoSliders[i].TickStyle = System.Windows.Forms.TickStyle.Both;
                servoSliders[i].Value = 300;
                servoSliders[i].Scroll += new System.EventHandler(trackBar_Scroll);
                this.Controls.Add(servoSliders[i]);
            }
            // 
            // Instantiate CheckBoxes for all registered servos
            //
            servoInvertBoxes = new System.Windows.Forms.CheckBox[numberOfServos];
            for (int i = 0; i < numberOfServos; i++)
            {
                servoInvertBoxes[i] = new System.Windows.Forms.CheckBox();
                servoInvertBoxes[i].AutoSize = true;
                servoInvertBoxes[i].Location = new System.Drawing.Point(12 + (100 * i), 640);
                servoInvertBoxes[i].Name = "checkBox" + i;
                servoInvertBoxes[i].Size = new System.Drawing.Size(150, 30);
                servoInvertBoxes[i].TabIndex = numberOfServos + i;
                servoInvertBoxes[i].Text = "Invert";
                servoInvertBoxes[i].UseVisualStyleBackColor = true;
                servoInvertBoxes[i].CheckedChanged += new System.EventHandler(checkBox_CheckedChanged);
                this.Controls.Add(servoInvertBoxes[i]);
            }
            //
            // Serial port selector dropdown
            //
            this.serialPortSelector.Location = new System.Drawing.Point(680, 300);
            this.serialPortSelector.Name = "serialPortSelector";
            this.serialPortSelector.Size = new System.Drawing.Size(200, 50);
            this.serialPortSelector.TabIndex = (numberOfServos * 2) + 1;
            this.serialPortSelector.Text = "Select Serial Port";
            this.serialPortSelector.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            this.serialPortSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDown;
            foreach (string port in this.serialPortSelector.Items)
            {
                if (port == controller.getSerialPortName())
                {
                    this.serialPortSelector.SelectedIndex = this.serialPortSelector.FindStringExact(controller.getSerialPortName());
                }
            }
            this.serialPortSelector.SelectedIndexChanged += new System.EventHandler(chooseSerialPort);
            // 
            // Refresh serial port selector options
            //
            this.serialPortRefresh.Location = new System.Drawing.Point(680, 360);
            this.serialPortRefresh.Name = "serialPortRefresh";
            this.serialPortRefresh.Size = new System.Drawing.Size(200, 50);
            this.serialPortRefresh.TabIndex = (numberOfServos * 2) + 2;
            this.serialPortRefresh.Text = "Refresh Ports";
            this.serialPortRefresh.Click += new System.EventHandler(refreshSerialPorts);
            //
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(680, 540);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 85);
            this.button1.TabIndex = 1;
            this.button1.Text = "All 1500";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(680, 420);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 85);
            this.button2.TabIndex = 2;
            this.button2.Text = "All 0";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.serialPortSelector);
            this.Controls.Add(this.serialPortRefresh);
            this.Name = "mainWindow";
            this.Text = "Better SSC-32";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox serialPortSelector;
        private System.Windows.Forms.Button serialPortRefresh;
    }
}