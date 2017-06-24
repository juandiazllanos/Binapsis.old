using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Cambios.Analisis
{
    class AnalisisItemCambios : AnalisisObjetoCambios
    {        
        internal AnalisisItemCambios(ITipo tipo, AnalisisObjetoCambios propietario, int indice) 
            : base(tipo, propietario)
        {
            Indice = indice;
        }

        public int Indice
        {
            get;
        }

    }
}
