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

        static private List<Token> listaTokens;
        private String retorno;
        private String retornoErrores;
        public int estado_token;

        //errores tokens
        static private List<ErroresToken> listaErrores;

        public Analizador()
        {
            listaTokens = new List<Token>();
            tokens = new ArrayList();

            //errores tokens
            listaErrores = new List<ErroresToken>();

        }

        //agrego token a la lista
        public void addToken(String lexema, String idToken, int linea, int columna, int indice)
        {
            
            Token nuevo = new Token(lexema, idToken, linea, columna, indice);
            listaTokens.Add(nuevo);
        }

        //agrego error a la lista
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
                        else if (c == '!')
                        {
                            lexema += c;
                            addToken(lexema, "Operador not", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '&')
                        {
                            lexema += c;
                            addToken(lexema, "Operador and", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '|' )
                        {
                            lexema += c;
                            addToken(lexema, "Operador Or", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            addToken(lexema, "Parentesis Abre", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            addToken(lexema, "Parentesis Cierra", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ';')
                        {
                            lexema += c;
                            addToken(lexema, "Final Sentencia", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (c == '<')
                        {
                            lexema += c;
                            addToken(lexema, "Menor que", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            addToken(lexema, "Mayor que", fila, columna, i - lexema.Length);
                            lexema = "";
                        }


                        /*operadores mat*/
                        else if (c == '+')
                        {
                            lexema += c;
                            addToken(lexema, "Suma", fila, columna, i);
                            lexema = "";

                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            addToken(lexema, "Menos", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '*')
                        {
                            lexema += c;
                            addToken(lexema, "Multiplicacion", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '/')
                        {
                            lexema += c;
                            addToken(lexema, "Division", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '=')
                        {
                            lexema += c;
                            addToken(lexema, "Asignacion de valor ", fila, columna, i);
                            lexema = "";
                        }
                        else
                        {
                            //se agrega a los errores
                            estado = 7;
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

                        }
                        else
                        {
                            Boolean encontrado = false;
                            
                            {
                                encontrado = Reservada(lexema);
                                if (encontrado)
                                {
                                    addToken(lexema, "Reservada", fila, columna, i - lexema.Length);
                                }
                                else
                                {
                                    addToken(lexema, "Identificador", fila, columna, i - lexema.Length);

                                }

                                lexema = "";
                                i--;
                                columna--;
                                estado = 0;
                            }
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
                            addToken(lexema, "Entero", fila, columna, i - lexema.Length);                         
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
                            addToken(lexema, "Decimal", fila, columna, i - lexema.Length);
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
                            addToken(lexema, "Cadena", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        break;   

                    //estado de error.
                    case 7:
                        lexema += c;
                        addError(lexema, "Carácter Desconocido", fila, columna);
                        estado = 0;
                        lexema = "";
                        break;
                }
            }


        }


        public Boolean Reservada(String sente)
        {
            Boolean enco = false;
            for (int i = 0; i < tokens.Count; ++i)
            {

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
                retorno += "Lexema: " + actual.getLexema() + ", IdToken: " + actual.getIdToken() + ", Linea: " + actual.getLinea() + Environment.NewLine;
            }
        }

        public void generarListaErrores()
        {
            for (int i = 0; i < listaErrores.Count; i++)
            {
                ErroresToken actual = listaErrores.ElementAt(i);
                retornoErrores += "Lexema: " + actual.getLexema() + ", IdToken: " + actual.getIdToken() + ", Linea: " + actual.getLinea() + Environment.NewLine;
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

        public List<Token> getListaTokens()
        {
            return listaTokens;
        }

        public List<ErroresToken> getListaErrores()
        {
            return listaErrores;
        }
    }
}

