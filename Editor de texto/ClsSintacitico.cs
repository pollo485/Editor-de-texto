using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor_de_texto
{
    internal class ClsSintacitico : ClsLexico
    {
        // Se agrega 122 (caracter) al final. Su columna se genera copiando
        // el comportamiento de 121 (cadena) - ver AgregarColumnaCaracter().
        int[] tablaToken = {
            600, 100, 101, 102, 103, 104, 105, 106, 107, 108, 109, 110, 111, 112, 113, 114,
            115, 116, 117, 118, 119, 120, 121, 122, 200, 201, 202, 203, 204, 205, 206, 207,
            208, 209, 210, 211, 212, 213, 214, 215, 216, 217, 218, 219, 220, 221, 222, 223,
            224, 225, 226, 227
        };
        int[,] matrizSintacticoBase =
        {
            //   600  100  101  102  103  104  105  106  107  108  109  110  111  112  113  114  115  116  117  118  119  120  121  122  200  201  202  203  204  205  206  207  208  209  210  211  212  213  214  215  216  217  218  219  220  221  222  223  224  225  226  227
            { 3,   413, 413, 413, 414, 414, 414, 414, 415, 415, 415, 415, 415, 415, 415, 0,   416, 416, 416, 416, 416, 416, 417, 417, 1,   1,   1,   1,   6,   303, 418, 11,  418, 418, 418, 28,  34,  418, 418, 418, 316, 418, 418, 418, 312, 309, 314, 315, 16,  20,  24,  26 },  // estado 0
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


        // Matriz final que realmente usa RecorrerSintactico: se construye en el constructor
        // agregando la columna 122 (caracter) con el mismo comportamiento que 121 (cadena).
        int[,] matrizSintactico;

        public ClsSintacitico()
        {
            // 22 = indice de 121 (cadena) dentro de tablaToken/columnas de matrizSintacticoBase.
            // El token 122 (caracter) hereda exactamente ese comportamiento.
            matrizSintactico = AgregarColumnaCaracter(matrizSintacticoBase, 22);
        }

        private static int[,] AgregarColumnaCaracter(int[,] original, int colOrigen)
        {
            int filas = original.GetLength(0);
            int cols = original.GetLength(1);
            int[,] nuevo = new int[filas, cols + 1];
            for (int f = 0; f < filas; f++)
            {
                for (int c = 0; c < cols; c++)
                    nuevo[f, c] = original[f, c];
                nuevo[f, cols] = original[f, colOrigen]; // copia el comportamiento de "cadena"
            }
            return nuevo;
        }

        Dictionary<string, (string palC, int tok)> dicPalabrasReservadas = new Dictionary<string, (string, int)>()
        {
            {"entero",      ("int",         200)},
            {"cadena",      ("string",      201)},
            {"doble",       ("double",      202)},
            {"si",          ("if",          203)},
            {"sino",        ("else",        204)},
            {"vacio",       ("void",        205)},
            {"mientras",    ("wihle",       206)},
            {"no",          ("!",           207)},
            {"y",           ("&&",          208)},
            {"o",           ("||",          209)},
            {"inc",         ("++,+=",       210)},
            {"dec",         ("--,-=",       211)},
            {"residuo",     ("%",           212)},
            {"potencia",    ("^",           213)},
            {"cuchara",     ("var",         214)},
            {"inicio",      ("begin",       215)},
            {"fin",         ("end",         216)},
            {"imprimir",    ("PRINT",       217)},
            {"leer",        ("READ",        218)},
            {"metodo",      ("PROCEDURE",   219)},
            {"devolver",    ("RET",         220)}
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
            {419, "Se abrio parentesis despues de inicio"},
            {420, "Parentesis de cierre sin apertura"},
            {421, "Parentesis sin cerrar antes de inicio"},
            {422, "Fin sin bloque que cerrar"},
            {423, "Fin sin if, sino o mientras asociado"},
            {424, "Sino sin si correspondiente"},
            {425, "Fin inesperado"},
            {426, "Bloque sin cerrar al final del codigo"},
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
            {313, "Inicio de variables"},
            {314, "Inicio bloque principal"}
        };


        public int ObtenerColumna(int tokenAct)
        {
            for (int j = 0; j < tablaToken.Length; j++)
            {
                if (tokenAct == tablaToken[j])
                    return j;
            }
            return 0;
        }
        int i = 0;
        int estado = 0;
        int estadoNuevo = 0;
        int columnaMatriz = 0;
        int tokenActual = 0;
        string palabra = "";
        int columnaTexto = 1;
        int renglonTexto = 1;
        string editor = "";
        int token = 0;

        DataTable TablaSintactica;
        public Tuple<DataTable, DataTable> RecorrerSintactico(DataTable tablaLexico, DataTable tablaErrores)
        {
            TablaSintactica = new DataTable();
            TablaSintactica.Columns.Add("Token");
            TablaSintactica.Columns.Add("Descripcion");
            TablaSintactica.Columns.Add("Palabra");
            TablaSintactica.Columns.Add("Renglon");
            TablaSintactica.Columns.Add("Columna");

            Stack<(int token, string palabra, int renglon, int columna)> pila =
                new Stack<(int, string, int, int)>();

            var renglones = tablaLexico.AsEnumerable()
                .GroupBy(row => row["Renglon"].ToString())
                .ToList();

            foreach (var renglon in renglones)
            {
                estado = 0;
                bool hayError = false;
                int errorEstado = 0;
                string palabraError = "";
                int ultimoEstadoAceptacion = 0;

                string lineaCompleta = string.Join(" ", renglon.Select(f => f["Palabra"].ToString()));
                renglonTexto = Convert.ToInt32(renglon.First()["Renglon"]);
                columnaTexto = Convert.ToInt32(renglon.First()["Columna"]);

                bool dentroIncDec = false;

                foreach (DataRow fila in renglon)
                {
                    tokenActual = Convert.ToInt32(fila["Tocken"]);
                    palabra = fila["Palabra"].ToString();
                    renglonTexto = Convert.ToInt32(fila["Renglon"]);
                    columnaTexto = Convert.ToInt32(fila["Columna"]);

                    if (tokenActual == 210 || tokenActual == 211)
                    {
                        dentroIncDec = true;
                    }

                    // ====== VALIDACION DE PILA ======
                    if (tokenActual == 203)
                    {
                        pila.Push((203, palabra, renglonTexto, columnaTexto));
                    }
                    else if (tokenActual == 204)
                    {
                        pila.Push((204, palabra, renglonTexto, columnaTexto));
                    }
                    else if (tokenActual == 206)
                    {
                        pila.Push((206, palabra, renglonTexto, columnaTexto));
                    }
                    else if (tokenActual == 219)
                    {
                        pila.Push((219, palabra, renglonTexto, columnaTexto));
                    }
                    else if (tokenActual == 115)
                    {
                        if (!dentroIncDec)
                        {
                            bool inicioEnEsteRenglon = renglon
                                .TakeWhile(f => f != fila)
                                .Any(f => Convert.ToInt32(f["Tocken"]) == 215);

                            if (inicioEnEsteRenglon)
                            {
                                tablaErrores.Rows.Add(419, palabra,
                                    "Se abrio parentesis despues de inicio", renglonTexto, columnaTexto);
                            }
                            else
                            {
                                pila.Push((115, palabra, renglonTexto, columnaTexto));
                            }
                        }
                    }
                    else if (tokenActual == 116)   // )
                    {
                        if (!dentroIncDec) // ignorar paréntesis de inc/dec
                        {
                            if (pila.Count == 0 || pila.Peek().token != 115)
                            {
                                tablaErrores.Rows.Add(420, palabra,
                                    "Parentesis de cierre sin apertura", renglonTexto, columnaTexto);
                            }
                            else
                            {
                                pila.Pop();
                            }
                        }
                    }
                    else if (tokenActual == 215)   // inicio
                    {
                        bool hayParentesisSinCerrar = false;
                        foreach (var elem in pila)
                        {
                            if (elem.token == 115)
                            {
                                hayParentesisSinCerrar = true;
                                break;
                            }
                        }

                        if (hayParentesisSinCerrar)
                        {
                            tablaErrores.Rows.Add(421, palabra,
                                "Parentesis sin cerrar antes de inicio", renglonTexto, columnaTexto);
                        }
                        else
                        {
                            // Verificar si en el MISMO renglón hay si/mientras/metodo
                            bool inicioConBloque = renglon
                                .Any(f => Convert.ToInt32(f["Tocken"]) == 203 ||
                                          Convert.ToInt32(f["Tocken"]) == 206 ||
                                          Convert.ToInt32(f["Tocken"]) == 219);

                            if (!inicioConBloque)
                            {
                                // Inicio solo = bloque principal
                                pila.Push((999, palabra, renglonTexto, columnaTexto));
                            }
                            // Si viene con si/mientras/metodo NO se pushea, ya están en la pila
                        }
                    }
                    else if (tokenActual == 216)   // fin
                    {
                        if (pila.Count == 0)
                        {
                            tablaErrores.Rows.Add(422, palabra,
                                "Fin sin bloque que cerrar", renglonTexto, columnaTexto);
                        }
                        else
                        {
                            int tope = pila.Peek().token;

                            if (tope == 999)        // bloque principal
                            {
                                pila.Pop();
                            }
                            else if (tope == 203)   // si
                            {
                                pila.Pop();
                            }
                            else if (tope == 204)   // sino → 2 pops: sino + si
                            {
                                pila.Pop();
                                if (pila.Count > 0 && pila.Peek().token == 203)
                                    pila.Pop();
                            }
                            else if (tope == 206)   // mientras
                            {
                                pila.Pop();
                            }
                            else if (tope == 219)   // metodo
                            {
                                pila.Pop();
                            }
                            else
                            {
                                tablaErrores.Rows.Add(425, palabra,
                                    "Fin inesperado", renglonTexto, columnaTexto);
                            }
                        }
                    }

                    // ====== MATRIZ SINTÁCTICA ======
                    columnaMatriz = ObtenerColumna(tokenActual);

                    if (estado >= matrizSintactico.GetLength(0))
                        estado = 0;

                    estado = matrizSintactico[estado, columnaMatriz];

                    if (estado >= 400 && estado < 500)
                    {
                        hayError = true;
                        errorEstado = estado;
                        palabraError = palabra;
                        estado = 0;
                        break;
                    }

                    if (estado >= 300 && estado < 400)
                    {
                        ultimoEstadoAceptacion = estado;
                        estado = 0;
                    }
                }

                if (hayError)
                {
                    string descripcion = dicErrores.ContainsKey(errorEstado)
                        ? dicErrores[errorEstado]
                        : "Error sintactico desconocido";
                    tablaErrores.Rows.Add(errorEstado, palabraError, descripcion, renglonTexto, columnaTexto);
                }
                else
                {
                    // *** CORRECCIÓN: verificar que el renglón realmente llegó a un estado de aceptación
                    if (ultimoEstadoAceptacion == 0 && lineaCompleta.Trim() != "")
                    {
                        // El renglón tiene tokens pero no llegó a ningún estado de aceptación
                        // Verificar que no sea un renglón de solo palabras reservadas sin cuerpo (sino, fin)
                        bool esSoloReservada = renglon.All(f =>
                        {
                            int tok = Convert.ToInt32(f["Tocken"]);
                            return tok == 204 || tok == 216; // sino, fin
                        });

                        if (!esSoloReservada)
                        {
                            tablaErrores.Rows.Add(405, lineaCompleta.Trim(),
                                "Se esperaba ;", renglonTexto, columnaTexto);
                        }
                        else
                        {
                            string descSintactica = dicTokensSintacticos.ContainsKey(ultimoEstadoAceptacion)
                                ? dicTokensSintacticos[ultimoEstadoAceptacion]
                                : "Instruccion";
                            TablaSintactica.Rows.Add(ultimoEstadoAceptacion, descSintactica,
                                lineaCompleta, renglonTexto, columnaTexto);
                        }
                    }
                    else
                    {
                        string descSintactica = dicTokensSintacticos.ContainsKey(ultimoEstadoAceptacion)
                            ? dicTokensSintacticos[ultimoEstadoAceptacion]
                            : "Instruccion";
                        TablaSintactica.Rows.Add(ultimoEstadoAceptacion, descSintactica,
                            lineaCompleta, renglonTexto, columnaTexto);
                    }
                }
            }

            if (pila.Count > 0)
            {
                var elementosPila = pila.ToList();

                foreach (var elemento in elementosPila)
                {
                    string msgError;
                    switch (elemento.token)
                    {
                        case 203: msgError = "Si sin fin correspondiente"; break;
                        case 204: msgError = "Sino sin fin correspondiente"; break;
                        case 206: msgError = "Mientras sin fin correspondiente"; break;
                        case 115: msgError = "Parentesis sin cerrar"; break;
                        case 219: msgError = "Metodo sin fin correspondiente"; break;
                        case 999: msgError = "Bloque principal sin fin correspondiente"; break;
                        default: msgError = "Bloque sin cerrar"; break;
                    }

                    if (elemento.token == 203 || elemento.token == 204 ||
                        elemento.token == 206 || elemento.token == 219 ||
                        elemento.token == 115 || elemento.token == 999)
                    {
                        tablaErrores.Rows.Add(430, elemento.palabra, msgError,
                                              elemento.renglon, elemento.columna);
                    }
                }
                pila.Clear();
            }

            return new Tuple<DataTable, DataTable>(TablaSintactica, tablaErrores);
        }
    }
}