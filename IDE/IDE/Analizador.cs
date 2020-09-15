using System;
using System.Collections;
using System.Collections.Generic;
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

        public void addToken(String lexema, String idToken, int linea, int columna, int indice)
        {
            //MessageBox.Show("*" + lexema + "* lin: " + linea + " col: " + columna, "Lexema_final");
            Token nuevo = new Token(lexema, idToken, linea, columna, indice);
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
                        //columna++;
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

                            addToken(lexema, "Llave que Abre", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '}')
                        {
                            lexema += c;
                            addToken(lexema, "Llave que Cierra", fila, columna, i - lexema.Length);
                            ////addToken(lexema, "llaveDer", pos + 1, 0);
                            lexema = "";
                        }
                        else if (c == '(')
                        {
                            lexema += c;
                            addToken(lexema, "Parentesis que Abre", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ')')
                        {
                            lexema += c;
                            addToken(lexema, "Parentesis que Cierra", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            //addToken(lexema, "coma", pos + 1, 0);
                            lexema = "";
                        }

                        else if (c == ';')
                        {
                            lexema += c;
                            addToken(lexema, "Punto y Coma", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (c == '<')
                        {
                            lexema += c;
                            addToken(lexema, "Menor que ", fila, columna, i - lexema.Length);
                            lexema = "";
                        }
                        else if (c == '>')
                        {
                            lexema += c;
                            addToken(lexema, "Mayor que ", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        else if (c == '.')
                        {
                            lexema += c;
                            addToken(lexema, "Punto", fila, columna, i - lexema.Length);
                            lexema = "";
                        }

                        /*fin nuevos*/

                        else if (c == '+')
                        {
                            estado = 10;
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
                                //token = new Token(1, "PalabraReservada", lexema, fila, columna);
                                //tokens.add(token);

                                //////////////////////////77MessageBox.Show("*1*" + lexema + "*1*", "lexema");
                                addToken(lexema, "Reservada", fila, columna, i - lexema.Length);
                            }
                            else
                            {
                                ////////////////////////777MessageBox.Show("*2*" + lexema + "*2*", "lexema");
                                addToken(lexema, "Identificador", fila, columna, i - lexema.Length);
                                /*nuevo inicio*/
                                /*Boolean encon_tipo = false;
                                encon_tipo = Macht_enTipo(lexema);
                                if (encon_tipo)
                                {  addToken(lexema, "Tipo", fila, columna);  }
                                else
                                {  addToken(lexema, "Identificador", fila, columna);  }*/
                                /*nuevo fin*/


                            }
                            //MessageBox.Show("*2*" + lexema + "*2*", "lexema");
                            //addToken(lexema, "Identificador", fila, columna);

                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 2:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        /*nuevo*/
                        else if (c == '.')
                        {
                            estado = 8;
                            lexema += c;
                        }
                        /*nuevo fin*/
                        else
                        {
                            //token = new Token(3, "Numero", lexema, fila, columna);
                            //tokens.add(token);
                            addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else
                        {
                            estado = -99;
                            i = i - 2;
                            columna = columna - 2;
                            lexema = "";
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
                            //token = new Token(2, "Cadena", lexema, fila, columna);
                            //tokens.add(token);
                            addToken(lexema, "Cadena", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }
                        else if (c == ',')
                        {
                            lexema += c;
                            //token = new Token(4, "Coma", lexema, fila, columna);
                            //tokens.add(token);
                            addToken(lexema, "Coma", fila, columna, i - lexema.Length);
                            estado = 0;
                            lexema = "";
                        }

                        break;

                    /**inicio nuevo**/
                    case 8:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                            //retorno += "Se esperaba un digito[" + caracter + "]" + Environment.NewLine;
                            addError(lexema, "Se esperaba un digito [" + lexema + "]", fila, columna);
                            estado = 0;
                            lexema = "";
                        }
                        break;
                    case 9:
                        if (Char.IsDigit(c))
                        {
                            estado = 9;
                            lexema += c;
                        }
                        else
                        {
                            //addToken(lexema, "decimal", pos + 1, 0);
                            //estado = 0;
                            //lexema = "";
                            //pos -= 1;
                            addToken(lexema, "Digito", fila, columna, i - lexema.Length);
                            lexema = "";
                            i--;
                            columna--;
                            estado = 0;
                        }

                        break;
                    /*fin nuevo*/

                    case 10:
                        if (c == '+')
                        {
                            lexema += c;
                            addToken(lexema, "Suma", fila, columna, i);
                            lexema = "";
                        }
                        else if (c == '-')
                        {
                            lexema += c;
                            addToken(lexema, "Resta", fila, columna, i);
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
                        else
                        {
                            addError(c.ToString() , "Desconocido", fila, columna);
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
        /*verifica si es tipo*/






        public void generarLista()
        {
            for (int i = 0; i < listaTokens.Count; i++)
            {
                Token actual = listaTokens.ElementAt(i);
                retorno += "Lexema:" + actual.getLexema() + ",IdToken: " + actual.getIdToken() + ",Linea: " + actual.getLinea() + Environment.NewLine;
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

