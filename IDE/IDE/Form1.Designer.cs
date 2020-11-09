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
            this.exportarErroresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Entrada = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Salida = new System.Windows.Forms.RichTextBox();
            this.Errores = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tablaErrores = new System.Windows.Forms.RichTextBox();
            this.CuadroSintactico = new System.Windows.Forms.RichTextBox();
            this.Sintacticos = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GrayText;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(937, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoProyectoToolStripMenuItem,
            this.abrirProyectoToolStripMenuItem,
            this.guardarProyectoToolStripMenuItem,
            this.exportarErroresToolStripMenuItem});
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
            // exportarErroresToolStripMenuItem
            // 
            this.exportarErroresToolStripMenuItem.Name = "exportarErroresToolStripMenuItem";
            this.exportarErroresToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportarErroresToolStripMenuItem.Text = "Exportar Errores";
            this.exportarErroresToolStripMenuItem.Click += new System.EventHandler(this.exportarErroresToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.salirToolStripMenuItem.Text = "Salir ";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // Entrada
            // 
            this.Entrada.BackColor = System.Drawing.SystemColors.AppWorkspace;
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
            this.Salida.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Salida.Location = new System.Drawing.Point(556, 41);
            this.Salida.Name = "Salida";
            this.Salida.Size = new System.Drawing.Size(248, 277);
            this.Salida.TabIndex = 3;
            this.Salida.Text = "";
            // 
            // Errores
            // 
            this.Errores.AutoSize = true;
            this.Errores.Location = new System.Drawing.Point(12, 321);
            this.Errores.Name = "Errores";
            this.Errores.Size = new System.Drawing.Size(79, 13);
            this.Errores.TabIndex = 4;
            this.Errores.Text = "Errores Lexicos";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // tablaErrores
            // 
            this.tablaErrores.Location = new System.Drawing.Point(15, 342);
            this.tablaErrores.Name = "tablaErrores";
            this.tablaErrores.Size = new System.Drawing.Size(789, 86);
            this.tablaErrores.TabIndex = 5;
            this.tablaErrores.Text = "";
            // 
            // CuadroSintactico
            // 
            this.CuadroSintactico.Location = new System.Drawing.Point(15, 451);
            this.CuadroSintactico.Name = "CuadroSintactico";
            this.CuadroSintactico.Size = new System.Drawing.Size(789, 86);
            this.CuadroSintactico.TabIndex = 6;
            this.CuadroSintactico.Text = "";
            // 
            // Sintacticos
            // 
            this.Sintacticos.AutoSize = true;
            this.Sintacticos.Location = new System.Drawing.Point(12, 435);
            this.Sintacticos.Name = "Sintacticos";
            this.Sintacticos.Size = new System.Drawing.Size(95, 13);
            this.Sintacticos.TabIndex = 7;
            this.Sintacticos.Text = "Errores Sintacticos";
            // 
            // button2
            // 
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(255, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "Generar Arbol";
            this.button2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button2.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(937, 561);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Sintacticos);
            this.Controls.Add(this.CuadroSintactico);
            this.Controls.Add(this.tablaErrores);
            this.Controls.Add(this.Errores);
            this.Controls.Add(this.Salida);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Entrada);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
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
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RichTextBox tablaErrores;
        private System.Windows.Forms.ToolStripMenuItem exportarErroresToolStripMenuItem;
        private System.Windows.Forms.RichTextBox CuadroSintactico;
        private System.Windows.Forms.Label Sintacticos;
        private System.Windows.Forms.Button button2;
    }
}

