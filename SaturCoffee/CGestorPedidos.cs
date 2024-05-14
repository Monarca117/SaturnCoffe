using SaturnCoffee;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

/*
 * Autor: Miguel Angel Arellano Juárez
 * Fecha: 07/05/2024
 * Versión: 1.0.0.4
 * Modificación: 13/05/2024
 */

namespace SaturnCoffee
{
    [Serializable]

    /// Clase que gestiona los pedidos en la cafetería.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 07-05-2024
    /// Versión: 1.0.0.4
    /// Modificación:13-05-2024
    internal class CGestorPedidos : IEnumerable<CPedido>
    {
        private List<CPedido> pedidos = new List<CPedido>();

        // Definición de delegado para descuento
        public delegate void DDesc(CPedido pedido);



        /// Método para aplicar un descuento 
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param name="operacion">Delegado que representa la operación a aplicar al pedido.</param>
        /// <param name="indicePedido">Índice del pedido al que se aplicará la operación.</param>
        /// <returns>No regresa nada.</returns>
        public void Descuento(DDesc operacion, int indicePedido)
        {
            // Verifica si el índice del pedido está dentro de los límites de la lista de pedidos
            if (indicePedido >= 0 && indicePedido < pedidos.Count)
            {
                // Obtiene el pedido correspondiente al índice proporcionado
                CPedido pedido = pedidos[indicePedido];

                // Aplica la operación proporcionada al pedido
                operacion(pedido);

                // Muestra un mensaje indicando que la operación se aplicó correctamente al pedido
                Console.WriteLine($"Operación aplicada al pedido #{indicePedido + 1}");
            }
            else
            {
                // Si el índice del pedido está fuera de los límites, muestra un mensaje de error
                Console.WriteLine("Índice de pedido inválido.");
            }
        }


        /// Método para aplicar una operación a todos los pedidos
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param name="pedido">Pedido a agregar.</param>
        /// <returns>No regresa nada.</returns>
        public void AgregarPedido(CPedido pedido)
        {
            pedidos.Add(pedido);
        }

        /// Muestra todos los pedidos almacenados en el gestor de pedidos.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param >No tiene argumentos</param>
        /// <returns>No regresa nada.</returns>
        public void MostrarPedidos()
        {
            Console.WriteLine("Todos los Pedidos");

            int contador = 1;
            foreach (var pedido in pedidos)
            {
                Console.WriteLine($"Pedido {contador}:");
                foreach (var producto in pedido.Productos)
                {
                    Console.WriteLine($"- {producto}");
                }
                Console.WriteLine();
                contador++;
            }
        }


        /// Elimina un pedido del gestor de pedidos.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param >No tiene argumentos</param>
        /// <returns>No regresa nada.</returns>
        public void EliminarPedido()
        {
            Console.WriteLine("Eliminar Pedido");

            Console.Write("Ingrese el número del pedido a eliminar: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out int numeroPedido))
            {
                if (numeroPedido >= 1 && numeroPedido <= pedidos.Count)
                {
                    pedidos.RemoveAt(numeroPedido - 1);
                    Console.WriteLine("Pedido eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Número de pedido fuera de rango.");
                }
            }
            else
            {
                Console.WriteLine("Por favor, ingrese un número válido.");
            }
        }


        /// Serializa la lista de pedidos en un archivo binario.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param name="rutaArchivo">Ruta del archivo donde se guardará la lista de pedidos.</param>
        /// <returns>No regresa nada.</returns>
        public void SerializarPedidos(string rutaArchivo)
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Create))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(fs, pedidos);
            }
        }


        /// Deserializa la lista de pedidos desde un archivo binario.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param name="rutaArchivo">Ruta del archivo desde donde se cargará la lista de pedidos.</param>
        /// <returns>No regresa nada.</returns>
        public void DeserializarPedidos(string rutaArchivo)
        {
            using (FileStream fs = new FileStream(rutaArchivo, FileMode.Open))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                pedidos = (List<CPedido>)formatter.Deserialize(fs);
            }
        }


        /// Devuelve un enumerador de tipo CPedido que permite recorrer la lista de pedidos en el gestor.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param name="rutaArchivo">Ruta del archivo desde donde se cargará la lista de pedidos.</param>
        /// <returns>No regresa nada.</returns>
        public IEnumerator<CPedido> GetEnumerator()
        {
            // Devuelve un enumerador de tipo CPedido que permite recorrer la lista de pedidos en el gestor.
            return pedidos.GetEnumerator();
        }


        /// Implementación explícita del método GetEnumerator() de la interfaz no genérica IEnumerable.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 13-05-2024
        /// <param>No tiene parametros</param>
        /// <returns>Enumerador obtenido del método GetEnumerator() anterior, permitiendo que la clase CGestorPedidos también sea enumerada como una interfaz IEnumerable.</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            // Implementación explícita del método GetEnumerator() de la interfaz no genérica IEnumerable.
            // Devuelve el enumerador obtenido del método GetEnumerator() anterior, permitiendo que la clase CGestorPedidos también sea enumerada como una interfaz IEnumerable.
            return GetEnumerator();
        }


    }
}
    