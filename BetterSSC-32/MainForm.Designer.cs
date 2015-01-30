namespace BetterSSC32
{
    partial class MainForm
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
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.pulseWidthEntry = new System.Windows.Forms.MaskedTextBox();
            this.portEntry = new System.Windows.Forms.MaskedTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(357, 360);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 58);
            this.button1.TabIndex = 0;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pulseWidthEntry
            // 
            this.pulseWidthEntry.Location = new System.Drawing.Point(357, 166);
            this.pulseWidthEntry.Mask = "00000";
            this.pulseWidthEntry.Name = "pulseWidthEntry";
            this.pulseWidthEntry.Size = new System.Drawing.Size(168, 31);
            this.pulseWidthEntry.TabIndex = 1;
            this.pulseWidthEntry.ValidatingType = typeof(int);
            // 
            // portEntry
            // 
            this.portEntry.Location = new System.Drawing.Point(357, 96);
            this.portEntry.Mask = "0";
            this.portEntry.Name = "portEntry";
            this.portEntry.Size = new System.Drawing.Size(168, 31);
            this.portEntry.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(778, 314);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 63);
            this.button2.TabIndex = 3;
            this.button2.Text = "About";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(986, 466);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.portEntry);
            this.Controls.Add(this.pulseWidthEntry);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MaskedTextBox pulseWidthEntry;
        private System.Windows.Forms.MaskedTextBox portEntry;
        private System.Windows.Forms.Button button2;
    }
}