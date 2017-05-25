using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.MVVM.Mapeo
{
    public class MapeoComando
    {
        MapeoTipo _mapeo;

        public MapeoComando(MapeoTipo mapeo, string nombre, IEditorComando invocador, IComando comando)
        {
            _mapeo = mapeo;
            Comando = comando;
            Invocador = invocador;
            Nombre = nombre;            
        }

        public IComando Comando { get; }
        public IEditorComando Invocador { get; }
        public string Nombre { get; }
    }
}
