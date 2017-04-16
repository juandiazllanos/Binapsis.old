using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Escritura
{
	internal class MetodoEscrituraTipo : MetodoEscritura
    {
        IObjetoDatos _od;
		ITipo _tipo;
        int _refid;
        IMetodoEscritura _metodoescritura;
        
        public MetodoEscrituraTipo(IModeloEscritura modelo, IEscritor escritor, IMetodoEscritura metodoEscritura, IObjetoDatos od, int refid) 
            : base(modelo, escritor)
        {
            _od = od;
            _tipo = od.Tipo;
            _refid = refid;
            _metodo = Metodo.Tipo;
            _metodoescritura = metodoEscritura;
        }

        public override void Escribir()
        {
            EscribirMetodo();
            EscribirObjetoDatos();
            EscribirMetodoCierre();
        }

        private void EscribirMetodo()
        {
            _escritor.EscribirMetodo((byte)_metodo);
            _escritor.EscribirMetodoIdentidad(_refid);
            _escritor.EscribirMetodoUri(_tipo.Uri);
            _escritor.EscribirMetodoTipo(_tipo.Nombre);
        }

        private void EscribirObjetoDatos()
        {
            _metodoescritura.Escribir();
            //_modelo.Crear(_od).Escribir();
        }

        private void EscribirMetodoCierre()
        {
            _escritor.EscribirMetodoCierre();
        }
    }

}