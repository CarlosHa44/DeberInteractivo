namespace DeberInteractivo
{
    partial class FrmHome
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.lineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.curvasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.circuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.elipseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rellenoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recorteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametricasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.LightSkyBlue;
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineasToolStripMenuItem,
            this.curvasToolStripMenuItem,
            this.rellenoToolStripMenuItem,
            this.recorteToolStripMenuItem,
            this.parametricasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(938, 34);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // lineasToolStripMenuItem
            // 
            this.lineasToolStripMenuItem.Name = "lineasToolStripMenuItem";
            this.lineasToolStripMenuItem.Size = new System.Drawing.Size(53, 30);
            this.lineasToolStripMenuItem.Text = "Lineas";
            this.lineasToolStripMenuItem.Click += new System.EventHandler(this.lineasToolStripMenuItem_Click);
            // 
            // curvasToolStripMenuItem
            // 
            this.curvasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.circuloToolStripMenuItem,
            this.elipseToolStripMenuItem});
            this.curvasToolStripMenuItem.Name = "curvasToolStripMenuItem";
            this.curvasToolStripMenuItem.Size = new System.Drawing.Size(56, 30);
            this.curvasToolStripMenuItem.Text = "Curvas";
            // 
            // circuloToolStripMenuItem
            // 
            this.circuloToolStripMenuItem.Name = "circuloToolStripMenuItem";
            this.circuloToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.circuloToolStripMenuItem.Text = "Circulo";
            this.circuloToolStripMenuItem.Click += new System.EventHandler(this.circuloToolStripMenuItem_Click);
            // 
            // elipseToolStripMenuItem
            // 
            this.elipseToolStripMenuItem.Name = "elipseToolStripMenuItem";
            this.elipseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.elipseToolStripMenuItem.Text = "Elipse";
            this.elipseToolStripMenuItem.Click += new System.EventHandler(this.elipseToolStripMenuItem_Click);
            // 
            // rellenoToolStripMenuItem
            // 
            this.rellenoToolStripMenuItem.Name = "rellenoToolStripMenuItem";
            this.rellenoToolStripMenuItem.Size = new System.Drawing.Size(61, 30);
            this.rellenoToolStripMenuItem.Text = "Relleno";
            this.rellenoToolStripMenuItem.Click += new System.EventHandler(this.rellenoToolStripMenuItem_Click);
            // 
            // recorteToolStripMenuItem
            // 
            this.recorteToolStripMenuItem.Name = "recorteToolStripMenuItem";
            this.recorteToolStripMenuItem.Size = new System.Drawing.Size(64, 30);
            this.recorteToolStripMenuItem.Text = "Recorte";
            // 
            // parametricasToolStripMenuItem
            // 
            this.parametricasToolStripMenuItem.Name = "parametricasToolStripMenuItem";
            this.parametricasToolStripMenuItem.Size = new System.Drawing.Size(91, 30);
            this.parametricasToolStripMenuItem.Text = "Parametricas";
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 561);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmHome";
            this.Text = "DeberInteractivo";
            this.Load += new System.EventHandler(this.FrmHome_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem lineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem curvasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem circuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem elipseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rellenoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem recorteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parametricasToolStripMenuItem;
    }
}