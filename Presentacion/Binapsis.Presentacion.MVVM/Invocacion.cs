using Binapsis.Presentacion.MVVM.InvocacionEditor;
using Binapsis.Presentacion.MVVM.Observable;

namespace Binapsis.Presentacion.MVVM
{
    class Invocacion
    {
        public Invocacion(InvocacionTipo invocacionTipo)
        {
            InvocacionTipo = invocacionTipo;
        }

        public InvocacionTipo InvocacionTipo
        {
            get;
        }

        public ObservableInvocacion Observable
        {
            get => InvocacionTipo?.Observable;
        }
    }
}
