using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Binapsis.Plataforma.Datos.Impl
{
    public class Parametros : IEnumerable<Parametro>
    {
        List<Parametro> _parametros;

        #region Constructores
        public Parametros()
        {         
            _parametros = new List<Parametro>();
        }
        #endregion


        #region Metodos
        public bool Existe(string nombre)
        {
            return _parametros.Exists(item => item.Nombre == nombre);
        }

        public void Remover(Parametro parametro)
        {
            if (parametro == null || _parametros.Contains(parametro)) return;

            int i = _parametros.IndexOf(parametro);
            _parametros.Remove(parametro);
            
            for (int i2 = i; i2 < _parametros.Count; i2++)
                _parametros[i2].Indice = i2;            
        }

        public Parametro Agregar(string nombre)
        {
            return Agregar(nombre, typeof(string));
        }

        public Parametro Agregar(string nombre, Type type)
        {
            return Agregar(nombre, type, null);
        }

        public Parametro Agregar(string nombre, Type type, object valor)
        {
            return Agregar(nombre, type, "IN", valor);
        }

        public Parametro Agregar(string nombre, Type type, string direccion, object valor)
        {
            Parametro parametro = new Parametro();

            parametro.Nombre = nombre;
            parametro.Type = type;
            parametro.Direccion = direccion;
            parametro.Valor = valor;

            Agregar(parametro);

            return parametro;
        }

        public void Agregar(Parametro parametro)
        {
            if (!Existe(parametro.Nombre))
                _parametros.Add(parametro);
            else
                throw new Exception($"El parametro '{parametro.Nombre}' ya ha sido agregado.");

            parametro.Indice = _parametros.IndexOf(parametro);
        }

        public int Contar()
        {
            return _parametros.Count;
        }

        public Parametro Obtener(string nombre)
        {
            return _parametros.FirstOrDefault(item => item.Nombre == nombre);
        }

        public Parametro Obtener(int indice)
        {
            if (indice > 0 && indice < _parametros.Count)
                return _parametros[indice];
            else
                return null;
        }
        #endregion


        #region Indizadores
        public Parametro this[string nombre]
        {
            get => Obtener(nombre);
        }

        public Parametro this[int indice]
        {
            get => Obtener(indice);
        }
        #endregion


        #region IEnumerable
        public IEnumerator<Parametro> GetEnumerator()
        {
            return ((IEnumerable<Parametro>)_parametros).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Parametro>)_parametros).GetEnumerator();
        }
        #endregion
    }
}
