using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Autor: Miguel Angel Arellano Juárez
 * Fecha: 07/05/2024
 * Versión: 1.0.0.2
 * Modificación: 08/05/2024
 */

namespace SaturnCoffee
{
    [Serializable]

    /// Clase que representa un pedido en la cafetería.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 07-05-2024
    /// Versión: 1.0.0.2
    /// Modificación:08-05-2024
    internal class CPedido
    {
        /// <summary>
        /// Lista de productos en el pedido.
        /// </summary>
        public List<string> Productos { get; private set; }


        /// Constructor de la clase CPedido.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación:08-05-2024
        /// <param >No posee argumentos</param>
        /// <returns> No regresa nada</returns>
        public CPedido()
        {
            Productos = new List<string>();
        }


        /// Agrega un producto al pedido.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.4
        /// Modificación: 08-05-2024
        /// <param name="producto">Nombre del producto a agregar.</param>
        /// <returns> No regresa nada</returns>
        public void AgregarProducto(string producto)
        {
            Productos.Add(producto);
        }
    }
}
