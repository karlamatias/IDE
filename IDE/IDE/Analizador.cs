using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE
{
    class Analizador
    {
        ArrayList tokens;
        ArrayList tipos;


        static private List<Token> listaTokens;
        private String retorno;
        public int estado_token;

        //errores tokens
        static private List<ErroresToken> listaErrores;

        public Analizador()
        {
            //this.listaTokens = new List<Token>();
            listaTokens = new List<Token>();
            tokens = new ArrayList();
            tipos = new ArrayList();

            tipos.Add("Valor");
            tipos.Add("Operador");
            tipos.Add("IZQ");
            tipos.Add("DER");

            //errores toks
            listaErrores = new List<ErroresToken>();

        }

        public void addToken(String lexema, String idToken, int linea, int columna, int indice, Color color)
        {
            //MessageBox.Show("*" + lexema + "* lin: " + linea + " col: " + columna, "Lexema_final");
            Token nuevo = new Token(lexema, idToken, linea, columna, indice, color);
            listaTokens.Add(nuevo);
        }

        public void addError(String lexema, String idToken, int linea, int columna)
        {
            ErroresToken errtok = new ErroresToken(lexema, idToken, linea, columna);
            listaErrores.Add(errtok);
        }

        public void Analizador_cadena(String entrada)
        {
            int estado = 0;
            int columna = 0;
            int fila = 1;
            string lexema = "";
            Char c;

            entrada = entrada + " ";

            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                columna++;
                //MessageBox.Show(c.ToString(), i.ToString() );
                //MessageBox.Show(estado.ToString(), "estado");
                switch (estado)
                {

                    case 0:
                        if (Char.IsLetter(c))
                        {
                            estado = 1;
                            lexema += c;
                        }
                        else if (Char.IsDigit(c))
                        {
                            estado = 2;
                            lexema += c;
                        }
                        else if (c == '"')
                        {
                            estado = 4;
                            i--;
                            columna--;
                        }
                        else if (c == ',')
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        else if (c == '\n')
                        {
                            columna = 0;
                            fila++;
                            estado = 0;
                        }
                        /*nuevos*/
                        else if (c == '{')
                        {
                            lexema += c;
                            ////addToken(lexema, "llaveIzq", pos + 1, 0);

                            addToken(lexema, "llaveIzq", fila, columna, i - lexema.Length, Color.Azure);
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            addToken(lexema, "llaveDer", fila, columna, i - lexema.Length, Color.Azure);
                            ////addToken(lexema, "llaveDer", pos + 1, 0);
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            addToken(lexema, "parIzq", fila, columna, i - lexema.Length, Color.Blue);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            addToken(lexema, "parDer", fila, columna, i - lexema.Length, Color.Blue);
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            lexema = "";
                        }

                        else if (c == ';')
                        {
                            lexema += c;
                            addToken(lexema, "Final Sentencia", fila, columna, i - lexema.Length, Color.Fuchsia);
                            lexema = "";
                        }

                        else if (c == '<')
                        {
                            lexema += c;
                            addToken(lexema, "Menor", fila, columna, i - lexema.Length, Color.Blue);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            addToken(lexema, "Mayor", fila, columna, i - lexema.Length, Color.Blue);
                            lexema = "";
                        }

                        else if (c == '.')
                        {
                            lexema += c;
                            addToken(lexema, "Punto", fila, columna, i - lexema.Length, Color.Blue);
                            lexema = "";
                        }


                        /*operadores mat*/
                        else if (c == '+')
                        {
                            lexema += c;
                            addToken(lexema, "Suma", fila, columna, i, Color.Blue);
                            lexema = "";

                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            addToken(lexema, "Menos", fila, columna, i, Color.Blue);
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            addToken(lexema, "Multiplicacion", fila, columna, i, Color.Blue);
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            addToken(lexema, "Division", fila, columna, i, Color.Blue);
                            lexema = "";
                        }


                        /*fin operadors mat*/
                        else
                        {
                            //addError(c.ToString() , "Desconocido", fila, columna);
                            estado = -99;
                            i--;
                            columna--;
                        }

                        break;
                    case 1:
                        //if (Char.IsLetter(c))
                        if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            lexema += c;
                            estado = 1;
                            //MessageBox.Show("*1*"+lexema + "*1*", "lexema");
                        }
                        else
                        {
                            Boolean encontrado = false;
                            /*if (verificarReservada(lexema))*/
                            encontrado = Macht_enReser(lexema);
                            if (encontrado)
                            {
                                addToken(lexema, "Reservada", fila, columna, i - lexema.Length, Color.Green);
                            }
                            else
                            {
                                addToken(lexema, "Identificador", fila, columna, i - lexema.Length, Color.BlueViolet);

                            }

                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;

                    case 2:
                        if (Char.IsDigit(c))
                        {
                            estado = 2;
                            lexema += c;
                        }
                        else if (c.CompareTo('.') == 0)
                        {
                            estado = 3;
                            lexema += c;
                        }
                        else
                        {
                            addToken(lexema, "Entero", fila, columna, i - lexema.Length, Color.Magenta);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;


                    case 3:
                        if (Char.IsDigit(c))
                        {
                            estado = 3;
                            lexema += c;
                        }
                        else
                        {
                            addToken(lexema, "Decimal", fila, columna, i - lexema.Length, Color.Cyan);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }                       
                        break;

                    case 4:
                        if (c == '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        break;
                    case 5:
                        if (c != '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else
                        {
                            estado = 6;
                            i--;
                            columna--;
                        }
                        break;

                    case 6:
                        if (c == '"')
                        {
                            lexema += c;
                            addToken(lexema, "Cadena", fila, columna, i - lexema.Length, Color.Gray);
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;                          
                            addToken(lexema, "Coma", fila, columna, i - lexema.Length, Color.Fuchsia);
                            estado = 0;
                            lexema = "";
                        }
                        break;   

                    case 8:
                        if (c == '!')
                        {
                            lexema += c;
                            addToken(lexema, "Operador not", fila, columna, i, Color.Blue);
                            lexema = "";
                        }
                        else if (c == '|' + '|')
                        {
                            lexema += c;
                            addToken(lexema, "Operador Or", fila, columna, i, Color.Blue);
                            lexema = "";
                        }
                        else if (c == '&' + '&')
                        {
                            lexema += c;
                            addToken(lexema, "Operador and", fila, columna, i, Color.Blue);
                            lexema = "";
                        }
                        else
                        {
                            addError(c.ToString(), "Desconocido", fila, columna);
                            estado = -99;
                            i--;
                            columna--;
                        }
                        break;

                    //estado de error.
                    case -99:
                        lexema += c;
                        addError(lexema, "Carácter Desconocido", fila, columna);
                        estado = 0;
                        lexema = "";
                        break;
                }
            }


        }

        public Boolean Macht_enReser(String sente)
        {
            Boolean enco = false;
            for (int i = 0; i < tokens.Count; ++i)
            {
                //MessageBox.Show(tokens[i].ToString(), sente);
                //(reservadas[i].Lexema.Equals(lexema)) a = reservadas[i].Id;
                if (sente.ToString() == tokens[i].ToString())
                {
                    enco = true;
                    estado_token = i;
                    return enco;
                }
                else { enco = false; }

            }
            return enco;
        }

        public void generarLista()
        {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token actual = listaTokens.ElementAt(i);
                retorno += "Lexema: " + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + Environment.NewLine;
            }
        }
        public String getRetorno()
        {
            return this.retorno;
        }

        public List<Token> getListaTokens()
        {
            return listaTokens;
        }


    }
}

