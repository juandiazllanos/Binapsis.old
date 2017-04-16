using System;
using helper = Binapsis.Plataforma.Estructura.Helpers.PathHelper;

namespace Binapsis.Plataforma.Estructura.Impl
{
    public abstract class ObjetoBase : IObjetoDatos
    {        
        private IImplementacion _impl;
        
        protected ObjetoBase(IImplementacion impl)
        {
            _impl = impl;
		}

        protected internal IImplementacion Impl
        {
            get { return _impl; }
        }

        protected ITipo Tipo
        {
            get
            {
                return _impl.Tipo;
            }
        }
        
        protected IObjetoDatos Propietario
        {
            get
            {
                return _impl.Propietario;
            }
        }


        protected IObjetoDatos CrearObjetoDatos(IPropiedad propiedad)
        {
            IObjetoDatos od = Fabrica.Instancia.Crear(_impl.Crear(propiedad.Tipo, this)); //FabricaObjetoDatos.Crear(_impl.Crear(propiedad.Tipo, this));  //_impl.CrearObjetoDatos(propiedad, this);

            if (propiedad.Cardinalidad >= Cardinalidad.Muchos)
                _impl.AgregarObjetoDatos(propiedad, od);
            else
                _impl.EstablecerObjetoDatos(propiedad, od);

            return od;
        }

        protected IObjetoDatos CrearObjetoDatos(int indice)
        {
            return CrearObjetoDatos(Tipo.ObtenerPropiedad(indice));
        }

        protected IObjetoDatos CrearObjetoDatos(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.CrearObjetoDatos(this, ruta);
            else
                return CrearObjetoDatos(Tipo[ruta]);
        }
        
        protected void Eliminar()
        {
            _impl.Eliminar();
        }

        protected bool Establecido(IPropiedad propiedad)
        {
            return _impl.Establecido(propiedad);
        }

        protected bool Establecido(int indice)
        {
            return Establecido(Tipo[indice]);
        }

        protected bool Establecido(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.Establecido(this, ruta);
            else
                return Establecido(Tipo[ruta]); 
        }

        protected void Establecer(IPropiedad propiedad, object valor)
        {
            _impl.Establecer(propiedad, valor);
        }

