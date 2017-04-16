using System;

namespace Binapsis.Plataforma.Serializacion.Lectura
{
	internal class MetodoLecturaAsociacion : MetodoLectura, IMetodoAsociacion
    {
		int _refid;
		int _propietarioid;
		int _propiedad;

        public MetodoLecturaAsociacion(IModeloLectura modelo, ILector lector) 
            : base(modelo, lector)
        {

        }

        public override void Leer()
        {
            _refid = _lector.LeerMetodoIdentidad();
            _propietarioid = _lector.LeerMetodoPropietario();
            _propiedad = _lector.LeerMetodoPropiedad();

            _modelo.Agregar(this);
        }

        void IMetodoAsociacion.Resolver()
        {
            _modelo.Resolver(_refid, _propietarioid, _propiedad);
        }
    }

}