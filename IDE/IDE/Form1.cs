using System;
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
        static private List<Token> lis_toks;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String texto;
            texto = Entrada.Text;
            Analizador analiz = new Analizador();
            analiz.Analizador_cadena(texto);

            analiz.generarLista();
            Salida.Text = analiz.getRetorno();


            lis_toks = new List<Token>();
            lis_toks = analiz.getListaTokens();

            for (int i = 0; i < lis_toks.Count; i++)
            {
                Token actual = lis_toks.ElementAt(i);
                MessageBox.Show("[Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + "]", "des");
            }

        }

        private void nuevoProyectoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Entrada.Enabled = true;
            Entrada.Clear();
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
    }
}
