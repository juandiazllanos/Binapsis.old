using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
	public interface ISecuencia
    {
		/// <summary>
		/// Obtiene la secuencia que representa un Objeto de Datos.
		/// </summary>		
        Stream Stream { get; }
        /// <summary>
		/// Cierrar la secuencia.
		/// </summary>		
        void Cerrar();
	}

}