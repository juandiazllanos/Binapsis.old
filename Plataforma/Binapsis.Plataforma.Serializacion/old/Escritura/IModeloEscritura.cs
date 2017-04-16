using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal interface IModeloEscritura
    {
        /// <summary>
        /// Crea un m�todo de escritura de un Objeto de datos.
        /// </summary>
		IMetodoEscritura Crear(IObjetoDatos od);

        /// <summary>
        /// Crea un m�todo de escritura de una referencia de un Objeto de datos; o un m�todo de escritura de una asociaci�n de una referencia de un Objeto de datos.
        /// </summary>
        IMetodoEscritura Crear(IObjetoDatos propietario, IPropiedad propiedad);

        /// <summary>
        /// Crea un m�todo de escritura de un item de un Objeto de datos; o un m�todo de escritura de una asociaci�n de una referencia de un Objeto de datos.
        /// </summary>
        IMetodoEscritura Crear(IObjetoDatos propietario, IPropiedad propiedad, int indice);
    }

}