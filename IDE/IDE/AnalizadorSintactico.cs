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


        /* public AnalizadorSintactico()
         {
     
        //No terminales
        string terminales [] = { }
        static int P = 100;
        static int C = 101;
        static int L = 102;
        static int CV = 103;
        static int B = 104;
        static int V = 105;
        static int IF = 105;
        static int WHILE = 106;
        static int DOWHILE = 107;
        static int FOR = 108;
        static int IF = 109;
        static int SI = 110;
        static int O = 111;
        static int CON = 112;
        static int NO = 113;
        static int SINO = 114;
        static int F = 115;
        static int H = 116;
        static int I = 117;
        static int I = 118;

        //terminales
        static int Principal = 105;
        static int parentesisabre = 106;
        static int parentesiscierra = 107;
        static int llavesabre = 106;
        static int llavescierra = 107;
        static int id = 108;
        static int entero = 108;
        static int decimal = 108;
        static int booleano = 108;
        static int char = 108;
        static int cadena = 108;
        static int si = 108;
        static int no = 108;
        static int mientras = 108;
        static int hacer = 108;
        static int desde = 108;
        static int hasta = 108;
        static int ++ = 108;
        static int -- = 108;
        static int $ = 108;
       	

        /**********************************************/
        //producciones
        /* int[] p1 = { TPrima, E }; // E-> ET’ 
         int[] p2 = { EPrima, T, tokenMas }; // Eprima->+TE’
         int[] p3 = { TPrima, F };// T -> F T’
         int[] p4 = { TPrima, F, tokenPor };     //T’ -> *F T’
         int[] p5 = { tokenC, E, tokenA };    //F -> (E)
         //F->num
         /**********************************************/
        //identificadores estaticos para la matriz   
        static int error = -100;
        static int nada = 0;
        static int p_1 = 100001;
        static int p_2 = 100002;
        static int p_3 = 100003;
        static int p_4 = 100004;
        static int p_5 = 100005;
        static int p_6 = 100006;
        static int p_7 = 100007;
        static int p_8 = 100008;
        //tabla que guarda las producciones en base a la tabla de analisis sintactico
        Object[,] tabla = { //   id     |    +       |      *    |     (     |    )     |     $
                /*E*/         { p_1 , /*|*/ error ,/*|*/ error,/*|*/ p_1,  /*|*/error,/*|*/ error},
                /*Eprima*/    { error,/*|*/ p_2 ,  /*|*/ error,/*|*/ error,/*|*/nada, /*|*/ nada},
                /*T*/         { p_4,  /*|*/ error ,/*|*/ error,/*|*/ p_4,  /*|*/error,/*|*/ error},
                /*Tprima*/    { error,/*|*/ nada,  /*|*/ p_5,  /*|*/error ,/*|*/nada, /*|*/nada },
                /*F*/         { p_8,  /*|*/ error ,/*|*/ error,/*|*/ p_7,  /*|*/error,/*|*/ error} };

        //el metodo que sigue es el de analisis???? ese metodo ustedes lo analizan en base a la tabla 
      /*  public void Parsear()
        {
            pila.push(-1); //ingresa a la pila el valor -1
            pila.push(E); //ingresa a la pila el valor de la primera produccion
            Token token = this.getToken(); //get token me devuelve un token de la lista de tokens
                                           //que me devolvio el scanner
            do
            { //Entra a un ciclo por lo menos una vez
                if (token.valor != -1)
                { //pregunto si el token que no es -1, esto nos indica que
                  //si no es -1 la lista de tokens contiene varios tokens
                  //antes que nos aparezca el token -1 que seria el final
                  //’Este if pregunta si lo que hay en la cima de la pila es un terminal
                  // o si lo que esta en la cima de la pila es -1
                  //el método EsTerminal(String), recibe un string que comprueba si el token
                  //obtenido es un terminal
                    if (EsTerminal(Integer.parserInt(pila.peek())) == true || pila.peek().equals("-1"))
                    {
                        //si el valor del token es igual al token que devuelve la pila
                        if (token.valor == Integer.parseInt(String.valueOf(pila.peek())))
                        {
                            //el metodo obtener variable(int, string)
                            this.setObtenerVariable(token.valor, token.lexema);
                            pila.pop(); //saca lo que se encuentra actualmente en la pila
                            token = this.getToken(); //se obtiene un Nuevo token
                        }
                        else
                        {
                            //quiere decir que vino un terminal que no concuerda con el
                            //que la pila estaba esperando, por lo tanto es un error
                            //sintáctico por lo que hay que recuperarse de los errores como
                            //ustedes plantean
                        }
                    }
                    //si lo que hay en la cima de la pila es un terminal
                    else if (this.EsNoTerminal(String.valueOf(pila.peek())) == true)
                    {
                        int nt = Integer.parseInt(String.valueOf(pila.peek()));//obtengo el codigo
                                                                               // del no terminal
                        int f = this.ObtenerFila(nt); //este método devuelve la fila en la que
                                                      //esta la producción representada por

                    }

                }*/

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

