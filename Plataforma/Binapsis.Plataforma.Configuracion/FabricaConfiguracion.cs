using Binapsis.Plataforma.Estructura.Impl;
using System;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Configuracion.Base;

namespace Binapsis.Plataforma.Configuracion
{
    public class FabricaConfiguracion : FabricaBase<ObjetoBase>
    {
        public FabricaConfiguracion()
            : base()
        {
        }

        public FabricaConfiguracion(IFabricaImpl fabrica) 
            : base(fabrica)
        {
        }

        public static FabricaConfiguracion Instancia { get; } = new FabricaConfiguracion();
                
        public override ObjetoBase Crear(IImplementacion impl)
        {
            Type type = Type.GetType(string.Format("{0}.{1}", impl.Tipo.Uri, impl.Tipo.Nombre));
            object instancia = Activator.CreateInstance(type, impl);
            return (ObjetoBase)instancia;
        }

        public ObjetoBase Crear(Type type)
        {
            ITipo tipo = BaseTypes.Instancia.Obtener(type);
            if (tipo == null) tipo = Types.Instancia.Obtener(type);
            return Crear(tipo);
        }

        public Definicion CrearDefinicion()
        {
            return (Definicion)Crear(typeof(Definicion));
        }

        public Definicion CrearDefinicion(string nombre)
        {
            Definicion definicion = CrearDefinicion();
            definicion.Nombre = nombre;
            return definicion;
        }

        public Definicion CrearDefinicion(string nombre, string valor)
        {
            Definicion definicion = CrearDefinicion(nombre);
            definicion.Valor = valor;
            return definicion;
        }

        public Definicion CrearDefinicion(string nombre, string valor, string alias)
        {
            Definicion definicion = CrearDefinicion(nombre, valor);
            definicion.Alias = alias;
            return definicion;
        }

        public Ensamblado CrearEnsamblado()
        {
            return (Ensamblado)Crear(typeof(Ensamblado));
        }

        public Ensamblado CrearEnsamblado(string nombre)
        {
            Ensamblado instancia = CrearEnsamblado();
            instancia.Nombre = nombre;
            return instancia;
        }

        public Propiedad CrearPropiedad()
        {
            return (Propiedad)Crear(typeof(Propiedad));
        }

        public Propiedad CrearPropiedad(string nombre)
        {
            Propiedad propiedad = CrearPropiedad();
            propiedad.Nombre = nombre;
            return propiedad;
        }

        public Propiedad CrearPropiedad(string nombre, Tipo tipo)
        {
            Propiedad propiedad = CrearPropiedad(nombre);
            propiedad.TipoAsociado = tipo;
            return propiedad;
        }

        public Propiedad CrearPropiedad(string nombre, Tipo tipo, string alias)
        {
            Propiedad propiedad = CrearPropiedad(nombre, tipo);
            propiedad.Alias = alias;
            return propiedad;
        }

        public Tipo CrearTipo()
        {
            return (Tipo)Crear(typeof(Tipo));
        }

        public Tipo CrearTipo(Uri uri)
        {
            Tipo instancia = CrearTipo();
            instancia.Uri = uri;
            return instancia;
        }

        public Tipo CrearTipo(Uri uri, string nombre)
        {
            Tipo instancia = CrearTipo(uri);
            instancia.Nombre = nombre;
            return instancia;
        }

        public Tipo CrearTipo(Uri uri, string nombre, string alias)
        {
            Tipo instancia = CrearTipo(uri, nombre);
            instancia.Alias = alias;
            return instancia;
        }

        public Tipo CrearTipo(Uri uri, string nombre, string alias, bool esTipoDeDato)
        {
            Tipo instancia = CrearTipo(uri, nombre, alias);
            instancia.EsTipoDeDato = esTipoDeDato;
            return instancia;
        }

        public Uri CrearUri()
        {
            return (Uri)Crear(typeof(Uri));
        }

        public Uri CrearUri(Ensamblado ensam)
        {
            Uri instancia = CrearUri();
            instancia.Ensamblado = ensam;
            return instancia;
        }

        public Uri CrearUri(Ensamblado ensam, string nombre)
        {
            Uri instancia = CrearUri(ensam);
            instancia.Nombre = nombre;
            return instancia;
        }

    }
}
