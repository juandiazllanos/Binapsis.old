using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Estructura.Colecciones;

namespace Binapsis.Plataforma.Historial
{
	public class DecoradorHistorial : IObjetoDatosImpl
    {
		private HistorialObjetoDatos _historial;
		private IObjetoDatosImpl _impl;

		public DecoradorHistorial(IObjetoDatosImpl impl)
            : this(impl, new HistorialObjetoDatos())
        {            
            
		}

        DecoradorHistorial(IObjetoDatosImpl impl, HistorialObjetoDatos historial)
        {
            _impl = impl;
            _historial = historial;
        }

        public ObjetoDatos Propietario
        {
            get
            {
                return _impl.Propietario;
            }
        }

        public ITipo Tipo
        {
            get
            {
                return _impl.Tipo;
            }
        }
        
        public IObjetoDatosImpl Crear(ITipo tipo)
        {
            return new DecoradorHistorial(_impl.Crear(tipo), _historial); 
        }

        public IObjetoDatosImpl Crear(ITipo tipo, ObjetoDatos propietario)
        {
            return new DecoradorHistorial(_impl.Crear(tipo, propietario), _historial);
        }
                
        public ObjetoDatos CrearObjetoDatos(IPropiedad propiedad, ObjetoDatos propietario)
        {
            ObjetoDatos od = _impl.CrearObjetoDatos(propiedad, propietario);
            _historial.CrearObjetoDatos(_impl, propiedad, od, ResolverIndice(propiedad, od)); 
            return od;
        }

        public void Eliminar()
        {
            throw new NotImplementedException();
        }

        public void Establecer(IPropiedad propiedad, object valor)
        {
            Establecer(propiedad, valor, _impl.Obtener(propiedad));
        }

        public void EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            EstablecerBoolean(propiedad, valor, _impl.ObtenerBoolean(propiedad));
        }

        public void EstablecerByte(IPropiedad propiedad, byte valor)
        {
            EstablecerByte(propiedad, valor, _impl.ObtenerByte(propiedad));
        }

        public void EstablecerChar(IPropiedad propiedad, char valor)
        {
            EstablecerChar(propiedad, valor, _impl.ObtenerChar(propiedad));
        }

