using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Notificaciones.Impl
{
    internal class ImplementacionNotificacion : ImplementacionBase
    {
        Observable _observable;
        
        public ImplementacionNotificacion(IImplementacion impl) 
            : base(impl)
        {            
            _observable = new Observable();
        }
        
        public override IImplementacion Crear(ITipo tipo, IObjetoDatos propietario)
        {            
            return new ImplementacionNotificacion(_impl.Crear(tipo, propietario));
        }

        public Observable Observable
        {
            get { return _observable; }
        }

        public override void AgregarObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {            
            base.AgregarObjetoDatos(propiedad, item);            
            _observable.NotificarAgregar(propiedad, item, _impl.ObtenerColeccion(propiedad).Indice(item));
        }

        public override void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            int indice = _impl.ObtenerColeccion(propiedad).Indice(item);
            base.RemoverObjetoDatos(propiedad, item);
            _observable.NotificarRemover(propiedad, item, indice);
        }
        
        public override void Establecer(IPropiedad propiedad, object valor)
        {
            base.Establecer(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            base.EstablecerBoolean(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerByte(IPropiedad propiedad, byte valor)
        {
            base.EstablecerByte(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerChar(IPropiedad propiedad, char valor)
        {
            base.EstablecerChar(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            base.EstablecerDateTime(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            base.EstablecerDecimal(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerDouble(IPropiedad propiedad, double valor)
        {
            base.EstablecerDouble(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerFloat(IPropiedad propiedad, float valor)
        {
            base.EstablecerFloat(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerInteger(IPropiedad propiedad, int valor)
        {
            base.EstablecerInteger(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerLong(IPropiedad propiedad, long valor)
        {
            base.EstablecerLong(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerObject(IPropiedad propiedad, object valor)
        {
            base.EstablecerObject(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        {
            base.EstablecerObjetoDatos(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            base.EstablecerSByte(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerShort(IPropiedad propiedad, short valor)
        {
            base.EstablecerShort(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerString(IPropiedad propiedad, string valor)
        {
            base.EstablecerString(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            base.EstablecerUInteger(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            base.EstablecerULong(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            base.EstablecerUShort(propiedad, valor);
            _observable.Notificar(propiedad);
        }

        public override void Eliminar()
        {
            base.Eliminar();
        }
    }
}
