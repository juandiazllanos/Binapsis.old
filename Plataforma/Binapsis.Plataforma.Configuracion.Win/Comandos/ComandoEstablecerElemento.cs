using Binapsis.Presentacion.MVVM;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using System.Reflection;
using Binapsis.Presentacion.Editores;

namespace Binapsis.Plataforma.Configuracion.Win.Comandos
{
    class ComandoEstablecerElemento : IComando
    {
        ComandoSeleccionarElemento _comando;
                        
        public ComandoEstablecerElemento(string propiedad, IEditorAtributo editor, IContexto contexto)
        {
            _comando = new ComandoSeleccionarElemento() { Editor = editor, ElementoRoot = contexto.ElementoRoot };
            Repositorio = contexto.Repositorio;
            Propiedad = propiedad;            
        }

        public void Ejecutar(IObjetoDatos od)
        {
            if (Repositorio == null || string.IsNullOrEmpty(Propiedad)) return;

            PropertyInfo property = od.GetType().GetProperty(Propiedad);
            if (property == null) return;
                        
            _comando.Type = property.PropertyType;
            _comando.Ejecutar(od);

            IElemento elemento = _comando.ElementoSeleccionado;
            if (elemento == null) return;

            ObjetoBase valor = Repositorio.Obtener(elemento.Type, elemento.Valor);
            if (valor == null) return;

            property.SetValue(od, valor);
        }

        public string Propiedad
        {
            get;
            set;
        }

        public IRepositorio Repositorio
        {
            get;
            set;
        }
    }
}
