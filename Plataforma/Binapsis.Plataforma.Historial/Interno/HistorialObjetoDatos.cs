using System;
using System.Collections.Generic;
using Binapsis.Plataforma.Estructura;
using Binapsis.Plataforma.Historial.Interno.Comandos;

namespace Binapsis.Plataforma.Historial.Interno
{
	internal class HistorialObjetoDatos
    {
		private Stack<HistorialComando> _comandos; // LIFO
        //private Queue<HistorialComando> _rehacer; // FIFO
		
		public HistorialObjetoDatos()
        {
            _comandos = new Stack<HistorialComando>();
            //_rehacer = new Queue<HistorialComando>();
		}

        internal Instantanea CrearInstantanea()
        {
            return new Instantanea(this, _comandos.Count);
        }

        internal void Recuperar(Instantanea instantanea)
        {
            instantanea?.Recuperar(this);
        }

        public void Deshacer()
        {
            Deshacer(0);
        }

        internal void Deshacer(int id)
        {
            HistorialComando comando;
            
            while (_comandos.Count > id)
            {
                // obtener comando en la pila
                comando = _comandos.Peek();
                // deshacer comando
                comando.Deshacer();

                // quitar comando de la pila
                _comandos.Pop();
                // agregar comando a la cola
                //_rehacer.Enqueue(comando);
            }
        }

        //public void Rehacer()
        //{
        //    HistorialComando comando;

        //    while (_rehacer.Count != 0)
        //    {
        //        // obtener comando en la cola
        //        comando = _rehacer.Peek();
        //        // rehacer comando
        //        comando.Rehacer();

        //        // quitar comando de la cola
        //        _rehacer.Dequeue();
        //        // agregar comando a la cola
        //        _comandos.Push(comando);
        //    }
        //}

        private void RegistrarEstablecer(HistorialEstado estado)
        {
            _comandos.Push(new ComandoEstablecer(estado));
        }

        private void RegistrarAgregar(HistorialEstado estado)
        {
            _comandos.Push(new ComandoAgregar(estado));
        }

        private void RegistrarRemover(HistorialEstado estado)
        {
            _comandos.Push(new ComandoRemover(estado));
        }

        public void CrearObjetoDatos(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, int indice)
        {
            //if (propiedad.Cardinalidad >= Cardinalidad.Muchos)
            //    RegistrarAgregar(FabricaEstado.Crear(impl, propiedad, valor, indice));
            //else 
            //    RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valor));
        }

        public void Establecer(IImplementacion impl, IPropiedad propiedad, object valor, object valorInicial)
        {
            if ((valorInicial != null && !valorInicial.Equals(valor)) || (valorInicial == null && valor != null))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerBoolean(IImplementacion impl, IPropiedad propiedad, bool valor, bool valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerByte(IImplementacion impl, IPropiedad propiedad, byte valor, byte valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerChar(IImplementacion impl, IPropiedad propiedad, char valor, char valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerDateTime(IImplementacion impl, IPropiedad propiedad, DateTime valor, DateTime valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerDecimal(IImplementacion impl, IPropiedad propiedad, decimal valor, decimal valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerDouble(IImplementacion impl, IPropiedad propiedad, double valor, double valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerFloat(IImplementacion impl, IPropiedad propiedad, float valor, float valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerInteger(IImplementacion impl, IPropiedad propiedad, int valor, int valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerLong(IImplementacion impl, IPropiedad propiedad, long valor, long valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerObject(IImplementacion impl, IPropiedad propiedad, object valor, object valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerObjetoDatos(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, IObjetoDatos valorInicial)
        {
            if (!(valorInicial?.Equals(valor) ?? valor == null)) // si valor inicial es nulo, sera igual al nuevo valor si nuevo valor no es nulo
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerSByte(IImplementacion impl, IPropiedad propiedad, sbyte valor, sbyte valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerShort(IImplementacion impl, IPropiedad propiedad, short valor, short valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerString(IImplementacion impl, IPropiedad propiedad, string valor, string valorInicial)
        {
            if (!(valorInicial?.Equals(valor) ?? valor == null)) // si valor inicial es nulo, sera igual al nuevo valor si nuevo valor no es nulo
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerULong(IImplementacion impl, IPropiedad propiedad, ulong valor, ulong valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerUInteger(IImplementacion impl, IPropiedad propiedad, uint valor, uint valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void EstablecerUShort(IImplementacion impl, IPropiedad propiedad, ushort valor, ushort valorInicial)
        {
            if (!valorInicial.Equals(valor))
                RegistrarEstablecer(FabricaEstado.Crear(impl, propiedad, valorInicial));
        }

        public void AgregarObjetoDatos(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, int indice)
        {
            RegistrarAgregar(FabricaEstado.Crear(impl, propiedad, valor, indice));
        }

        public void RemoverObjetoDatos(IImplementacion impl, IPropiedad propiedad, IObjetoDatos valor, int indice)
        {
            RegistrarRemover(FabricaEstado.Crear(impl, propiedad, valor, indice));
        }

    }

}