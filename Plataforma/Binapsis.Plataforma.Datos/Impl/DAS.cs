using Binapsis.Plataforma.Cambios;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Datos.Mapeo;
using Binapsis.Plataforma.Datos.Builder;
using System.Collections;
using System;
using Binapsis.Plataforma.Datos.Heap;
using Binapsis.Plataforma.Configuracion;
using Binapsis.Plataforma.Datos.Helper;
using Binapsis.Plataforma.Estructura.Impl;
using Binapsis.Plataforma.Datos.Operacion;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class DAS : IDAS
    {
        #region Constructores
        public DAS(IConfiguracion configuracion, IContexto contexto)
        {
            Configuracion = configuracion;
            Contexto = contexto;

            MapeoCatalogo = new MapeoCatalogo();
            MapeoCatalogo.Configuracion = configuracion;
        }
        #endregion


        #region Metodos
        public void AplicarCambios(IDiagramaDatos dd)
        {
            try
            {
                // iniciar transaccion
                Contexto.IniciarTransaccion();
                // ejecutar comando
                AplicarCambios(dd.ObjetoDatos, dd.ResumenCambios);
                // confirmar transaccion
                Contexto.TerminarTransaccion();
            }
            catch
            {
                // descartar transaccion
                Contexto.DeshacerTransaccion();
                throw;
            }
        }

        public void AplicarCambios(IList datos)
        {
            try
            {
                // iniciar transaccion
                Contexto.IniciarTransaccion();
                // ejecutar comando
                foreach(IDiagramaDatos dd in datos)
                    AplicarCambios(dd.ObjetoDatos, dd.ResumenCambios);
                // confirmar transaccion
                Contexto.TerminarTransaccion();
            }
            catch
            {
                // descartar transaccion
                Contexto.DeshacerTransaccion();
                throw;
            }
        }

        public void AplicarCambios(IObjetoDatos od)
        {
            
        }
            
        private void AplicarCambios(IObjetoDatos od, IResumenCambios resumen)
        {
            // construir cambios
            Operacion.Cambios cambios = new Operacion.Cambios();
            BuilderCambios builder = new BuilderCambios(cambios);

            builder.Contexto = Contexto;
            builder.MapeoCatalogo = MapeoCatalogo;
            builder.ObjetoDatos = od;
            builder.ResumenCambios = resumen;

            builder.Construir();

            // construir operacion
            AplicarCambios aplicarCambios = new AplicarCambios();

            aplicarCambios.Contexto = Contexto;
            aplicarCambios.Cambios = cambios;
                        
            // ejecutar operacion
            aplicarCambios.Ejecutar();                         
        }
        
        public IComando ObtenerComando(string nombre)
        {
            Comando comando = Configuracion.ObtenerComando(nombre);
            if (comando == null) return null;

            return CrearComando(comando);
        }

        public IComando CrearComando(Comando comando)
        {
            // crear comando consulta
            if (comando.ComandoTipo == ComandoTipo.QUERY)
                return CrearConsulta(comando);
            // crear comando procedimiento
            else if (comando.ComandoTipo == ComandoTipo.PROCEDURE)
                return CrearProcedimiento(comando);
            // null
            else
                return null;            
        }
               

        public IComando CrearComando(ITipo tipo)
        {            
            ConsultaHelper consultaHelper = new ConsultaHelper(MapeoCatalogo);            
            ComandoLectura comando = consultaHelper.CrearConsulta(tipo);

            return CrearComando(comando);
        }

        public IComando CrearComando(ITipo tipo, IPropiedad propiedad)
        {
            ConsultaHelper consultaHelper = new ConsultaHelper(MapeoCatalogo);
            ComandoLectura comando = consultaHelper.CrearConsulta(tipo, propiedad);

            return CrearComando(comando);
        }

        private IComando CrearConsulta(Comando comando)
        {
            if (comando.ComandoTipo != ComandoTipo.QUERY) return null;

            ConsultaHelper consultaHelper = new ConsultaHelper(MapeoCatalogo);
            ComandoLectura comandoLectura = consultaHelper.CrearConsulta(comando);

            return CrearComando(comandoLectura);
        }

        private IComando CrearProcedimiento(Comando comando)
        {
            if (comando.ComandoTipo != ComandoTipo.PROCEDURE) return null;

            ComandoBase comandoBase = new ComandoBase(comando);
            EjecutarComando ejecutar = new EjecutarComando(comandoBase);

            ejecutar.Contexto = Contexto;

            return ejecutar;
        }

        private IComando CrearComando(ComandoLectura comando)
        {
            RecuperarHelper recuperarHelper = new RecuperarHelper(MapeoCatalogo);
            HeapObjetoDatos heapObjetoDatos = new HeapObjetoDatos();
            IFabrica fabrica = FabricaDatos.Instancia;

            recuperarHelper.Contexto = Contexto;
            recuperarHelper.Fabrica = fabrica;
            recuperarHelper.Heap = heapObjetoDatos;

            EjecutarComando ejecutar = new EjecutarComando(comando);

            ejecutar.Contexto = Contexto;
            ejecutar.Helper = recuperarHelper;
            ejecutar.MapeoCatalogo = MapeoCatalogo;

            return ejecutar;
        }
                
        #endregion



        #region Propiedades
        public IConfiguracion Configuracion
        {
            get;
        }

        public IContexto Contexto
        {
            get;
        }

        private MapeoCatalogo MapeoCatalogo
        {
            get;
        }
        #endregion

    }
}
