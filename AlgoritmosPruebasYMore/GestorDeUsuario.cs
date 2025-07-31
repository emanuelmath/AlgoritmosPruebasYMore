using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoritmosPruebasYMore
{
    // ATENCIÓN: Faltan algunas mejoras o métodos completos, espero luego poder agregar lo que falta. 😀
    public class GestorDeUsuario
    {
        private const int salirOpc = 5;

        /// <summary>
        /// Función rústica que unifica una clase y varios métodos para hacer funcionar un mini-gestor para usuarios por consola.
        /// </summary>
        public static void IniciarGestor()
        {
            int opc = 0;
            List<Usuario> listaDeUsuarios = new List<Usuario>();
            while (opc != salirOpc)
            {
                Console.WriteLine("¡Bienvenido! ¿Qué quieres hacer hoy?");
                Console.WriteLine("1- Agregar un usuario.");
                Console.WriteLine("2- Eliminar un usuario.");
                Console.WriteLine("3- Actualizar un usuario.");
                Console.WriteLine("4- Ver a todos los usuarios.");
                Console.WriteLine($"{salirOpc}- Salir.");
                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("No has ingresado un número de opción mostrada.");
                }
                switch (opc)
                {
                    case 1:
                        listaDeUsuarios.Add(AgregarUsuario(listaDeUsuarios));
                        RefrescarLista(listaDeUsuarios);
                        break;
                    case 2:
                        EliminarUsuario(listaDeUsuarios);
                        break;
                    case 3:
                        Console.WriteLine("Método en desarrollo.");
                        break;
                    case 4:
                        RefrescarLista(listaDeUsuarios);
                        break;
                    case salirOpc:
                        Console.WriteLine("Saliendo...");
                        break;
                    default:
                        Console.WriteLine("No elegiste ninguna opción mostrada.");
                        break;

                }

            }
        }

        private static Usuario AgregarUsuario(List<Usuario> lista)
        {
            Usuario usuario = new Usuario();
            Console.WriteLine("Ingresa el nombre del usuario: ");
            while(String.IsNullOrEmpty(usuario.Nombre = Console.ReadLine().Trim()))
            {
               Console.WriteLine("Entrada vacía, por favor ingresa un nombre.");
            }

            Console.WriteLine("Ingresa la edad del usuario: ");
            int edad = 0;
            while (!int.TryParse(Console.ReadLine(), out edad))
            {
                Console.WriteLine("Ingresa un número entero.");
            }
            if (edad < 0 || edad > 120)
            {
                Console.WriteLine("Edad fuera de los límites permitidos, reajustada automáticamente a 18 años.");
                edad = 18;
            }
            usuario.Edad = edad;

            if (usuario.Edad < 18)
            {
                usuario.EtapaDeVida = "Menor de Edad";
            }
            else
            {
                usuario.EtapaDeVida = "Mayor de Edad";
            }

            if (lista.Count <= 0)
            {
                usuario.Id = 1;
            }
            else
            {
                usuario.Id = lista[lista.Count - 1].Id + 1;
             
            }

            return usuario;
        }

        private static void EliminarUsuario(List<Usuario> lista)
        {
            if (lista.Count > 0)
            {
                Console.WriteLine("Ingresa el id del usuario a eliminar: ");
                int id = 0;
                while (!int.TryParse(Console.ReadLine(), out id))
                {
                    Console.WriteLine("Ingresa un número entero.");
                }
                if (id <= 0)
                {
                    Console.WriteLine("Id inválida, eliminación cancelada.");
                }
                else
                {

                    if (lista.Remove(lista.Find(usuario => usuario.Id == id)))
                    {
                        Console.WriteLine("Usuario eliminado correctamente.");
                        if(lista.Count > 0)
                        {
                            RefrescarLista(lista);
                        }
                        else
                        {
                            Console.WriteLine("Ahora estás sin usuarios.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado.");
                    }
                }
            }
            else
            {
                Console.WriteLine("No hay usuarios para eliminar.");
            }
        }

        private static void RefrescarLista(List<Usuario> lista)
        {
            if(lista.Count <= 0)
            {
                Console.WriteLine("No hay usuarios aún.");
            }
            else
            {
                foreach (Usuario usuario in lista)
                {
                    Console.WriteLine($"|  {usuario.Id} | {usuario.Nombre} | {usuario.Edad} | {usuario.EtapaDeVida} |");
                }
            }
        }
    }

    public class Usuario
    {   
        public int Id { get; set; } = -1;
        public string Nombre { get; set; } = "";
        public int Edad { get; set; } = 0;
        public string EtapaDeVida { get; set; } = "";
    }
}

