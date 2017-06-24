using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Cambios
{
    public interface IDiagramaDatos
    {
        IObjetoDatos ObjetoDatos { get; set; }
        IResumenCambios ResumenCambios { get; set; }
        ITipo Tipo { get; }
    }
}
