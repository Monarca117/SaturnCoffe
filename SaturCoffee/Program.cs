using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

/*
 * Autor: Miguel Angel Arellano Juárez
 * Fecha: 07/05/2024
 * Versión: 1.0.0.4
 * Modificación: 13/05/2024
 */

namespace SaturnCoffee
{
    /// Clase principal donde se ejecuta el código.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 07-05-2024
    /// Versión: 1.0.0.4
    /// Modificación: 13-05-2024
    internal class Program
    {
        /// Punto de entrada del programa.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param name="args">Argumentos de la línea de comandos.</param>
        /// <returns> No regresa nada</returns>
        static void Main(string[] args)
        {
            // Instanciar objetos necesarios
            CCafeteria cafeteria = new CCafeteria();
            CGestorPedidos gestorPedidos = new CGestorPedidos();
            string rutaArchivo = "pedidos.bin";

            // Deserializar los pedidos existentes al iniciar el programa, si existe el archivo.
            if (File.Exists(rutaArchivo))
            {
                gestorPedidos.DeserializarPedidos(rutaArchivo);
            }

            bool salir = false; //Variable booleana para el ciclo.
            while (!salir)
            {
                //Menú principal
                Console.WriteLine("************************************");
                Console.WriteLine("*           M E N U                *");
                Console.WriteLine("*  1. Nuevo Pedido                 *");
                Console.WriteLine("*  2. Mostrar todos los pedididos. *");
                Console.WriteLine("*  3. Eliminar pedidos             *");
                Console.WriteLine("*  4. Aplicar descuento            *");
                Console.WriteLine("*  5. Guardar y salir              *");
                Console.WriteLine("************************************");
                string opcion = Console.ReadLine();
                Console.WriteLine();

                //Selección de opción.
                switch (opcion)
                {
                    case "1":
                        cafeteria.NuevoPedido(gestorPedidos);
                        break;
                    case "2":
                        gestorPedidos.MostrarPedidos();
                        break;
                    case "3":
                        gestorPedidos.EliminarPedido();
                        break;
                    case "4":
                        Console.WriteLine("Ingrese el número del pedido a aplicar el descuento:");
                        int numPedido = Convert.ToInt32(Console.ReadLine()) - 1;
                        gestorPedidos.Descuento(pedido =>
                        {
                            Console.WriteLine($"Aplicando un 10% de descuento al pedido con {pedido.Productos.Count} productos.");
                        }, numPedido);
                        break;
                    case "5":
                        gestorPedidos.SerializarPedidos(rutaArchivo);
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, selecciona una opción válida.");
                        break;
                }

                Console.WriteLine("Presiona Enter para continuar...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
