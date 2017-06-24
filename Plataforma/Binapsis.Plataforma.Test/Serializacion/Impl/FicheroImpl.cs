using Binapsis.Plataforma.Serializacion;
using System.IO;
using System;

namespace Binapsis.Plataforma.Test.Serializacion.Impl
{
    internal class FicheroImpl : ISecuencia
    {
        string _ruta;
        bool _cerrado;

        public FicheroImpl(string ruta)
        {
            _ruta = ruta;
            Stream = Crear();
        }

        public void Cerrar()
        {
            if (_cerrado) return;
            Stream?.Dispose();
            _cerrado = true;
        }

        public Stream Crear()
        {
            return new FileStream(_ruta, FileMode.OpenOrCreate, FileAccess.ReadWrite);            
        }

        public string Ruta
        {
            get => _ruta;
        }

        public Stream Stream
        {
            get;
        }


    }
}
