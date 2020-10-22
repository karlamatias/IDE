using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE
{
    public partial class Form1 : Form
    {

        //declaro las variables para cambiar el color segun sea el caso 
        string[] OpMatematicos = new string[] { "+" , "-" , "*" , "/" , "--" , "++" };
        string[] VariableString = new string[] { "cadena" };
        string[] VariableInt = new string[]{ "entero" };  
        string[] VariableDouble = new string[] { "decimal" };
        string[] VariableBoolean = new string[] { "booleano" };
        string[] VariableChar = new string[] { "caracter" };
        string[] Operadores = new string[] { "||" , "&&" , "!" , "(" , ")" , "<" , ">" , ">=" , "<=" , "==" , "!="};
        string[] Asignacion_Final = new string[] { "=" , ";"};
        string[] Comentarios = new string[] { "//" , "/*" , "*/"};
        string[] Reservadas = new string[] { "SI" , "SINO" , "SINO_SI" , "MIENTRAS" , "HACER" , "DESDE" , "HASTA" , "INCREMENTO" , "Principal"};
        static private List<Token> lis_toks;

        int posicion = 0;
        

        public Form1()
        {
            InitializeComponent();
            Entrada.Enabled = false;
            Salida.Enabled = false;
            tablaErrores.Enabled = false;
            //cambio de color a la hora de ingresar el texto 
            {
                CambioColor();
                this.Entrada.SelectionStart = this.Entrada.Text.Length;
                this.Entrada.TextChanged += (ob, ev) =>
                {
                    posicion = Entrada.SelectionStart;
                    CambioColor();
                };
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String texto;
            texto = Entrada.Text;
            String[] nuevo = new String[] { texto };
            Analizador analiz = new Analizador();
            analiz.Analizador_cadena(texto);

            analiz.generarLista();
            Salida.Text = analiz.getRetorno();

            analiz.generarListaErrores();
            tablaErrores.Text = analiz.getRetornoErrores();

            lis_toks = new List<Token>();
            lis_toks = analiz.getListaTokens();


            for (int i = 0; i < lis_toks.Count; i++)
            {
                Token actual = lis_toks.ElementAt(i);
                
            }

            AnalizadorSintactico sintactico = new AnalizadorSintactico();
            sintactico.AnalizadorL(nuevo);
        }


        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string nombreProyecto;
            nombreProyecto = Microsoft.VisualBasic.Interaction.InputBox("Ingrese nombre del Proyecto:" , "Nuevo Proyecto", "", 100, 0);


            string carpeta = Application.StartupPath + nombreProyecto;
            try
            {
                if (Directory.Exists(carpeta))
                {
                    MessageBox.Show("Ese nombre ya existe ");
                }
                else
                {
                    Directory.CreateDirectory(carpeta);
                    MessageBox.Show("Proyecto crado con exito! ");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error :" + ex.Message);
            }
                /*Entrada.Enabled = true;
                Salida.Enabled = true;
                tablaErrores.Enabled = true;
                Entrada.Clear();
                Salida.Clear();
                tablaErrores.Clear();*/

            }
        
    
   

        private void abrirProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entrada.Enabled = true;
            Salida.Enabled = true;
            tablaErrores.Enabled = true;
            Entrada.Clear();
            Salida.Clear();
            tablaErrores.Clear();
            openFileDialog1.Filter = "rich text box(*.txt) | *.txt";
            openFileDialog1.FileName = "";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.InitialDirectory = "Escritorio";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Entrada.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Archivo Abierto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            {
                CambioColor();
                this.Entrada.SelectionStart = this.Entrada.Text.Length;
                this.Entrada.TextChanged += (ob, ev) =>
                {
                    posicion = Entrada.SelectionStart;
                    CambioColor();
                };
            }
        }

        private void guardarProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "rich text box(*.txt) | *.txt";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.Title = "Save File";

            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Entrada.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("Archivo Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        public void CambioColor() {

            this.Entrada.Select(0, Entrada.Text.Length);
            this.Entrada.SelectionColor = Color.Black;
            this.Entrada.Select(posicion, 0);

            string[] texto = Entrada.Text.Trim().Split(' ');
            int inicio = 0;

            foreach (string x in texto)
            {
                foreach (string y in Reservadas)
                {
                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Green;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach (string y in OpMatematicos)
                {
                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Blue;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach (string y in Operadores)
                {
                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Blue;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach (string y in Asignacion_Final)
                {
                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Fuchsia;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                 }

                foreach (string y in VariableString)
                {
                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Gray;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach (string y in VariableInt)
                {

                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Purple;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach (string y in VariableDouble)
                {

                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Cyan;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach (string y in VariableBoolean)
                {

                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Orange;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach (string y in VariableChar)
                {

                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Maroon;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

                foreach(string y in Comentarios)
                {

                    if (x.Length != 0)
                    {
                        if (x.Trim().Equals(y))
                        {
                            inicio = this.Entrada.Text.IndexOf(x, inicio);
                            this.Entrada.Select(inicio, x.Length);
                            Entrada.SelectionColor = Color.Red;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }

            }//x
        

            } //Cierra CambioColor

        private void exportarErroresToolStripMenuItem_Click(object sender, EventArgs e)
        {

            SaveFileDialog guardar = new SaveFileDialog();
            guardar.Filter = "rich text box(*.gtE) | .gtE";
            guardar.Title = "Exportar Errores";
            var resultado = guardar.ShowDialog();

            if(resultado == DialogResult.OK)
            {
                StreamWriter escribir = new StreamWriter(guardar.FileName);
                foreach (object line in tablaErrores.Lines)
                {
                    escribir.WriteLine(line);

                }
                escribir.Close();
                MessageBox.Show("Archivo Guardado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }


        }
    }

    }

