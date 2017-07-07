namespace WindowsFormsApp1
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBoxSerialNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnexion = new System.Windows.Forms.Button();
            this.comboBoxParity = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxStopBit = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxHandshake = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboBoxDataBit = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBoxBaudRate = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.comboBoxAccelMinMax = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxAccelZ = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxAccelY = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxAccelX = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Magnetometer = new System.Windows.Forms.GroupBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBoxMagnMinMax = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxMagnetZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxMagnetY = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxMagnetX = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.timerUpdateValues = new System.Windows.Forms.Timer(this.components);
            this.glControl = new OpenTK.GLControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.Magnetometer.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxSerialNames
            // 
            this.comboBoxSerialNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSerialNames.FormattingEnabled = true;
            this.comboBoxSerialNames.Location = new System.Drawing.Point(87, 60);
            this.comboBoxSerialNames.Name = "comboBoxSerialNames";
            this.comboBoxSerialNames.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSerialNames.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Port série ;";
            // 
            // buttonConnexion
            // 
            this.buttonConnexion.Location = new System.Drawing.Point(16, 225);
            this.buttonConnexion.Name = "buttonConnexion";
            this.buttonConnexion.Size = new System.Drawing.Size(192, 23);
            this.buttonConnexion.TabIndex = 2;
            this.buttonConnexion.Text = "Connexion";
            this.buttonConnexion.UseVisualStyleBackColor = true;
            this.buttonConnexion.Click += new System.EventHandler(this.buttonConnexion_Click);
            // 
            // comboBoxParity
            // 
            this.comboBoxParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxParity.FormattingEnabled = true;
            this.comboBoxParity.Location = new System.Drawing.Point(87, 144);
            this.comboBoxParity.Name = "comboBoxParity";
            this.comboBoxParity.Size = new System.Drawing.Size(121, 21);
            this.comboBoxParity.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Parity :";
            // 
            // comboBoxStopBit
            // 
            this.comboBoxStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxStopBit.FormattingEnabled = true;
            this.comboBoxStopBit.Location = new System.Drawing.Point(87, 171);
            this.comboBoxStopBit.Name = "comboBoxStopBit";
            this.comboBoxStopBit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxStopBit.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 174);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Stop bit :";
            // 
            // comboBoxHandshake
            // 
            this.comboBoxHandshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxHandshake.FormattingEnabled = true;
            this.comboBoxHandshake.Location = new System.Drawing.Point(87, 198);
            this.comboBoxHandshake.Name = "comboBoxHandshake";
            this.comboBoxHandshake.Size = new System.Drawing.Size(121, 21);
            this.comboBoxHandshake.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 201);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Handshake :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxDataBit);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.comboBoxBaudRate);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.comboBoxSerialNames);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxHandshake);
            this.groupBox1.Controls.Add(this.buttonConnexion);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBoxParity);
            this.groupBox1.Controls.Add(this.comboBoxStopBit);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 309);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port";
            // 
            // comboBoxDataBit
            // 
            this.comboBoxDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxDataBit.FormattingEnabled = true;
            this.comboBoxDataBit.Location = new System.Drawing.Point(87, 117);
            this.comboBoxDataBit.Name = "comboBoxDataBit";
            this.comboBoxDataBit.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDataBit.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(24, 120);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(50, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Data bit :";
            // 
            // comboBoxBaudRate
            // 
            this.comboBoxBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxBaudRate.FormattingEnabled = true;
            this.comboBoxBaudRate.Location = new System.Drawing.Point(87, 90);
            this.comboBoxBaudRate.Name = "comboBoxBaudRate";
            this.comboBoxBaudRate.Size = new System.Drawing.Size(121, 21);
            this.comboBoxBaudRate.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(24, 93);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Baud rate :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.comboBoxAccelMinMax);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.textBoxAccelZ);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBoxAccelY);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBoxAccelX);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(259, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(229, 151);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Accelerometer";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 30);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(84, 13);
            this.label20.TabIndex = 13;
            this.label20.Text = "Min / Max : + / -";
            // 
            // comboBoxAccelMinMax
            // 
            this.comboBoxAccelMinMax.FormattingEnabled = true;
            this.comboBoxAccelMinMax.Location = new System.Drawing.Point(102, 25);
            this.comboBoxAccelMinMax.Name = "comboBoxAccelMinMax";
            this.comboBoxAccelMinMax.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAccelMinMax.TabIndex = 12;
            this.comboBoxAccelMinMax.SelectedIndexChanged += new System.EventHandler(this.comboBoxAccelMinMax_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(145, 118);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(13, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "g";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(145, 91);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(13, 13);
            this.label14.TabIndex = 7;
            this.label14.Text = "g";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(145, 64);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(13, 13);
            this.label13.TabIndex = 6;
            this.label13.Text = "g";
            // 
            // textBoxAccelZ
            // 
            this.textBoxAccelZ.Location = new System.Drawing.Point(39, 115);
            this.textBoxAccelZ.Name = "textBoxAccelZ";
            this.textBoxAccelZ.ReadOnly = true;
            this.textBoxAccelZ.Size = new System.Drawing.Size(100, 20);
            this.textBoxAccelZ.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(20, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Z :";
            // 
            // textBoxAccelY
            // 
            this.textBoxAccelY.Location = new System.Drawing.Point(39, 88);
            this.textBoxAccelY.Name = "textBoxAccelY";
            this.textBoxAccelY.ReadOnly = true;
            this.textBoxAccelY.Size = new System.Drawing.Size(100, 20);
            this.textBoxAccelY.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Y :";
            // 
            // textBoxAccelX
            // 
            this.textBoxAccelX.Location = new System.Drawing.Point(39, 61);
            this.textBoxAccelX.Name = "textBoxAccelX";
            this.textBoxAccelX.ReadOnly = true;
            this.textBoxAccelX.Size = new System.Drawing.Size(100, 20);
            this.textBoxAccelX.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "X :";
            // 
            // Magnetometer
            // 
            this.Magnetometer.Controls.Add(this.label19);
            this.Magnetometer.Controls.Add(this.comboBoxMagnMinMax);
            this.Magnetometer.Controls.Add(this.label18);
            this.Magnetometer.Controls.Add(this.label17);
            this.Magnetometer.Controls.Add(this.label16);
            this.Magnetometer.Controls.Add(this.textBoxMagnetZ);
            this.Magnetometer.Controls.Add(this.label8);
            this.Magnetometer.Controls.Add(this.textBoxMagnetY);
            this.Magnetometer.Controls.Add(this.label9);
            this.Magnetometer.Controls.Add(this.textBoxMagnetX);
            this.Magnetometer.Controls.Add(this.label10);
            this.Magnetometer.Location = new System.Drawing.Point(259, 169);
            this.Magnetometer.Name = "Magnetometer";
            this.Magnetometer.Size = new System.Drawing.Size(229, 152);
            this.Magnetometer.TabIndex = 11;
            this.Magnetometer.TabStop = false;
            this.Magnetometer.Text = "Magnetic field";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 28);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(84, 13);
            this.label19.TabIndex = 11;
            this.label19.Text = "Min / Max : + / -";
            // 
            // comboBoxMagnMinMax
            // 
            this.comboBoxMagnMinMax.FormattingEnabled = true;
            this.comboBoxMagnMinMax.Location = new System.Drawing.Point(96, 23);
            this.comboBoxMagnMinMax.Name = "comboBoxMagnMinMax";
            this.comboBoxMagnMinMax.Size = new System.Drawing.Size(121, 21);
            this.comboBoxMagnMinMax.TabIndex = 10;
            this.comboBoxMagnMinMax.SelectedIndexChanged += new System.EventHandler(this.comboBoxMagnMinMax_SelectedIndexChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(138, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(35, 13);
            this.label18.TabIndex = 9;
            this.label18.Text = "gauss";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(138, 89);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(35, 13);
            this.label17.TabIndex = 8;
            this.label17.Text = "gauss";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(138, 61);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "gauss";
            // 
            // textBoxMagnetZ
            // 
            this.textBoxMagnetZ.Location = new System.Drawing.Point(32, 112);
            this.textBoxMagnetZ.Name = "textBoxMagnetZ";
            this.textBoxMagnetZ.ReadOnly = true;
            this.textBoxMagnetZ.Size = new System.Drawing.Size(100, 20);
            this.textBoxMagnetZ.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Z :";
            // 
            // textBoxMagnetY
            // 
            this.textBoxMagnetY.Location = new System.Drawing.Point(32, 85);
            this.textBoxMagnetY.Name = "textBoxMagnetY";
            this.textBoxMagnetY.ReadOnly = true;
            this.textBoxMagnetY.Size = new System.Drawing.Size(100, 20);
            this.textBoxMagnetY.TabIndex = 3;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 88);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Y :";
            // 
            // textBoxMagnetX
            // 
            this.textBoxMagnetX.Location = new System.Drawing.Point(32, 58);
            this.textBoxMagnetX.Name = "textBoxMagnetX";
            this.textBoxMagnetX.ReadOnly = true;
            this.textBoxMagnetX.Size = new System.Drawing.Size(100, 20);
            this.textBoxMagnetX.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(20, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "X :";
            // 
            // timerUpdateValues
            // 
            this.timerUpdateValues.Enabled = true;
            this.timerUpdateValues.Tick += new System.EventHandler(this.timerUpdateValues_Tick);
            // 
            // glControl
            // 
            this.glControl.BackColor = System.Drawing.Color.Black;
            this.glControl.Location = new System.Drawing.Point(16, 334);
            this.glControl.Name = "glControl";
            this.glControl.Size = new System.Drawing.Size(472, 308);
            this.glControl.TabIndex = 12;
            this.glControl.VSync = false;
            this.glControl.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl_Paint);
            this.glControl.Resize += new System.EventHandler(this.glControl_Resize);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 654);
            this.Controls.Add(this.glControl);
            this.Controls.Add(this.Magnetometer);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "LSM303";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.Magnetometer.ResumeLayout(false);
            this.Magnetometer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSerialNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnexion;
        private System.Windows.Forms.ComboBox comboBoxParity;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxStopBit;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxHandshake;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBoxAccelZ;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxAccelY;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxAccelX;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox Magnetometer;
        private System.Windows.Forms.TextBox textBoxMagnetZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxMagnetY;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxMagnetX;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxDataBit;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBoxBaudRate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Timer timerUpdateValues;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBoxMagnMinMax;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.ComboBox comboBoxAccelMinMax;
        private OpenTK.GLControl glControl;
    }
}