        protected void Establecer(int indice, object valor)
        {
            _impl.Establecer(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void Establecer(string ruta, object valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.Establecer(this, ruta, valor);
            else
                _impl.Establecer(Tipo.ObtenerPropiedad(ruta), valor);
		}

        protected void EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            _impl.EstablecerBoolean(propiedad, valor);
        }

        protected void EstablecerBoolean(int indice, bool valor)
        {
            _impl.EstablecerBoolean(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerBoolean(string ruta, bool valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerBoolean(this, ruta, valor);
            else
                _impl.EstablecerBoolean(Tipo.ObtenerPropiedad(ruta), valor);
        }

        protected void EstablecerByte(IPropiedad propiedad, byte valor)
        {
            _impl.EstablecerByte(propiedad, valor);
        }

        protected void EstablecerByte(int indice, byte valor)
        {
            _impl.EstablecerByte(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerByte(string ruta, byte valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerByte(this, ruta, valor);
            else
                _impl.EstablecerByte(Tipo.ObtenerPropiedad(ruta), valor);
		}

        protected void EstablecerChar(IPropiedad propiedad, char valor)
        {
            _impl.EstablecerChar(propiedad, valor);
        }

        protected void EstablecerChar(int indice, char valor)
        {
            _impl.EstablecerChar(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerChar(string ruta, char valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerChar(this, ruta, valor);
            else
                _impl.EstablecerChar(Tipo.ObtenerPropiedad(ruta), valor);            
        }

        protected void EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            _impl.EstablecerDateTime(propiedad, valor);
        }

        protected void EstablecerDateTime(int indice, DateTime valor)
        {
            _impl.EstablecerDateTime(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerDateTime(string ruta, DateTime valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerDateTime(this, ruta, valor);
            else
                _impl.EstablecerDateTime(Tipo.ObtenerPropiedad(ruta), valor);
        }

        protected void EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            _impl.EstablecerDecimal(propiedad, valor);
        }

        protected void EstablecerDecimal(int indice, decimal valor)
        {
            _impl.EstablecerDecimal(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerDecimal(string ruta, decimal valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerDecimal(this, ruta, valor);
            else
                _impl.EstablecerDecimal(Tipo.ObtenerPropiedad(ruta), valor);
        }

        protected void EstablecerDouble(IPropiedad propiedad, double valor)
        {
            _impl.EstablecerDouble(propiedad, valor);
        }

        protected void EstablecerDouble(int indice, double valor)
        {
            _impl.EstablecerDouble(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerDouble(string ruta, double valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerDouble(this, ruta, valor);
            else
                _impl.EstablecerDouble(Tipo.ObtenerPropiedad(ruta), valor);
        }

        protected void EstablecerFloat(IPropiedad propiedad, float valor)
        {
            _impl.EstablecerFloat(propiedad, valor);
        }

        protected void EstablecerFloat(int indice, float valor)
        {
            _impl.EstablecerFloat(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerFloat(string ruta, float valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerFloat(this, ruta, valor);
            else
                _impl.EstablecerFloat(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerInteger(IPropiedad propiedad, int valor)
        {
            _impl.EstablecerInteger(propiedad, valor);
        }

        protected void EstablecerInteger(int indice, int valor)
        {
            _impl.EstablecerInteger(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerInteger(string ruta, int valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerInteger(this, ruta, valor);
            else
                _impl.EstablecerInteger(Tipo.ObtenerPropiedad(ruta), valor); 
        }
        
        protected void EstablecerLong(IPropiedad propiedad, long valor)
        {
            _impl.EstablecerLong(propiedad, valor);
        }

        protected void EstablecerLong(int indice, long valor)
        {
            _impl.EstablecerLong(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerLong(string ruta, long valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerLong(this, ruta, valor);
            else
                _impl.EstablecerLong(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerObject(IPropiedad propiedad, object valor)
        {
            _impl.EstablecerObject(propiedad, valor);
        }

        protected void EstablecerObject(int indice, object valor)
        {
            _impl.EstablecerObject(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerObject(string ruta, object valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerObject(this, ruta, valor);
            else
                _impl.EstablecerObject(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        {
            _impl.EstablecerObjetoDatos(propiedad, valor);
        }

        protected void EstablecerObjetoDatos(int indice, IObjetoDatos valor)
        {
            _impl.EstablecerObjetoDatos(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerObjetoDatos(string ruta, IObjetoDatos valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerObjetoDatos(this, ruta, valor);
            else
                _impl.EstablecerObjetoDatos(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            _impl.EstablecerSByte(propiedad, valor);
        }

        protected void EstablecerSByte(int indice, sbyte valor)
        {
            _impl.EstablecerSByte(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerSByte(string ruta, sbyte valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerSByte(this, ruta, valor);
            else
                _impl.EstablecerSByte(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerShort(IPropiedad propiedad, short valor)
        {
            _impl.EstablecerShort(propiedad, valor);
        }

        protected void EstablecerShort(int indice, short valor)
        {
            _impl.EstablecerShort(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerShort(string ruta, short valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerShort(this, ruta, valor);
            else
                _impl.EstablecerShort(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerString(IPropiedad propiedad, string valor)
        {
            _impl.EstablecerString(propiedad, valor);
        }

        protected void EstablecerString(int indice, string valor)
        {
            _impl.EstablecerString(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerString(string ruta, string valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerString(this, ruta, valor);
            else
                _impl.EstablecerString(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            _impl.EstablecerUInteger(propiedad, valor);
        }

        protected void EstablecerUInteger(int indice, uint valor)
        {
            _impl.EstablecerUInteger(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerUInteger(string ruta, uint valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerUInteger(this, ruta, valor);
            else
                _impl.EstablecerUInteger(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            _impl.EstablecerULong(propiedad, valor);
        }

        protected void EstablecerULong(int indice, ulong valor)
        {
            _impl.EstablecerULong(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerULong(string ruta, ulong valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerULong(this, ruta, valor);
            else
                _impl.EstablecerULong(Tipo.ObtenerPropiedad(ruta), valor); 
        }

        protected void EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            _impl.EstablecerUShort(propiedad, valor);
        }

        protected void EstablecerUShort(int indice, ushort valor)
        {
            _impl.EstablecerUShort(Tipo.ObtenerPropiedad(indice), valor);
        }

        protected void EstablecerUShort(string ruta, ushort valor)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.EstablecerUShort(this, ruta, valor);
            else
                _impl.EstablecerUShort(Tipo[ruta], valor); 
        }

        protected object Obtener(IPropiedad propiedad)
        {
            return _impl.Obtener(propiedad);
        }

        protected object Obtener(int indice)
        {
            return _impl.Obtener(Tipo[indice]);
        }

        protected object Obtener(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.Obtener(this, ruta);
            else
                return _impl.Obtener(Tipo[ruta]); 
        }

        protected bool ObtenerBoolean(IPropiedad propiedad)
        {
            return _impl.ObtenerBoolean(propiedad);
        }

        protected bool ObtenerBoolean(int indice)
        {
            return _impl.ObtenerBoolean(Tipo[indice]); ;
        }

        protected bool ObtenerBoolean(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerBoolean(this, ruta);
            else
                return _impl.ObtenerBoolean(Tipo[ruta]); 
        }

        protected byte ObtenerByte(IPropiedad propiedad)
        {
            return _impl.ObtenerByte(propiedad); 
        }

        protected byte ObtenerByte(int indice)
        {
            return _impl.ObtenerByte(Tipo[indice]); 
        }

        protected byte ObtenerByte(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerByte(this, ruta);
            else
                return _impl.ObtenerByte(Tipo[ruta]); 
        }

        protected char ObtenerChar(IPropiedad propiedad)
        {
            return _impl.ObtenerChar(propiedad);
        }

        protected char ObtenerChar(int indice)
        {
            return _impl.ObtenerChar(Tipo[indice]);
        }

        protected char ObtenerChar(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerChar(this, ruta);
            else
                return _impl.ObtenerChar(Tipo[ruta]); 
        }

        protected IColeccion ObtenerColeccion(IPropiedad propiedad)
        {
            return _impl.ObtenerColeccion(propiedad);
        }

        protected IColeccion ObtenerColeccion(int indice)
        {
            return _impl.ObtenerColeccion(Tipo[indice]);
        }

        protected IColeccion ObtenerColeccion(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerColeccion(this, ruta);
            else
                return _impl.ObtenerColeccion(Tipo[ruta]); 
        }

        protected DateTime ObtenerDateTime(IPropiedad propiedad)
        {
            return _impl.ObtenerDateTime(propiedad);
        }

        protected DateTime ObtenerDateTime(int indice)
        {
            return _impl.ObtenerDateTime(Tipo[indice]);
        }

        protected DateTime ObtenerDateTime(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerDateTime(this, ruta);
            else
                return _impl.ObtenerDateTime(Tipo[ruta]); 
        }

        protected decimal ObtenerDecimal(IPropiedad propiedad)
        {
            return _impl.ObtenerDecimal(propiedad);
        }

        protected decimal ObtenerDecimal(int indice)
        {
            return _impl.ObtenerDecimal(Tipo[indice]);
        }

        protected decimal ObtenerDecimal(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerDecimal(this, ruta);
            else
                return _impl.ObtenerDecimal(Tipo[ruta]); 
        }

        protected double ObtenerDouble(IPropiedad propiedad)
        {
            return _impl.ObtenerDouble(propiedad);
        }

        protected double ObtenerDouble(int indice)
        {
            return _impl.ObtenerDouble(Tipo[indice]);
        }

        protected double ObtenerDouble(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerDouble(this, ruta);
            else
                return _impl.ObtenerDouble(Tipo[ruta]); 
        }

        protected float ObtenerFloat(IPropiedad propiedad)
        {
            return _impl.ObtenerFloat(propiedad);
        }

        protected float ObtenerFloat(int indice)
        {
            return _impl.ObtenerFloat(Tipo[indice]);
        }

        protected float ObtenerFloat(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerFloat(this, ruta);
            else
                return _impl.ObtenerFloat(Tipo[ruta]); 
        }

        protected int ObtenerInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerInteger(propiedad);
        }

        protected int ObtenerInteger(int indice)
        {
            return _impl.ObtenerInteger(Tipo[indice]);
        }

        protected int ObtenerInteger(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerInteger(this, ruta);
            else
                return _impl.ObtenerInteger(Tipo[ruta]); 
        }

        protected long ObtenerLong(IPropiedad propiedad)
        {
            return _impl.ObtenerLong(propiedad);
        }

        protected long ObtenerLong(int indice)
        {
            return _impl.ObtenerLong(Tipo[indice]);
        }

        protected long ObtenerLong(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerLong(this, ruta);
            else
                return _impl.ObtenerLong(Tipo[ruta]); 
        }

        protected object ObtenerObject(IPropiedad propiedad)
        {
            return _impl.ObtenerObject(propiedad);
        }

        protected object ObtenerObject(int indice)
        {
            return _impl.ObtenerObject(Tipo[indice]);
        }

        protected object ObtenerObject(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerObject(this, ruta);
            else
                return _impl.ObtenerObject(Tipo[ruta]); 
        }

        protected IObjetoDatos ObtenerObjetoDatos(IPropiedad propiedad)
        {
            return _impl.ObtenerObjetoDatos(propiedad);
        }

        protected IObjetoDatos ObtenerObjetoDatos(int indice)
        {
            return _impl.ObtenerObjetoDatos(Tipo[indice]);
        }

        protected IObjetoDatos ObtenerObjetoDatos(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerObjetoDatos(this, ruta);
            else
                return _impl.ObtenerObjetoDatos(Tipo[ruta]); 
        }

        protected sbyte ObtenerSByte(IPropiedad propiedad)
        {
            return _impl.ObtenerSByte(propiedad);
        }

        protected sbyte ObtenerSByte(int indice)
        {
            return _impl.ObtenerSByte(Tipo[indice]);
        }

        protected sbyte ObtenerSByte(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerSByte(this, ruta);
            else
                return _impl.ObtenerSByte(Tipo[ruta]); 
        }

        protected short ObtenerShort(IPropiedad propiedad)
        {
            return _impl.ObtenerShort(propiedad);
        }

        protected short ObtenerShort(int indice)
        {
            return _impl.ObtenerShort(Tipo[indice]);
        }

        protected short ObtenerShort(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerShort(this, ruta);
            else
                return _impl.ObtenerShort(Tipo[ruta]); 
        }

        protected string ObtenerString(IPropiedad propiedad)
        {
            return _impl.ObtenerString(propiedad);
        }

        protected string ObtenerString(int indice)
        {
            return _impl.ObtenerString(Tipo[indice]);
        }

        protected string ObtenerString(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerString(this, ruta);
            else
                return _impl.ObtenerString(Tipo[ruta]); 
        }

        protected uint ObtenerUInteger(IPropiedad propiedad)
        {
            return _impl.ObtenerUInteger(propiedad);
        }

        protected uint ObtenerUInteger(int indice)
        {
            return _impl.ObtenerUInteger(Tipo[indice]);
        }

        protected uint ObtenerUInteger(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerUInteger(this, ruta);
            else
                return _impl.ObtenerUInteger(Tipo[ruta]); 
        }

        protected ulong ObtenerULong(IPropiedad propiedad)
        {
            return _impl.ObtenerULong(propiedad);
        }

        protected ulong ObtenerULong(int indice)
        {
            return _impl.ObtenerULong(Tipo[indice]);
        }

        protected ulong ObtenerULong(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerULong(this, ruta);
            else
                return _impl.ObtenerULong(Tipo[ruta]); 
        }

        protected ushort ObtenerUShort(IPropiedad propiedad)
        {
            return _impl.ObtenerUShort(propiedad);
        }

        protected ushort ObtenerUShort(int indice)
        {
            return _impl.ObtenerUShort(Tipo[indice]);
        }

        protected ushort ObtenerUShort(string ruta)
        {
            if (helper.ComprobarRuta(ref ruta))
                return helper.ObtenerUShort(this, ruta);
            else
                return _impl.ObtenerUShort(Tipo[ruta]); 
        }

        protected void RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            _impl.RemoverObjetoDatos(propiedad, item);
        }

        protected void RemoverObjetoDatos(int indice, IObjetoDatos item)
        {
            _impl.RemoverObjetoDatos(Tipo[indice], item);
        }

        protected void RemoverObjetoDatos(string ruta, IObjetoDatos item)
        {
            if (helper.ComprobarRuta(ref ruta))
                helper.RemoverObjetoDatos(this, ruta, item);
            else
                _impl.RemoverObjetoDatos(Tipo[ruta], item);
        }



        #region IObjetoDatos
        IObjetoDatos IObjetoDatos.Propietario
        {
            get
            {
                return Propietario;
            }
        }

        ITipo IObjetoDatos.Tipo
        {
            get
            {
                return Tipo;
            }
        }

        IObjetoDatos IObjetoDatos.CrearObjetoDatos(string ruta)
        {
            return CrearObjetoDatos(ruta);
        }

        IObjetoDatos IObjetoDatos.CrearObjetoDatos(IPropiedad propiedad)
        {
            return CrearObjetoDatos(propiedad);
        }

        IObjetoDatos IObjetoDatos.CrearObjetoDatos(int indice)
        {
            return CrearObjetoDatos(indice);
        }

        void IObjetoDatos.Eliminar()
        {
            Eliminar();
        }

        void IObjetoDatos.Establecer(string ruta, object valor)
        {
            Establecer(ruta, valor);
        }

        void IObjetoDatos.Establecer(IPropiedad propiedad, object valor)
        {
            Establecer(propiedad, valor);
        }

        void IObjetoDatos.Establecer(int indice, object valor)
        {
            Establecer(indice, valor);
        }

        void IObjetoDatos.EstablecerBoolean(string ruta, bool valor)
        {
            EstablecerBoolean(ruta, valor);
        }

        void IObjetoDatos.EstablecerBoolean(IPropiedad propiedad, bool valor)
        {
            EstablecerBoolean(propiedad, valor);
        }

        void IObjetoDatos.EstablecerBoolean(int indice, bool valor)
        {
            EstablecerBoolean(indice, valor);
        }

        void IObjetoDatos.EstablecerByte(string ruta, byte valor)
        {
            EstablecerByte(ruta, valor);
        }

        void IObjetoDatos.EstablecerByte(IPropiedad propiedad, byte valor)
        {
            EstablecerByte(propiedad, valor);
        }

        void IObjetoDatos.EstablecerByte(int indice, byte valor)
        {
            EstablecerByte(indice, valor);
        }

        void IObjetoDatos.EstablecerChar(string ruta, char valor)
        {
            EstablecerChar(ruta, valor);
        }

        void IObjetoDatos.EstablecerChar(IPropiedad propiedad, char valor)
        {
            EstablecerChar(propiedad, valor);
        }

        void IObjetoDatos.EstablecerChar(int indice, char valor)
        {
            EstablecerChar(indice, valor);
        }

        void IObjetoDatos.EstablecerDateTime(string ruta, DateTime valor)
        {
            EstablecerDateTime(ruta, valor);
        }

        void IObjetoDatos.EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        {
            EstablecerDateTime(propiedad, valor);
        }

        void IObjetoDatos.EstablecerDateTime(int indice, DateTime valor)
        {
            EstablecerDateTime(indice, valor);
        }

        void IObjetoDatos.EstablecerDecimal(string ruta, decimal valor)
        {
            EstablecerDecimal(ruta, valor);
        }

        void IObjetoDatos.EstablecerDecimal(IPropiedad propiedad, decimal valor)
        {
            EstablecerDecimal(propiedad, valor);
        }

        void IObjetoDatos.EstablecerDecimal(int indice, decimal valor)
        {
            EstablecerDecimal(indice, valor);
        }

        void IObjetoDatos.EstablecerDouble(string ruta, double valor)
        {
            EstablecerDouble(ruta, valor);
        }

        void IObjetoDatos.EstablecerDouble(IPropiedad propiedad, double valor)
        {
            EstablecerDouble(propiedad, valor);
        }

        void IObjetoDatos.EstablecerDouble(int indice, double valor)
        {
            EstablecerDouble(indice, valor);
        }

        void IObjetoDatos.EstablecerFloat(string ruta, float valor)
        {
            EstablecerFloat(ruta, valor);
        }

        void IObjetoDatos.EstablecerFloat(IPropiedad propiedad, float valor)
        {
            EstablecerFloat(propiedad, valor);
        }

        void IObjetoDatos.EstablecerFloat(int indice, float valor)
        {
            EstablecerFloat(indice, valor);
        }

        void IObjetoDatos.EstablecerInteger(string ruta, int valor)
        {
            EstablecerInteger(ruta, valor);
        }

        void IObjetoDatos.EstablecerInteger(IPropiedad propiedad, int valor)
        {
            EstablecerInteger(propiedad, valor);
        }

        void IObjetoDatos.EstablecerInteger(int indice, int valor)
        {
            EstablecerInteger(indice, valor);
        }

        void IObjetoDatos.EstablecerLong(string ruta, long valor)
        {
            EstablecerLong(ruta, valor);
        }

        void IObjetoDatos.EstablecerLong(IPropiedad propiedad, long valor)
        {
            EstablecerLong(propiedad, valor);
        }

        void IObjetoDatos.EstablecerLong(int indice, long valor)
        {
            EstablecerLong(indice, valor);
        }

        void IObjetoDatos.EstablecerObject(string ruta, object valor)
        {
            EstablecerObject(ruta, valor);
        }

        void IObjetoDatos.EstablecerObject(IPropiedad propiedad, object valor)
        {
            EstablecerObject(propiedad, valor);
        }

        void IObjetoDatos.EstablecerObject(int indice, object valor)
        {
            EstablecerObject(indice, valor);
        }

        void IObjetoDatos.EstablecerObjetoDatos(string ruta, IObjetoDatos valor)
        {
            EstablecerObjetoDatos(ruta, valor);
        }

        void IObjetoDatos.EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        {
            EstablecerObjetoDatos(propiedad, valor);
        }

        void IObjetoDatos.EstablecerObjetoDatos(int indice, IObjetoDatos valor)
        {
            EstablecerObjetoDatos(indice, valor);
        }

        void IObjetoDatos.EstablecerSByte(string ruta, sbyte valor)
        {
            EstablecerSByte(ruta, valor);
        }

        void IObjetoDatos.EstablecerSByte(IPropiedad propiedad, sbyte valor)
        {
            EstablecerSByte(propiedad, valor);
        }

        void IObjetoDatos.EstablecerSByte(int indice, sbyte valor)
        {
            EstablecerSByte(indice, valor);
        }

        void IObjetoDatos.EstablecerShort(string ruta, short valor)
        {
            EstablecerShort(ruta, valor);
        }

        void IObjetoDatos.EstablecerShort(IPropiedad propiedad, short valor)
        {
            EstablecerShort(propiedad, valor);
        }

        void IObjetoDatos.EstablecerShort(int indice, short valor)
        {
            EstablecerShort(indice, valor);
        }

        void IObjetoDatos.EstablecerString(string ruta, string valor)
        {
            EstablecerString(ruta, valor);
        }

        void IObjetoDatos.EstablecerString(IPropiedad propiedad, string valor)
        {
            EstablecerString(propiedad, valor);
        }

        void IObjetoDatos.EstablecerString(int indice, string valor)
        {
            EstablecerString(indice, valor);
        }

        void IObjetoDatos.EstablecerUInteger(string ruta, uint valor)
        {
            EstablecerUInteger(ruta, valor);
        }

        void IObjetoDatos.EstablecerUInteger(IPropiedad propiedad, uint valor)
        {
            EstablecerUInteger(propiedad, valor);
        }

        void IObjetoDatos.EstablecerUInteger(int indice, uint valor)
        {
            EstablecerUInteger(indice, valor);
        }

        void IObjetoDatos.EstablecerULong(string ruta, ulong valor)
        {
            EstablecerULong(ruta, valor);
        }

        void IObjetoDatos.EstablecerULong(IPropiedad propiedad, ulong valor)
        {
            EstablecerULong(propiedad, valor);
        }

        void IObjetoDatos.EstablecerULong(int indice, ulong valor)
        {
            EstablecerULong(indice, valor);
        }

        void IObjetoDatos.EstablecerUShort(string ruta, ushort valor)
        {
            EstablecerUShort(ruta, valor);
        }

        void IObjetoDatos.EstablecerUShort(IPropiedad propiedad, ushort valor)
        {
            EstablecerUShort(propiedad, valor);
        }

        void IObjetoDatos.EstablecerUShort(int indice, ushort valor)
        {
            EstablecerUShort(indice, valor);
        }

        bool IObjetoDatos.Establecido(string ruta)
        {
            return Establecido(ruta);
        }

        bool IObjetoDatos.Establecido(IPropiedad propiedad)
        {
            return Establecido(propiedad);
        }

        bool IObjetoDatos.Establecido(int indice)
        {
            return Establecido(indice);
        }

        object IObjetoDatos.Obtener(string ruta)
        {
            return Obtener(ruta);
        }

        object IObjetoDatos.Obtener(IPropiedad propiedad)
        {
            return Obtener(propiedad);
        }

        object IObjetoDatos.Obtener(int indice)
        {
            return Obtener(indice);
        }

        bool IObjetoDatos.ObtenerBoolean(string ruta)
        {
            return ObtenerBoolean(ruta);
        }

        bool IObjetoDatos.ObtenerBoolean(IPropiedad propiedad)
        {
            return ObtenerBoolean(propiedad);
        }

        bool IObjetoDatos.ObtenerBoolean(int indice)
        {
            return ObtenerBoolean(indice);
        }

        byte IObjetoDatos.ObtenerByte(string ruta)
        {
            return ObtenerByte(ruta);
        }

        byte IObjetoDatos.ObtenerByte(IPropiedad propiedad)
        {
            return ObtenerByte(propiedad);
        }

        byte IObjetoDatos.ObtenerByte(int indice)
        {
            return ObtenerByte(indice);
        }

        char IObjetoDatos.ObtenerChar(string ruta)
        {
            return ObtenerChar(ruta);
        }

        char IObjetoDatos.ObtenerChar(IPropiedad propiedad)
        {
            return ObtenerChar(propiedad);
        }

        char IObjetoDatos.ObtenerChar(int indice)
        {
            return ObtenerChar(indice);
        }

        IColeccion IObjetoDatos.ObtenerColeccion(string ruta)
        {
            return ObtenerColeccion(ruta);
        }

        IColeccion IObjetoDatos.ObtenerColeccion(IPropiedad propiedad)
        {
            return ObtenerColeccion(propiedad);
        }

        IColeccion IObjetoDatos.ObtenerColeccion(int indice)
        {
            return ObtenerColeccion(indice);
        }

        DateTime IObjetoDatos.ObtenerDateTime(string ruta)
        {
            return ObtenerDateTime(ruta);
        }

        DateTime IObjetoDatos.ObtenerDateTime(IPropiedad propiedad)
        {
            return ObtenerDateTime(propiedad);
        }

        DateTime IObjetoDatos.ObtenerDateTime(int indice)
        {
            return ObtenerDateTime(indice);
        }

        decimal IObjetoDatos.ObtenerDecimal(string ruta)
        {
            return ObtenerDecimal(ruta);
        }

        decimal IObjetoDatos.ObtenerDecimal(IPropiedad propiedad)
        {
            return ObtenerDecimal(propiedad);
        }

        decimal IObjetoDatos.ObtenerDecimal(int indice)
        {
            return ObtenerDecimal(indice);
        }

        double IObjetoDatos.ObtenerDouble(string ruta)
        {
            return ObtenerDouble(ruta);
        }

        double IObjetoDatos.ObtenerDouble(IPropiedad propiedad)
        {
            return ObtenerDouble(propiedad);
        }

        double IObjetoDatos.ObtenerDouble(int indice)
        {
            return ObtenerDouble(indice);
        }

        float IObjetoDatos.ObtenerFloat(string ruta)
        {
            return ObtenerFloat(ruta);
        }

        float IObjetoDatos.ObtenerFloat(IPropiedad propiedad)
        {
            return ObtenerFloat(propiedad);
        }

        float IObjetoDatos.ObtenerFloat(int indice)
        {
            return ObtenerFloat(indice);
        }

        int IObjetoDatos.ObtenerInteger(string ruta)
        {
            return ObtenerInteger(ruta);
        }

        int IObjetoDatos.ObtenerInteger(IPropiedad propiedad)
        {
            return ObtenerInteger(propiedad);
        }

        int IObjetoDatos.ObtenerInteger(int indice)
        {
            return ObtenerInteger(indice);
        }

        long IObjetoDatos.ObtenerLong(string ruta)
        {
            return ObtenerLong(ruta);
        }

        long IObjetoDatos.ObtenerLong(IPropiedad propiedad)
        {
            return ObtenerLong(propiedad);
        }

        long IObjetoDatos.ObtenerLong(int indice)
        {
            return ObtenerLong(indice);
        }

        object IObjetoDatos.ObtenerObject(string ruta)
        {
            return ObtenerObject(ruta);
        }

        object IObjetoDatos.ObtenerObject(IPropiedad propiedad)
        {
            return ObtenerObject(propiedad);
        }

        object IObjetoDatos.ObtenerObject(int indice)
        {
            return ObtenerObject(indice);
        }

        IObjetoDatos IObjetoDatos.ObtenerObjetoDatos(string ruta)
        {
            return ObtenerObjetoDatos(ruta);
        }

        IObjetoDatos IObjetoDatos.ObtenerObjetoDatos(IPropiedad propiedad)
        {
            return ObtenerObjetoDatos(propiedad);
        }

        IObjetoDatos IObjetoDatos.ObtenerObjetoDatos(int indice)
        {
            return ObtenerObjetoDatos(indice);
        }

        sbyte IObjetoDatos.ObtenerSByte(string ruta)
        {
            return ObtenerSByte(ruta);
        }

        sbyte IObjetoDatos.ObtenerSByte(IPropiedad propiedad)
        {
            return ObtenerSByte(propiedad);
        }

        sbyte IObjetoDatos.ObtenerSByte(int indice)
        {
            return ObtenerSByte(indice);
        }

        short IObjetoDatos.ObtenerShort(string ruta)
        {
            return ObtenerShort(ruta);
        }

        short IObjetoDatos.ObtenerShort(IPropiedad propiedad)
        {
            return ObtenerShort(propiedad);
        }

        short IObjetoDatos.ObtenerShort(int indice)
        {
            return ObtenerShort(indice);
        }

        string IObjetoDatos.ObtenerString(string ruta)
        {
            return ObtenerString(ruta);
        }

        string IObjetoDatos.ObtenerString(IPropiedad propiedad)
        {
            return ObtenerString(propiedad);
        }

        string IObjetoDatos.ObtenerString(int indice)
        {
            return ObtenerString(indice);
        }

        uint IObjetoDatos.ObtenerUInteger(string ruta)
        {
            return ObtenerUInteger(ruta);
        }

        uint IObjetoDatos.ObtenerUInteger(IPropiedad propiedad)
        {
            return ObtenerUInteger(propiedad);
        }

        uint IObjetoDatos.ObtenerUInteger(int indice)
        {
            return ObtenerUInteger(indice);
        }

        ulong IObjetoDatos.ObtenerULong(string ruta)
        {
            return ObtenerULong(ruta);
        }

        ulong IObjetoDatos.ObtenerULong(IPropiedad propiedad)
        {
            return ObtenerULong(propiedad);
        }

        ulong IObjetoDatos.ObtenerULong(int indice)
        {
            return ObtenerULong(indice);
        }

        ushort IObjetoDatos.ObtenerUShort(string ruta)
        {
            return ObtenerUShort(ruta);
        }

        ushort IObjetoDatos.ObtenerUShort(IPropiedad propiedad)
        {
            return ObtenerUShort(propiedad);
        }

        ushort IObjetoDatos.ObtenerUShort(int indice)
        {
            return ObtenerUShort(indice);
        }

        void IObjetoDatos.RemoverObjetoDatos(string nombre, IObjetoDatos item)
        {
            RemoverObjetoDatos(nombre, item);
        }

        void IObjetoDatos.RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        {
            RemoverObjetoDatos(propiedad, item);
        }

        void IObjetoDatos.RemoverObjetoDatos(int indice, IObjetoDatos item)
        {
            RemoverObjetoDatos(indice, item);
        }
        #endregion

    }
}