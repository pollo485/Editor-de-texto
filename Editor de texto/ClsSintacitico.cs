using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Editor_de_texto
{
    internal class ClsSintacitico : ClsLexico
    {
        int[] tablaToken = {
            600, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122, 200, 201, 202, 203, 204, 205, 206, 207,
            208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223,
            224, 225, 226, 227
        };
        // Filas = estados (0-39). Valor < 100: estado siguiente | 300-399: instruccion aceptada | 400-499: error
        int[,] matriz =
        {
            //   600  100  101  102  103  104  105  106  107  108  109  110  111  112  113  114  115  116  117  118  119  120  121  122  200  201  202  203  204  205  206  207  208  209  210  211  212  213  214  215  216  217  218  219  220  221  222  223  224  225  226  227
            { 3,   413, 413, 413, 414, 414, 414, 414, 415, 415, 415, 415, 415, 415, 415, 0,   416, 416, 416, 416, 416, 416, 417, 417, 1,   1,   1,   1,   6,   303, 418, 11,  418, 418, 418, 28,  34,  418, 418, 315, 316, 418, 418, 418, 312, 309, 313, 314, 16,  20,  24,  26 },  // estado 0
            { 2,   404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 1
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 300, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 2
            { 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 4,   406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406 },  // estado 3
            { 5,   5,   5,   5,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 4,   407, 407, 407, 407, 407, 407, 5,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 4
            { 405, 405, 405, 405, 4,   4,   4,   4,   405, 405, 405, 405, 405, 405, 405, 405, 405, 5,   405, 405, 405, 301, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 5
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 7,   408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 6
            { 8,   8,   8,   8,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 7,   407, 407, 407, 407, 407, 8,   8,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 7
            { 409, 409, 409, 409, 7,   7,   7,   7,   9,   9,   9,   9,   9,   9,   9,   409, 409, 8,   409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409 },  // estado 8
            { 10,  10,  10,  10,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 9,   407, 407, 407, 407, 407, 10,  10,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 9
            { 410, 410, 410, 410, 9,   9,   9,   9,   410, 410, 410, 410, 410, 410, 410, 410, 410, 10,  410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 7,   7,   410, 410, 410, 410, 410, 410, 410, 302, 410, 410, 410, 410, 410, 410, 410, 410, 410 },  // estado 10
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 12,  408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 11
            { 13,  13,  13,  13,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 12,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 12
            { 409, 409, 409, 409, 12,  12,  12,  12,  14,  14,  14,  14,  14,  14,  14,  409, 409, 13,  409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409 },  // estado 13
            { 15,  15,  15,  15,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 14,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 14
            { 410, 410, 410, 410, 14,  14,  14,  14,  410, 410, 410, 410, 410, 410, 410, 410, 410, 15,  410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 12,  12,  410, 410, 410, 410, 410, 410, 410, 410, 304, 410, 410, 410, 410, 410, 410, 410, 410 },  // estado 15
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 17,  408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 16
            { 18,  412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 18,  18,  412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412 },  // estado 17
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 19,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 18
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 305, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 19
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 21,  408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 20
            { 22,  412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412 },  // estado 21
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 23,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 22
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 306, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 23
            { 25,  404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 24
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 307, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 25
            { 27,  27,  27,  27,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 27,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 26
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 308, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 27
            { 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 29,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 28
            { 30,  404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 29
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 31,  405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 30
            { 407, 32,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 31
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 33,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 32
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 310, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 33
            { 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 35,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 34
            { 36,  404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 35
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 37,  405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 36
            { 407, 38,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 37
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 39,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 38
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 311, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 39
        };


        Dictionary<int, string> dicErrores = new Dictionary<int, string>()
        {
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
            {419, "Se abrio parentesis despues de inicio"},
            {420, "Parentesis de cierre sin apertura"},
            {421, "Parentesis sin cerrar antes de inicio"},
            {422, "Fin sin bloque que cerrar"},
            {423, "Fin sin if, sino o mientras asociado"},
            {424, "Sino sin si correspondiente"},
            {425, "Fin inesperado"},
            {426, "Bloque sin cerrar al final del codigo"}
        };

        Dictionary<int, string> dicTokensSintacticos = new Dictionary<int, string>()
        {
            {300, "Declaracion de variable"},
            {301, "Igualacion"},
            {302, "Condicional"},
            {303, "Condicional else"},
            {304, "Ciclo while"},
            {305, "Escribir"},
            {306, "Leer"},
            {307, "Metodo"},
            {308, "Devolver"},
            {309, "Fin metodo"},
            {310, "Incremento"},
            {311, "Decremento"},
            {312, "Fin metodo principal"},
            {313, "Fin condicional"},      
            {314, "Fin ciclo"},            
            {315, "Inicio de variables"},  
            {316, "Inicio de bloque principal"}
        };

        Dictionary<int, int> dicCierres = new Dictionary<int, int>()
        {
            {313, 302},    
            {314, 304},    
            {309, 307},   
            {312, 316}    
        };

        Dictionary<int, int> dicAperturas = new Dictionary<int, int>()
        {
            {204, 302},   
            {207, 304},   
            {226, 307}    
        };

        const int tokenOC = 206;

        int i = 0;
        int estado = 0;
        int columnaMatriz = 0;
        int tokenActual = 0;
        int tokenInicio = 0;
        string palabra = "";
        int columnaTexto = 1;
        int renglonTexto = 1;
        int renglonInicio = 1;
        int columnaInicio = 1;
        int renglonActual = 0;
        bool renglonConError = false;
        int parentesis = 0;
        string ultimaPalabra = "";
        int ultimoRenglon = 1;
        int ultimaColumna = 1;

        Stack<int> pilaParentesis = new Stack<int>();
        Stack<int> pilaBloques = new Stack<int>();
        DataTable tablaSint;
        DataTable tablaError;

        public Tuple<DataTable, DataTable> RecorrerSintactico(DataTable tablaLexico, DataTable tablaErrores)
        {
            tablaSint = new DataTable();
            tablaSint.Columns.Add("Token");
            tablaSint.Columns.Add("Descripcion");
            tablaSint.Columns.Add("Palabra");
            tablaSint.Columns.Add("Renglon");
            tablaSint.Columns.Add("Columna");
            tablaError = tablaErrores;

            if (tablaLexico.Rows.Count == 0)
                return new Tuple<DataTable, DataTable>(tablaSint, tablaError);

            i = 0; estado = 0;
            palabra = "";
            renglonActual = 0;
            renglonConError = false;
            pilaParentesis.Clear();
            pilaBloques.Clear();

            do
            {
                DataRow fila = tablaLexico.Rows[i];
                tokenActual = Convert.ToInt32(fila["Tocken"]);
                string palabraToken = fila["Palabra"].ToString();
                renglonTexto = Convert.ToInt32(fila["Renglon"]);
                columnaTexto = Convert.ToInt32(fila["Columna"]);

                if (renglonTexto != renglonActual)
                {
                    CerrarRenglon();
                    renglonActual = renglonTexto;
                }

                if (!renglonConError)
                {
                    ultimaPalabra = palabraToken;
                    ultimoRenglon = renglonTexto;
                    ultimaColumna = columnaTexto;

                    if (estado == 0)
                    {
                        tokenInicio = tokenActual;
                        renglonInicio = renglonTexto;
                        columnaInicio = columnaTexto;
                        palabra = "";
                    }

                    columnaMatriz = ObtenerColumna(tokenActual);
                    if (columnaMatriz == -1)
                        estado = 403;
                    else
                        estado = matriz[estado, columnaMatriz];

                    if (estado != 0 && estado < 400)
                    {
                        palabra += (palabra == "" ? "" : " ") + palabraToken;
                        estado = ValidarParentesis(estado);
                    }
                    if (estado >= 300 && estado < 400)
                        estado = ValidarBloque(estado);

                    if (estado < 100)
                    {

                    }
                    else if (estado >= 400 && estado < 500)
                    {
                        RegistrarError(estado, palabraToken, renglonTexto, columnaTexto);
                    }
                    else if (estado >= 300 && estado < 400)
                    {
                        string descripcion = dicTokensSintacticos.ContainsKey(estado)
                            ? dicTokensSintacticos[estado]
                            : "Instruccion";
                        tablaSint.Rows.Add(estado, descripcion, palabra, renglonInicio, columnaInicio);
                        estado = 0;
                        palabra = "";
                        pilaParentesis.Clear();
                    }
                }

                i++;
            } while (i != tablaLexico.Rows.Count);

            CerrarRenglon();

            foreach (var token in pilaBloques)
            {
                string nombre = dicTokensSintacticos.ContainsKey(token) ? dicTokensSintacticos[token] : "Bloque";
                tablaError.Rows.Add(426, nombre, dicErrores[426], "-", "-");
            }
            pilaBloques.Clear();

            return new Tuple<DataTable, DataTable>(tablaSint, tablaError);
        }

        void CerrarRenglon()
        {
            if (estado != 0)
            {
                int codigo = matriz[estado, ObtenerColumna(tokenOC)];
                RegistrarError(codigo, ultimaPalabra, ultimoRenglon, ultimaColumna);
            }
            estado = 0;
            palabra = "";
            pilaParentesis.Clear();
            renglonConError = false;
        }

        void RegistrarError(int codigo, string palabraError, int renglon, int columna)
        {
            string descripcion = dicErrores.ContainsKey(codigo)
                ? dicErrores[codigo]
                : "Error sintactico desconocido";
            tablaError.Rows.Add(codigo, palabraError, descripcion, renglon, columna);

            if (dicAperturas.ContainsKey(tokenInicio))
                pilaBloques.Push(dicAperturas[tokenInicio]);

            estado = 0;
            palabra = "";
            pilaParentesis.Clear();
            renglonConError = true;
        }

        int ValidarParentesis(int siguiente)
        {
            if (tokenActual == 115) 
            {
                pilaParentesis.Push(115);
            }
            else if (tokenActual == 116) 
            {
                if (pilaParentesis.Count == 0)
                    return 420;    
                pilaParentesis.Pop();
            }

            if (siguiente >= 300 && pilaParentesis.Count > 0)
                return (siguiente == 302 || siguiente == 304) ? 421 : 411;

            return siguiente;
        }

        int ValidarBloque(int tokenSint)
        {
            if (dicCierres.ContainsValue(tokenSint))      
            {
                pilaBloques.Push(tokenSint);
            }
            else if (tokenSint == 303)                 
            {
                pilaBloques.Push(303);
            }
            else if (dicCierres.ContainsKey(tokenSint))    
            {
                if (pilaBloques.Count > 0)
                {
                    int tope = pilaBloques.Pop();
                    if (tokenSint == 313 && tope == 303 && pilaBloques.Count > 0)
                        pilaBloques.Pop(); 
                }
            }
            return tokenSint;
        }

        public int ObtenerColumna(int tokenAct)
        {
            for (int j = 0; j < tablaToken.Length; j++)
            {
                if (tokenAct == tablaToken[j])
                    return j;
            }
            return -1;
        }
    }
}