using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Editor_de_texto
{
    internal class ClsLexico
    {
        char[] tablaCaracteres = { 'A', '0', '_', 'e', '+', '-', '*', '/', '=', '>', '<',
            '!', '(', ')', '.', ',', ':', ';', '"', '@', '\n', '\t', ' ', '\'' };

        int[,] matriz =
          {     
                {1,2,403,1,103,104,105,106,10,8,9,11,115,116,117,118,119,120,12,403,0,0,0,               13 } , 
                {1,1,1,1,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,600,    600} , 
                {100,2,100,5,100,100,100,100,100,100,100,100,100,100,3,100,100,100,100,100,100,100,100,  100} , 
                {400,4,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400,400} , 
                {101,4,101,5,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101,101} , 
                {401,7,401,401,6,6,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,  401} , 
                {401,7,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401,401} , 
                {102,7,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102,102} , 
                {107,107,107,107,107,107,107,107,108,107,107,107,107,107,107,107,107,107,107,107,107,107,107,107} , 
                {109,109,109,109,109,109,109,109,110,111,109,109,109,109,109,109,109,109,109,109,109,109,109,109} , 
                {113,113,113,113,113,113,113,113,112,113,113,113,113,113,113,113,113,113,113,113,113,113,113,113} , 
                {11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,11,114,11,11,                   11 } , 
                {12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,12,121,12,402,12,12,                  12 } , 
                {14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,14,                    427} , 
                {428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428,428, 122} 
        };
        Dictionary<string, (string palC, int tok)> dicPalabrasReservadas = new Dictionary<string, (string, int)>()
        {
            {"entero",      ("int",         200)},
            {"cadena",      ("string",      201)},
            {"doble",       ("double",      202)},
            {"caracter",    ("char",        203)},
            {"si",          ("if",          204)},
            {"sino",        ("else",        205)},
            {"vacio",       ("void",        206)},
            {"mientras",    ("while",       207)},
            {"no",          ("!",           208)},
            {"y",           ("&&",          209)},
            {"o",           ("||",          210)},
            {"inc",         ("++,+=",       211)},
            {"dec",         ("--,-=",       212)},
            {"residuo",     ("%",           213)},
            {"potencia",    ("^",           214)},
            {"cuchara",     ("var",         215)},
            {"inicio",      ("begin",       216)},
            {"iniM",        ("begin",       217)},
            {"iniS",        ("begin",       218)},
            {"iniC",        ("begin",       219)},
            {"fin",         ("end",         220)},
            {"finM",        ("end",         221)},
            {"finS",        ("end",         222)},
            {"finC",        ("end",         223)},
            {"imprimir",    ("PRINT",       224)},
            {"leer",        ("READ",        225)},
            {"metodo",      ("PROCEDURE",   226)},
            {"devolver",    ("RET",         227)},
            {"llamar",      ("CALL",        228)}
        };
        Dictionary<int, string> dicErrores = new Dictionary<int, string>()
        {
            {400, "Se esperaba digito"},
            {401, "Se esperaba digito o +/-"},
            {402, "Se esperaban comillas "},
            {403, "Parametro no reconocido"},
            {404, "Se esperaba variable"},
            {405, "Se esperaba ;"},
            {406, "se esperaba signo de ="},
            {407, "Se esperaba variable o algun numero u operador"},
            {408, "Se esperaba ("},
            {409, "Se esperaba operador de comparacion"},
            {410, "Se esperaba begin"},
            {411, "Se esperaba )"},
            {412, "Se esperaba variable o cadena"},
            {413, "valores no inicializados"},
            {414, "operador fuera de lugar"},
            {415, "comparador/es fuera de lugar"},
            {416, "Agrupador/es fuera de lugar"},
            {417, "Cadena fuera de lugar"},
            {418, "Reservada fuera de lugar"},
            {427, "Se esperaba un caracter (comillas vacias)"},
            {428, "Se esperaba comilla simple de cierre"}
        };

        int i = 0;
        int estado = 0;
        int estadoNuevo = 0;
        int columnaMatriz = 0;
        char caracterActual = ' ';
        string palabra = "";
        int columnaTexto = 1;
        int renglonTexto = 1;
        string editor = "";
        int token = 0;
        public Tuple<DataTable, DataTable> RecorrerCodigo(string texto)
        {
            if (string.IsNullOrEmpty(texto))
                return new Tuple<DataTable, DataTable>(new DataTable(), new DataTable());
            DataTable tablaLex = new DataTable();
            tablaLex.Columns.Add("Tocken");
            tablaLex.Columns.Add("Palabra");
            tablaLex.Columns.Add("PalabraEnC#");
            tablaLex.Columns.Add("Renglon");
            tablaLex.Columns.Add("Columna");
            DataTable tablaError = new DataTable();
            tablaError.Columns.Add("TokenError");
            tablaError.Columns.Add("Palabra");
            tablaError.Columns.Add("Descripcion");
            tablaError.Columns.Add("Renglon");
            tablaError.Columns.Add("Columna");
            i = 0; estado = 0;
            palabra = "";
            editor = texto;
            do
            {
                caracterActual = editor[i];
                columnaMatriz = ObetnerColumna(caracterActual);
                if (estado >= matriz.GetLength(0))
                    estado = 0;
                estado = matriz[estado, columnaMatriz];
                if (estado < 100)
                {
                    if (estado != 0)
                    {
                        palabra += caracterActual;
                    }
                }

                else if (estado >= 100)
                {

                    if (estado >= 400 && estado < 500)
                    {
                        palabra += caracterActual;

                        string palError = "";
                        if (dicErrores.ContainsKey(estado))
                        {
                            palError = dicErrores[estado];
                            token = estado;
                        }
                        tablaError.Rows.Add(token, palabra, palError, renglonTexto, columnaTexto);
                        estado = 0;
                        palabra = "";
                    }
                    else if (estado == 103 || estado == 104)
                    {
                        palabra += caracterActual;
                        token = estado;
                        string palEnC = "";
                        tablaLex.Rows.Add(token, palabra, palEnC, renglonTexto, columnaTexto);
                        estado = 0;
                        palabra = "";
                    }
                    else if (estado == 114)
                    {
                        estado = 0;
                        palabra = "";
                    }
                    else if (estado == 113)
                    {
                        token = 113;
                        string palEnC = "";
                        tablaLex.Rows.Add(token, palabra, palEnC, renglonTexto, columnaTexto);
                        estado = 0;
                        palabra = "";

                        if (caracterActual != ' ' && caracterActual != '\t' && caracterActual != '\n')
                        {
                            columnaMatriz = ObetnerColumna(caracterActual);
                            estadoNuevo = matriz[0, columnaMatriz];

                            if (estadoNuevo >= 100 && estadoNuevo < 600 && estadoNuevo != 0 && estadoNuevo != 121)
                            {
                                token = estadoNuevo;
                                tablaLex.Rows.Add(token, caracterActual.ToString(), "", renglonTexto, columnaTexto);
                                estadoNuevo = 0;
                            }
                            else if (estadoNuevo > 0 && estadoNuevo < 100)
                            {
                                palabra = caracterActual.ToString();
                                estado = estadoNuevo;
                                estadoNuevo = 0;
                            }
                            else
                            {
                                palabra += caracterActual;
                            }
                        }
                    }
                    else if (estado >= 107 && estado <= 112)
                    {
                        if (estado == 107 || estado == 109)
                        {
                            // Estados con O.C. (retroceso): > y 
                            // El caracterActual NO pertenece a este token, hay que reprocesarlo
                            token = estado;
                            string palEnC = "";
                            tablaLex.Rows.Add(token, palabra, palEnC, renglonTexto, columnaTexto);
                            estado = 0;
                            palabra = "";

                            if (caracterActual != ' ' && caracterActual != '\t' && caracterActual != '\n')
                            {
                                columnaMatriz = ObetnerColumna(caracterActual);
                                estadoNuevo = matriz[0, columnaMatriz];

                                if (estadoNuevo >= 100 && estadoNuevo < 600 && estadoNuevo != 0 && estadoNuevo != 121)
                                {
                                    token = estadoNuevo;
                                    tablaLex.Rows.Add(token, caracterActual.ToString(), "", renglonTexto, columnaTexto);
                                    estadoNuevo = 0;
                                }
                                else if (estadoNuevo > 0 && estadoNuevo < 100)
                                {
                                    if (estadoNuevo < matriz.GetLength(0))
                                    {
                                        palabra = caracterActual.ToString();
                                        estado = estadoNuevo;
                                        estadoNuevo = 0;
                                    }
                                    else
                                    {
                                        estadoNuevo = 0;
                                        palabra = "";
                                    }
                                }
                            }
                        }
                        else if (estado == 108 || estado == 110 || estado == 111 || estado == 112)
                        {
                            // Estados SIN retroceso: >= , <= , <>
                            // El caracterActual (= o >) YA forma parte del token, se agrega a palabra
                            palabra += caracterActual;
                            token = estado;
                            string palEnC = "";
                            tablaLex.Rows.Add(token, palabra, palEnC, renglonTexto, columnaTexto);
                            estado = 0;
                            palabra = "";
                            // No hay retroceso: el siguiente ciclo tomará el siguiente carácter normalmente
                        }
                    }
                    else if (estado >= 115 && estado <= 120)
                    {
                        palabra += caracterActual;
                        token = estado;
                        string palEnC = "";
                        tablaLex.Rows.Add(token, palabra, palEnC, renglonTexto, columnaTexto);
                        estado = 0;
                        palabra = "";


                    }

                    else // bloque general (600, 100, 101, 102, 121, 122...)
                    {
                        token = estado;
                        string palEnC = "";
                        if (dicPalabrasReservadas.ContainsKey(palabra))
                        {
                            var datos = dicPalabrasReservadas[palabra];
                            palEnC = datos.palC;
                            token = datos.tok;
                        }
                        if (caracterActual == '"' || caracterActual == '\'')
                            palabra += caracterActual;
                        tablaLex.Rows.Add(token, palabra, palEnC, renglonTexto, columnaTexto);
                        estado = 0;
                        palabra = "";

                        // *** CORRECCIÓN: Si era una cadena (121) o un caracter (122), NO reprocesar el cierre ***
                        if (token == 121 || token == 122)
                        {
                            // La comilla de cierre ya fue consumida, no reprocesar
                        }
                        else
                        {
                            columnaMatriz = ObetnerColumna(caracterActual);
                            estadoNuevo = matriz[0, columnaMatriz];
                            if (estadoNuevo >= 100 && estadoNuevo < 600 && estadoNuevo != 0 && estadoNuevo != 121)
                            {
                                token = estadoNuevo;
                                tablaLex.Rows.Add(token, caracterActual.ToString(), "", renglonTexto, columnaTexto);
                                estadoNuevo = 0;
                                palabra = "";
                            }
                            else if (estadoNuevo > 0 && estadoNuevo < 100)
                            {
                                palabra = caracterActual.ToString();
                                estado = estadoNuevo;
                                estadoNuevo = 0;
                            }
                        }
                    }

                }


                i++;
                columnaTexto += 1;
                if (caracterActual == '\n')
                {
                    renglonTexto += 1;
                    columnaTexto = 1;
                }
            } while (i != editor.Length);
            return new Tuple<DataTable, DataTable>(tablaLex, tablaError);
        }

        public int ObetnerColumna(char caracterAct)
        {
            int col = 0;
            bool comprobante = false;
            for (int j = 0; j < tablaCaracteres.Length; j++)
            {
                if (caracterAct == tablaCaracteres[j])
                {
                    col = j;
                    comprobante = true;
                    break;
                }

            }
            if (char.IsDigit(caracterAct))
            {
                col = 1;
                comprobante = true;
            }
            else if (char.IsLetter(caracterAct) && caracterAct != 'e')
            {
                col = 0;
                comprobante = true;
            }
            if (comprobante == false)
            {
                col = 19;
            }
            return col;
        }
    }
}