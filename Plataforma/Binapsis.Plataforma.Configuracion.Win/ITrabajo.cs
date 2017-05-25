using System;

namespace Binapsis.Plataforma.Configuracion.Win
{
    interface ITrabajo
    {
        IActividad CrearSiguiente(IActividad actividad);
        Type Type { get; set; }
    }
}
