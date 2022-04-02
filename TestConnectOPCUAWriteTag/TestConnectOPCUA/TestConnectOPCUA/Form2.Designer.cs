namespace TestConnectOPCUA
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.lbAnalogMeter1 = new LBSoft.IndustrialCtrls.Meters.LBAnalogMeter();
            this.label1 = new System.Windows.Forms.Label();
            this.lbLed1 = new LBSoft.IndustrialCtrls.Leds.LBLed();
            this.lbButton1 = new LBSoft.IndustrialCtrls.Buttons.LBButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbAnalogMeter1
            // 
            this.lbAnalogMeter1.BackColor = System.Drawing.Color.Transparent;
            this.lbAnalogMeter1.BodyColor = System.Drawing.Color.Blue;
            this.lbAnalogMeter1.CriticalValue = 80D;
            this.lbAnalogMeter1.Location = new System.Drawing.Point(12, 12);
            this.lbAnalogMeter1.MaxValue = 1000D;
            this.lbAnalogMeter1.MeterStyle = LBSoft.IndustrialCtrls.Meters.LBAnalogMeter.AnalogMeterStyle.Circular;
            this.lbAnalogMeter1.MinValue = 0D;
            this.lbAnalogMeter1.Name = "lbAnalogMeter1";
            this.lbAnalogMeter1.NeedleColor = System.Drawing.Color.Yellow;
            this.lbAnalogMeter1.Renderer = null;
            this.lbAnalogMeter1.ScaleColor = System.Drawing.Color.White;
            this.lbAnalogMeter1.ScaleDivisions = 11;
            this.lbAnalogMeter1.ScaleSubDivisions = 10;
            this.lbAnalogMeter1.Size = new System.Drawing.Size(150, 150);
            this.lbAnalogMeter1.TabIndex = 0;
            this.lbAnalogMeter1.Value = 300D;
            this.lbAnalogMeter1.ViewGlass = false;
            this.lbAnalogMeter1.WarningValue = 70D;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbLed1
            // 
            this.lbLed1.BackColor = System.Drawing.Color.Transparent;
            this.lbLed1.BlinkInterval = 500;
            this.lbLed1.Label = "Led";
            this.lbLed1.LabelPosition = LBSoft.IndustrialCtrls.Leds.LBLed.LedLabelPosition.Top;
            this.lbLed1.LedColor = System.Drawing.Color.Red;
            this.lbLed1.LedSize = new System.Drawing.SizeF(50F, 50F);
            this.lbLed1.Location = new System.Drawing.Point(242, 121);
            this.lbLed1.Name = "lbLed1";
            this.lbLed1.Renderer = null;
            this.lbLed1.Size = new System.Drawing.Size(127, 77);
            this.lbLed1.State = LBSoft.IndustrialCtrls.Leds.LBLed.LedState.Off;
            this.lbLed1.Style = LBSoft.IndustrialCtrls.Leds.LBLed.LedStyle.Circular;
            this.lbLed1.TabIndex = 3;
            // 
            // lbButton1
            // 
            this.lbButton1.BackColor = System.Drawing.Color.Transparent;
            this.lbButton1.ButtonColor = System.Drawing.Color.Red;
            this.lbButton1.Label = "";
            this.lbButton1.Location = new System.Drawing.Point(242, 204);
            this.lbButton1.Name = "lbButton1";
            this.lbButton1.Renderer = null;
            this.lbButton1.RepeatInterval = 100;
            this.lbButton1.RepeatState = false;
            this.lbButton1.Size = new System.Drawing.Size(127, 50);
            this.lbButton1.StartRepeatInterval = 500;
            this.lbButton1.State = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonState.Pressed;
            this.lbButton1.Style = LBSoft.IndustrialCtrls.Buttons.LBButton.ButtonStyle.Rectangular;
            this.lbButton1.TabIndex = 4;
            this.lbButton1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lbButton1_MouseDown);
            this.lbButton1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lbButton1_MouseUp);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(211, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(193, 103);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(205, 296);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 362);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbButton1);
            this.Controls.Add(this.lbLed1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbAnalogMeter1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private LBSoft.IndustrialCtrls.Meters.LBAnalogMeter lbAnalogMeter1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private LBSoft.IndustrialCtrls.Leds.LBLed lbLed1;
        private LBSoft.IndustrialCtrls.Buttons.LBButton lbButton1;
        private System.Windows.Forms.Button button1;
    }
}