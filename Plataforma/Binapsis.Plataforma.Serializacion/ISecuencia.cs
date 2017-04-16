using System.IO;

namespace Binapsis.Plataforma.Serializacion
{
	public interface ISecuencia
    {
		/// <summary>
		/// Crea la secuencia que representa un Objeto de Datos.
		/// </summary>
		Stream Crear();
	}

}