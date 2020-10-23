using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Windows.Forms;

namespace IDE
{
    class AnalizadorSintactico
    {
        Analizador lexico = new Analizador();
        string[] Operadores = new string[] { "||", "&&", "!", "(", ")", "<", ">", ">=", "<=", "==", "!=" };

        String errores = "";
        
        int contador = 0;
        int produccion = 0;
        String resultado = "";
        int columna = 1;
        int fila = 1;
        int estado = 0;
        string lexema = "";

        public void DeclararIF_Else(string[] datos)
        {
            int total = datos.Length;
            for (int i = 0; i < datos.Length; i++)
            {
                String valor = datos[i].ToString();
                columna++;

                switch (estado)
                {
                    case 0:
                        if (valor.Contains("SI"))
                        {
                            estado = 1;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("SI"))
                        {
                            lexema += valor;
                            estado = 0;
                            errores += "Falta palabra reservada SI.... ";
                        }
                        break;

                    case 1:
                        if (valor.Contains("("))
                            {
                            estado = 2;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("("))
                        {
                            lexema += valor;
                            estado = 1;
                            errores += "Falta parentesis que abre.... ";
                        }

                        break;
      

                    case 2:
                        if (valor.Contains(")"))
                        {
                            estado = 3;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals(")"))
                        {
                            lexema += valor;
                            estado = 2;
                            lexema = "";
                            errores += "Falta parentesis que cierra.... ";
                        }
                        break;

                    case 3:
                        if (valor.Contains("{"))
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("{"))
                        {
                            lexema += valor;
                            estado = 3;
                            lexema = "";
                            errores += "Falta llave que abre.... ";
                        }
                        break;

                    case 4:
                        if (valor.Contains("}"))
                        {
                            estado = 5;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("}"))
                        {
                            lexema += valor;
                            estado = 4;
                            lexema = "";
                            errores += "Falta llave que cierra.... ";
                        }
                        break;

                    case 5:
                        if (valor.Equals("}"))
                        {

                            errores += "Metodo Si analizado con exito!.... ";
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        else if (valor.Equals("SINO"))
                        {
                            if (valor.Equals("SI"))
                            {
                                estado = 0;
                                i--;
                                columna--;
                            }
                            else if (!valor.Equals("SI") && valor.Equals("{"))
                            {
                                estado = 6;
                                i--;
                                columna--;
                            }
                        }
                        break;
                    case 6:
                        if (valor.Contains("{"))
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("{"))
                        {
                            lexema += valor;
                            estado = 7;
                            lexema = "";
                            errores += "Falta llave que abre.... ";
                        }
                        break;

                    case 7:
                        if (valor.Equals("}"))
                        {

                            errores += "Metodo SINO analizado con exito!.... ";
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                }

            }
            if (errores != "")
            {
                MessageBox.Show(errores);
            }
            else
            {
                MessageBox.Show("No se encontraron Errores sintacticos");
            }
        }


        public void Variables(string[] datos)
        {
            for (int i = 0; i < datos.Length; i++)
            {
                String valor = datos[i].ToString();
                if (valor.Contains("entero") || valor.Contains("cadena") || valor.Contains("booleano") || valor.Contains("decimal") || valor.Contains("caracter") && !valor.Contains("SI") && !valor.Contains("SINO"))
                {
                    try
                    {
                        int inicioval = 0;
                        int inicioval2 = fin(datos[i], "=");
                        string ident = datos[i].Substring((inicioval), (inicioval2));
                        if (lexico.Reservada(ident.Trim()))
                        {
                            errores += "Se esperaba un identificador " + datos[i] + "\n";

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
                        
                    }

                    catch (Exception e)
                    {
                        errores += "Error de gramatica de variable " + datos[i] + "\n";
                    }

                }
            }
        }


        public void MetodoPrincipal(string[] datos)
        {
            for (int i = 0; i < datos.Length; i++)
            {
                String valor = datos[i].ToString();
                columna++;

                switch (estado)
                {
                    case 0:
                        if (valor.Contains("Principal"))
                        {
                            estado = 1;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("Principal"))
                        {
                            lexema += valor;
                            estado = 0;
                            errores += "Falta metodo Principal.... ";
                        }
                        break;

                    case 1:
                        if (valor.Contains("("))
                        {
                            estado = 2;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("("))
                        {
                            lexema += valor;
                            estado = 1;
                            errores += "Falta parentesis que abre.... ";
                        }

                        break;


                    case 2:
                        if (valor.Contains(")"))
                        {
                            estado = 3;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals(")"))
                        {
                            lexema += valor;
                            estado = 2;
                            lexema = "";
                            errores += "Falta parentesis que cierra.... ";
                        }
                        break;

                    case 3:
                        if (valor.Contains("{"))
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("{"))
                        {
                            lexema += valor;
                            estado = 3;
                            lexema = "";
                            errores += "Falta llave que abre.... ";
                        }
                        break;

                    case 4:
                        if (valor.Contains("}"))
                        {
                            estado = 5;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("}"))
                        {
                            lexema += valor;
                            estado = 4;
                            lexema = "";
                            errores += "Falta llave que cierra.... ";
                        }
                        break;
                }
            }
            if (errores != "")
            {
                MessageBox.Show(errores);
            }
            else
            {
                MessageBox.Show("No se encontraron Errores sintacticos");
            }
        }

