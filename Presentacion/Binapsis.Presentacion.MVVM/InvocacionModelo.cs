using Binapsis.Plataforma.Estructura;
using Binapsis.Presentacion.MVVM.Builder;
using Binapsis.Presentacion.MVVM.Controlador;
using System.Collections.Generic;

namespace Binapsis.Presentacion.MVVM
{
    class InvocacionModelo
    {
        Dictionary<string, IComando> _comandos;
        ControladorInvocacionModelo _controlador;
        
        public InvocacionModelo(Invocacion invocacion)
        {
            _comandos = new Dictionary<string, IComando>();
            _controlador = new ControladorInvocacionModelo();
            
            Invocacion = invocacion;

            BuilderInvocacionModelo builderInvocacion = new BuilderInvocacionModelo(this);
            builderInvocacion.Construir(Invocacion.InvocacionTipo);
        }

        public void Establecer(IObjetoDatos modelo)
        {        
            Modelo = modelo;
            _controlador.Establecer(this);
        }

        public void Agregar(string nombre, IComando comando)
        {
            if (!_comandos.ContainsKey(nombre))
                _comandos.Add(nombre, comando);
        }

        public void Remover(string comando)
        {
            if (_comandos.ContainsKey(comando))
                _comandos.Remove(comando);
        }

        public void RemoverTodo()
        {
            _comandos.Clear();
        }

        public void Ejecutar(string nombre)
        {
            if (_comandos.ContainsKey(nombre))
                Ejecutar(_comandos[nombre]);
        }

        private void Ejecutar(IComando comando)
        {
            if (Modelo != null)
                comando.Ejecutar(Modelo);
        }

        public Invocacion Invocacion
        {
            get;
        }

        private IObjetoDatos Modelo
        {
            get;
            set;
        }
                
    }
}
