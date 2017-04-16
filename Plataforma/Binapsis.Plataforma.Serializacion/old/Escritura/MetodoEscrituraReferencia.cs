using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal class MetodoEscrituraReferencia : MetodoEscrituraObjetoDatos
    {

		int _propietarioid;
		IPropiedad _propiedad;

        public MetodoEscrituraReferencia(IModeloEscritura modelo, IEscritor escritor, IObjetoDatos od, int refid, int propietarioid, IPropiedad propiedad) 
            : base(modelo, escritor, od, refid)
        {
            _propietarioid = propietarioid;
            _propiedad = propiedad;
            _metodo = Metodo.Referencia;
        }

        protected override void EscribirMetodo()
        {
            base.EscribirMetodo();
            _escritor.EscribirMetodoPropietario(_propietarioid);
            _escritor.EscribirMetodoPropiedad(_propiedad.Indice);
        }
    }

}