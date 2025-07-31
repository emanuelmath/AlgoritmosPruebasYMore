using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosPruebasYMore
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("¡Bienvenido a Algoritmos, Pruebas y Más! Por defecto el algoritmo de CorreoElectrónico está para probarse, pero puedes cambiarlo.");
            string correo = "";

            Task.Delay(1000).Wait();

            while(correo != "Parar")
            {
                Console.WriteLine("Ingresa un correo electrónico válido o inválido, con [Parar] dejas de probar");
                correo = Console.ReadLine();

                if(CorreoElectronico.CorreoValido(correo))
                {
                    Console.WriteLine("Es un correo válido.");
                }
                else
                {
                    if(correo != "Parar")
                    {
                       Console.WriteLine("No es un correo válido.");
                    }    
                }
            }

        }
       
    }

}
        