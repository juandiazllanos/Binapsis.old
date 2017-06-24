using System;
using System.IO;
using Binapsis.Plataforma.Cambios;
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


        public override void EscribirColeccion(int items)
        {
            EscribirItems(items);
        }

        public override void EscribirColeccionCierre()
        {
            
        }

        public override void EscribirDiagramaDatos()
        {
            
        }

        public override void EscribirDiagramaDatosCierre()
        {
            
        }

        public override void EscribirObjetoDatos(ITipo tipo, int id)
        {
            EscribirId(id);
        }

        public override void EscribirObjetoDatos(ITipo tipo, int id, string ruta, Cambio cambio)
        {
            EscribirObjetoDatos(tipo, id);
            EscribirRuta(ruta);
            EscribirCambio(cambio);
        }

        public override void EscribirObjetoDatos(IPropiedad propiedad, int id)
        {
            EscribirPropiedad(propiedad);
            EscribirId(id);
        }

        public override void EscribirObjetoDatos(IPropiedad propiedad, int id, string ruta, Cambio cambio)
        {
            EscribirObjetoDatos(propiedad, id);
            EscribirRuta(ruta);
            EscribirCambio(cambio);
        }

        public override void EscribirObjetoDatosCierre()
        {
            // escribir cierre
            _writer.Write((short)-1);
        }
        
        private void EscribirItems(int items)
        {
            _writer.Write(items);
        }

        private void EscribirId(int id)
        {
            _writer.Write(id);            
        }

        private void EscribirCambio(Cambio cambio)
        {
            _writer.Write((byte)cambio);
        }

        private void EscribirRuta(string ruta)
        {
            _writer.Write(ruta ?? string.Empty);
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
