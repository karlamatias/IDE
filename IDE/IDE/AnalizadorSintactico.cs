using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Windows.Forms;
public struct Vector : IFormattable
{
    public string ToString(string format, IFormatProvider formatProvider)
    {
        throw new NotImplementedException();
    }
};


namespace IDE
{

    class AnalizadorSintactico
    {
        private String retorno;
        private String retornoErrores;

        
        static private List<ErroresSintacticos> listaErroresS;
       
        
        public void addError(string error, int fila, int columna, string solucion)
        {
            ErroresSintacticos errores = new ErroresSintacticos(error, fila, columna, solucion);
            listaErroresS.Add(errores);
        }
          public AnalizadorSintactico()
          {

              //errores tokens
              listaErroresS = new List<ErroresSintacticos>();

          }

          Analizador lexico = new Analizador();

          string[] Operadores = new string[] { "||", "&&", "!", "(", ")", "<", ">", ">=", "<=", "==", "!=" };

          String errores = "";

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

          public void MetodoPrincipal(string[] datos)
          {
              for (int i = 0; i < datos.Length; i++)
              {

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
                              addError("Falta parentesis que abre ", fila, columna, "Coloque el parentesis que falta");
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
                              addError("Falta parentesis que cierra ", fila, columna, "Coloque el parentesis que falta");
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
                              addError("Falta llave que abre metodo ", fila, columna, "Coloque llave que abre el metodo");
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
                              addError("Falta llave que cierra metodo ", fila, columna, "Coloque llave que cierra el metodo");
                          }
                          break;

                      case 5:
                          if (valor.Equals("}"))
                          {

                              errores += "Metodo MIENTRAS analizado con exito!.... ";
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


          public void AnalizadorL(string[] datos)
          {
              int total = datos.Length;
              int columna = 1;
              int fila = 1;
              int estado = 0;
              string lexema = "";

              for (int i = 0; i < datos.Length; i++)
              {
                  String valor = datos[i].ToString();
                  columna++;

                          if (valor.Contains("MIENTRAS"))
                          {
                              DeclararWhile(datos);
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
                                      addError("Falta identificador", fila, columna, "Coloque un identificador para la variable ");

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
                                  //addError("Error en la gramatica ", fila, columna, "Revise que sus varables esten escritas correctamente  ");
                              }

                          }

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
                              addError("Falta metodo Principal", fila, columna, "Coloque el metodo Principal");
                              // errores += "Falta metodo Principal.... ";
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
                              addError("Falta parentesis que abre", fila, columna, "Coloque el parentesis que hace falta");
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
                              addError("Falta parentesis que cierra", fila, columna, "Coloque el parentesis que hace falta");
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
                              addError("Falta llave que abre", fila, columna, "Coloque el parentesis que hace falta");
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
                              addError("Falta cerrar el metodo Principal", fila, columna, "Cierre el metodo Principal con una llave");
                          }
                          break;
                  }
              }
          }
          public void generarListaErrores()
          {
              for (int i = 0; i < listaErroresS.Count; i++)
              {
                  ErroresSintacticos actual = listaErroresS.ElementAt(i);
                  retornoErrores += "Error: " + actual.error + ", Fila del error: " + actual.num_lineaE + ", Columna: " + actual.columna + ", Solucion: " + actual.sol_error + Environment.NewLine;
              }
          }

          public String getRetornoErrores()
          {
              return this.retornoErrores;
          }
          public String getRetorno()
          {
              return this.retorno;
          }
          public List<ErroresSintacticos> getListaErrores()
          {
              return listaErroresS;
          }
        

           /* //No terminales
            string[] columnas = {"Principal ( ) ", "{", "}", "id", "entero", "decimal", "booleano", "char", "cadena", "SI", "SINO", "NO", "MIENTRAS",
                "HACER" ,"DESDE", "HASTA", "<", ">", "<=", ">=", "=", "!=", " Ɛ", "++", "--", "$"};
            string[] filas = { "E", "P", "C", "CV", "B", "V", "IF", "WHILE", "FOR", "IF", "SI", "O", "CON", "NO", "SINO", "F", "H", "I", "S" };

            string[] tabla = {"				P		",
            "C	C	C	C	$				P		",
            "						L	L	L	L	L														$			",
            "						CV	CV	CV	CV	CV																	",
            "						$	$	$	$	$																	",
            "												IF															",
            "						$	$	$	$	$																	",
            "														CON													",
            "															CON												",
            "												F				F	F										",
            "												SI															",
			"									SI															            ", 
			"			V	V	V	V	V																	            ",
			"															V	V	V	V		V				            ", 
			"			  							NO														            ",
			"								SINO																        ",
			"		V																	V					            ",
			"														H										            ",
			"		S																						            "
            };

        

        List<string []> tablacompleta;

        public AnalizadorSintactico()
        {
            int columna = 1;
            int fila = 1;
            listaErroresS = new List<ErroresSintacticos>();
            string  textoSucio = "" ;
            string[] texto = limpiarTexto(textoSucio);
 
        }

        private string[] limpiarTexto(string txt)
        {
            string aux = txt.Replace("\\r\\n|\\r|\\n", "");
            return aux.Split();
        }

        public string [] Accion(string tengo, string buscar)
        {
            int a = DevolverPosicion(columnas, buscar);
            int b = DevolverPosicion(filas, tengo);
            return tablacompleta.ElementAt(a)[b].Split(' ');
        }

 
        Stack<string> cadena;
        public void Analizar(string[] text)
        {
            string tengo = "";
            string busco = "";

            for (int i = 0; i < text.Length; i++)
            {
                busco = text[i];
            }
            do
            {
                addError("", fila, columna, "");
                if (tengo.Equals(""))
                {
                    cadena.Pop();
                    tengo = cadena.Last();

                }
                else
                {
                    if (cadena.Count() != 0)
                    {
                        cadena.Pop();
                        string[] accion = Accion(tengo, busco);
                        for (int j = accion.Length - 1; j >= 0; j++)
                        {
                            cadena.Push(accion[j]);
                        }
                        tengo = cadena.Last();
                    }

                } 
            } while (!tengo.Equals(busco));

            cadena.Pop();
            tengo = cadena.Last();
        }

        string[] aux;


        public int DevolverPosicion(string[] busca,string cad)
        {
            int aux = 0;
            for (int i = 0; i < busca.Length; i++)
            {
                if (busca[i].Equals(cad))
                {
                    aux = i;
                }
                else
                {

                }
            }
            return aux;
        }

        public void generarListaErrores()
        {
            for (int i = 0; i < listaErroresS.Count; i++)
            {
                ErroresSintacticos actual = listaErroresS.ElementAt(i);
                retornoErrores += "Error: " + actual.error + ", Fila del error: " + actual.num_lineaE + ", Columna: " + actual.columna + ", Solucion: " + actual.sol_error + Environment.NewLine;
            }
        }

        public String getRetornoErrores()
        {
            return this.retornoErrores;
        }
        public String getRetorno()
        {
            return this.retorno;
        }
        public List<ErroresSintacticos> getListaErrores()
        {
            return listaErroresS;
        }*/
    }
    }
