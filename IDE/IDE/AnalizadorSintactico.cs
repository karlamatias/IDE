using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IDE
{
    class AnalizadorSintactico
    {
        ArrayList tokens;
        Analizador lexico = new Analizador();

        public void AnalizadorL(String[] datos) {
            String errores = "";
            int total = datos.Length;
            int contador = 0;
            int produccion = 0;
            List<Token> listaTokens;
            String resultado = "";
            for (int i = 0; i < datos.Length; i++) {
                Boolean tradu = false;
                String valor = datos[i].ToString().ToUpper();
                if (!valor.Equals("PRINCIPAL") && i == 0)
                {
                    errores += "Se esperaba PRINCIPAL \n";
                }
                else if (i == 0) {
                    produccion++;
                    tradu = true;
                }
                //validacion de variable 
                if (valor.Contains("entero") || valor.Contains("cadena") || valor.Contains("booleano") || valor.Contains("decimal") || valor.Contains("caracter") && !valor.Contains("Funciones")) {
                    try
                    {
                        int inicioval = 0;
                        int inicioval2 = fin(datos[i], ":");
                        string ident = datos[i].Substring((inicioval), (inicioval2));
                        if (lexico.Reservada(ident.Trim()))
                        {
                            errores += "Se esperaba un identificador \n";

                        }



                    }
                    catch (Exception e) {
                        errores += "Error de gramatica de variable " + datos[i] + "\n";  
                    }

                }


            }



        }

        private int fin(string cadena, string comparacion)
        {
            int fin = cadena.ToString().IndexOf(comparacion.ToUpper());
            if (fin == 1) {
                fin = cadena.ToString().IndexOf(comparacion.ToUpper());
            }
            return fin;
        }


    }
}