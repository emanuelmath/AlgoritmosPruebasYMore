using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosPruebasYMore
{
    public class LychrelNumber
    {
        /// <summary>
        /// Función rústica que une el trabajo de otras funciones con el fin de aplicar el algoritmo de Lychrel a un entero positivo.
        /// </summary>
        /// <param name="number"></param>
       public static void ProcesarNumero(long number)
       {
            string numberString = number.ToString();

            if (number > 0)
            {
                while (!EsPalindromo(number.ToString()))
                {
                    number = LynchNumber(number, numberString);
                    numberString = number.ToString();
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("Número menor a 0 o entrada inválida");
            }
       }
       public static long LynchNumber(long num, string numS)
       {
            string numInvertedS = Reverso(numS);
            long numInverted = Convert.ToInt64(numInvertedS);
            long sumOf = num + numInverted;
            return sumOf;
       }

        public static string Reverso(string s)
        {
            string reverseS = "";

            for (int i = s.Trim().Length - 1; i >= 0; i--)
            {
                reverseS += s[i];
            }

            return reverseS;
        }

        public static bool EsPalindromo(string s)
        {
            string reverseS = Reverso(s);
            if (s == reverseS)
            {
                return true;
            }
            return false;

        }
    }
}
