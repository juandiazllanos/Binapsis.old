using Binapsis.Presentacion.Editores;

namespace Binapsis.Presentacion.MVVM.InvocacionEditor
{
    class InvocacionComando
    {
        InvocacionTipo _invocacionTipo;

        public InvocacionComando(InvocacionTipo invocacionTipo, string nombre, IComando comando, IEditorComando invocador)
        {
            _invocacionTipo = invocacionTipo;

            Nombre = nombre;
            Comando = comando;
            Invocador = invocador;

            Invocador.Notificar += () => _invocacionTipo.Notificar(this);
        }
                
        public IComando Comando
        {
            get;
            private set;
        }

        public IEditorComando Invocador
        {
            get;
            private set;
        }

        public string Nombre
        {
            get;
        }
        
    }
}
