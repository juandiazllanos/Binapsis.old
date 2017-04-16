using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Lectura
{
	internal class LectorObjetoDatos : IMetodoLectura
    {
		ILector _lector;
		IObjetoDatos _od;
        int _longitud;

		public LectorObjetoDatos(ILector lector, IObjetoDatos od, int longitud)
        {
            _lector = lector;
            _od = od;
            _longitud = longitud;
		}
        
		public void Leer()
        {
            for(int i = 1; i <= _longitud; i++)
                Leer(_lector.Leer(_od.Tipo));
        }

        private void Leer(IPropiedad propiedad)
        {
            if (propiedad == null) return;
            LectorAtributo.Leer(_lector, _od, propiedad);
        }
	}
}