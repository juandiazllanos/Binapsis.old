using System;
using System.IO;
using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Serializacion.Binario
{
    public class EscritorBinario : IEscritor, IDisposable
    {
        private BinaryWriter _writer;
        private Stream _stream;

        public void Abrir(Stream stream)
        {
            _writer = new BinaryWriter(stream);
            _stream = stream;
        }

        public void Cerrar()
        {
            if (_writer != null)
            {
                _writer.Flush();
                _writer.Dispose();
                _writer = null;
            }

            if (_stream != null)
            {
                _stream.Dispose();
                _stream = null;
            }
        }

        public void EscribirMetodo(byte metodo)
        {
            _writer.Write(metodo);
        }

        public void EscribirMetodoIdentidad(int refid)
        {
            _writer.Write((ushort)refid);
        }

        public void EscribirMetodoLongitud(int longitud)
        {
            _writer.Write((sbyte)longitud);
        }

        public void EscribirMetodoPropietario(int propietario)
        {
            _writer.Write((ushort)propietario);
        }

        public void EscribirMetodoPropiedad(int propiedad)
        {
            _writer.Write((sbyte)propiedad);
        }

        public void EscribirMetodoUri(string uri)
        {
            _writer.Write(uri);
        }

        public void EscribirMetodoTipo(string nombre)
        {
            _writer.Write(nombre);
        }

        public void EscribirMetodoCierre()
        {

        }

        public void EscribirAtributoBoolean(IPropiedad propiedad, bool valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoByte(IPropiedad propiedad, byte valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoChar(IPropiedad propiedad, char valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoDateTime(IPropiedad propiedad, DateTime valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor.Ticks);
        }

        public void EscribirAtributoDecimal(IPropiedad propiedad, decimal valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoDouble(IPropiedad propiedad, double valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoFloat(IPropiedad propiedad, float valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoInteger(IPropiedad propiedad, int valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoLong(IPropiedad propiedad, long valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoObject(IPropiedad propiedad, object valor)
        {
            
        }

        public void EscribirAtributoSByte(IPropiedad propiedad, sbyte valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoShort(IPropiedad propiedad, short valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoString(IPropiedad propiedad, string valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoUInteger(IPropiedad propiedad, uint valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoULong(IPropiedad propiedad, ulong valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }

        public void EscribirAtributoUShort(IPropiedad propiedad, ushort valor)
        {
            _writer.Write(propiedad.Indice);
            _writer.Write(valor);
        }
                
        void IDisposable.Dispose()
        {
            Cerrar();
        }

        
    }
}
