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
                String valor = datos[i].ToString().ToUpper();

                if (!valor.Equals("Principal ()") && i == 0)
                {
                    errores += "Falta metodo inicial. Se esperaba Principal () \n";
                }
                 if (i == 0) {
                    produccion++;
                    tradu = true;
                }




                /*if (!valor.Equals("Principal") && i == 0)
                {
                    errores += "Se esperaba Principal \n";
                }
                 if (i == 0) {
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
                if (valor.Contains("Funciones")) {
                    try
                    {
                        int inicioval = inicio(datos[i], "");
                        int inicioval2 = fin(datos[i], "(");
                        //nombre que se le dara al metodo 
                        string ident = datos[i].Substring((inicioval), (inicioval2));
                        if (lexico.Reservada(ident.Trim()))
                        {
                            errores += "Se esperaba un identificador \n";

                        }
                        string tipo = "principal";
                        if (valor.Contains("( : cadena") || valor.Contains(" ) : cadena "))
                        {
                            tipo = "String";
                        }
                        else if (valor.Contains("( : entero ") || valor.Contains(") : entero"))
                        {
                            tipo = "Int";  
                        }
                        string llave = "";
                        if (valor.Trim().Contains("{")) {
                            llave = "{";
                        }

                        if (valor.Contains("Principal")) {
                            tradu = true;
                        }
                        else
                        {
                            tradu = true;
                        }

                        if (!valor.Contains("Funciones"))
                        {
                            errores = "Se esperaba la palabra Metodo " + datos;

                        }
                        else if(!valor.Contains("Principal"))
                        {
                           inicioval = inicio(datos[i], "");
                           inicioval2 = fin(datos[i], "(");

                            //string de los parametros 
                             ident = datos[i].Substring((inicioval), (inicioval2));
                            if (ident.Trim() != "") 
                            {
                                String[] listaParametros = null;
                                if (ident.Contains(","))
                                {
                                    listaParametros = ident.Split(',');

                                }
                                else
                                {
                                    listaParametros = new string[i];
                                    listaParametros[0] = ident;
                                }

                                for (int j = 0; j<listaParametros.Length; j++)
                                {
                                    String detalles = listaParametros[j];
                                    if (detalles.Contains("entero") || detalles.Contains("cadena") || detalles.Contains("booleano") || detalles.Contains("decimal") || detalles.Contains("caracter"))
                                    {
                                        inicioval = 0;
                                        inicioval2 = fin(datos[i], ":");
                                        ident = datos[i].Substring((inicioval), (inicioval2));
                                        if (lexico.Reservada(ident.Trim()))
                                        {
                                            errores += "Se esperaba un identificador \n";

                                        }

                                    }
                                }
                            }
                        }

                    }
                    catch (Exception e) {
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
            if (fin == 1) {
                fin = cadena.ToString().IndexOf(comparacion.ToUpper());
            }
            return fin;
        }
*/

            }
        }
    }
}