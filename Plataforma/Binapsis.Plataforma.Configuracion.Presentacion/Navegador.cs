using Binapsis.Plataforma.AgenteConfiguracion;
using Binapsis.Plataforma.Configuracion.Presentacion.Navegacion;
using Binapsis.Plataforma.Estructura;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Configuracion.Presentacion
{
    public class Navegador
    {
        public Navegador(Consola consola)
        {
            Consola = consola;
            Grupos = new Grupos();
        }
        
        public Nodo CrearNodo(Grupo grupo)
        {
            Nodo nodo = new Nodo(grupo);

            if (grupo is Categoria categoria)
                nodo.Nombre = categoria.Descripcion;
            else 
                nodo.Nombre = grupo.Nombre;
            
            return nodo;
        }

        public Nodo CrearNodo(Clave clave)
        {
            Nodo nodo = new Nodo(clave);

            if (clave.ObjetoDatos.Tipo.ContienePropiedad("Nombre"))
                nodo.Nombre = clave.ObjetoDatos.ObtenerString("Nombre");
            else
                nodo.Nombre = clave.Valor;

            //nodo.Nombre = clave.Nombre ?? clave.Valor;

            return nodo;
        }

        public void ResolverNodo(Nodo nodo)
        {
            nodo.Nodos.RemoverTodo();

            if (nodo.Elemento is Clave clave)
                ResolverNodoClave(nodo, clave);
            else if (nodo.Elemento is Categoria categoria)
                ResolverNodoCategoria(nodo, categoria);
            else if (nodo.Elemento is Grupo grupo)
                ResolverNodoGrupo(nodo, grupo);

        }

        private void ResolverNodoGrupo(Nodo nodo, Grupo grupo)
        {
            foreach (Grupo subgrupo in grupo.Grupos)
                nodo.Nodos.Agregar(CrearNodo(subgrupo));
        }

        private void ResolverNodoCategoria(Nodo nodo, Categoria categoria)
        {
            Nodo nodoPadre = nodo.Padre as Nodo;
            Clave clave = nodoPadre?.Elemento as Clave;

            string consulta = Consola.Recursos[Consola.RECURSO_CONSULTA][categoria.Nombre] as string;
            IColeccion resultado = EjecutarConsulta(consulta, clave);
            if (resultado == null) return;

            foreach (IObjetoDatos od in resultado)
                ResolverNodoCategoria(nodo, od);

        }

        private void ResolverNodoCategoria(Nodo nodo, IObjetoDatos od)
        {
            Clave clave = new Clave(od);
            Nodo subNodo = CrearNodo(clave);

            // asignar padre categoria a la clave
            clave.Nombre = nodo.Elemento.Nombre;
            clave.Padre = nodo.Elemento;

            //ResolverNodoClave(subNodo, subClave);

            nodo.Nodos.Agregar(subNodo);
        }

        private void ResolverNodoClave(Nodo nodo, Clave clave)
        {
            Nodo nodoPadre = nodo.Padre as Nodo;
            Grupo grupo = nodoPadre?.Elemento as Grupo;

            foreach (Grupo subGrupo in grupo.Grupos)
                nodo.Nodos.Agregar(CrearNodo(subGrupo));
        }

        public IEnumerable<Clave> ObtenerClaves(Nodo nodo)
        {
            if (nodo.Elemento is Categoria categoria)
                return nodo.Nodos.Select(item => item.Elemento).OfType<Clave>();
            else
                return null;
        }
        
        public IColeccion EjecutarConsulta(string consulta, Clave clave)
        {
            ComandoHelper comandoHelper = null;

            if (!string.IsNullOrEmpty(consulta))
                comandoHelper = Consola.Repositorio.CrearComando(consulta);

            if (comandoHelper == null) return null;

            if (clave != null)
                comandoHelper.Establecer(clave.Nombre, clave.Valor);

            return comandoHelper.EjecutarConsulta();
        }
        
        private Consola Consola
        {
            get;
        }

        public Grupos Grupos
        {
            get;
        }
        
    }
}
