using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Autor: Miguel Angel Arellano Juárez
 * Fecha: 07/05/2024
 * Versión: 1.0.0.1
 * Modificación: 10/05/2024
 */

namespace SaturnCoffee
{
    /// Clase que representa la cafetería.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 07-05-2024
    /// Versión: 1.0.0.1
    /// Modificación:10-05-2024
    internal class CCafeteria
    {
        private CGestorPedidos gestorPedidos = new CGestorPedidos();

        /// Crea un nuevo pedido y lo agrega al gestor de pedidos.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.1
        /// Modificación: 10-05-2024
        /// <param name="gestorPedidos">El gestor de pedidos donde se agregará el nuevo pedido.</param>
        /// <returns> No regresa nada</returns>
        public void NuevoPedido(CGestorPedidos gestorPedidos)
        {
            Console.WriteLine("Nuevo Pedido");

            CPedido pedido = new CPedido();

            Console.Write("Ingrese el nombre del producto: ");
            string producto = Console.ReadLine();
            pedido.AgregarProducto(producto);

            gestorPedidos.AgregarPedido(pedido);

            Console.WriteLine("Pedido agregado exitosamente.");
        }
    }
}
