using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosPruebasYMore
{
    public static class CorreoElectronico
    {

        /// <summary>
        /// Función rústica para verificar que un string sea un email válido con mínimo 5 caracteres antes del dominio.
        /// </summary>
        /// <param name="correo"></param>
        /// <returns>Un true si es un correo válido, un false si no.</returns>
        public static bool CorreoValido(string correo)
        {
            //bool respuesta = false; En fase de agregar, puede servir para evitar tanto else y su return true o false, cambiando o dejando el valor contrario.
            const char arroba = '@';
            const char punto = '.';
            string correoFormateado = correo.Trim().ToLower();
            int contadorAntesDelArroba = 0;
            int contadorDeArrobaDespues = 0;
            int contadorDePuntoDespues = 0;
            string dominio = "";
            int coordenadaArroba = -1;
            List<char> caracteresInvalidos = new List<char>() { ' ', '{', '}', '(', ')', 'ñ', ':', ';', ',' }; 
            //No incluyo la arroba para comparar más fácil luego, al inicio sí la usé. Lo mismo con el punto.

            if (!string.IsNullOrEmpty(correoFormateado))
            {
                foreach (char c in correoFormateado)
                {
                    if (caracteresInvalidos.Contains(c) == false)
                    {
                        if (contadorAntesDelArroba < 5)
                        {
                            if (c == arroba || c == punto)
                            {
                                return false;
                            }
                            else
                            {
                                contadorAntesDelArroba++;
                                
                            }
                        }

                        if (contadorAntesDelArroba >= 5)
                        {
                            if (c == arroba)
                            {
                                contadorDeArrobaDespues++;
                                coordenadaArroba = correoFormateado.IndexOf(c);
                            }

                            if (c == punto)
                            {
                                contadorDePuntoDespues++;
                            }
                            else
                            {
                                if (coordenadaArroba == -1)
                                {
                                    contadorAntesDelArroba++;
                                }

                            }

                        }
                    }
                    else
                    {
                        return false;
                    }

                }

                if (contadorDePuntoDespues != 1)
                {
                    return false;
                }

                if (contadorDeArrobaDespues != 1)
                {
                    return false;
                }
                else
                {
                    int i = 0;
                    foreach (char c in correoFormateado)
                    {

                        if (i > coordenadaArroba)
                        {
                            dominio += c;
                        }
                        i++;
                    }
                    

                    if (dominio.Contains(punto))
                    {
                        int j = 0;

                        foreach (char c in dominio)
                        {
                            if (caracteresInvalidos.Contains(c))
                            {
                                return false;
                            }

                            if (c == punto && j <= 0)
                            {
                                return false;
                            }

                            j++;
                            return true;
                        }
                    }
                }
            }

            return false;
        }


    }
}
