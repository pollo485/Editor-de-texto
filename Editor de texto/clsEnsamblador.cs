using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Editor_de_texto
{
    internal class clsEnsamblador
    {
        Stack<(string tipo, int num)> pilaBloques = new Stack<(string, int)>();
        List<int> sinoImpreso = new List<int>();
        static readonly Dictionary<string, string> saltoInverso = new Dictionary<string, string>
        {
            { "<",  "JGE" },
            { "<=", "JG"  },
            { ">",  "JLE" },
            { ">=", "JL"  },
            { "<>", "JE"  },
            { "==", "JNE" }
        };
        static readonly Dictionary<string, string> setSegunComparador = new Dictionary<string, string>
        {
            { "<",  "SETL"  },
            { "<=", "SETLE" },
            { ">",  "SETG"  },
            { ">=", "SETGE" },
            { "<>", "SETNE" },
            { "==", "SETE"  }
        };

        static bool EsLogico(string t)
        {
            return t == "y" || t == "o" || t == "&&" || t == "||";
        }
        static bool EsCondicionCompuesta(List<string> p, int desde)
        {
            for (int k = desde + 1; k < p.Count; k++)
            {
                if (p[k].StartsWith("inicioSi") || p[k].StartsWith("inicioMientras"))
                    return false;
                if (EsLogico(p[k]))
                    return true;
            }
            return false;
        }
        public string GenerarCodigo(DataTable variables, List<string> postfijo)
        {
            postfijo = new List<string>(postfijo);
            string data = ".data \n";
            string codigo = "";           
            int maxTemporales = 0;
            string renglonPost = "";
            int contadorTemporales = 0;
            int contadorSi = 0;
            int contadorMientras = 0;

            pilaBloques.Clear();
            sinoImpreso.Clear();
            bool condicionCompuestaPendiente = false;

            foreach (DataRow row in variables.Rows)
            {
                switch (row["Tipo"].ToString())
                {
                    case "entero":
                        data += $"{row["Variable"]} db 0 \n";
                        break;
                    case "doble":
                        data += $"{row["Variable"]} dd 0.0 \n";
                        break;
                    case "cadena":
                        data += $"{row["Variable"]} db \"\" \n";
                        break;
                    case "caracter":
                        data += $"{row["Variable"]} db \"\" \n";
                        break;
                }
            }
            codigo += "\n.code \n";

            for (int i = 0; i < postfijo.Count; i++)
            {
                renglonPost = postfijo[i];
                if (postfijo[i] == "metodo")
                {
                    codigo += "PROC ";
                }
                else if (renglonPost.StartsWith("metodo_") && renglonPost != "metodo_iniM")
                {
                    if (renglonPost[7] == 'f')
                    {
                        codigo += "ENDP \n";
                    }
                    else
                    {
                        contadorTemporales = 0;
                        codigo += postfijo[i].Replace("metodo_", "");
                        codigo += ": \n";
                    }
                }

                if (postfijo[i].StartsWith("sino"))
                {
                    contadorTemporales = 0;
                    int num = pilaBloques.Peek().num;
                    sinoImpreso.Add(num);
                    codigo += "JMP FIN_ELSE" + num + " \n";
                    codigo += "ELSE" + num + ": \n";
                }
                else if (postfijo[i].StartsWith("si"))
                {
                    contadorTemporales = 0;
                    contadorSi++;
                    pilaBloques.Push(("si", contadorSi));
                    codigo += "IF" + contadorSi + ": \n";
                }
                else if (postfijo[i].StartsWith("mientras"))
                {
                    contadorTemporales = 0;
                    contadorMientras++;
                    pilaBloques.Push(("mientras", contadorMientras));
                    codigo += "WHILE" + contadorMientras + ": \n";
                }
                else if (postfijo[i].StartsWith("finmientras"))
                {
                    int num = pilaBloques.Pop().num;
                    codigo += "JMP WHILE" + num + " \n";
                    codigo += "FIN_WHILE" + num + ": \n";
                }

                if (postfijo[i] == "inicio")
                {
                    codigo += "\nMAIN: \n";
                }
                else if (postfijo[i] == "fin")
                {
                    codigo += "END MAIN \n";
                }
                else if (postfijo[i].StartsWith("finsi"))
                {
                    int num = pilaBloques.Pop().num;

                    if (!sinoImpreso.Contains(num))
                        codigo += "JMP FIN_ELSE" + num + "\nELSE" + num + ": \n";

                    codigo += "FIN_ELSE" + num + ": \n";
                }
                if (saltoInverso.ContainsKey(postfijo[i]) && EsCondicionCompuesta(postfijo, i))
                {
                    contadorTemporales++;
                    string temp = $"temp{contadorTemporales}";
                    codigo += $"cmp {postfijo[i - 2]}, {postfijo[i - 1]}\n";
                    codigo += $"{setSegunComparador[postfijo[i]]} {temp} \n";

                    postfijo.RemoveRange(i - 2, 3);
                    postfijo.Insert(i - 2, temp);
                    i -= 2;
                    condicionCompuestaPendiente = true;
                }
                else if (EsLogico(postfijo[i]) && i >= 2)
                {
                    string op = (postfijo[i] == "y" || postfijo[i] == "&&") ? "AND" : "OR";

                    codigo += $"{op} {postfijo[i - 2]}, {postfijo[i - 1]} \n";

                    string resultado = postfijo[i - 2];
                    postfijo.RemoveRange(i - 2, 3);
                    postfijo.Insert(i - 2, resultado);
                    i -= 2;
                }
                else if ((postfijo[i].StartsWith("inicioSi") || postfijo[i].StartsWith("inicioMientras"))
                         && condicionCompuestaPendiente && pilaBloques.Count > 0)
                {
                    var bloque = pilaBloques.Peek();
                    string destino = bloque.tipo == "si" ? "ELSE" + bloque.num : "FIN_WHILE" + bloque.num;

                    codigo += $"cmp {postfijo[i - 1]}, 0\n";
                    codigo += $"JE {destino} \n";
                    condicionCompuestaPendiente = false;
                }
                else if (saltoInverso.ContainsKey(postfijo[i]) && pilaBloques.Count > 0)
                {
                    codigo += $"cmp {postfijo[i - 2]}, {postfijo[i - 1]}\n";

                    var bloque = pilaBloques.Peek();
                    string destino = bloque.tipo == "si" ? "ELSE" + bloque.num : "FIN_WHILE" + bloque.num;

                    codigo += $"{saltoInverso[postfijo[i]]} {destino} \n";
                }
                else if (postfijo[i] == "llamar")
                {
                    codigo += "CALL " + postfijo[i + 1] + " \n";
                }
                else if (postfijo[i] == "leer" || postfijo[i] == "imprimir")
                {
                    codigo += postfijo[i] + ", " + postfijo[i + 1] + " \n";
                }
                else if (postfijo[i] == "inc" || postfijo[i] == "dec")
                {
                    codigo += $"{postfijo[i].ToUpper()} {postfijo[i + 1]}, {postfijo[i + 2]} \n";
                }

                if (postfijo[i] == "+" || postfijo[i] == "-" || postfijo[i] == "*" || postfijo[i] == "/")
                {
                    contadorTemporales++;
                    codigo += $" = temp{contadorTemporales}, {postfijo[i - 2]} \n";
                    codigo += $" {postfijo[i]} temp{contadorTemporales}, {postfijo[i - 1]} \n";
                    postfijo.RemoveRange(i - 2, 3);
                    postfijo.Insert(i - 2, $"temp{contadorTemporales}");
                    i -= 2;
                }
                if (postfijo[i] == "=")
                {
                    codigo += $" = {postfijo[i - 2]}, {postfijo[i - 1]} \n";
                }
                if (contadorTemporales > maxTemporales)
                    maxTemporales = contadorTemporales;
            }
            for (int t = 1; t <= maxTemporales; t++)
                data += $"temp{t} dw 0 \n";

            return data + codigo;
        }
    }
}
