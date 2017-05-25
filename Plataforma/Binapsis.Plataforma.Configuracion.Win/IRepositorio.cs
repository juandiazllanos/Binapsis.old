using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Configuracion.Win
{
    public interface IRepositorio
    {
        void Establecer(ObjetoBase valor);
        void Establecer(ObjetoBase valor, string clave);
        void Eliminar(Type type, string clave);
        ObjetoBase Obtener(Type type, string clave);
        ObjetoBase Obtener(Type type, string clave, IFabricaImpl impl);

        string Url { get; set; }

        
    }
}