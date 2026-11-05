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
            224, 225, 226, 227, 228
        };
        // Filas = estados (0-39). Valor < 100: estado siguiente | 300-399: instruccion aceptada | 400-499: error
        int[,] matriz =
        {
            //   600  100  101  102  103  104  105  106  107  108  109  110  111  112  113  114  115  116  117  118  119  120  121  122  200  201  202  203  204  205  206  207  208  209  210  211  212  213  214  215  216  217  218  219  220  221  222  223  224  225  226  227  228
            { 3,   413, 413, 413, 414, 414, 414, 414, 415, 415, 415, 415, 415, 415, 415, 0,   416, 416, 416, 416, 416, 416, 417, 417, 1,   1,   1,   1,   6,   303, 418, 11,  418, 418, 418, 28,  34,  418, 418, 315, 316, 418, 418, 418, 312, 309, 313, 314, 16,  20,  24,  26,    40},  // estado 0
            { 2,   404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 1
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 300, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 2
            { 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 4,   406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406, 406 },  // estado 3
            { 5,   5,   5,   5,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 4,   407, 407, 407, 407, 407, 407, 5,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 4
            { 405, 405, 405, 405, 4,   4,   4,   4,   405, 405, 405, 405, 405, 405, 405, 405, 405, 5,   405, 405, 405, 301, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 5
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 7,   408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 6
            { 8,   8,   8,   8,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 7,   407, 407, 407, 407, 407, 8,   8,   407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 7
            { 409, 409, 409, 409, 7,   7,   7,   7,   9,   9,   9,   9,   9,   9,   9,   409, 409, 8,   409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409 },  // estado 8
            { 10,  10,  10,  10,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 9,   407, 407, 407, 407, 407, 10,  10,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 9
            { 410, 410, 410, 410, 9,   9,   9,   9,   410, 410, 410, 410, 410, 410, 410, 410, 410, 10,  410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 7,   7,   410, 410, 410, 410, 410, 410, 410, 302, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410 },  // estado 10
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 12,  408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 11
            { 13,  13,  13,  13,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 12,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 12
            { 409, 409, 409, 409, 12,  12,  12,  12,  14,  14,  14,  14,  14,  14,  14,  409, 409, 13,  409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409, 409 },  // estado 13
            { 15,  15,  15,  15,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 14,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 14
            { 410, 410, 410, 410, 14,  14,  14,  14,  410, 410, 410, 410, 410, 410, 410, 410, 410, 15,  410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 410, 12,  12,  410, 410, 410, 410, 410, 410, 410, 410, 304, 410, 410, 410, 410, 410, 410, 410, 410, 410 },  // estado 15
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 17,  408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 16
            { 18,  412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 18,  18,  412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412 },  // estado 17
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 19,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 18
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 305, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 19
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 21,  408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 20
            { 22,  412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412, 412 },  // estado 21
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 23,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 22
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 306, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 23
            { 25,  404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 24
            { 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 307, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408, 408 },  // estado 25
            { 27,  27,  27,  27,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 27,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 26
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 308, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 27
            { 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 29,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 28
            { 30,  404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 29
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 31,  405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 30
            { 407, 32,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 31
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 33,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 32
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 310, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 33
            { 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 35,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 34
            { 36,  404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404, 404 },  // estado 35
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 37,  405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 36
            { 407, 38,  407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407, 407 },  // estado 37
            { 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 39,  411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411, 411 },  // estado 38
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 311, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 39
            { 41, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 404, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 40
            { 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 317, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405, 405 },  // estado 41
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
            {426, "Bloque sin cerrar al final del codigo"},
            {427, "Variable no declarada"},
            {428, "Tipo de valor no coincide"},
            {429, "Metodo no declarado"},
            {430, "Operacion no valida"},
            {431, "La variable ya ha sido declarada anteriormente"},
            {432, "El metodo ya ha sido declarado anteriormente"}
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
            {316, "Inicio de bloque principal"},
            {317, "Llamada de metodo"}
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
        List<string> listaPostFija = new List<string>();
        Stack<int> pilaNumeracionIf = new Stack<int>();
        Stack<int> pilaNumeracionWhile = new Stack<int>();

        Dictionary<string, int> prioridadOperadores = new Dictionary<string, int>()
        {
            {"=", 1},
            {"||", 2}, {"o", 2},
            {"&&", 2}, {"y", 2},
            {"==", 3}, {"<>", 3}, {"<", 3}, {">", 3}, {"<=", 3}, {">=", 3},
            {"+", 4}, {"-", 4},
            {"*", 5}, {"/", 5}, {"%", 5},
            {"^", 6},
            {"!", 7}, {"no", 7}
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
        string[] partes;
        string tipoInicial = "int";
        int contIf = 0;
        int contWhile = 0;
        string variableTipo;
        string variableNombre;
        Stack<int> pilaParentesis = new Stack<int>();
        Stack<int> pilaBloques = new Stack<int>();
        DataTable tablaSint;
        DataTable tablaError;
        DataTable tablaVariables;
        bool yaDeclarada;
        public Tuple<DataTable, DataTable, DataTable> RecorrerSintactico(DataTable tablaLexico, DataTable tablaErrores)
        {
            tablaSint = new DataTable();
            tablaSint.Columns.Add("Token");
            tablaSint.Columns.Add("Descripcion");
            tablaSint.Columns.Add("Palabra");
            tablaSint.Columns.Add("Renglon");
            tablaSint.Columns.Add("Columna");
            tablaVariables = new DataTable();
            tablaVariables.Columns.Add("Variable");
            tablaVariables.Columns.Add("Tipo");
            tablaVariables.Columns.Add("Valor inicial");
            tablaError = tablaErrores;

            if (tablaLexico.Rows.Count == 0)
                return new Tuple<DataTable, DataTable, DataTable>(tablaSint, tablaError, tablaVariables);

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
                        if (estado == 300)
                        {
                            partes = palabra.Split(' ');
                            variableTipo = partes[0];
                            variableNombre = partes[1];

                            yaDeclarada = tablaVariables.Rows.Cast<DataRow>()
                                .Any(f => f["Variable"].ToString() == variableNombre);

                            if (yaDeclarada)
                            {
                                tablaError.Rows.Add(431, variableNombre,
                                    $"{dicErrores[431]} ({variableNombre})", renglonInicio, columnaInicio);
                            }
                            else
                            {
                                if (partes[0] == "entero")
                                {
                                    tipoInicial = "int";
                                    tablaVariables.Rows.Add(partes[1], partes[0], "0");
                                }
                                else if (partes[0] == "doble")
                                {
                                    tipoInicial = "double";
                                    tablaVariables.Rows.Add(partes[1], partes[0], "0.0");
                                }
                                else if (partes[0] == "cadena")
                                {
                                    tipoInicial = "string";
                                    tablaVariables.Rows.Add(partes[1], partes[0], "\"\"");
                                }
                                else if (partes[0] == "caracter")
                                {
                                    tipoInicial = "char";
                                    tablaVariables.Rows.Add(partes[1], partes[0], "' '");
                                }
                            }
                        }
                        else if (estado == 307)
                        {
                            partes = palabra.Split(' ');
                            variableTipo = partes[0];
                            variableNombre = partes[1];

                            yaDeclarada = tablaVariables.Rows.Cast<DataRow>()
                                .Any(f => f["Variable"].ToString() == variableNombre);

                            if (yaDeclarada)
                            {
                                tablaError.Rows.Add(432, variableNombre,
                                    $"{dicErrores[432]} ({variableNombre})", renglonInicio, columnaInicio);
                            }
                            else
                            {
                                tablaVariables.Rows.Add(partes[1], "Proc", " ");
                            }
                        }
                        tablaSint.Rows.Add(estado, descripcion, palabra, renglonInicio, columnaInicio);
                        estado = 0;
                        palabra = "";
                        pilaParentesis.Clear();

                    }
                    if (estado == 600)
                    {
                        foreach (DataRow filas in tablaVariables.Rows)
                        {
                            if (filas["variable"].ToString() == palabra)
                            {
                                tablaError.Rows.Add(427, palabra, dicErrores[427], renglonTexto, columnaTexto);
                            }
                        }
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

            return new Tuple<DataTable, DataTable, DataTable>(tablaSint, tablaError, tablaVariables);
        }

        public DataTable ErroresSemanticos(DataTable tablaSintactico, DataTable tablaVarsRecibida, DataTable tablaErrores)
        {
            tablaError = tablaErrores;
            tablaVariables = tablaVarsRecibida;

            foreach (DataRow fila in tablaSintactico.Rows)
            {
                int tokenSint = Convert.ToInt32(fila["Token"]);
                string palabra = fila["Palabra"].ToString();
                int renglon = Convert.ToInt32(fila["Renglon"]);
                int columna = Convert.ToInt32(fila["Columna"]);

                List<string> partes = DividirRespetandoComillas(palabra);

                switch (tokenSint)
                {
                    case 301: // Igualacion
                        ValidarIgualacion(partes, renglon, columna);
                        break;
                    case 302: // Condicional
                    case 304: // Ciclo while
                        ValidarCondicion(partes, renglon, columna);
                        break;
                    case 317: // Llamada de metodo
                        ValidarLlamada(partes, renglon, columna);
                        break;
                    case 305: // escribir
                    case 306: // leer
                        ValidarVariableSimple(partes, renglon, columna);
                        break;
                    case 310: // Incremento
                    case 311: // Decremento
                        ValidarIncrementoDecremento(partes, renglon, columna);
                        break;
                }
            }
            return tablaError;
        }
        private void ValidarIncrementoDecremento(List<string> partes, int renglon, int columna)
        {
            int idxAbre = partes.IndexOf("(");
            int idxCierra = partes.IndexOf(")");
            if (idxAbre == -1 || idxCierra == -1) return;

            for (int k = idxAbre + 1; k < idxCierra; k++)
            {
                string tok = partes[k];
                if (tok == ",") continue;
                if (InferirTipoLiteral(tok) != null) continue;

                bool declarada;
                BuscarTipoVariable(tok, out declarada);
                if (!declarada)
                {
                    tablaError.Rows.Add(427, tok, $"{dicErrores[427]} ({tok})", renglon, columna);
                    tipoInicial = "double";
                }
            }
        }

        private void ValidarIgualacion(List<string> partes, int renglon, int columna)
        {
            if (partes.Count < 3) return;
            string variable = partes[0];

            bool declarada;
            string tipoVar = BuscarTipoVariable(variable, out declarada);

            if (!declarada)
            {
                tablaError.Rows.Add(427, variable, $"{dicErrores[427]} ({variable})", renglon, columna);
                tipoInicial = "double";
            }
            else
            {
                tipoInicial = tipoVar;
            }

            for (int k = 2; k < partes.Count; k++)
            {
                string tok = partes[k];
                if (tok == ";" || tok == "(" || tok == ")" || EsOperador(tok)) continue;

                string tipoLit = InferirTipoLiteral(tok);
                if (tipoLit != null)
                {
                    if (tipoLit != tipoInicial)
                        tablaError.Rows.Add(428, tok, $"{dicErrores[428]} ({tok})", renglon, columna);
                }
                else
                {
                    bool declOtra;
                    string tipoOtra = BuscarTipoVariable(tok, out declOtra);
                    if (!declOtra)
                    {
                        tablaError.Rows.Add(427, tok, $"{dicErrores[427]} ({tok})", renglon, columna);
                        tipoInicial = "double";
                    }
                    else if (tipoOtra != tipoInicial)
                    {
                        tablaError.Rows.Add(428, tok, $"{dicErrores[428]} ({tok})", renglon, columna);
                    }
                }
            }
        }

        private void ValidarCondicion(List<string> partes, int renglon, int columna)
        {
            int idxAbre = partes.IndexOf("(");
            int idxCierra = partes.LastIndexOf(")"); 
            if (idxAbre == -1 || idxCierra == -1 || idxCierra <= idxAbre + 1) return;

            string[] expresion = partes.Skip(idxAbre + 1).Take(idxCierra - idxAbre - 1).ToArray();
            string tipoEsperado = null;

            foreach (string tok in expresion)
            {
                if (tok == ";" || tok == "(" || tok == ")" || EsOperador(tok)) continue;

                string tipoLit = InferirTipoLiteral(tok);
                if (tipoLit != null)
                {
                    if (tipoEsperado != null && tipoLit != tipoEsperado)
                        tablaError.Rows.Add(428, tok, $"{dicErrores[428]} ({tok})", renglon, columna);
                }
                else
                {
                    bool declOtra;
                    string tipoVar = BuscarTipoVariable(tok, out declOtra);
                    if (!declOtra)
                    {
                        tablaError.Rows.Add(427, tok, $"{dicErrores[427]} ({tok})", renglon, columna);
                        tipoInicial = "double";
                        tipoEsperado = tipoEsperado ?? "double";
                    }
                    else
                    {
                        if (tipoEsperado != null && tipoVar != tipoEsperado)
                            tablaError.Rows.Add(428, tok, $"{dicErrores[428]} ({tok})", renglon, columna);
                        tipoEsperado = tipoEsperado ?? tipoVar;
                        tipoInicial = tipoVar;
                    }
                }
            }
        }
        private List<string> DividirRespetandoComillas(string texto)
        {
            List<string> tokens = new List<string>();
            bool enComillasDobles = false, enComillasSimples = false;
            string actual = "";

            foreach (char c in texto)
            {
                if (c == '"' && !enComillasSimples)
                {
                    actual += c;
                    if (enComillasDobles) { tokens.Add(actual); actual = ""; }
                    enComillasDobles = !enComillasDobles;
                    continue;
                }
                if (c == '\'' && !enComillasDobles)
                {
                    actual += c;
                    if (enComillasSimples) { tokens.Add(actual); actual = ""; }
                    enComillasSimples = !enComillasSimples;
                    continue;
                }
                if (enComillasDobles || enComillasSimples) { actual += c; continue; }

                if (c == ' ')
                {
                    if (actual != "") { tokens.Add(actual); actual = ""; }
                }
                else actual += c;
            }
            if (actual != "") tokens.Add(actual);
            return tokens;
        }

        private void ValidarLlamada(List<string> partes, int renglon, int columna)
        {
            if (partes.Count < 2) return;
            string metodo = partes[1];
            if (!EsMetodoDeclarado(metodo))
                tablaError.Rows.Add(429, metodo, $"{dicErrores[429]} ({metodo})", renglon, columna);
        }

        private void ValidarVariableSimple(List<string> partes, int renglon, int columna)
        {
            int idxAbre = partes.IndexOf("(");
            int idxCierra = partes.IndexOf(")");
            if (idxAbre == -1 || idxCierra == -1 || idxCierra <= idxAbre + 1) return;

            for (int k = idxAbre + 1; k < idxCierra; k++)
            {
                string tok = partes[k];
                if (InferirTipoLiteral(tok) != null) continue;

                bool declarada;
                BuscarTipoVariable(tok, out declarada);
                if (!declarada)
                {
                    tablaError.Rows.Add(427, tok, $"{dicErrores[427]} ({tok})", renglon, columna);
                    tipoInicial = "double";
                }
            }
        }
        private string MapearTipoDeclarado(string tipoPalabra)
        {
            switch (tipoPalabra)
            {
                case "entero": return "int";
                case "doble": return "double";
                case "cadena": return "string";
                case "caracter": return "char";
                default: return null;
            }
        }

        private string BuscarTipoVariable(string nombre, out bool declarada)
        {
            foreach (DataRow fila in tablaVariables.Rows)
            {
                if (fila["Variable"].ToString() == nombre)
                {
                    declarada = true;
                    return MapearTipoDeclarado(fila["Tipo"].ToString());
                }
            }
            declarada = false;
            return null;
        }

        private bool EsMetodoDeclarado(string nombre)
        {
            foreach (DataRow fila in tablaVariables.Rows)
                if (fila["Variable"].ToString() == nombre && fila["Tipo"].ToString() == "Proc")
                    return true;
            return false;
        }

        private string InferirTipoLiteral(string tok)
        {
            if (string.IsNullOrEmpty(tok)) return null;
            if (tok.Length >= 2 && tok.StartsWith("\"") && tok.EndsWith("\"")) return "string";
            if (tok.Length >= 2 && tok.StartsWith("'") && tok.EndsWith("'")) return "char";
            if (tok.Contains(".") && double.TryParse(tok, out _)) return "double";
            if (int.TryParse(tok, out _)) return "int";
            return null;
        }

        private bool EsOperador(string tok)
        {
            string[] ops = { "+", "-", "*", "/", "%", "^", "&&", "y", "||", "o", "!", "no", "==", "<>", "<", ">", "<=", ">=" };
            return Array.IndexOf(ops, tok) >= 0;
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
        public List<string> GenerarListaPostFija(DataTable tablaSintactico)
        {
            listaPostFija = new List<string>();
            pilaNumeracionIf.Clear();
            pilaNumeracionWhile.Clear();
            contIf = 0;
            contWhile = 0;

            foreach (DataRow fila in tablaSintactico.Rows)
            {
                int tokenSint = Convert.ToInt32(fila["Token"]);
                string palabra = fila["Palabra"].ToString();
                List<string> partes = DividirRespetandoComillas(palabra);

                switch (tokenSint)
                {

                    case 309:
                        listaPostFija.Add("metodo_finM");
                        break;

                    case 301:
                        {
                            List<string> tokensExpr = partes.Where(t => t != ";").ToList();
                            ProcesarExpresionPostfija(tokensExpr);
                        }
                        break;

                    case 310:
                    case 311:
                        {
                            string variable = partes[2];
                            string cantidad = partes[4];

                            listaPostFija.Add(tokenSint == 310 ? "inc" : "dec");
                            listaPostFija.Add(variable);
                            listaPostFija.Add(cantidad);
                        }
                        break;

                    case 302:
                        {
                            contIf++;
                            pilaNumeracionIf.Push(contIf);
                            listaPostFija.Add($"si{contIf}");

                            int idxAbre = partes.IndexOf("(");
                            int idxCierra = partes.LastIndexOf(")");
                            List<string> condicion = partes.Skip(idxAbre + 1).Take(idxCierra - idxAbre - 1).ToList();
                            ProcesarExpresionPostfija(condicion);

                            listaPostFija.Add($"inicioSi{contIf}");
                        }
                        break;

                    case 303: // sino
                        {
                            int num = pilaNumeracionIf.Count > 0 ? pilaNumeracionIf.Peek() : contIf;
                            listaPostFija.Add($"sino{num}");
                        }
                        break;

                    case 313: // finS
                        {
                            int num = pilaNumeracionIf.Count > 0 ? pilaNumeracionIf.Pop() : contIf;
                            listaPostFija.Add($"finsi{num}");
                            contIf--;
                        }
                        break;

                    case 304:
                        {
                            contWhile++;
                            pilaNumeracionWhile.Push(contWhile);
                            listaPostFija.Add($"mientras{contWhile}");

                            int idxAbre = partes.IndexOf("(");
                            int idxCierra = partes.LastIndexOf(")");
                            List<string> condicion = partes.Skip(idxAbre + 1).Take(idxCierra - idxAbre - 1).ToList();
                            ProcesarExpresionPostfija(condicion);

                            listaPostFija.Add($"inicioMientras{contWhile}");
                        }
                        break;

                    case 314: // finC
                        {
                            int num = pilaNumeracionWhile.Count > 0 ? pilaNumeracionWhile.Pop() : contWhile;
                            listaPostFija.Add($"finmientras{num}");
                            contWhile--;
                        }
                        break;

                    case 305:
                    case 306:
                        {
                            int idxAbre = partes.IndexOf("(");
                            int idxCierra = partes.IndexOf(")");
                            listaPostFija.Add(partes[0]);
                            for (int k = idxAbre + 1; k < idxCierra; k++)
                                listaPostFija.Add(partes[k]);
                        }
                        break;
                    case 307: // Metodo (inicio)
                        {
                            listaPostFija.Add("metodo");
                            listaPostFija.Add($"metodo_{partes[1]}"); 
                            listaPostFija.Add("metodo_iniM");
                        }
                        break;

                    case 317:
                        listaPostFija.Add("llamar");
                        listaPostFija.Add(partes[1]);
                        break;

                    case 316:
                        listaPostFija.Add("inicio");
                        break;

                    case 312:
                        listaPostFija.Add("fin");
                        break;
                }
            }

            return listaPostFija;
        }
        private void ProcesarExpresionPostfija(List<string> tokens)
        {
            Stack<string> pilaOperadores = new Stack<string>();

            foreach (string tok in tokens)
            {
                if (tok == "(")
                {
                    pilaOperadores.Push(tok);
                }
                else if (tok == ")")
                {
                    while (pilaOperadores.Count > 0 && pilaOperadores.Peek() != "(")
                        listaPostFija.Add(pilaOperadores.Pop());
                    if (pilaOperadores.Count > 0)
                        pilaOperadores.Pop();
                }
                else if (prioridadOperadores.ContainsKey(tok))
                {
                    int prioridadActual = prioridadOperadores[tok];
                    while (pilaOperadores.Count > 0 &&
                           pilaOperadores.Peek() != "(" &&
                           prioridadOperadores.ContainsKey(pilaOperadores.Peek()) &&
                           prioridadOperadores[pilaOperadores.Peek()] >= prioridadActual)
                    {
                        listaPostFija.Add(pilaOperadores.Pop());
                    }
                    pilaOperadores.Push(tok);
                }
                else
                {
                    listaPostFija.Add(tok); // aiudaaaaaaaaa
                }
            }


            while (pilaOperadores.Count > 0)
                listaPostFija.Add(pilaOperadores.Pop());
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