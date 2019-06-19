using System;

namespace BaseConverter
{
    class BaseConverter
    {
        // Dicionário com todos os caracteres da base 36 (e, consequentemente, de todas as anteriores)
        static char[] dictionary = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

        // Verifica se um caractere é válido para a base de entrada
        static int CharValid(char c, int basein)
        {
            for (int i = 0; i < basein; i++)
                if (c == dictionary[i])
                    return i;
            return -1;
        }

        // Verifica se uma base é valida
        static bool BaseValid(int b)
        {
            if (b > 1 && b < dictionary.Length + 1)
                return true;
            else
                return false;
        }

        // Função potência com valores inteiros
        static int IntPow(int nBase, int nExpo)
        {
            if (nExpo == 0) return 1; if (nExpo == 1) return nBase;
            if (nBase == 0) return 0; if (nBase == 1) return 1;

            int y = nBase;
            for (int i = 2;  i <= nExpo;  i++)
            {
                y *= nBase;
            }
            return y;
        }

        // Função de conversão
        static string Converter(int basein, string input, int baseout)
        {
            // Definições
            if (!BaseValid(basein))
                return null;
            if (!BaseValid(baseout))
                return null;
            string output = "", inputFormatted = input.ToUpper();
            long dec = 0;
            int expo = inputFormatted.Length - 1, valueNum;

            // Da base de entrada pra decimal
            foreach (char c in inputFormatted)
            {
                valueNum = CharValid(c, basein);
                if (valueNum < 0)
                    return null;
                else
                    dec += valueNum * IntPow(basein, expo);
                expo--;
            }

            // De decimal pra base de saída
            do
            {
                if (dec % baseout == 0)
                    output = "0" + output;
                else
                    output = dictionary[dec % baseout] + output;
                dec /= baseout;
            } while (dec != 0);

            return output;
        }

        static void Main()
        {
            string output;
            bool repeat = true;
            Console.WriteLine("\n  CONVERSOR DE BASE NUMÉRICA          @EdeiltonSO");
            Console.WriteLine("  (suporta bases de entrada e saída entre 2 e {0})", dictionary.Length);

            while (repeat)
            {
                Console.Write("\n  Base de entrada: ");
                string basein = Console.ReadLine();

                Console.Write("  Valor de entrada: ");
                string input = Console.ReadLine();

                Console.Write("  Base de saída: ");
                string baseout = Console.ReadLine();

                try
                {
                    output = Converter(Convert.ToInt16(basein), input, Convert.ToInt16(baseout));
                }
                catch
                {
                    output = "ERRO NAS BASES! Informe valores numéricos entre 2 e 36.";
                }
                Console.WriteLine("  Valor de saída: " + output);

                Console.Write("\n  Informe 1 para sair ou tecle ENTER para reiniciar: ");
                string op = Console.ReadLine();

                if (op == "1")
                    repeat = false;
            }
        }
    }
}