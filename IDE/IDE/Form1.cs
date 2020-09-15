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
    }
}
