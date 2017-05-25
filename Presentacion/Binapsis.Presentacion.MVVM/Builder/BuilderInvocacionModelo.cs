using Binapsis.Presentacion.MVVM.InvocacionEditor;

namespace Binapsis.Presentacion.MVVM.Builder
{
    class BuilderInvocacionModelo
    {
        public BuilderInvocacionModelo(InvocacionModelo invocacionModelo)
        {
            InvocacionModelo = invocacionModelo;
        }

        public void Construir(InvocacionTipo invocacionTipo)
        {
            InvocacionModelo.RemoverTodo();

            foreach (InvocacionComando item in invocacionTipo.Invocaciones)
                InvocacionModelo.Agregar(item.Nombre, item.Comando);
        }

        public InvocacionModelo InvocacionModelo
        {
            get;
        }
    }
}
