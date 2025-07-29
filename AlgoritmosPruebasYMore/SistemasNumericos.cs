using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosPruebasYMore
{
    public class SistemasNumericos
    {
        /// <summary>
        /// Función que convierte un entero positivo a binario, devolviendo un string con el resultado.
        /// </summary>
        /// <param name="numDecimal"></param>
        /// <returns>string del binario del decimal.</returns>
        public static string ConvertirDecimalABinario(int numDecimal)
        {
            string binarioString = "";
            string reverse = "";

            if (numDecimal == 0)
            {
                return "0";
            }
            else if (numDecimal == 1)
            {
                return "1";
            }
            else if (numDecimal > 0 && numDecimal > 1)
            {
                while (numDecimal >= 1)
                {

                    if (numDecimal % 2 == 0)
                    {
                        binarioString += "0";
                        numDecimal /= 2;
                    }
                    else
                    {
                        binarioString += "1";
                        numDecimal = (numDecimal - 1) / 2;
                    }

                }

                for (int i = binarioString.Length - 1; i >= 0; i--)
                {
                    reverse += binarioString[i];
                }
                binarioString = reverse;
                return binarioString;
            }
            else
            {
                return "Pon un número entero positivo.";
            }

        }

        /// <summary>
        /// Función que convierte un string que representa a un binario a decimal (entero positivo).
        /// </summary>
        /// <param name="binario"></param>
        /// <returns>string del decimal del binario.</returns>
        public static string ConvertirBinarioADecimal(string binario)
        {
            bool isBinary = false;
            int decimalS = 0;

            if (binario.Trim() != null || binario.Trim() == "")
            {
                foreach (char c in binario.Trim())
                {
                    if (int.TryParse(c.ToString(), out int b))
                    {
                        if (b == 1 || b == 0)
                        {
                            isBinary = true;
                        }
                        else
                        {
                            return "No es un número binario.";
                        }
                    }
                    else
                    {
                        return "No es un número binario.";
                    }

                }
            }

            if (isBinary)
            {
                int lenght = binario.Trim().Length - 1;

                foreach (char c in binario.Trim())
                {
                    int.TryParse(c.ToString(), out int b);
                    if (b == 1)
                    {
                        decimalS += (int)Math.Pow(2, lenght);
                    }
                    lenght--;
                }
                return decimalS.ToString();
            }

            return "No es un número binario";

        }
    }

}
