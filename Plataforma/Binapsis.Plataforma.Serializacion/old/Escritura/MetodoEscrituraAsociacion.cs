using System;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal class MetodoEscrituraAsociacion : MetodoEscritura
    {
        
        private int _propietarioid;
		private IPropiedad _propiedad;
        private int _refid;

        public MetodoEscrituraAsociacion(IModeloEscritura modelo, IEscritor escritor, int propietarioid, IPropiedad propiedad, int refid) 
            : base(modelo, escritor)
        {
            _propietarioid = propietarioid;
            _propiedad = propiedad;
            _refid = refid;
            _metodo = Metodo.Asociacion;
        }

        public override void Escribir()
        {
            _escritor.EscribirMetodo((byte)_metodo);
            _escritor.EscribirMetodoIdentidad(_refid);
            _escritor.EscribirMetodoPropietario(_propietarioid);
            _escritor.EscribirMetodoPropiedad(_propiedad.Indice);

            _escritor.EscribirMetodoCierre();
        }

    }

}