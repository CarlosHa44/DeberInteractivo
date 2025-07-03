namespace DeberInteractivo
{
    partial class FrmFloodFill
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnToggleMode = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnFloodFill = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trbarAnimationSpeed = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.grbCanva = new System.Windows.Forms.GroupBox();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbAlgoritmo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtRadio = new System.Windows.Forms.TextBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbarAnimationSpeed)).BeginInit();
            this.grbCanva.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grbProcess.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.SeaShell;
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnToggleMode);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.btnFloodFill);
            this.groupBox2.Location = new System.Drawing.Point(10, 359);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(271, 163);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Proceso";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(22, 89);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(130, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "Modo actual: Dibujar";
            // 
            // btnToggleMode
            // 
            this.btnToggleMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnToggleMode.Location = new System.Drawing.Point(153, 34);
            this.btnToggleMode.Name = "btnToggleMode";
            this.btnToggleMode.Size = new System.Drawing.Size(92, 33);
            this.btnToggleMode.TabIndex = 4;
            this.btnToggleMode.Text = "Dibujar";
            this.btnToggleMode.UseVisualStyleBackColor = true;
            this.btnToggleMode.Click += new System.EventHandler(this.btnToggleMode_Click);
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.Location = new System.Drawing.Point(80, 123);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(95, 33);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnFloodFill
            // 
            this.btnFloodFill.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFloodFill.Location = new System.Drawing.Point(23, 34);
            this.btnFloodFill.Name = "btnFloodFill";
            this.btnFloodFill.Size = new System.Drawing.Size(86, 33);
            this.btnFloodFill.TabIndex = 2;
            this.btnFloodFill.Text = "Rellenar";
            this.btnFloodFill.UseVisualStyleBackColor = true;
            this.btnFloodFill.Click += new System.EventHandler(this.btnFloodFill_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.SeaShell;
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.trbarAnimationSpeed);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(10, 181);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 172);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Animacion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(232, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "6";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "1";
            // 
            // trbarAnimationSpeed
            // 
            this.trbarAnimationSpeed.LargeChange = 2;
            this.trbarAnimationSpeed.Location = new System.Drawing.Point(23, 91);
            this.trbarAnimationSpeed.Maximum = 6;
            this.trbarAnimationSpeed.Minimum = 1;
            this.trbarAnimationSpeed.Name = "trbarAnimationSpeed";
            this.trbarAnimationSpeed.Size = new System.Drawing.Size(222, 45);
            this.trbarAnimationSpeed.TabIndex = 1;
            this.trbarAnimationSpeed.Value = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Velocidad:";
            // 
            // grbCanva
            // 
            this.grbCanva.Controls.Add(this.picCanvas);
            this.grbCanva.Location = new System.Drawing.Point(287, 5);
            this.grbCanva.Name = "grbCanva";
            this.grbCanva.Size = new System.Drawing.Size(635, 517);
            this.grbCanva.TabIndex = 5;
            this.grbCanva.TabStop = false;
            this.grbCanva.Text = "Gráfico";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.White;
            this.picCanvas.Location = new System.Drawing.Point(7, 13);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(622, 498);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PicCanvas_MouseClick);
            // 
            // grbProcess
            // 
            this.grbProcess.BackColor = System.Drawing.Color.SeaShell;
            this.grbProcess.Controls.Add(this.txtRadio);
            this.grbProcess.Controls.Add(this.label9);
            this.grbProcess.Controls.Add(this.label8);
            this.grbProcess.Controls.Add(this.label4);
            this.grbProcess.Controls.Add(this.label3);
            this.grbProcess.Controls.Add(this.cmbAlgoritmo);
            this.grbProcess.Controls.Add(this.label1);
            this.grbProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbProcess.Location = new System.Drawing.Point(10, 5);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(271, 170);
            this.grbProcess.TabIndex = 4;
            this.grbProcess.TabStop = false;
            this.grbProcess.Text = "Entrada";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 13);
            this.label8.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(31, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 64);
            this.label4.TabIndex = 3;
            this.label4.Text = "Clikea dentro del apartado grafico\r\npara graficar circulos, luego clikea \r\nsobre " +
    "rellenar y clickea sobre los\r\ncirculos que quieres rellenar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 2;
            // 
            // cmbAlgoritmo
            // 
            this.cmbAlgoritmo.FormattingEnabled = true;
            this.cmbAlgoritmo.Items.AddRange(new object[] {
            "Flood Fill DFS",
            "Flood Fill BFS"});
            this.cmbAlgoritmo.Location = new System.Drawing.Point(80, 63);
            this.cmbAlgoritmo.Name = "cmbAlgoritmo";
            this.cmbAlgoritmo.Size = new System.Drawing.Size(185, 21);
            this.cmbAlgoritmo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Método:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(20, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 16);
            this.label9.TabIndex = 5;
            this.label9.Text = "Radio: ";
            // 
            // txtRadio
            // 
            this.txtRadio.Location = new System.Drawing.Point(80, 31);
            this.txtRadio.Name = "txtRadio";
            this.txtRadio.Size = new System.Drawing.Size(185, 20);
            this.txtRadio.TabIndex = 6;
            // 
            // FrmFloodFill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 527);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grbCanva);
            this.Controls.Add(this.grbProcess);
            this.Name = "FrmFloodFill";
            this.Text = "FrmFloodFill";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trbarAnimationSpeed)).EndInit();
            this.grbCanva.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grbProcess.ResumeLayout(false);
            this.grbProcess.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnFloodFill;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TrackBar trbarAnimationSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grbCanva;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbAlgoritmo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnToggleMode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtRadio;
    }
}