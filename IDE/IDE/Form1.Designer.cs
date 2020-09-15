namespace IDE
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarProyectoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Entrada = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Salida = new System.Windows.Forms.RichTextBox();
            this.Errores = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProyectoToolStripMenuItem,
            this.abrirProyectoToolStripMenuItem,
            this.guardarProyectoToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoProyectoToolStripMenuItem
            // 
            this.nuevoProyectoToolStripMenuItem.Name = "nuevoProyectoToolStripMenuItem";
            this.nuevoProyectoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.nuevoProyectoToolStripMenuItem.Text = "Nuevo Proyecto ";
            this.nuevoProyectoToolStripMenuItem.Click += new System.EventHandler(this.nuevoProyectoToolStripMenuItem_Click);
            // 
            // abrirProyectoToolStripMenuItem
            // 
            this.abrirProyectoToolStripMenuItem.Name = "abrirProyectoToolStripMenuItem";
            this.abrirProyectoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.abrirProyectoToolStripMenuItem.Text = "Abrir Proyecto";
            this.abrirProyectoToolStripMenuItem.Click += new System.EventHandler(this.abrirProyectoToolStripMenuItem_Click);
            // 
            // guardarProyectoToolStripMenuItem
            // 
            this.guardarProyectoToolStripMenuItem.Name = "guardarProyectoToolStripMenuItem";
            this.guardarProyectoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.guardarProyectoToolStripMenuItem.Text = "Guardar Proyecto";
            this.guardarProyectoToolStripMenuItem.Click += new System.EventHandler(this.guardarProyectoToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.salirToolStripMenuItem.Text = "Salir ";
            // 
            // Entrada
            // 
            this.Entrada.Location = new System.Drawing.Point(12, 41);
            this.Entrada.Name = "Entrada";
            this.Entrada.Size = new System.Drawing.Size(538, 277);
            this.Entrada.TabIndex = 1;
            this.Entrada.Text = "";
            // 
            // button1
            // 
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(151, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Analizar";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Salida
            // 
            this.Salida.Location = new System.Drawing.Point(12, 350);
            this.Salida.Name = "Salida";
            this.Salida.Size = new System.Drawing.Size(776, 79);
            this.Salida.TabIndex = 3;
            this.Salida.Text = "";
            // 
            // Errores
            // 
            this.Errores.AutoSize = true;
            this.Errores.Location = new System.Drawing.Point(12, 321);
            this.Errores.Name = "Errores";
            this.Errores.Size = new System.Drawing.Size(40, 13);
            this.Errores.TabIndex = 4;
            this.Errores.Text = "Errores";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Errores);
            this.Controls.Add(this.Salida);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Entrada);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarProyectoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.RichTextBox Entrada;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox Salida;
        private System.Windows.Forms.Label Errores;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

