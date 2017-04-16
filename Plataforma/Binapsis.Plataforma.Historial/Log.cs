using Binapsis.Plataforma.Historial.Interno;

namespace Binapsis.Plataforma.Historial
{
    public class Log
    {
        HistorialObjetoDatos _historial;

        public Log()
        {
            _historial = new HistorialObjetoDatos();
        }

        public Instantanea CrearInstantanea() => _historial.CrearInstantanea();

        public void Recuperar(Instantanea instantanea) => _historial.Recuperar(instantanea);

        public void Deshacer() => _historial.Deshacer();

        internal HistorialObjetoDatos Historial { get { return _historial; } }

    }
}
