using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Autor: Miguel Angel Arellano Juárez
 * Fecha: 07/05/2024
 * Versión: 1.0.0.0
 * Modificación: 07/05/2024
 */

namespace SaturnCoffee
{
    /// Interfaz para representar un pedido.
    /// Autor: Miguel Angel Arellano Juárez
    /// Fecha: 07-05-2024
    /// Versión: 1.0.0.0
    /// Modificación:07-05-2024
    internal interface IPedido
    {
        /// Agrega un producto al pedido.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.0
        /// Modificación: 07-05-2024
        /// <param name="producto">Nombre del producto a agregar.</param>
        /// <returns> No regresa nada</returns>
        void AgregarProducto(string producto);


        /// Elimina un producto del pedido.
        /// Autor: Miguel Angel Arellano Juárez
        /// Fecha: 07-05-2024
        /// Versión: 1.0.0.0
        /// Modificación: 08-05-2024
        /// <param name="producto">Nombre del producto a eliminar.</param>
        /// <returns> No regresa nada</returns>
        void EliminarProducto(string producto);
    }
}