        public void DeclararWhile(string[] datos)
        {
            int total = datos.Length;
            for (int i = 0; i < datos.Length; i++)
            {
                String valor = datos[i].ToString();
                columna++;
                switch (estado)
                {
                    case 0:
                        if (valor.Contains("MIENTRAS"))
                        {
                            estado = 1;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("MIENTRAS"))
                        {
                            lexema += valor;
                            estado = 0;
                            errores += "Falta palabra reservada MIENTRAS.... ";
                        }
                        break;

                    case 1:
                        if (valor.Contains("("))
                        {
                            estado = 2;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("("))
                        {
                            lexema += valor;
                            estado = 1;
                            errores += "Falta parentesis que abre.... ";
                        }

                        break;


                    case 2:
                        if (valor.Contains(")"))
                        {
                            estado = 3;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals(")"))
                        {
                            lexema += valor;
                            estado = 2;
                            lexema = "";
                            errores += "Falta parentesis que cierra.... ";
                        }
                        break;

                    case 3:
                        if (valor.Contains("{"))
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("{"))
                        {
                            lexema += valor;
                            estado = 3;
                            lexema = "";
                            errores += "Falta llave que abre.... ";
                        }
                        break;

                    case 4:
                        if (valor.Contains("}"))
                        {
                            estado = 5;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("}"))
                        {
                            lexema += valor;
                            estado = 4;
                            lexema = "";
                            errores += "Falta llave que cierra.... ";
                        }
                        break;

                    case 5:
                        if (valor.Equals("}"))
                        {

                            errores += "Metodo Si analizado con exito!.... ";
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        else if (valor.Equals("SINO"))
                        {
                            if (valor.Equals("SI"))
                            {
                                estado = 0;
                                i--;
                                columna--;
                            }
                            else if (!valor.Equals("SI") && valor.Equals("{"))
                            {
                                estado = 6;
                                i--;
                                columna--;
                            }
                        }
                        break;
                    case 6:
                        if (valor.Contains("{"))
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (!valor.Equals("{"))
                        {
                            lexema += valor;
                            estado = 7;
                            lexema = "";
                            errores += "Falta llave que abre.... ";
                        }
                        break;

                    case 7:
                        if (valor.Equals("}"))
                        {

                            errores += "Metodo SINO analizado con exito!.... ";
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                }

            }



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
        
        
        /* public AnalizadorSintactico()
         {
             tabla = new string[24, 23];
             tas = new string[24, 23];
         }

         public string PrintPila(Stack pila)
         {
             string cadena = "";
             for (int i = 0; i < pila.Count; i++)
             {
                 cadena = cadena + pila[i];
                 if (i != pila.Count - 1)
                 {
                     cadena = cadena + "";
                 }

             }

             if (cadena.Length < 24)
             {
                 for (int i = cadena.Length; i < 24; i++)
                 {
                     cadena = cadena + "";
                 }
             }
             return cadena;
         }

         public void llamarTabla()
         {
             tabla[0, 1] = "Principal () {";
             tabla[0, 2] = "id";
             tabla[0, 3] = "entero";
             tabla[0, 4] = "decimal";
             tabla[0, 5] = "booleano";
             tabla[0, 6] = "cadena";
             tabla[0, 7] = "char";
             tabla[0, 8] = "_id";
             tabla[0, 9] = "SI (";
             tabla[0, 10] = "<";
             tabla[0, 11] = ">";
             tabla[0, 12] = "<=";
             tabla[0, 13] = ">=";
             tabla[0, 14] = "NO {";
             tabla[0, 15] = "SINO(";
             tabla[0, 16] = "MIENTRAS(";
             tabla[0, 17] = "HACER(";
             tabla[0, 18] = "DESDE(";
             tabla[0, 19] = "HASTA(";
             tabla[0, 20] = "AUMENTO";
             tabla[0, 21] = "DECREMENTO";
             tabla[0, 22] = "signo";
             tabla[0, 23] = "$";

             tabla[0, 0] = "";
             tabla[1, 0] = "<principal>";
             tabla[2, 0] = "<codigo>";
             tabla[3, 0] = "<lineas>";
             tabla[4, 0] = "<metodo>";
             tabla[5, 0] = "<parametro>";
             tabla[6, 0] = "<parametroEnvio>";
             tabla[7, 0] = "<pEnvio>";
             tabla[8, 0] = "<valor>";
             tabla[9, 0] = "<crearVariable>";
             tabla[10, 0] = "<bucle>";
             tabla[11, 0] = "<If>";
             tabla[12, 0] = "<condicionSi>";
             tabla[13, 0] = "<condicion>";
             tabla[14, 0] = "<condicional>";
             tabla[15, 0] = "<condicionNO>";
             tabla[16, 0] = "<condicionSINO>";
             tabla[17, 0] = "<While>";
             tabla[18, 0] = "<doWhile>";
             tabla[19, 0] = "<condicionFOR>";
             tabla[20, 0] = "<for>";
             tabla[21, 0] = "<HASTA>";
             tabla[22, 0] = "<INCREMENTO>";
             tabla[23, 0] = "<signo>";

         }

         public Boolean verificarNumero(string tok)
         {
             try
             {
                 int.Parse(tok);
                 return true;
             }
             catch (Exception)
             {

                 return false;
             }

         }
         public Boolean esTerminal(string cadena)
         {
             for (int i = 0; i < tabla[0, i].Length; i++)
             {
                 if (cadena.Equals(tabla[0, i]))
                 {
                     return true;
                 }
             }
             return false;
         }

         public void verificar(string[] tok, int apu)
         {
             this.estado = 1; //inicializar estado en 1
             string[] tokens = tok;
             pila = new Stack();
             if (verificarNumero(tokens[apu]) == true)
             {
                 pila.Push("$");
                 pila.Push(tabla[0, 1]);
             }


         }

         public Boolean verificarIf(string tok)
         {
             for (int i = 0; i < tok.Length; i++)
             {
                 if (!char.IsLetter(tok[i]))
                 {
                     return false;
                 }
             }
             return true;
         }

       /*  public Boolean obtenerGramatica(string noTerminal, string terminal)
         {
             int fila = obtenerFila(noTerminal);
             int columna = obtenerColumna(terminal);

             if (columna == 0 && noTerminal.Equals("<parametro>"))
             {
                 if (verificarNumero(terminal) == true)
                 {
                     tabla[0, 3] = terminal;
                     tabla[0, 4] = terminal;
                     columna = 3;
                     columna = 4;
                 }
             }

             if (columna == 0 && noTerminal.Equals("<parametro>"))
             {
                 if (verificarIf(terminal) == true || verificarNumero(terminal) == true)
                 {
                     tabla[0, 2] = terminal;
                     tabla[0, 8] = terminal;
                     columna = 2;
                     columna = 8;
                 }
             }
         }

     */

        /*   static private List<ErroresToken> listaErrores;
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







       public void AnalizadorL(string [] datos) {

           int principal = 1;
           int llavesnecesarias = 0;
           Boolean cierrePrincipal= false;
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
               string palabraanterior = "";
               cierrePrincipal = false;



               if (!valor.Equals("Principal ( ) { "))
               {
                   errores += "Falta Metodo Principal \n";
               } 


               else if (i == 0)
               {
                   produccion++;
                   tradu = true;

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
                           errores += "Se esperaba un identificador " + datos[i] + "\n";

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
                       int inicioval2 = fin(datos[i], ")");
                       string ident = datos[i].Substring((inicioval), (inicioval2));
                       if (lexico.Reservada(ident.Trim()))
                       {
                          errores += "Se esperaba parentesis " + datos[i] + "\n";

                       }

                       string llave = "";
                       if (valor.Trim().Contains("{"))
                       {
                           llave = "{";
                       }

                       if (valor.Contains("Principal"))
                       {
                           tradu = true;
                       }
                       else
                       {
                           tradu = true;
                       }

                       if (valor.Contains("SINO"))
                       {
                           inicioval = 0;
                           inicioval2 = fin(datos[i], "}");
                           ident = datos[i].Substring((inicioval), (inicioval2));
                           if (lexico.Reservada(ident.Trim()))
                           {
                               errores += "Se esperaban llaves " + datos[i] + "\n";

                           }



                           if (valor.Contains("Principal "))
                           {
                               tradu = true;
                           }
                           else
                           {
                               tradu = true;
                           }
                       }

                   }
                   catch (Exception e)
                   {

                       errores += "Se esperaba Parentesis " + datos[i] + "\n";
                   }





               }

               if (valor.Contains("FIN"))
               {
                   string valortraducir = valor.Replace("FIN", "return");
                   tradu = true;

               }

           }

           if (errores != "")
           {
               MessageBox.Show(errores);
           }
           else
           {
               MessageBox.Show("No se encontraron Errores sintacticos");
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
       }*/


    }
        }

