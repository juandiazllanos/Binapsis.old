using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using Binapsis.Plataforma.Estructura;
using System;

namespace Binapsis.Plataforma.Configuracion.Presentacion.Actividades
{
    public class Seleccionar : Actividad, IResultado
    {
        public Seleccionar(string vista)
        {
            Vista = vista;
        }

        public override void Iniciar()
        {
            string consulta = Parametros["consulta"] as string;
            Repositorio repositorio = Contexto.Repositorio;

            ComandoHelper comandoHelper = null;
            Claves claves = null;
            IVista vista = null;

            if (consulta != null && repositorio != null)
                comandoHelper = repositorio.CrearComando(consulta);

            if (comandoHelper != null)
                claves = CrearClaves(comandoHelper);

            if (claves != null)
                vista = Contexto.ObtenerFabrica(Vista)?.Crear() as IVista;

            if (vista != null)
            {
                vista.Resultado = this;
                vista.Mostrar(claves);
            }
            else
                Cancelar();
        }

        private Claves CrearClaves(ComandoHelper comandoHelper)
        {
            Claves claves = null;

            foreach (Parametro parametro in comandoHelper.Comando.Parametros)
                comandoHelper.Establecer(parametro.Nombre, Parametros[parametro.Nombre]);

            IColeccion items = comandoHelper.EjecutarConsulta();

            claves = new Claves(items);

            return claves;
        }

        private void Resolver(Clave clave)
        {
            Parametros["clave"] = clave;
            Terminar();            
        }

        public string Vista
        {
            get;
        }


        #region IResultado
        void IResultado.OK()
        {
            Resolver(null);
        }

        void IResultado.OK(object resultado)
        {
            Resolver(resultado as Clave);
        }

        void IResultado.Cancelar()
        {
            Cancelar();
        }
        #endregion

    }
}
