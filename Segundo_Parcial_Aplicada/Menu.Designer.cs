namespace Segundo_Parcial_Aplicada
{
    partial class Menu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Menu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.articuloToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.articuloToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.registroArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroTalleresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroVehiculosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroEntradaArticulosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ayudaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Orange;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articuloToolStripMenuItem,
            this.consultarToolStripMenuItem,
            this.ayudaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(730, 29);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // articuloToolStripMenuItem
            // 
            this.articuloToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.articuloToolStripMenuItem1,
            this.registroArticulosToolStripMenuItem,
            this.registroTalleresToolStripMenuItem,
            this.registroVehiculosToolStripMenuItem,
            this.registroEntradaArticulosToolStripMenuItem});
            this.articuloToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.articuloToolStripMenuItem.Name = "articuloToolStripMenuItem";
            this.articuloToolStripMenuItem.Size = new System.Drawing.Size(129, 25);
            this.articuloToolStripMenuItem.Text = "Crear Registro";
            // 
            // articuloToolStripMenuItem1
            // 
            this.articuloToolStripMenuItem1.Name = "articuloToolStripMenuItem1";
            this.articuloToolStripMenuItem1.Size = new System.Drawing.Size(278, 26);
            this.articuloToolStripMenuItem1.Text = "Registro Mantenimiento";
            this.articuloToolStripMenuItem1.Click += new System.EventHandler(this.articuloToolStripMenuItem1_Click);
            // 
            // registroArticulosToolStripMenuItem
            // 
            this.registroArticulosToolStripMenuItem.Name = "registroArticulosToolStripMenuItem";
            this.registroArticulosToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.registroArticulosToolStripMenuItem.Text = "Registro Articulos";
            this.registroArticulosToolStripMenuItem.Click += new System.EventHandler(this.registroArticulosToolStripMenuItem_Click);
            // 
            // registroTalleresToolStripMenuItem
            // 
            this.registroTalleresToolStripMenuItem.Name = "registroTalleresToolStripMenuItem";
            this.registroTalleresToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.registroTalleresToolStripMenuItem.Text = "Registro Talleres";
            this.registroTalleresToolStripMenuItem.Click += new System.EventHandler(this.registroTalleresToolStripMenuItem_Click);
            // 
            // registroVehiculosToolStripMenuItem
            // 
            this.registroVehiculosToolStripMenuItem.Name = "registroVehiculosToolStripMenuItem";
            this.registroVehiculosToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.registroVehiculosToolStripMenuItem.Text = "Registro Vehiculos";
            this.registroVehiculosToolStripMenuItem.Click += new System.EventHandler(this.registroVehiculosToolStripMenuItem_Click);
            // 
            // registroEntradaArticulosToolStripMenuItem
            // 
            this.registroEntradaArticulosToolStripMenuItem.Name = "registroEntradaArticulosToolStripMenuItem";
            this.registroEntradaArticulosToolStripMenuItem.Size = new System.Drawing.Size(278, 26);
            this.registroEntradaArticulosToolStripMenuItem.Text = "Registro Entrada Articulos";
            this.registroEntradaArticulosToolStripMenuItem.Click += new System.EventHandler(this.registroEntradaArticulosToolStripMenuItem_Click);
            // 
            // consultarToolStripMenuItem
            // 
            this.consultarToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.consultarToolStripMenuItem.Name = "consultarToolStripMenuItem";
            this.consultarToolStripMenuItem.Size = new System.Drawing.Size(95, 25);
            this.consultarToolStripMenuItem.Text = "Consultar";
            // 
            // ayudaToolStripMenuItem
            // 
            this.ayudaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ayudaToolStripMenuItem.Name = "ayudaToolStripMenuItem";
            this.ayudaToolStripMenuItem.Size = new System.Drawing.Size(71, 25);
            this.ayudaToolStripMenuItem.Text = "Ayuda";
            // 
            // Menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(730, 377);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Menu";
            this.Text = "Menu";
            this.Load += new System.EventHandler(this.Menu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem articuloToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem articuloToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem consultarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroArticulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroTalleresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroVehiculosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroEntradaArticulosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ayudaToolStripMenuItem;
    }
}

