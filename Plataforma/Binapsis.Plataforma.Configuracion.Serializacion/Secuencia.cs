using Binapsis.Plataforma.Serializacion;
using System.IO;
using System.Text;
using System;

namespace Binapsis.Plataforma.Configuracion.Serializacion
{
    public class Secuencia : ISecuencia
    {
        Stream _stream;
        bool _cerrado;
        byte[] _contenido;

        public Secuencia()
            : this(new MemoryStream())
        {
        }

        public Secuencia(string contenido)
            : this(Encoding.UTF8.GetBytes(contenido))
        {
        }

        public Secuencia(byte[] contenido)
            : this(new MemoryStream(contenido))
        {
            _contenido = contenido;
        }

        public Secuencia(Stream stream)
        {
            _stream = stream;
        }

        public void Cerrar()
        {
            if (_cerrado) return;

            if (_contenido == null)
            {
                _contenido = new byte[Stream.Length];
                Stream.Position = 0;
                Stream.Read(_contenido, 0, _contenido.GetLength(0));
            }

            Stream?.Dispose();
            _cerrado = true;
        }

        public byte[] Contenido
        {
            get { return _contenido; }
        }

        public Stream Stream
        {
            get { return _stream; }
        }
    }
}
