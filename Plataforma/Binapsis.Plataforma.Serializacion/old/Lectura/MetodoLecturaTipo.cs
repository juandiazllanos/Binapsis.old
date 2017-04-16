namespace Binapsis.Plataforma.Serializacion.Lectura
{
	internal class MetodoLecturaTipo : MetodoLectura
    {
        int _refid;
        string _uri;
		string _nombre;

        public MetodoLecturaTipo(IModeloLectura modelo, ILector lector) 
            : base(modelo, lector)
        {
        }

        public override void Leer()
        {
            LeerMetodo();
            InstanciarObjetoDatos();
        }

        private void LeerMetodo()
        {
            _refid = _lector.LeerMetodoIdentidad();
            _uri = _lector.LeerMetodoUri();
            _nombre = _lector.LeerMetodoTipo();
        }

        private void InstanciarObjetoDatos()
        {
            _modelo.Instanciar(_refid, _uri, _nombre);
        }
    }

}