        public void EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            EstablecerDateTime(propiedad, valor, _impl.ObtenerDateTime(propiedad));
        }

        public void EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            EstablecerDecimal(propiedad, valor, _impl.ObtenerDecimal(propiedad));
        }

        public void EstablecerDouble(IPropiedad propiedad, double valor)
        {
            EstablecerDouble(propiedad, valor, _impl.ObtenerDouble(propiedad));
        }

        public void EstablecerFloat(IPropiedad propiedad, float valor)
        {
            EstablecerFloat(propiedad, valor, _impl.ObtenerFloat(propiedad));
        }

        public void EstablecerInteger(IPropiedad propiedad, int valor)
        {
            EstablecerInteger(propiedad, valor, _impl.ObtenerInteger(propiedad));
        }

        public void EstablecerLong(IPropiedad propiedad, long valor)
        {
            EstablecerLong(propiedad, valor, _impl.ObtenerLong(propiedad));
        }
        
        public void EstablecerObject(IPropiedad propiedad, object valor)
        {
            EstablecerObject(propiedad, valor, _impl.ObtenerObject(propiedad));
        }

        public void EstablecerObjetoDatos(IPropiedad propiedad, ObjetoDatos valor)
        {
            EstablecerObjetoDatos(propiedad, valor, _impl.ObtenerObjetoDatos(propiedad));
        }

        public void EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            EstablecerSByte(propiedad, valor, _impl.ObtenerSByte(propiedad));
        }

        public void EstablecerShort(IPropiedad propiedad, short valor)
        {
            EstablecerShort(propiedad, valor, _impl.ObtenerShort(propiedad));
        }

        public void EstablecerString(IPropiedad propiedad, string valor)
        {
            EstablecerString(propiedad, valor, _impl.ObtenerString(propiedad));            
        }

        public void EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            EstablecerUInteger(propiedad, valor, _impl.ObtenerUInteger(propiedad));            
        }

        public void EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            EstablecerULong(propiedad, valor, _impl.ObtenerULong(propiedad));
        }

        public void EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            EstablecerUShort(propiedad, valor, _impl.ObtenerUShort(propiedad));
        }

        
        public object Obtener(IPropiedad propiedad)
        {
            return _impl.Obtener(propiedad);
        }

        public bool ObtenerBoolean(IPropiedad propiedad)
        {
            return _impl.ObtenerBoolean(propiedad); 
        }

        public byte ObtenerByte(IPropiedad propiedad)
        {
            return _impl.ObtenerByte(propiedad);
        }

        public char ObtenerChar(IPropiedad propiedad)
        {
            return _impl.ObtenerChar(propiedad);
        }

        public IColeccionSoloLectura ObtenerColeccion(IPropiedad propiedad)
        {
            return _impl.ObtenerColeccion(propiedad);
        }

        public DateTime ObtenerDateTime(IPropiedad propiedad)
        {
            return _impl.ObtenerDateTime(propiedad);
        }

        public decimal ObtenerDecimal(IPropiedad propiedad)
        {
            return _impl.ObtenerDecimal(propiedad);
        }

        public double ObtenerDouble(IPropiedad propiedad)
        {
            return _impl.ObtenerDouble(propiedad);
        }

        public float ObtenerFloat(IPropiedad propiedad)
        {
            return _impl.ObtenerFloat(propiedad);
        }

        public int ObtenerInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerInteger(propiedad);
        }

        public long ObtenerLong(IPropiedad propiedad)
        {
            return _impl.ObtenerLong(propiedad);
        }

        public object ObtenerObject(IPropiedad propiedad)
        {
            return _impl.ObtenerObject(propiedad);
        }

        public ObjetoDatos ObtenerObjetoDatos(IPropiedad propiedad)
        {
            return _impl.ObtenerObjetoDatos(propiedad);
        }

        public sbyte ObtenerSByte(IPropiedad propiedad)
        {
            return _impl.ObtenerSByte(propiedad);
        }

        public short ObtenerShort(IPropiedad propiedad)
        {
            return _impl.ObtenerShort(propiedad);
        }

        public string ObtenerString(IPropiedad propiedad)
        {
            return _impl.ObtenerString(propiedad);
        }

        public uint ObtenerUInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerUInteger(propiedad);
        }

        public ulong ObtenerULong(IPropiedad propiedad)
        {
            return _impl.ObtenerULong(propiedad);
        }

        public ushort ObtenerUShort(IPropiedad propiedad)
        {
            return _impl.ObtenerUShort(propiedad);
        }

        public void AgregarObjetoDatos(IPropiedad propiedad, ObjetoDatos item)
        {
            _impl.AgregarObjetoDatos(propiedad, item);
            _historial.AgregarObjetoDatos(_impl, propiedad, item, _impl.ObtenerColeccion(propiedad).Indice(item));
        }

        public void RemoverObjetoDatos(IPropiedad propiedad, ObjetoDatos item)
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

        private void EstablecerObjetoDatos(IPropiedad propiedad, ObjetoDatos valor, ObjetoDatos valorInicial)
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
        
        private void RemoverObjetoDatos(IPropiedad propiedad, ObjetoDatos item, int indice)
        {
            _impl.RemoverObjetoDatos(propiedad, item);
            _historial.RemoverObjetoDatos(_impl, propiedad, item, indice);
        }

        private int ResolverIndice(IPropiedad propiedad, ObjetoDatos item)
        {
            int indice = 0;

            if (propiedad.Cardinalidad >= Cardinalidad.Muchos)
            {
                indice = _impl.ObtenerColeccion(propiedad).Indice(item);
            }

            return indice;
        }

    }

}