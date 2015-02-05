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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
        /// Don't listen to the IDE. As long as you put valid code in here, it's very editable.
        /// 
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            //TODO instantiate trackbars and inversion checkboxes for number of servos
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
                if (i == 0)
                {
                    ((System.ComponentModel.ISupportInitialize)(servoSliders[i])).BeginInit();
                }
                this.Controls.Add(servoSliders[i]);
            }
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(683, 538);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(205, 86);
            this.button1.TabIndex = 1;
            this.button1.Text = "All 1500";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(683, 424);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(205, 83);
            this.button2.TabIndex = 2;
            this.button2.Text = "All 0";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 639);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(150, 29);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            //TODO fix checkboxes
            //this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // mainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 697);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "mainWindow";
            this.Text = "Better SSC-32";
            ((System.ComponentModel.ISupportInitialize)(servoSliders[0])).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}