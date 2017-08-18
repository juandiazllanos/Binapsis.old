using Binapsis.Plataforma.Estructura;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Navegacion
{
    public class Clave : Elemento
    {
        public Clave(IObjetoDatos od)
        {
            ObjetoDatos = od;            
        }

        //public override string Nombre
        //{
        //    get => ObjetoDatos.ObtenerString("Nombre");
        //    //set => base.Nombre;
        //}

        public string Valor
        {
            get => ObjetoDatos.ObtenerString("Clave");
        }

        public IObjetoDatos ObjetoDatos
        {
            get;
        }

        //#region IObjetoDatos
        //IObjetoDatos IObjetoDatos.Propietario
        //{
        //    get => _od.Propietario;
        //}

        //ITipo IObjetoDatos.Tipo
        //{
        //    get => _od.Tipo;
        //}

        //void IObjetoDatos.AgregarObjetoDatos(string ruta, IObjetoDatos item)
        //{
        //    _od.AgregarObjetoDatos(ruta, item);
        //}

        //void IObjetoDatos.AgregarObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        //{
        //    _od.AgregarObjetoDatos(propiedad, item);
        //}

        //void IObjetoDatos.AgregarObjetoDatos(int indice, IObjetoDatos item)
        //{
        //    _od.AgregarObjetoDatos(indice, item);
        //}

        //IObjetoDatos IObjetoDatos.CrearObjetoDatos(string ruta)
        //{
        //    return _od.CrearObjetoDatos(ruta);
        //}

        //IObjetoDatos IObjetoDatos.CrearObjetoDatos(IPropiedad propiedad)
        //{
        //    return _od.CrearObjetoDatos(propiedad);
        //}

        //IObjetoDatos IObjetoDatos.CrearObjetoDatos(int indice)
        //{
        //    return _od.CrearObjetoDatos(indice);
        //}

        //void IObjetoDatos.Eliminar()
        //{
        //    _od.Eliminar();
        //}

        //void IObjetoDatos.Establecer(string ruta, object valor)
        //{
        //    _od.Establecer(ruta, valor);
        //}

        //void IObjetoDatos.Establecer(IPropiedad propiedad, object valor)
        //{
        //    _od.Establecer(propiedad, valor);
        //}

        //void IObjetoDatos.Establecer(int indice, object valor)
        //{
        //    _od.Establecer(indice, valor);
        //}

        //void IObjetoDatos.EstablecerBoolean(string ruta, bool valor)
        //{
        //    _od.EstablecerBoolean(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerBoolean(IPropiedad propiedad, bool valor)
        //{
        //    _od.EstablecerBoolean(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerBoolean(int indice, bool valor)
        //{
        //    _od.EstablecerBoolean(indice, valor);
        //}

        //void IObjetoDatos.EstablecerByte(string ruta, byte valor)
        //{
        //    _od.EstablecerByte(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerByte(IPropiedad propiedad, byte valor)
        //{
        //    _od.EstablecerByte(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerByte(int indice, byte valor)
        //{
        //    _od.EstablecerByte(indice, valor);
        //}

        //void IObjetoDatos.EstablecerChar(string ruta, char valor)
        //{
        //    _od.EstablecerChar(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerChar(IPropiedad propiedad, char valor)
        //{
        //    _od.EstablecerChar(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerChar(int indice, char valor)
        //{
        //    _od.EstablecerChar(indice, valor);
        //}

        //void IObjetoDatos.EstablecerDateTime(string ruta, DateTime valor)
        //{
        //    _od.EstablecerDateTime(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerDateTime(IPropiedad propiedad, DateTime valor)
        //{
        //    _od.EstablecerDateTime(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerDateTime(int indice, DateTime valor)
        //{
        //    _od.EstablecerDateTime(indice, valor);
        //}

        //void IObjetoDatos.EstablecerDecimal(string ruta, decimal valor)
        //{
        //    _od.EstablecerDecimal(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerDecimal(IPropiedad propiedad, decimal valor)
        //{
        //    _od.EstablecerDecimal(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerDecimal(int indice, decimal valor)
        //{
        //    _od.EstablecerDecimal(indice, valor);
        //}

        //void IObjetoDatos.EstablecerDouble(string ruta, double valor)
        //{
        //    _od.EstablecerDouble(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerDouble(IPropiedad propiedad, double valor)
        //{
        //    _od.EstablecerDouble(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerDouble(int indice, double valor)
        //{
        //    _od.EstablecerDouble(indice, valor);
        //}

        //void IObjetoDatos.EstablecerFloat(string ruta, float valor)
        //{
        //    _od.EstablecerFloat(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerFloat(IPropiedad propiedad, float valor)
        //{
        //    _od.EstablecerFloat(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerFloat(int indice, float valor)
        //{
        //    _od.EstablecerFloat(indice, valor);
        //}

        //void IObjetoDatos.EstablecerInteger(string ruta, int valor)
        //{
        //    _od.EstablecerInteger(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerInteger(IPropiedad propiedad, int valor)
        //{
        //    _od.EstablecerInteger(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerInteger(int indice, int valor)
        //{
        //    _od.EstablecerInteger(indice, valor);
        //}

        //void IObjetoDatos.EstablecerLong(string ruta, long valor)
        //{
        //    _od.EstablecerLong(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerLong(IPropiedad propiedad, long valor)
        //{
        //    _od.EstablecerLong(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerLong(int indice, long valor)
        //{
        //    _od.EstablecerLong(indice, valor);
        //}

        //void IObjetoDatos.EstablecerObject(string ruta, object valor)
        //{
        //    _od.EstablecerObject(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerObject(IPropiedad propiedad, object valor)
        //{
        //    _od.EstablecerObject(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerObject(int indice, object valor)
        //{
        //    _od.EstablecerObject(indice, valor);
        //}

        //void IObjetoDatos.EstablecerObjetoDatos(string ruta, IObjetoDatos valor)
        //{
        //    _od.EstablecerObjetoDatos(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerObjetoDatos(IPropiedad propiedad, IObjetoDatos valor)
        //{
        //    _od.EstablecerObjetoDatos(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerObjetoDatos(int indice, IObjetoDatos valor)
        //{
        //    _od.EstablecerObjetoDatos(indice, valor);
        //}

        //void IObjetoDatos.EstablecerSByte(string ruta, sbyte valor)
        //{
        //    _od.EstablecerSByte(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerSByte(IPropiedad propiedad, sbyte valor)
        //{
        //    _od.EstablecerSByte(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerSByte(int indice, sbyte valor)
        //{
        //    _od.EstablecerSByte(indice, valor);
        //}

        //void IObjetoDatos.EstablecerShort(string ruta, short valor)
        //{
        //    _od.EstablecerShort(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerShort(IPropiedad propiedad, short valor)
        //{
        //    _od.EstablecerShort(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerShort(int indice, short valor)
        //{
        //    _od.EstablecerShort(indice, valor);
        //}

        //void IObjetoDatos.EstablecerString(string ruta, string valor)
        //{
        //    _od.EstablecerString(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerString(IPropiedad propiedad, string valor)
        //{
        //    _od.EstablecerString(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerString(int indice, string valor)
        //{
        //    _od.EstablecerString(indice, valor);
        //}

        //void IObjetoDatos.EstablecerUInteger(string ruta, uint valor)
        //{
        //    _od.EstablecerUInteger(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerUInteger(IPropiedad propiedad, uint valor)
        //{
        //    _od.EstablecerUInteger(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerUInteger(int indice, uint valor)
        //{
        //    _od.EstablecerUInteger(indice, valor);
        //}

        //void IObjetoDatos.EstablecerULong(string ruta, ulong valor)
        //{
        //    _od.EstablecerULong(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerULong(IPropiedad propiedad, ulong valor)
        //{
        //    _od.EstablecerULong(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerULong(int indice, ulong valor)
        //{
        //    _od.EstablecerULong(indice, valor);
        //}

        //void IObjetoDatos.EstablecerUShort(string ruta, ushort valor)
        //{
        //    _od.EstablecerUShort(ruta, valor);
        //}

        //void IObjetoDatos.EstablecerUShort(IPropiedad propiedad, ushort valor)
        //{
        //    _od.EstablecerUShort(propiedad, valor);
        //}

        //void IObjetoDatos.EstablecerUShort(int indice, ushort valor)
        //{
        //    _od.EstablecerUShort(indice, valor);
        //}

        //bool IObjetoDatos.Establecido(string ruta)
        //{
        //    return _od.Establecido(ruta);
        //}

        //bool IObjetoDatos.Establecido(IPropiedad propiedad)
        //{
        //    return _od.Establecido(propiedad);
        //}

        //bool IObjetoDatos.Establecido(int indice)
        //{
        //    return _od.Establecido(indice);
        //}

        //object IObjetoDatos.Obtener(string ruta)
        //{
        //    return _od.Obtener(ruta);
        //}

        //object IObjetoDatos.Obtener(IPropiedad propiedad)
        //{
        //    return _od.Obtener(propiedad);
        //}

        //object IObjetoDatos.Obtener(int indice)
        //{
        //    return _od.Obtener(indice);
        //}

        //bool IObjetoDatos.ObtenerBoolean(string ruta)
        //{
        //    return _od.ObtenerBoolean(ruta);
        //}

        //bool IObjetoDatos.ObtenerBoolean(IPropiedad propiedad)
        //{
        //    return _od.ObtenerBoolean(propiedad);
        //}

        //bool IObjetoDatos.ObtenerBoolean(int indice)
        //{
        //    return _od.ObtenerBoolean(indice);
        //}

        //byte IObjetoDatos.ObtenerByte(string ruta)
        //{
        //    return _od.ObtenerByte(ruta);
        //}

        //byte IObjetoDatos.ObtenerByte(IPropiedad propiedad)
        //{
        //    return _od.ObtenerByte(propiedad);
        //}

        //byte IObjetoDatos.ObtenerByte(int indice)
        //{
        //    return _od.ObtenerByte(indice);
        //}

        //char IObjetoDatos.ObtenerChar(string ruta)
        //{
        //    return _od.ObtenerChar(ruta);
        //}

        //char IObjetoDatos.ObtenerChar(IPropiedad propiedad)
        //{
        //    return _od.ObtenerChar(propiedad);
        //}

        //char IObjetoDatos.ObtenerChar(int indice)
        //{
        //    return _od.ObtenerChar(indice);
        //}

        //IColeccion IObjetoDatos.ObtenerColeccion(string ruta)
        //{
        //    return _od.ObtenerColeccion(ruta);
        //}

        //IColeccion IObjetoDatos.ObtenerColeccion(IPropiedad propiedad)
        //{
        //    return _od.ObtenerColeccion(propiedad);
        //}

        //IColeccion IObjetoDatos.ObtenerColeccion(int indice)
        //{
        //    return _od.ObtenerColeccion(indice);
        //}

        //DateTime IObjetoDatos.ObtenerDateTime(string ruta)
        //{
        //    return _od.ObtenerDateTime(ruta);
        //}

        //DateTime IObjetoDatos.ObtenerDateTime(IPropiedad propiedad)
        //{
        //    return _od.ObtenerDateTime(propiedad);
        //}

        //DateTime IObjetoDatos.ObtenerDateTime(int indice)
        //{
        //    return _od.ObtenerDateTime(indice);
        //}

        //decimal IObjetoDatos.ObtenerDecimal(string ruta)
        //{
        //    return _od.ObtenerDecimal(ruta);
        //}

        //decimal IObjetoDatos.ObtenerDecimal(IPropiedad propiedad)
        //{
        //    return _od.ObtenerDecimal(propiedad);
        //}

        //decimal IObjetoDatos.ObtenerDecimal(int indice)
        //{
        //    return _od.ObtenerDecimal(indice);
        //}

        //double IObjetoDatos.ObtenerDouble(string ruta)
        //{
        //    return _od.ObtenerDouble(ruta);
        //}

        //double IObjetoDatos.ObtenerDouble(IPropiedad propiedad)
        //{
        //    return _od.ObtenerDouble(propiedad);
        //}

        //double IObjetoDatos.ObtenerDouble(int indice)
        //{
        //    return _od.ObtenerDouble(indice);
        //}

        //float IObjetoDatos.ObtenerFloat(string ruta)
        //{
        //    return _od.ObtenerFloat(ruta);
        //}

        //float IObjetoDatos.ObtenerFloat(IPropiedad propiedad)
        //{
        //    return _od.ObtenerFloat(propiedad);
        //}

        //float IObjetoDatos.ObtenerFloat(int indice)
        //{
        //    return _od.ObtenerFloat(indice);
        //}

        //int IObjetoDatos.ObtenerInteger(string ruta)
        //{
        //    return _od.ObtenerInteger(ruta);
        //}

        //int IObjetoDatos.ObtenerInteger(IPropiedad propiedad)
        //{
        //    return _od.ObtenerInteger(propiedad);
        //}

        //int IObjetoDatos.ObtenerInteger(int indice)
        //{
        //    return _od.ObtenerInteger(indice);
        //}

        //long IObjetoDatos.ObtenerLong(string ruta)
        //{
        //    return _od.ObtenerLong(ruta);
        //}

        //long IObjetoDatos.ObtenerLong(IPropiedad propiedad)
        //{
        //    return _od.ObtenerLong(propiedad);
        //}

        //long IObjetoDatos.ObtenerLong(int indice)
        //{
        //    return _od.ObtenerLong(indice);
        //}

        //object IObjetoDatos.ObtenerObject(string ruta)
        //{
        //    return _od.ObtenerObject(ruta);
        //}

        //object IObjetoDatos.ObtenerObject(IPropiedad propiedad)
        //{
        //    return _od.ObtenerObject(propiedad);
        //}

        //object IObjetoDatos.ObtenerObject(int indice)
        //{
        //    return _od.ObtenerObject(indice);
        //}

        //IObjetoDatos IObjetoDatos.ObtenerObjetoDatos(string ruta)
        //{
        //    return _od.ObtenerObjetoDatos(ruta);
        //}

        //IObjetoDatos IObjetoDatos.ObtenerObjetoDatos(IPropiedad propiedad)
        //{
        //    return _od.ObtenerObjetoDatos(propiedad);
        //}

        //IObjetoDatos IObjetoDatos.ObtenerObjetoDatos(int indice)
        //{
        //    return _od.ObtenerObjetoDatos(indice);
        //}

        //sbyte IObjetoDatos.ObtenerSByte(string ruta)
        //{
        //    return _od.ObtenerSByte(ruta);
        //}

        //sbyte IObjetoDatos.ObtenerSByte(IPropiedad propiedad)
        //{
        //    return _od.ObtenerSByte(propiedad);
        //}

        //sbyte IObjetoDatos.ObtenerSByte(int indice)
        //{
        //    return _od.ObtenerSByte(indice);
        //}

        //short IObjetoDatos.ObtenerShort(string ruta)
        //{
        //    return _od.ObtenerShort(ruta);
        //}

        //short IObjetoDatos.ObtenerShort(IPropiedad propiedad)
        //{
        //    return _od.ObtenerShort(propiedad);
        //}

        //short IObjetoDatos.ObtenerShort(int indice)
        //{
        //    return _od.ObtenerShort(indice);
        //}

        //string IObjetoDatos.ObtenerString(string ruta)
        //{
        //    return _od.ObtenerString(ruta);
        //}

        //string IObjetoDatos.ObtenerString(IPropiedad propiedad)
        //{
        //    return _od.ObtenerString(propiedad);
        //}

        //string IObjetoDatos.ObtenerString(int indice)
        //{
        //    return _od.ObtenerString(indice);
        //}

        //uint IObjetoDatos.ObtenerUInteger(string ruta)
        //{
        //    return _od.ObtenerUInteger(ruta);
        //}

        //uint IObjetoDatos.ObtenerUInteger(IPropiedad propiedad)
        //{
        //    return _od.ObtenerUInteger(propiedad);
        //}

        //uint IObjetoDatos.ObtenerUInteger(int indice)
        //{
        //    return _od.ObtenerUInteger(indice);
        //}

        //ulong IObjetoDatos.ObtenerULong(string ruta)
        //{
        //    return _od.ObtenerULong(ruta);
        //}

        //ulong IObjetoDatos.ObtenerULong(IPropiedad propiedad)
        //{
        //    return _od.ObtenerULong(propiedad);
        //}

        //ulong IObjetoDatos.ObtenerULong(int indice)
        //{
        //    return _od.ObtenerULong(indice);
        //}

        //ushort IObjetoDatos.ObtenerUShort(string ruta)
        //{
        //    return _od.ObtenerUShort(ruta);
        //}

        //ushort IObjetoDatos.ObtenerUShort(IPropiedad propiedad)
        //{
        //    return _od.ObtenerUShort(propiedad);
        //}

        //ushort IObjetoDatos.ObtenerUShort(int indice)
        //{
        //    return _od.ObtenerUShort(indice);
        //}

        //void IObjetoDatos.RemoverObjetoDatos(string nombre, IObjetoDatos item)
        //{
        //    _od.RemoverObjetoDatos(nombre, item);
        //}

        //void IObjetoDatos.RemoverObjetoDatos(IPropiedad propiedad, IObjetoDatos item)
        //{
        //    _od.RemoverObjetoDatos(propiedad, item);
        //}

        //void IObjetoDatos.RemoverObjetoDatos(int indice, IObjetoDatos item)
        //{
        //    _od.RemoverObjetoDatos(indice, item);
        //}
        //#endregion 
    }
}
