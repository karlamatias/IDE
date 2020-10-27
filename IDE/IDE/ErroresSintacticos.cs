using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDE
{
    class ErroresSintacticos
    {
     
        public int num_lineaE;
        public string error;
        public string descrip;
        public string sol_error;
        public int columna;

        public ErroresSintacticos(string error, int fila, int columna, string solucion )
        {

                error = error;
                num_lineaE = fila;
                sol_error = solucion;
                columna = columna;

            }
            

            public ErroresSintacticos ()
            {

            }



        public int NumerodeLinea
        {
            get { return num_lineaE; }
            set { num_lineaE = value; }
        }

        public string Error
        {
            get { return error; }
            set { error = value; }
        }

        public string Solucion
        {
            get { return sol_error; }
            set { sol_error = value; }
        }
        public string Descripcion
        {
            get { return descrip; }
            set { descrip = value; }
        }

        public int Columna
        {
            get { return columna; }
            set { columna = value; }
        }

    }
    }
