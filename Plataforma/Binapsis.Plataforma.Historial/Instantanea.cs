using Binapsis.Plataforma.Historial.Interno;

namespace Binapsis.Plataforma.Historial
{
    public class Instantanea
    {
        HistorialObjetoDatos _historial;
        int _id;

        internal Instantanea(HistorialObjetoDatos historial, int id)
        {
            _historial = historial;
            _id = id;
        }
        
        internal void Recuperar(HistorialObjetoDatos historial)
        {
            if (ReferenceEquals(historial, _historial))
            {
                historial?.Deshacer(_id);
            }            
            _historial = null;
        }
    }
}
