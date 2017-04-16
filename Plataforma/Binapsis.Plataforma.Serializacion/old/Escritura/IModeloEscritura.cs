using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal interface IModeloEscritura
    {
        /// <summary>
        /// Crea un método de escritura de un Objeto de datos.
        /// </summary>
		IMetodoEscritura Crear(IObjetoDatos od);

        /// <summary>
        /// Crea un método de escritura de una referencia de un Objeto de datos; o un método de escritura de una asociación de una referencia de un Objeto de datos.
        /// </summary>
        IMetodoEscritura Crear(IObjetoDatos propietario, IPropiedad propiedad);

        /// <summary>
        /// Crea un método de escritura de un item de un Objeto de datos; o un método de escritura de una asociación de una referencia de un Objeto de datos.
        /// </summary>
        IMetodoEscritura Crear(IObjetoDatos propietario, IPropiedad propiedad, int indice);
    }

}