using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IDE
{
    class AnalizadorSintactico
    {
        ArrayList tokens;
        Analizador lexico = new Analizador();

        public void AnalizadorL(String[] datos)
        {
            String errores = "";
            int total = datos.Length;
            int contador = 0;
            int produccion = 0;
            List<Token> listaTokens;
            String resultado = "";

            for (int i = 0; i < datos.Length; i++)
            {
                Boolean tradu = false;
                String valor = datos[i].ToString();

                if (!valor.Equals("Principal ()") && i == 0)
                {
                    errores += "Falta metodo inicial. Se esperaba Principal () \n";
                }

               else if (i == 0)
                {
                    produccion++;
                    tradu = true;
                }
  
                //validacion de variable 
                if (valor.Contains("entero") || valor.Contains("cadena") || valor.Contains("booleano") || valor.Contains("decimal") || valor.Contains("caracter") && !valor.Contains("SI"))
                {
                    try
                    {
                        int inicioval = 0;
                        int inicioval2 = fin(datos[i], "=");
                        string ident = datos[i].Substring((inicioval), (inicioval2));
                        if (lexico.Reservada(ident.Trim()))
                        {
                            errores += "Se esperaba un identificador \n";

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
                        errores += "Error de gramatica de variable " + datos[i] + "\n";
                    }

                }

                if (valor.Contains("SI"))
                {
                    try
                    {
                        int inicioval = 0;
                        int inicioval2 = fin(datos[i], "(");
                        //nombre que se le dara al metodo 
                        string ident = datos[i].Substring((inicioval), (inicioval2));
                        if (lexico.Reservada(ident.Trim()))
                        {
                            errores += "Se esperaba Parentesis \n";

                        }
                        
                        string llave = "";
                        if (valor.Trim().Contains("{"))
                        {
                            llave = "{";
                        }

                        if (valor.Trim().Contains("}"))
                        {
                            llave = "}";
                        }


                       else if (valor.Contains("SINO"))
                        {
                            inicioval = inicio(datos[i], "{");
                            inicioval2 = fin(datos[i], "");
                            //nombre que se le dara al metodo 
                            ident = datos[i].Substring((inicioval), (inicioval2));
                            if (lexico.Reservada(ident.Trim()))
                            {
                                errores += "Se esperaban llaves \n";

                            }

                        }
                        

                    }
                    catch (Exception e)
                    {
                        errores += "Error en la gramatica de la funcion ingresada ";
                    }

                }



            }









            if (errores != "")
                {
                    MessageBox.Show(errores, "Cuadro Errores");

                }
                else
                {
                    MessageBox.Show("No se han encontrado Errores Semanticos", "Cuadro Errores");
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
