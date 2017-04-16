namespace Binapsis.Plataforma.Serializacion.Lectura
{
	internal class MetodoLecturaReferencia : MetodoLecturaObjetoDatos
    {
		int _propietario;
        int _propiedad;

        public MetodoLecturaReferencia(IModeloLectura modelo, ILector lector)
            : base(modelo, lector)
        {
        }

        protected override void LeerMetodo()
        {
            _refid = _lector.LeerMetodoIdentidad();
            _longitud = _lector.LeerMetodoLongitud();
            _propietario = _lector.LeerMetodoPropietario();
            _propiedad = _lector.LeerMetodoPropiedad();
        }

        protected override void LeerObjetoDatos()
        {
            IMetodoLectura metodo = _modelo.Crear(_refid, _longitud, _propietario, _propiedad);
            metodo.Leer();
        }

    }

}