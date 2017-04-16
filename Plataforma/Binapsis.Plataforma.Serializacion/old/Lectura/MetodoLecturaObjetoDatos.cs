namespace Binapsis.Plataforma.Serializacion.Lectura
{
	internal class MetodoLecturaObjetoDatos : MetodoLectura
    {
        protected int _refid;
        protected int _longitud;		

        public MetodoLecturaObjetoDatos(IModeloLectura modelo, ILector lector)
            : base(modelo, lector)
        {
        }

        public override sealed void Leer()
        {
            LeerMetodo();
            LeerObjetoDatos();
        }

        protected virtual void LeerMetodo()
        {
            _refid = _lector.LeerMetodoIdentidad();
            _longitud = _lector.LeerMetodoLongitud();
        }

        protected virtual void LeerObjetoDatos()
        {
            IMetodoLectura metodo = _modelo.Crear(_refid, _longitud);
            metodo.Leer();
        }

    }

}