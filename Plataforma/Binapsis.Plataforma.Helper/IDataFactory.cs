using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Helper
{
    public interface IDataFactory
    {
        IObjetoDatos Create(Type type);
        IObjetoDatos Create(ITipo tipo);
        IObjetoDatos Create(string uri, string tipo);
    }
}