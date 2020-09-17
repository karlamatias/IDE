using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE
{
    public partial class Form1 : Form
    {
        string[] OpMatematicos = new string[] { "+", "-", "*", "/" };
        string[] VariableString = new string[] { "String" };
        string[] VariableInt = new string[] { "int" + "" };
        string[] VariableDouble = new string[] { "Double" + "" };
        string[] Operadores = new string[] { "||", "&&", "!", "(", ")", "<", ">", ">=", "<=", "==", "!=" };
        string[] Asignacion_Final = new string[] { "=", ";" };
        string[] Reservadas = new string[] { "if", "else if", "while" };
        static private List<Token> lis_toks;
        static private List<ErroresToken> lis_errores;
        int posicion = 0;

        public Form1()
        {
            InitializeComponent();
            Entrada.Enabled = false;
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
            Analizador analiz = new Analizador();
            analiz.Analizador_cadena(texto);

            analiz.generarLista();
            Salida.Text = analiz.getRetorno();

            analiz.generarListaErrores();
            tablaErrores.Text = analiz.getRetorno();

            lis_toks = new List<Token>();
            lis_toks = analiz.getListaTokens();

            lis_errores = new List<ErroresToken>();
            lis_errores = analiz.getListaErrores();

            for (int i = 0; i < lis_toks.Count; i++)
            {
                Token actual = lis_toks.ElementAt(i);
                //MessageBox.Show("[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]", "des");

            }

            /*for (int i = 0; i < lis_errores.Count; i++)
            {
                ErroresToken actual = lis_errores.ElementAt(i);
                MessageBox.Show("[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]", "des");
            }
            */

        }

        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entrada.Enabled = true;
            Entrada.Clear();
            Salida.Clear();
        }

        private void abrirProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "rich text box(*.gtE) | *.gtE";
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
            saveFileDialog1.Filter = "rich text box(*.gtE) | *.gtE";
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
                            Entrada.SelectionColor = Color.Fuchsia;
                            this.Entrada.Select(posicion, 0);
                            inicio = inicio + 1;
                        }
                    }
                }






            }//x
        

            } //Cierra CambioColor
        }

    }

