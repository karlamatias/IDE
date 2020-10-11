using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace IDE
{
    class AnalizadorSintactico
    {
        static private List<ErroresToken> listaErrores;
        Analizador lexico = new Analizador();
       
        public AnalizadorSintactico()
        {
           
            //errores tokens
            listaErrores = new List<ErroresToken>();

        }
        public void addError(String lexema, String idToken, int linea, int columna)
        {
            ErroresToken errtok = new ErroresToken(lexema, idToken, linea, columna);
            listaErrores.Add(errtok);
        }


        public void AnalizadorL(String[] datos)
        {
            String errores = "";
            int total = datos.Length;
            int contador = 0;
            int produccion = 0;
            String resultado = "";
            int columna = 1;
            int fila = 1;
            int estado = 0;
            string lexema = "";

            for (int i = 0; i < datos.Length; i++)
            {
                columna++;
                Boolean tradu = false;
                String valor = datos[i].ToString();
         

                if (!valor.Equals("Principal ") && i == 0)
                {
                    MessageBox.Show("Falta Metodo Principal", "Cuadro Errores");
                }
                else if (i == 0)
                {
                    produccion++;
                    tradu = true; 
                    MessageBox.Show("No se han encontrado Errores Semanticos", "Cuadro Errores");
                }

                    //validacion de variable 
                    if (valor.Contains("entero") || valor.Contains("cadena") || valor.Contains("booleano") || valor.Contains("decimal") || valor.Contains("caracter") && !valor.Contains("SI") && !valor.Contains("SINO"))
                        {
                            try
                            {
                                int inicioval = 0;
                                int inicioval2 = fin(datos[i], "=");
                                string ident = datos[i].Substring((inicioval), (inicioval2));
                                if (lexico.Reservada(ident.Trim()))
                                {
                                    MessageBox.Show( "Se esperaba un identificador \n");

                                }

                                string tipo = "";
                                if (valor.Contains("entero"))
                                {
                                    tipo = "Int";
                                }
                                else if (valor.Contains("cadena"))
                                {
                                    tipo = "String";
                                }
                                else if (valor.Contains("booleano"))
                                {
                                    tipo = "Boolean";
                                }
                                else if (valor.Contains("decimal"))
                                {
                                    tipo = "Decimal";

                                }
                                else if (valor.Contains("Caracter"))
                                {
                                    tipo = "Char";
                                }
                                tradu = true;
                            }

                            catch (Exception e)
                            {
                                MessageBox.Show( "Error de gramatica de variable " + datos[i] + "\n");
                            }

                        }

                if (valor.Contains("SI"))
                {
                    try
                    {
                        int inicioval = 0;
                        int inicioval2 = fin(datos[i], ")");
                        string ident = datos[i].Substring((inicioval), (inicioval2));
                        if (lexico.Reservada(ident.Trim()))
                        {
                            MessageBox.Show("Se esperaba parentesis \n");

                        }

                        string llave = "";
                        if (valor.Trim().Contains("{")) {
                            llave = "{";
                        }

                    }
                    catch (Exception e)
                    {

                        MessageBox.Show("Se esperaba Parentesis " + datos[i] + "\n");
                    }
                    
                    }

                }

                

                



            



            }



       


                
        private int inicio(string cadena, string comparacion)
        {
            int inicio = cadena.ToString().IndexOf(comparacion.ToUpper());
            if (inicio == 1)
            {
                inicio = cadena.ToString().IndexOf(comparacion.ToUpper());
            }
            return inicio;
        }
        private int fin(string cadena, string comparacion)
        {
            int fin = cadena.ToString().IndexOf(comparacion.ToUpper());
            if (fin == 1)
            {
               fin = cadena.ToString().IndexOf(comparacion.ToUpper());
            }
            return fin;
        }

  
    }
    }
