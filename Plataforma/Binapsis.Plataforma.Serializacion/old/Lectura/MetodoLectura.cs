namespace Binapsis.Plataforma.Serializacion.Lectura
{
	internal abstract class MetodoLectura : IMetodoLectura
    {
        protected IModeloLectura _modelo;
        protected ILector _lector;		

		public MetodoLectura(IModeloLectura modelo, ILector lector)
        {            
            _modelo = modelo;
            _lector = lector;
        }

        public abstract void Leer();

	}

}