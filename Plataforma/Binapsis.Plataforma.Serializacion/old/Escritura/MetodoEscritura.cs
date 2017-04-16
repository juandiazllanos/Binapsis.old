namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal abstract class MetodoEscritura : IMetodoEscritura
    {
        protected IModeloEscritura _modelo;
        protected IEscritor _escritor;
		protected Metodo _metodo;		

		public MetodoEscritura(IModeloEscritura modelo, IEscritor escritor)
        {
            _modelo = modelo;
            _escritor = escritor;
		}

        public abstract void Escribir();

	}

}