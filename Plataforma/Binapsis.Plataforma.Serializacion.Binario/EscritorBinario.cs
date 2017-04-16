using System;
using System.IO;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Serializacion.Impl;

namespace Binapsis.Plataforma.Serializacion.Binario
{
    public class EscritorBinario : EscritorBase
    {
        BinaryWriter _writer;

        public EscritorBinario()
        {

        }

        public EscritorBinario(BinaryWriter writer)
        {
            _writer = writer;
        }
        
        protected override void EstablecerStream(Stream stream)
        {
            base.EstablecerStream(stream);

            if (_writer == null)
                _writer = new BinaryWriter(stream);
        }

        public override void Escribir(INodoObjeto objeto)
        {
            // escribir objeto
            base.Escribir(objeto);
            // escribir cierre
            _writer.Write((short)-1);
        }

        public override void EscribirId(int id)
        {
            _writer.Write(id);
            System.Diagnostics.Debug.WriteLine(string.Format("id={0}", id));
        }

        void EscribirPropiedad(IPropiedad propiedad)
        {
            _writer.Write((short)propiedad.Indice);
            System.Diagnostics.Debug.WriteLine(string.Format("propiedad={0}", propiedad.Indice));
        }

        public override void EscribirBoolean(IPropiedad propiedad, bool valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirByte(IPropiedad propiedad, byte valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirChar(IPropiedad propiedad, char valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirDateTime(IPropiedad propiedad, DateTime valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor.Ticks);
        }

        public override void EscribirDecimal(IPropiedad propiedad, decimal valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirDouble(IPropiedad propiedad, double valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirFloat(IPropiedad propiedad, float valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirInteger(IPropiedad propiedad, int valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirLong(IPropiedad propiedad, long valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirObject(IPropiedad propiedad, object valor)
        {
            
        }

        public override void EscribirObjetoDatos(IPropiedad propiedad, INodoObjeto valor)
        {
            EscribirPropiedad(propiedad);
            Escribir(valor);
        }

        public override void EscribirSByte(IPropiedad propiedad, sbyte valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirShort(IPropiedad propiedad, short valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirString(IPropiedad propiedad, string valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirUInteger(IPropiedad propiedad, uint valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirULong(IPropiedad propiedad, ulong valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }

        public override void EscribirUShort(IPropiedad propiedad, ushort valor)
        {
            EscribirPropiedad(propiedad);
            _writer.Write(valor);
        }
    }
}
