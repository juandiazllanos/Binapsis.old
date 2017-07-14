using Binapsis.Plataforma.Datos.Operacion;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;
using System;
using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Datos.Mapeo;

namespace Binapsis.Plataforma.Datos.Builder
{
    class BuilderCambios 
    {
        public BuilderCambios(Operacion.Cambios cambios)            
        {
            Cambios = cambios;
        }

        #region Metodos
        public void Construir()
        {
            if (ObjetoDatos == null || ResumenCambios == null) return;

            IEnumerable<IObjetoDatos> items = ResumenCambios.ObtenerObjetoDatosCambiados();

            foreach (IObjetoDatos item in items)
                ConstruirOperacion(item);
        }
        
        private void ConstruirOperacion(IObjetoDatos od)
        {
            OperacionBase operacion;
            Func<OperacionBase> fabrica = null;

            if (ResumenCambios.Creado(od))
                fabrica = () => new OperacionCrear();
            else if (ResumenCambios.Eliminado(od))
                fabrica = () => new OperacionEliminar();
            else if (ResumenCambios.Modificado(od))
                fabrica = () => new OperacionEditar();
            else
                return;

            operacion = fabrica.Invoke();

            ConstruirOperacion(od, operacion);
            
            if (operacion is OperacionCrear || operacion is OperacionEliminar)
                ConstruirOperacionRecursiva(od, fabrica);
        }

        private void ConstruirOperacion(IObjetoDatos od, OperacionBase operacion)
        {
            BuilderOperacion builder;

            if (operacion is OperacionCrear crear)
                builder = new BuilderOperacionCrear(crear);
            else if (operacion is OperacionEliminar eliminar)
                builder = new BuilderOperacionEliminar(eliminar);
            else if (operacion is OperacionEditar editar)
                builder = new BuilderOperacionEditar(editar);
            else
                return;
            
            builder.Contexto = Contexto;
            builder.MapeoCatalogo = MapeoCatalogo;
            builder.ObjetoDatos = od;
            builder.ResumenCambios = ResumenCambios;

            builder.Construir();

            // validar que la operacion editar tenga cambios a efectuar
            if (builder is BuilderOperacionEditar builderOperacionEditar &&
                builderOperacionEditar.CantidadCambios == 0)
                return;

            Cambios.Agregar(operacion);
        }
        
        private void ConstruirOperacionRecursiva(IObjetoDatos od, Func<OperacionBase> fabrica)
        {
            var referencias = od.Tipo.Propiedades.Where(item => !item.Tipo.EsTipoDeDato && item.Asociacion == Asociacion.Composicion);
            List<IObjetoDatos> items = new List<IObjetoDatos>();

            foreach (IPropiedad propiedad in referencias)
                if (!propiedad.EsColeccion)
                    items.Add(od.ObtenerObjetoDatos(propiedad));
                else
                    items.AddRange(od.ObtenerColeccion(propiedad));
                        
            foreach(IObjetoDatos item in items)
            {
                ConstruirOperacion(item, fabrica.Invoke());
                ConstruirOperacionRecursiva(item, fabrica);
            }                
        }        
        #endregion


        #region Propiedades        
        public Operacion.Cambios Cambios
        {
            get;
        }

        public IContexto Contexto
        {
            get;
            set;
        }

        public MapeoCatalogo MapeoCatalogo
        {
            get;
            set;
        }

        public IObjetoDatos ObjetoDatos
        {
            get;
            set;
        }

        public IResumenCambios ResumenCambios
        {
            get;
            set;
        }
        #endregion

    }
}
