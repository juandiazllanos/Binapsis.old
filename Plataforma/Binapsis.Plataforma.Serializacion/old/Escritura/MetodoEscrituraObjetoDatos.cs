using Binapsis.Plataforma.Estructura;
using System.Linq;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal class MetodoEscrituraObjetoDatos : MetodoEscritura
    {
		protected int _longitud;
		protected int _refid;
        protected IObjetoDatos _od;
		protected IMetodoEscritura _escritorod;

        public MetodoEscrituraObjetoDatos(IModeloEscritura modelo, IEscritor escritor, IObjetoDatos od, int refid)
            : base(modelo, escritor)
        {
            EscritorObjetoDatos escritorod = new EscritorObjetoDatos(escritor, od);
            _longitud = escritorod.Longitud;
            _escritorod = escritorod;
            _refid = refid;
            _od = od;
            _metodo = Metodo.ObjetoDatos;
        }

        public override sealed void Escribir()
        {
            EscribirMetodo();
            EscribirObjetoDatos();
            EscribirMetodoCierre();
        }

        protected virtual void EscribirMetodo()
        {
            _escritor.EscribirMetodo((byte)_metodo);
            _escritor.EscribirMetodoIdentidad(_refid);
            _escritor.EscribirMetodoLongitud(_longitud);
        }
        
        private void EscribirMetodoCierre()
        {
            _escritor.EscribirMetodoCierre();
        }

        private void EscribirObjetoDatos()
        {
            _escritorod.Escribir();
            EscribirReferencias();
        }

        private void EscribirReferencias()
        {
            var referencias = from propiedad in _od.Tipo.Propiedades
                              where !propiedad.Tipo.EsTipoDeDato && _od.Establecido(propiedad)
                              select propiedad;

            foreach(IPropiedad referencia in referencias)
            {
                if (referencia.Cardinalidad >= Cardinalidad.Muchos)
                    EscribirColeccion(referencia);
                else
                    _modelo.Crear(_od, referencia).Escribir();
            }
        }
        
        private void EscribirColeccion(IPropiedad propiedad)
        {
            int longitud = _od.ObtenerColeccion(propiedad).Longitud;
            for(int i = 0; i <= (longitud - 1); i++)
            {
                _modelo.Crear(_od, propiedad, i).Escribir();
            }
        }
        
    }

}