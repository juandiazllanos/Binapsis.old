using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Historial.Interno;

namespace Binapsis.Plataforma.Historial.Impl
{
	internal class HistorialImpl : ImplementacionBase
    {
		private HistorialObjetoDatos _historial;
		
        internal HistorialImpl(IImplementacion impl)
            : this(impl, new HistorialObjetoDatos())
        {            
            
		}
        
        internal HistorialImpl(IImplementacion impl, HistorialObjetoDatos historial)
            : base(impl)
        {
            _historial = historial;
        }
        
        public override IImplementacion Crear(ITipo tipo, IObjetoDatos propietario)
        {
            return new HistorialImpl(_impl.Crear(tipo, propietario), _historial);
        }
           
        public override void Eliminar()
        {
            throw new NotImplementedException();
        }

        public override void Establecer(IPropiedad propiedad, object valor)
        {
            Establecer(propiedad, valor, _impl.Obtener(propiedad));
        }

        public override void EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            EstablecerBoolean(propiedad, valor, _impl.ObtenerBoolean(propiedad));
        }

        public override void EstablecerByte(IPropiedad propiedad, byte valor)
        {
            EstablecerByte(propiedad, valor, _impl.ObtenerByte(propiedad));
        }

        public override void EstablecerChar(IPropiedad propiedad, char valor)
        {
            EstablecerChar(propiedad, valor, _impl.ObtenerChar(propiedad));
        }

        public override void EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            EstablecerDateTime(propiedad, valor, _impl.ObtenerDateTime(propiedad));
        }

        public override void EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            EstablecerDecimal(propiedad, valor, _impl.ObtenerDecimal(propiedad));
        }

        public override void EstablecerDouble(IPropiedad propiedad, double valor)
        {
            EstablecerDouble(propiedad, valor, _impl.ObtenerDouble(propiedad));
        }

        public override void EstablecerFloat(IPropiedad propiedad, float valor)
        {
            EstablecerFloat(propiedad, valor, _impl.ObtenerFloat(propiedad));
        }

        public override void EstablecerInteger(IPropiedad propiedad, int valor)
        {
            EstablecerInteger(propiedad, valor, _impl.ObtenerInteger(propiedad));
        }

        public override void EstablecerLong(IPropiedad propiedad, long valor)
        {
            EstablecerLong(propiedad, valor, _impl.ObtenerLong(propiedad));
        }
        
        public override void EstablecerObject(IPropiedad propiedad, object valor)
        {
            EstablecerObject(propiedad, valor, _impl.ObtenerObject(propiedad));
        }

        public override void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        {
            EstablecerObjetoDatos(propiedad, valor, _impl.ObtenerObjetoDatos(propiedad));
        }

        public override void EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            EstablecerSByte(propiedad, valor, _impl.ObtenerSByte(propiedad));
        }

        public override void EstablecerShort(IPropiedad propiedad, short valor)
        {
            EstablecerShort(propiedad, valor, _impl.ObtenerShort(propiedad));
        }

        public override void EstablecerString(IPropiedad propiedad, string valor)
        {
            EstablecerString(propiedad, valor, _impl.ObtenerString(propiedad));            
        }

        public override void EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            EstablecerUInteger(propiedad, valor, _impl.ObtenerUInteger(propiedad));            
        }

        public override void EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            EstablecerULong(propiedad, valor, _impl.ObtenerULong(propiedad));
        }

        public override void EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            EstablecerUShort(propiedad, valor, _impl.ObtenerUShort(propiedad));
        }
                
        public override void AgregarObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            _impl.AgregarObjetoDatos(propiedad, item);
            _historial.AgregarObjetoDatos(_impl, propiedad, item, _impl.ObtenerColeccion(propiedad).Indice(item));
        }

        public override void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            RemoverObjetoDatos(propiedad, item, _impl.ObtenerColeccion(propiedad).Indice(item));
        }


        private void Establecer(IPropiedad propiedad, object valor, object valorInicial)
        {
            _impl.Establecer(propiedad, valor);
            _historial.Establecer(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerBoolean(IPropiedad propiedad, bool valor, bool valorInicial)
        {
            _impl.EstablecerBoolean(propiedad, valor);
            _historial.EstablecerBoolean(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerByte(IPropiedad propiedad, byte valor, byte valorInicial)
        {
            _impl.EstablecerByte(propiedad, valor);
            _historial.EstablecerByte(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerChar(IPropiedad propiedad, char valor, char valorInicial)
        {
            _impl.EstablecerChar(propiedad, valor);
            _historial.EstablecerChar(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerDateTime(IPropiedad propiedad, DateTime valor, DateTime valorInicial)
        {
            _impl.EstablecerDateTime(propiedad, valor);
            _historial.EstablecerDateTime(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerDecimal(IPropiedad propiedad, decimal valor, decimal valorInicial)
        {
            _impl.EstablecerDecimal(propiedad, valor);
            _historial.EstablecerDecimal(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerDouble(IPropiedad propiedad, double valor, double valorInicial)
        {
            _impl.EstablecerDouble(propiedad, valor);
            _historial.EstablecerDouble(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerFloat(IPropiedad propiedad, float valor, float valorInicial)
        {
            _impl.EstablecerFloat(propiedad, valor);
            _historial.EstablecerFloat(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerInteger(IPropiedad propiedad, int valor, int valorInicial)
        {
            _impl.EstablecerInteger(propiedad, valor);
            _historial.EstablecerInteger(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerLong(IPropiedad propiedad, long valor, long valorInicial)
        {
            _impl.EstablecerLong(propiedad, valor);
            _historial.EstablecerLong(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerObject(IPropiedad propiedad, object valor, object valorInicial)
        {
            _impl.EstablecerObject(propiedad, valor);
            _historial.EstablecerObject(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor, IObjetoDatos valorInicial)
        {
            _impl.EstablecerObjetoDatos(propiedad, valor);
            _historial.EstablecerObjetoDatos(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerSByte(IPropiedad propiedad, sbyte valor, sbyte valorInicial)
        {
            _impl.EstablecerSByte(propiedad, valor);
            _historial.EstablecerSByte(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerShort(IPropiedad propiedad, short valor, short valorInicial)
        {
            _impl.EstablecerShort(propiedad, valor);
            _historial.EstablecerShort(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerString(IPropiedad propiedad, string valor, string valorInicial)
        {
            _impl.EstablecerString(propiedad, valor);
            _historial.EstablecerString(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerUInteger(IPropiedad propiedad, uint valor, uint valorInicial)
        {
            _impl.EstablecerUInteger(propiedad, valor);
            _historial.EstablecerUInteger(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerULong(IPropiedad propiedad, ulong valor, ulong valorInicial)
        {
            _impl.EstablecerULong(propiedad, valor);
            _historial.EstablecerULong(_impl, propiedad, valor, valorInicial);
        }

        private void EstablecerUShort(IPropiedad propiedad, ushort valor, ushort valorInicial)
        {
            _impl.EstablecerUShort(propiedad, valor);
            _historial.EstablecerUShort(_impl, propiedad, valor, valorInicial);
        }
        
        private void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item, int indice)
        {
            _impl.RemoverObjetoDatos(propiedad, item);
            _historial.RemoverObjetoDatos(_impl, propiedad, item, indice);
        }

        private int ResolverIndice(IPropiedad propiedad, IObjetoDatos item)
        {
            int indice = 0;

            if (propiedad.Cardinalidad >= Cardinalidad.CeroAMuchos)
            {
                indice = _impl.ObtenerColeccion(propiedad).Indice(item);
            }

            return indice;
        }
        
    }

}