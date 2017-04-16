using System;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;
using Binapsis.Plataforma.Estructura.Impl;

namespace Binapsis.Plataforma.Serializacion.Lectura
{
	internal class ModeloLectura : IMetodoLectura, IModeloLectura
    {
		ILector _lector;
		Identidad _stack;
		IObjetoDatos _od;
        Dictionary<string, ITipo> _tipos;
        List<IMetodoAsociacion> _asociaciones;

        internal ModeloLectura(ILector lector, IObjetoDatos od)
        {
            _lector = lector;
            _od = od;
            _stack = new Identidad();
            _asociaciones = new List<IMetodoAsociacion>();

            ConstruirTipos();
		}

        #region IModelo        
        IMetodoLectura IModeloLectura.Crear(Metodo metodo)
        {
            return Crear(metodo);
		}
        
        IObjetoDatos IModeloLectura.Instanciar(int refid, string uri, string tipo)
        {
            return Instanciar(refid, uri, tipo);
        }

        void IModeloLectura.Agregar(IMetodoAsociacion asociacion)
        {
            Agregar(asociacion);
        }

        void IModeloLectura.Resolver(int refid, int propietario, int propiedad)
        {
            Resolver(refid, propietario, propiedad);
        }

        IMetodoLectura IModeloLectura.Crear(int refid, int longitud)
        {
            return Crear(refid, longitud);
        }

        IMetodoLectura IModeloLectura.Crear(int refid, int longitud, IObjetoDatos od)
        {
            return Crear(refid, longitud, od);
		}
        
		IMetodoLectura IModeloLectura.Crear(int refid, int longitud, int propietario, int propiedad)
        {
            return Crear(refid, longitud, propietario, propiedad);
		}
        #endregion

        #region IMetodo        
        void IMetodoLectura.Leer()
        {
            Leer();
		}
        #endregion

        private void ConstruirTipos()
        {
            _tipos = new Dictionary<string, ITipo>();
            AgregarTipo(_od.Tipo);
            ConstruirTipos(_od.Tipo);
        }

        private void ConstruirTipos(ITipo contexto)
        {
            var propiedades = from propiedad in contexto.Propiedades
                              where !propiedad.Tipo.EsTipoDeDato && propiedad.Asociacion == Estructura.Asociacion.Agregacion
                              select propiedad;

            foreach(IPropiedad propiedad in propiedades)
            {
                ConstruirTipos(propiedad);
            }
        }

        private void ConstruirTipos(IPropiedad propiedad)
        {
            if (propiedad.Asociacion != Estructura.Asociacion.Agregacion) return;
            AgregarTipo(propiedad.Tipo);
            ConstruirTipos(propiedad.Tipo);
        }

        private void AgregarTipo(ITipo tipo)
        {
            string clave = $"{tipo.Uri}.{tipo.Nombre}";
            if (!_tipos.ContainsKey(clave))
                _tipos.Add(clave, tipo);
        }

        private IObjetoDatos Instanciar(int refid, string uri, string nombre)
        {
            // obtener el tipo
            ITipo tipo = _tipos[$"{uri}.{nombre}"];
            IObjetoDatos od;

            // instanciar el od
            if  (refid == 0)//(tipo == _od.Tipo)
                od = _od;
            else
                od = Fabrica.Instancia.Crear(tipo);

            // agregar el od
            _stack.Agregar(od, refid);

            return od;
        }

        private void Agregar(IMetodoAsociacion asociacion)
        {
            _asociaciones.Add(asociacion);
        }

        private void Resolver(int refid, int propietario, int propiedad)
        {
            IObjetoDatos od = _stack.Obtener(propietario);
            IObjetoDatos valor = _stack.Obtener(refid);

            od.EstablecerObjetoDatos(propiedad, valor);
        }

        private IMetodoLectura Crear(Metodo metodo)
        {
            IMetodoLectura instancia = null;

            switch(metodo)
            {
                case Metodo.Tipo:
                    instancia = new MetodoLecturaTipo(this, _lector);
                    break;

                case Metodo.ObjetoDatos:
                    instancia = new MetodoLecturaObjetoDatos(this, _lector);
                    break;

                case Metodo.Referencia:
                    instancia = new MetodoLecturaReferencia(this, _lector);
                    break;

                case Metodo.Asociacion:
                    instancia = new MetodoLecturaAsociacion(this, _lector);
                    break;
            }

            return instancia;    
        }
        
        private IMetodoLectura Crear(int refid, int longitud)
        {
            IObjetoDatos od = _stack[refid];
            return Crear(refid, longitud, od);
        }

        private IMetodoLectura Crear(int refid, int longitud, IObjetoDatos od)
        {            
            return new LectorObjetoDatos(_lector, od, longitud);
        }

        private IMetodoLectura Crear(int refid, int longitud, int propietario, int propiedad)
        {
            IObjetoDatos od;
            // obtener propietario y crear referencia
            od = _stack.Obtener(propietario).CrearObjetoDatos(propiedad);
            // agregar identidad de referencia 
            _stack.Agregar(od, refid);
            // crear metodo
            return Crear(refid, longitud, od);
        }

        private void Leer()
        {
            byte metodo = 0;

            do
            {
                metodo = _lector.LeerMetodo();

                if (metodo != 0)
                    Crear((Metodo)metodo).Leer();
            }
            while (metodo != 0);
            
            // resolver asociaciones
            foreach(IMetodoAsociacion asociacion in _asociaciones)
            {
                asociacion.Resolver();
            }
        }
        
    }

}